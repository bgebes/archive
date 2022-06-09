#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../urun/urun_linkedList.c"

struct mag_linkedList
{
  int ID;
  char isim[64];
  int yildizPuani;

  urun_node *urunler;
  int toplamUrunSayisi;
  int toplamGelir, toplamCalisanSayisi, calisanMaasi;

  int toplamSatisSayisi;
  int basarisizSatisSayisi, basariliSatisSayisi, aktifSatisSayisi;

  struct mag_linkedList *prev, *next;
};
typedef struct mag_linkedList mag_node;

mag_node *findNode_mag(mag_node *, char *), *findLastNode_mag(mag_node *);
mag_node *addStore(mag_node *, char *);
void updatingProperty(mag_node *, char *, int, char *);
void updateStore(mag_node *, char *isim, char, char *, char *);
mag_node *deleteStore(mag_node *, char *), *deleteFromStart_mag(mag_node *);
void deleteFromBetween_mag(mag_node *), deleteFromEnd_mag(mag_node *);
void addProductToStore(mag_node *, char *, urun_node *, char *);
void listProductsInStore(mag_node *, char *);
void listStores(mag_node *);

mag_node *findNode_mag(mag_node *root, char *isim)
{
  mag_node *temp = root;
  while (temp != NULL)
  {
    if (!strcmp(temp->isim, isim))
      return temp;
    temp = temp->next;
  }
  return NULL;
}

mag_node *findLastNode_mag(mag_node *root)
{
  mag_node *temp = root;

  while (temp != NULL)
  {
    if (temp->next == NULL)
      return temp;
    temp = temp->next;
  }

  return temp;
}

mag_node *addStore(mag_node *root, char *isim)
{
  mag_node *new = (mag_node *)malloc(sizeof(mag_node)), *lastNode = findLastNode_mag(root);
  int lastID = (lastNode == NULL) ? -1 : lastNode->ID;

  new->ID = lastID + 1;
  strncpy(new->isim, isim, 64);

  new->yildizPuani = 1;

  new->urunler = (urun_node *)malloc(sizeof(urun_node));
  new->toplamUrunSayisi = 0;
  new->toplamGelir = 0, new->toplamCalisanSayisi = 0, new->calisanMaasi = 0;

  new->toplamSatisSayisi = 0;
  new->basarisizSatisSayisi = 0, new->basariliSatisSayisi = 0, new->aktifSatisSayisi = 0;

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

void updatingProperty(mag_node *new, char *ozellikIsmi, int integer, char *string)
{
  if (!strcmp(ozellikIsmi, "isim"))
    strcpy(new->isim, string);
  else if (!strcmp(ozellikIsmi, "yildizPuani"))
    new->yildizPuani = integer;
  else if (!strcmp(ozellikIsmi, "toplamUrunSayisi"))
    new->toplamUrunSayisi = integer;
  else if (!strcmp(ozellikIsmi, "toplamGelir"))
    new->toplamGelir = integer;
  else if (!strcmp(ozellikIsmi, "toplamCalisanSayisi"))
    new->toplamCalisanSayisi = integer;
  else if (!strcmp(ozellikIsmi, "calisanMaasi"))
    new->calisanMaasi = integer;
  else if (!strcmp(ozellikIsmi, "toplamSatisSayisi"))
    new->toplamSatisSayisi = integer;
  else if (!strcmp(ozellikIsmi, "basarisizSatisSayisi"))
    new->basarisizSatisSayisi = integer;
  else if (!strcmp(ozellikIsmi, "basariliSatisSayisi"))
    new->basariliSatisSayisi = integer;
  else if (!strcmp(ozellikIsmi, "aktifSatisSayisi"))
    new->aktifSatisSayisi = integer;
}

void updateStore(mag_node *root, char *isim, char veriTuru, char *ozellikIsmi, char *veri)
{
  mag_node *node = findNode_mag(root, isim);

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

  updatingProperty(node, ozellikIsmi, integer, string);
}

mag_node *deleteStore(mag_node *root, char *isim)
{
  mag_node *silinecek = findNode_mag(root, isim);
  if (silinecek == NULL)
  {
    printf("Hata: Silinecek eleman bulunamadi.\n");
    return NULL;
  }

  if (silinecek->ID == 0)
  {
    return deleteFromStart_mag(silinecek);
  }
  else if (silinecek->next != NULL)
  {
    deleteFromBetween_mag(silinecek);
  }
  else
  {
    deleteFromEnd_mag(silinecek);
  }
}

mag_node *deleteFromStart_mag(mag_node *root)
{
  mag_node *sonraki = root->next;
  if (sonraki != NULL)
  {
    sonraki->prev = NULL;
    return sonraki;
  }

  free(root);
}

void deleteFromBetween_mag(mag_node *silinecek)
{
  mag_node *onceki = silinecek->prev, *sonraki = silinecek->next;
  onceki->next = sonraki, sonraki->prev = onceki;
  free(silinecek);
}

void deleteFromEnd_mag(mag_node *silinecek)
{
  mag_node *onceki = silinecek->prev;
  onceki->next = NULL;
  free(silinecek);
}

void addProductToStore(mag_node *magazalar, char *mag_isim, urun_node *urunler, char *urun_isim)
{
  mag_node *magaza = findNode_mag(magazalar, mag_isim);
  urun_node *urun = findNode_urun(urunler, urun_isim);

  addProduct(magaza->urunler, urun->isim, urun->kategori, urun->fiyat, urun->stoktakiAdeti);
  magaza->toplamUrunSayisi += 1;
}

void listProductsInStore(mag_node *magazalar, char *isim)
{
  mag_node *seciliMagaza = findNode_mag(magazalar, isim);
  printf("--------------- %s Magazasinin Urunleri---------------------------------------\n", seciliMagaza->isim);
  listProducts(seciliMagaza->urunler);
}

void listStores(mag_node *root)
{
  mag_node *temp = root;
  printf("ID\tIsim\tYildiz Puani\tSatis Sayisi\tUrun Sayisi\tCalisan Sayisi\tCalisan Maasi\n");
  printf("----------------------------------------------------------------------------------------------------\n");
  while (temp != NULL)
  {
    int isimUzunlugu = strlen(temp->isim);
    if (isimUzunlugu > 10)
      printf("%d\t%s\t%d\t\t%d\t\t%d\t\t%d\t\t%d\n", temp->ID, temp->isim, temp->yildizPuani, temp->toplamSatisSayisi, temp->toplamUrunSayisi, temp->toplamCalisanSayisi, temp->calisanMaasi);
    else if (isimUzunlugu > 0)
      printf("%d\t%s\t\t%d\t\t%d\t\t%d\t\t%d\t\t%d\n", temp->ID, temp->isim, temp->yildizPuani, temp->toplamSatisSayisi, temp->toplamUrunSayisi, temp->toplamCalisanSayisi, temp->calisanMaasi);
    temp = temp->next;
  }
  printf("\n");
}