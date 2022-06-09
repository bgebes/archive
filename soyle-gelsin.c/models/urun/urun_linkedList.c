#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct urun_linkedList
{
  int ID;
  char isim[64], kategori[64];
  int fiyat, stoktakiAdeti, yildizPuani;
  struct urun_linkedList *prev, *next;
};
typedef struct urun_linkedList urun_node;

urun_node *findNode_urun(urun_node *, char *), *findLastNode_urun(urun_node *);
urun_node *addProduct(urun_node *, char *, char *, int, int);
void updatingProperty_urun(urun_node *, char *, int, char *);
void updateProduct(urun_node *, char *, char, char *, char *);
urun_node *deleteProduct(urun_node *, char *), *deleteFromStart_urun(urun_node *);
void deleteFromBetween_urun(urun_node *), deleteFromEnd_urun(urun_node *);
void listProducts(urun_node *);

urun_node *findNode_urun(urun_node *root, char *isim)
{
  urun_node *temp = root;
  while (temp != NULL)
  {
    if (!strcmp(temp->isim, isim))
      return temp;
    temp = temp->next;
  }
  return NULL;
}

urun_node *findLastNode_urun(urun_node *root)
{
  urun_node *temp = root;

  while (temp != NULL)
  {
    if (temp->next == NULL)
      return temp;
    temp = temp->next;
  }

  return temp;
}

urun_node *addProduct(urun_node *root, char *isim, char *kategori, int fiyat, int stoktakiAdeti)
{
  urun_node *new = (urun_node *)malloc(sizeof(urun_node)), *lastNode = findLastNode_urun(root);
  int lastID = (lastNode == NULL) ? -1 : lastNode->ID;

  new->ID = lastID + 1;
  strncpy(new->isim, isim, 20);
  strncpy(new->kategori, kategori, 64);

  new->fiyat = fiyat, new->stoktakiAdeti = stoktakiAdeti;
  new->yildizPuani = 1;

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

void updatingProperty_urun(urun_node *new, char *ozellikIsmi, int integer, char *string)
{
  if (!strcmp(ozellikIsmi, "isim"))
    strcpy(new->isim, string);
  else if (!strcmp(ozellikIsmi, "kategori"))
    strcpy(new->kategori, string);
  else if (!strcmp(ozellikIsmi, "fiyat"))
    new->fiyat = integer;
  else if (!strcmp(ozellikIsmi, "stoktakiAdeti"))
    new->stoktakiAdeti = integer;
  else if (!strcmp(ozellikIsmi, "yildizPuani"))
    new->yildizPuani = integer;
}

void updateProduct(urun_node *root, char *isim, char veriTuru, char *ozellikIsmi, char *veri)
{
  urun_node *node = findNode_urun(root, isim);

  int integer;
  char string[23];
  int _int;
  switch (veriTuru)
  {
  case 'I':
    integer = atoi(veri);
    break;
  case 'S':
    strcpy(string, veri);
    break;
  }

  updatingProperty_urun(node, ozellikIsmi, integer, string);
}

urun_node *deleteProduct(urun_node *root, char *isim)
{
  urun_node *silinecek = findNode_urun(root, isim);
  if (silinecek == NULL)
  {
    printf("Hata: Silinecek eleman bulunamadi.\n");
    return NULL;
  }

  if (silinecek->ID == 0)
  {
    return deleteFromStart_urun(silinecek);
  }
  else if (silinecek->next != NULL)
  {
    deleteFromBetween_urun(silinecek);
  }
  else
  {
    deleteFromEnd_urun(silinecek);
  }
}

urun_node *deleteFromStart_urun(urun_node *root)
{
  urun_node *sonraki = root->next;
  if (sonraki != NULL)
  {
    sonraki->prev = NULL;
    return sonraki;
  }

  free(root);
}

void deleteFromBetween_urun(urun_node *silinecek)
{
  urun_node *onceki = silinecek->prev, *sonraki = silinecek->next;
  onceki->next = sonraki, sonraki->prev = onceki;
  free(silinecek);
}

void deleteFromEnd_urun(urun_node *silinecek)
{
  urun_node *onceki = silinecek->prev;
  onceki->next = NULL;
  free(silinecek);
}

void listProducts(urun_node *root)
{
  urun_node *temp = root;
  printf("ID\tIsim\t\t\tKategori\tYildiz Puani\tFiyat\tStoktaki Adeti\n");
  printf("---------------------------------------------------------------------------------------\n");
  while (temp != NULL)
  {
    int isimUzunlugu = strlen(temp->isim);
    if (isimUzunlugu > 5)
      printf("%d\t%s\t\t%s\t\t%d Yildiz\t%d TL\t\t%d\n", temp->ID, temp->isim, temp->kategori, temp->yildizPuani, temp->fiyat, temp->stoktakiAdeti);
    else if (isimUzunlugu > 0)
      printf("%d\t%s\t\t\t%s\t\t%d Yildiz\t%d TL\t\t%d\n", temp->ID, temp->isim, temp->kategori, temp->yildizPuani, temp->fiyat, temp->stoktakiAdeti);
    temp = temp->next;
  }
  printf("\n");
}