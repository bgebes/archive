#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../../scripts/sifrelemeAlgoritmasi.c"

struct kur_linkedList
{
  int ID;
  char isim[20], soyisim[20], email[50], sifre[64];

  int puan, toplamTeslimatSayisi;
  int basarisizTeslimatSayisi, basariliTeslimatSayisi, aktifTeslimatSayisi;

  struct kur_linkedList *prev, *next;
};
typedef struct kur_linkedList kur_node;

kur_node *findNode_kur(kur_node *, char *), *findLastNode_kur(kur_node *);
kur_node *addCourier(kur_node *, char *, char *, char *, char *);
void updatingProperty_kur(kur_node *, char *, int, char *);
void updateCourier(kur_node *, char *, char, char *, char *);
kur_node *deleteCourier(kur_node *, char *), *deleteFromStart_kur(kur_node *);
void deleteFromBetween_kur(kur_node *), deleteFromEnd_kur(kur_node *);
void listCouriers(kur_node *);

kur_node *findNode_kur(kur_node *root, char *email)
{
  kur_node *temp = root;
  while (temp != NULL)
  {
    if (!strcmp(temp->email, email))
      return temp;
    temp = temp->next;
  }
  return NULL;
}

kur_node *findLastNode_kur(kur_node *root)
{
  kur_node *temp = root;

  while (temp != NULL)
  {
    if (temp->next == NULL)
      return temp;
    temp = temp->next;
  }

  return temp;
}

kur_node *addCourier(kur_node *root, char *isim, char *soyisim, char *email, char *sifre)
{
  kur_node *new = (kur_node *)malloc(sizeof(kur_node)), *lastNode = findLastNode_kur(root);
  int lastID = (lastNode == NULL) ? -1 : lastNode->ID;

  new->ID = lastID + 1;
  strncpy(new->isim, isim, 20);
  strncpy(new->soyisim, soyisim, 20);
  strncpy(new->email, email, 50);
  strncpy(new->sifre, sifrele(sifre), 64);

  new->puan = 0;
  new->toplamTeslimatSayisi = 0, new->aktifTeslimatSayisi = 0;
  new->basarisizTeslimatSayisi = 0, new->basariliTeslimatSayisi = 0;

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

void updatingProperty_kur(kur_node *new, char *ozellikIsmi, int integer, char *string)
{
  if (!strcmp(ozellikIsmi, "isim"))
    strcpy(new->isim, string);
  else if (!strcmp(ozellikIsmi, "soyisim"))
    strcpy(new->soyisim, string);
  else if (!strcmp(ozellikIsmi, "email"))
    strcpy(new->email, string);
  else if (!strcmp(ozellikIsmi, "sifre"))
    strcpy(new->sifre, sifrele(string));
  else if (!strcmp(ozellikIsmi, "puan"))
    new->puan = integer;
  else if (!strcmp(ozellikIsmi, "toplamTeslimatSayisi"))
    new->toplamTeslimatSayisi = integer;
  else if (!strcmp(ozellikIsmi, "basarisizTeslimatSayisi"))
    new->basarisizTeslimatSayisi = integer;
  else if (!strcmp(ozellikIsmi, "basariliTeslimatSayisi"))
    new->basariliTeslimatSayisi = integer;
  else if (!strcmp(ozellikIsmi, "aktifTeslimatSayisi"))
    new->aktifTeslimatSayisi = integer;
}

void updateCourier(kur_node *root, char *email, char veriTuru, char *ozellikIsmi, char *veri)
{
  kur_node *node = findNode_kur(root, email);

  int integer;
  char string[64];
  switch (veriTuru)
  {
  case 'I':
    integer = atoi(veri);
    break;
  case 'S':
    strcpy(string, veri);
    break;
  }

  updatingProperty_kur(node, ozellikIsmi, integer, string);
}

kur_node *deleteCourier(kur_node *root, char *email)
{
  kur_node *silinecek = findNode_kur(root, email);
  if (silinecek == NULL)
  {
    printf("Hata: Silinecek eleman bulunamadi.\n");
    return NULL;
  }

  if (silinecek->ID == 0)
  {
    return deleteFromStart_kur(silinecek);
  }
  else if (silinecek->next != NULL)
  {
    deleteFromBetween_kur(silinecek);
  }
  else
  {
    deleteFromEnd_kur(silinecek);
  }
}

kur_node *deleteFromStart_kur(kur_node *root)
{
  kur_node *sonraki = root->next;
  if (sonraki != NULL)
  {
    sonraki->prev = NULL;
    return sonraki;
  }

  free(root);
}

void deleteFromBetween_kur(kur_node *silinecek)
{
  kur_node *onceki = silinecek->prev, *sonraki = silinecek->next;
  onceki->next = sonraki, sonraki->prev = onceki;
  free(silinecek);
}

void deleteFromEnd_kur(kur_node *silinecek)
{
  kur_node *onceki = silinecek->prev;
  onceki->next = NULL;
  free(silinecek);
}

void listCouriers(kur_node *root)
{
  kur_node *temp = root;
  printf("ID\tIsim\tSoyisim\tMail Adres\t\tTop. Teslimat Sayisi\tBas. Teslimat Sayisi\tPuan\tSifre\n");
  printf("--------------------------------------------------------------\n");
  while (temp != NULL)
  {
    int isimUzunlugu = strlen(temp->isim);
    if (isimUzunlugu > 5)
      printf("%d\t%s %s\t%s\t\t%d\t\t%d\t\t\t%d\t%s\n", temp->ID, temp->isim, temp->soyisim, temp->email, temp->toplamTeslimatSayisi, temp->basariliTeslimatSayisi, temp->puan, temp->sifre);
    else
      printf("%d\t%s\t%s\t%s\t\t%d\t\t%d\t\t\t%d\t%s\n", temp->ID, temp->isim, temp->soyisim, temp->email, temp->toplamTeslimatSayisi, temp->basariliTeslimatSayisi, temp->puan, temp->sifre);

    temp = temp->next;
  }
  printf("\n");
}