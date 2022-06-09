#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../kurye/kur_linkedList.c"
#include "../magaza/mag_linkedList.c"

struct sip_linkedList
{
  int ID;
  int siparisDurumu, sepettekiUrunSayisi, sepetToplamFiyat;
  urun_node *siparisSepeti;
  kur_node *kurye;
  struct sip_linkedList *prev, *next;
};
typedef struct sip_linkedList sip_node;

sip_node *findNode_sip(sip_node *, int), *findLastNode_sip(sip_node *);
sip_node *addOrder(sip_node *, kur_node *, char *);
void updatingProperty_sip(sip_node *, char *, int, char *);
void updateOrder(sip_node *, int, char, char *, char *);
sip_node *deleteOrder(sip_node *, int), *deleteFromStart_sip(sip_node *);
void deleteFromBetween_sip(sip_node *), deleteFromEnd_sip(sip_node *);
void addProductToOrder(sip_node *, int, urun_node *, char *);
void listOrders(sip_node *);

sip_node *findNode_sip(sip_node *root, int id)
{
  sip_node *temp = root;
  while (temp != NULL)
  {
    if (temp->ID == id)
      return temp;
    temp = temp->next;
  }
  return NULL;
}

sip_node *findLastNode_sip(sip_node *root)
{
  sip_node *temp = root;

  while (temp != NULL)
  {
    if (temp->next == NULL)
      return temp;
    temp = temp->next;
  }

  return temp;
}

sip_node *addOrder(sip_node *root, kur_node *kuryeler, char *kurye_email)
{
  sip_node *new = (sip_node *)malloc(sizeof(sip_node)), *lastNode = findLastNode_sip(root);
  int lastID = (lastNode == NULL) ? -1 : lastNode->ID;

  new->ID = lastID + 1;

  kur_node *kurye = findNode_kur(kuryeler, kurye_email);
  new->kurye = kurye;
  new->siparisSepeti = (urun_node *)malloc(sizeof(urun_node));
  new->siparisDurumu = 0;
  kurye->aktifTeslimatSayisi += 1;

  new->next = NULL;

  if (lastID != -1)
  {
    new->prev = lastNode;
    lastNode->next = new;
  }
  else
    new->prev = NULL;
    
  return new;
}

void updatingProperty_sip(sip_node *new, char *ozellikIsmi, int integer, char *string)
{
  if (!strcmp(ozellikIsmi, "sepettekiUrunSayisi"))
    new->sepettekiUrunSayisi = integer;
  else if (!strcmp(ozellikIsmi, "sepetToplamFiyat"))
    new->sepetToplamFiyat = integer;
  else if (!strcmp(ozellikIsmi, "siparisDurumu"))
    new->siparisDurumu = integer;
}

void updateOrder(sip_node *root, int id, char veriTuru, char *ozellikIsmi, char *veri)
{
  sip_node *node = findNode_sip(root, id);

  int integer;
  char string[23];
  switch (veriTuru)
  {
  case 'I':
    integer = atoi(veri);
    break;
  case 'S':
    strcpy(string, veri);
    break;
  }

  updatingProperty_sip(node, ozellikIsmi, integer, string);
}

sip_node *deleteOrder(sip_node *root, int id)
{
  sip_node *silinecek = findNode_sip(root, id);
  if (silinecek == NULL)
  {
    printf("Hata: Silinecek eleman bulunamadi.\n");
    return NULL;
  }

  if (id == 0)
  {
    return deleteFromStart_sip(silinecek);
  }
  else if (silinecek->next != NULL)
  {
    deleteFromBetween_sip(silinecek);
  }
  else
  {
    deleteFromEnd_sip(silinecek);
  }
}

sip_node *deleteFromStart_sip(sip_node *root)
{
  sip_node *sonraki = root->next;
  if (sonraki != NULL)
  {
    sonraki->prev = NULL;
    return sonraki;
  }

  free(root);
}

void deleteFromBetween_sip(sip_node *silinecek)
{
  sip_node *onceki = silinecek->prev, *sonraki = silinecek->next;
  onceki->next = sonraki, sonraki->prev = onceki;
  free(silinecek);
}

void deleteFromEnd_sip(sip_node *silinecek)
{
  sip_node *onceki = silinecek->prev;
  onceki->next = NULL;
  free(silinecek);
}

void addProductToOrder(sip_node *siparisler, int sip_id, urun_node *urunler, char *urun_isim)
{
  sip_node *siparis = findNode_sip(siparisler, sip_id);
  urun_node *urun = findNode_urun(urunler, urun_isim);

  addProduct(siparis->siparisSepeti, urun->isim, urun->kategori, urun->fiyat, urun->stoktakiAdeti);
  siparis->sepetToplamFiyat += urun->fiyat;
  siparis->sepettekiUrunSayisi += 1;
}

void listOrders(sip_node *root)
{
  sip_node *temp = root;
  printf("ID\tSepetteki U.S.\tSepet T.F.\tSiparis Durumu\n");
  printf("--------------------------------------------------------------\n");
  while (temp != NULL)
  {
    if(temp -> siparisSepeti != NULL)
      printf("%d\t%d\t\t%d TL\t\t%d\n", temp->ID, temp->sepettekiUrunSayisi, temp->sepetToplamFiyat, temp->siparisDurumu);
    temp = temp->next;
  }
  printf("\n");
}