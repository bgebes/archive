#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>

typedef struct ProgramData
{
    int sizeM_matrixA;
    int sizeN_matrixA;

    int sizeM_matrixB;
    int sizeN_matrixB;
} ProgramData;

typedef struct Matrix
{
    int m;
    int n;
    char symbol;
    void *elements;
} Matrix;

// Thread Argument
typedef struct MultiplicationArgsObject
{
    int rowCount;
    Matrix *A;
    Matrix *B;
    Matrix *C;
} MultiplicationArgsObject;

ProgramData *validateArgs(int, char *[]);
void throwError(int, char *);
Matrix *createMatrix(char, int, int, char);
void *fillMatrixDefaultly(int, int);
void *fillMatrixRandomly(int, int);
void *fillMatrixFromFile(int, int, char *, char);
Matrix *matrixMultiplication(Matrix *, Matrix *);
void *multiplication(void *);
void *printMatrix(Matrix *);

// The Maximum Random Number The Matrix Element Can Take
#define MAX_RANDOM 10

int main(int argc, char *argv[])
{
    ProgramData *pd = validateArgs(argc, argv);

    Matrix *matrixA = createMatrix('A', pd->sizeM_matrixA, pd->sizeN_matrixA, 1);
    Matrix *matrixB = createMatrix('B', pd->sizeM_matrixB, pd->sizeN_matrixB, 1);
    Matrix *matrixC = matrixMultiplication(matrixA, matrixB);

    printMatrix(matrixA);
    printMatrix(matrixB);
    printMatrix(matrixC);

    return 0;
}

void throwError(int exitCode, char *exitMessage)
{
    printf("%s\n", exitMessage);
    exit(exitCode);
}

// Checking and Saving User Arguments
ProgramData *validateArgs(int argc, char *argv[])
{
    char *errorMessage1 = "Unexcepted arg count!\nCorrect Format: ./main {sizeM_matrixA} {sizeN_matrixA} {sizeM_matrixB} {sizeN_matrixB}";

    if (argc - 1 != 4)
        throwError(-1, errorMessage1);

    ProgramData *pd = (ProgramData *)malloc(sizeof(ProgramData));
    pd->sizeM_matrixA = atoi(argv[1]);
    pd->sizeN_matrixA = atoi(argv[2]);
    pd->sizeM_matrixB = atoi(argv[3]);
    pd->sizeN_matrixB = atoi(argv[4]);

    char *errorMessage2 = "N of A and M of B must be same!";
    if (pd->sizeN_matrixA != pd->sizeM_matrixB)
        throwError(-1, errorMessage2);

    return pd;
}

// Creating Matrix
Matrix *createMatrix(char symbol, int size_M, int size_N, char creatingChannel)
{
    Matrix *m = (Matrix *)malloc(sizeof(Matrix));
    m->m = size_M;
    m->n = size_N;
    m->symbol = symbol;
    m->elements = NULL;

    switch (creatingChannel)
    {
    case 0:
        m->elements = fillMatrixDefaultly(size_M, size_N);
        break;
    case 1:
        m->elements = fillMatrixRandomly(size_M, size_N);
        break;
    }

    return m;
}

// Initializing Matrix Elements as 0
void *fillMatrixDefaultly(int size_M, int size_N)
{
    int(*elements)[size_M][size_N] = (int(*)[size_M][size_N])malloc((size_M * size_N) * sizeof(int));

    for (int i = 0; i < size_M; i++)
    {
        for (int j = 0; j < size_N; j++)
        {
            (*elements)[i][j] = 0;
        }
    }

    return elements;
}

// Filling Matrix Elements with Random Numbers
void *fillMatrixRandomly(int size_M, int size_N)
{
    int(*elements)[size_M][size_N] = (int(*)[size_M][size_N])malloc((size_M * size_N) * sizeof(int));

    for (int i = 0; i < size_M; i++)
    {
        for (int j = 0; j < size_N; j++)
        {
            (*elements)[i][j] = rand() % (MAX_RANDOM + 1);
        }
    }

    return elements;
}

Matrix *matrixMultiplication(Matrix *A, Matrix *B)
{
    int THREAD_SIZE = A->m;
    pthread_t threads[THREAD_SIZE];

    Matrix *C = createMatrix('C', A->m, B->n, 0);

    for (int i = 0; i < THREAD_SIZE; i++)
    {
        MultiplicationArgsObject *mao = (MultiplicationArgsObject *)malloc(sizeof(MultiplicationArgsObject));
        mao->rowCount = i;
        mao->A = A;
        mao->B = B;
        mao->C = C;

        if (pthread_create(&threads[i], NULL, multiplication, mao) == -1)
        {
            exit(-1);
        }
    }

    for (int i = 0; i < THREAD_SIZE; i++)
    {
        pthread_join(threads[i], NULL);
    }

    return C;
}

// Thread Function
void *multiplication(void *args)
{
    MultiplicationArgsObject *mao = (MultiplicationArgsObject *)args;

    Matrix *matrixA = mao->A;
    int(*A)[matrixA->m][matrixA->n] = (int(*)[matrixA->m][matrixA->n])matrixA->elements;
    Matrix *matrixB = mao->B;
    int(*B)[matrixB->m][matrixB->n] = (int(*)[matrixB->m][matrixB->n])matrixB->elements;
    Matrix *matrixC = mao->C;
    int(*C)[matrixC->m][matrixC->n] = (int(*)[matrixC->m][matrixC->n])matrixC->elements;

    int rowCount = mao->rowCount;

    for (int i = 0; i < matrixC->n; i++)
    {
        for (int j = 0; j < matrixA->n && j < matrixB->m; j++)
        {
            (*C)[rowCount][i] += (*A)[rowCount][j] * (*B)[j][i];
        }
    }

    pthread_exit(0);
}

// Printing the Matrix in Custom Format to the User's View
void *printMatrix(Matrix *matrix)
{
    int(*elements)[matrix->m][matrix->n] = (int(*)[matrix->m][matrix->n])matrix->elements;

    printf("-------Matrix %c-------------------------------------------\n", matrix->symbol);
    for (int i = 0; i < matrix->m; i++)
    {
        for (int j = 0; j < matrix->n; j++)
        {
            printf("%d\t", (*elements)[i][j]);
        }
        printf("\n");
    }

    printf("----------------------------------------------------------\n");
}