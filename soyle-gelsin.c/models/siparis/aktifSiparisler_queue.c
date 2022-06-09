#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "sip_linkedList.c"

struct aktifSiparisler_queue
{
  sip_node *siparis;
  struct aktifSiparisler_queue *next;
};
typedef struct aktifSiparisler_queue aktifSiparisler;

aktifSiparisler *front_AktSip, *rear_AktSip;
#define getFront_AktSip() (front_AktSip->siparis)
#define getRear_AktSip() (rear_AktSip->siparis)

void fillQueue_AktSip(sip_node *), joinQueue_AktSip(sip_node *), leaveQueue_AktSip(), printQueue_AktSip();

void fillQueue_AktSip(sip_node *siparisler)
{
  sip_node *temp = siparisler;
  while (temp != NULL)
  {
    if(temp -> siparisDurumu == 0) // 0: Aktif, 1: Başarılı, 2: Başarısız
      joinQueue_AktSip(temp);
    temp = temp->next;
  }
}

void joinQueue_AktSip(sip_node *siparis)
{
  if(siparis -> siparisDurumu != 0)
    return;

  if (rear_AktSip == NULL)
  {
    aktifSiparisler *temp = (aktifSiparisler *)malloc(sizeof(aktifSiparisler));
    temp->siparis = siparis;
    rear_AktSip = temp;
    front_AktSip = rear_AktSip;
  }
  else
  {
    // Düğüm oluşturma ve tanımlama
    aktifSiparisler *temp = (aktifSiparisler *)malloc(sizeof(aktifSiparisler));
    temp->siparis = siparis;
    temp->next = NULL;

    // Kuyruk hizalanması.
    rear_AktSip->next = temp;
    rear_AktSip = temp;
  }
}

void leaveQueue_AktSip()
{
  if (front_AktSip == NULL) // Kuyruk boş
  {
    printf("Kuyruk bos!\n");
  }
  else
  {
    if (front_AktSip->next == NULL) // Kuyruk tek elemanlı
    {
      free(front_AktSip);
      free(rear_AktSip);
    }
    else // Kuyruk birden fazla elemanlı
    {
      aktifSiparisler *newFront_AktSip = front_AktSip->next;
      free(front_AktSip);
      front_AktSip = newFront_AktSip;
    }
  }
}

void printQueue_AktSip()
{
  aktifSiparisler *temp_Queue = front_AktSip;
  printf("----------------Aktif Siparisler----------------\n");
  printf("Sira\tID\tSepetteki U.S.\tSepet T.F.\tSiparis Durumu\n");
  printf("------------------------------------------------\n");

  int i = 1;
  while (temp_Queue != NULL)
  {
    sip_node *temp = temp_Queue->siparis;
    printf("%d\t%d\t%d\t\t%d TL\t\t%d\n", i, temp->ID, temp->sepettekiUrunSayisi, temp->sepetToplamFiyat, temp->siparisDurumu);
    temp_Queue = temp_Queue->next;
    i++;
  }
}