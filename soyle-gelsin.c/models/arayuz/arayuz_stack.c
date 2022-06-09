#include "../kullanici/kul_linkedList.c"

struct arayuz_stack
{
  char sonuc;
  int bolumID;

  kul_node *aktifKullanici;
  struct arayuz_stack *next;
};

typedef struct arayuz_stack arayuz;

arayuz *top = NULL;
#define getTopfromStack() (top)

void addStack(arayuz *), leaveStack();
char isEmpty(arayuz *);

void addStack(arayuz *bolum){
  if(isEmpty(top)){
    bolum -> next = NULL;
    top = bolum;
  } else {
    bolum -> next = top;
    top = bolum;
  }
}

void leaveStack(){
  if(isEmpty(top)){
    printf("Arayuz yigini zaten bos!\n");
  } else{
    arayuz *temp = top;
    top = temp -> next;
    free(temp);
  }
}

char isEmpty(arayuz *top){
  return top == NULL;
}