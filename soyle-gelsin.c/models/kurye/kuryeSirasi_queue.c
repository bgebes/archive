#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct kuryeSirasi_queue
{
  char *kuryeEmail;
  struct kuryeSirasi_queue *next;
};
typedef struct kuryeSirasi_queue kuryeSirasi;

kuryeSirasi *front_kur, *rear_kur;
#define getFront_kur() (front_kur->kuryeEmail)
#define getRear_kur() (rear_kur->kuryeEmail)

void joinQueue_kur(char *), leaveQueue_kur();

void joinQueue_kur(char *kuryeEmail)
{
  if (rear_kur == NULL)
  {
    kuryeSirasi *temp = (kuryeSirasi *)malloc(sizeof(kuryeSirasi));
    temp->kuryeEmail = kuryeEmail;
    rear_kur = temp;
    front_kur = rear_kur;
  }
  else
  {
    // Düğüm oluşturma ve tanımlama
    kuryeSirasi *temp = (kuryeSirasi *)malloc(sizeof(kuryeSirasi));
    temp->kuryeEmail = kuryeEmail;
    temp->next = NULL;

    // Kuyruk hizalanması.
    rear_kur->next = temp;
    rear_kur = temp;
  }
}

void leaveQueue_kur()
{
  if (front_kur == NULL) // Kuyruk boş
  {
    printf("Kuyruk bos!\n");
  }
  else
  {
    if (front_kur->next == NULL) // Kuyruk tek elemanlı
    {
      free(front_kur);
      free(rear_kur);
    }
    else // Kuyruk birden fazla elemanlı
    {
      kuryeSirasi *newFront_kur = front_kur->next;
      free(front_kur);
      front_kur = newFront_kur;
    }
  }
}
