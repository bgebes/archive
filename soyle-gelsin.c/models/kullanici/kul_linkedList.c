#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../siparis/sip_linkedList.c"

struct kul_linkedList
{
  int ID;

  char isim[20], soyisim[20], email[50], sifre[64];
  int bakiye, puan;

  sip_node *siparisler;
  int toplamSiparisSayisi;
  int basarisizSiparisSayisi, basariliSiparisSayisi, beklemedeSiparisSayisi;

  struct kul_linkedList *prev, *next;
};
typedef struct kul_linkedList kul_node;

kul_node *findNode_kul(kul_node *, char *), *findLastNode_kul(kul_node *);
kul_node *addUser(kul_node *, char *, char *, char *, char *);
kul_node *copyUser(kul_node *, int);
void updatingProperty_kul(kul_node *, char *, int, char *);
void updateUser(kul_node *, char *, char, char *, char *);
kul_node *deleteUser(kul_node *, char *), *deleteFromStart_kul(kul_node *);
void deleteFromBetween_kul(kul_node *), deleteFromEnd_kul(kul_node *);
void completeOrder(kul_node *, char *, int, int);
void listUsers(kul_node *);

kul_node *findNode_kul(kul_node *root, char *email)
{
  kul_node *temp = root;
  while (temp != NULL)
  {
    if (!strcmp(temp->email, email))
      return temp;
    temp = temp->next;
  }
  return NULL;
}

kul_node *findLastNode_kul(kul_node *root)
{
  kul_node *temp = root;

  while (temp != NULL)
  {
    if (temp->next == NULL)
      return temp;
    temp = temp->next;
  }

  return temp;
}

kul_node *addUser(kul_node *root, char *isim, char *soyisim, char *email, char *sifre)
{
  kul_node *new = (kul_node *)malloc(sizeof(kul_node)), *lastNode = findLastNode_kul(root);
  int lastID = (lastNode == NULL) ? -1 : lastNode->ID;

  new->ID = lastID + 1;
  strncpy(new->isim, isim, 20);
  strncpy(new->soyisim, soyisim, 20);
  strncpy(new->email, email, 50);
  strncpy(new->sifre, sifrele(sifre), 64);

  new->siparisler = (sip_node *)malloc(sizeof(sip_node));
  new->bakiye = 0, new->puan = 0;
  new->toplamSiparisSayisi = 0, new->beklemedeSiparisSayisi = 0;
  new->basarisizSiparisSayisi = 0, new->basariliSiparisSayisi = 0;

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

void updatingProperty_kul(kul_node *new, char *ozellikIsmi, int integer, char *string)
{
  if (!strcmp(ozellikIsmi, "isim"))
    strcpy(new->isim, string);
  else if (!strcmp(ozellikIsmi, "soyisim"))
    strcpy(new->soyisim, string);
  else if (!strcmp(ozellikIsmi, "email"))
    strcpy(new->email, string);
  else if (!strcmp(ozellikIsmi, "sifre"))
    strcpy(new->sifre, sifrele(string));
  else if (!strcmp(ozellikIsmi, "bakiye"))
    new->bakiye = integer;
  else if (!strcmp(ozellikIsmi, "puan"))
    new->puan = integer;
  else if (!strcmp(ozellikIsmi, "toplamSiparisSayisi"))
    new->toplamSiparisSayisi = integer;
  else if (!strcmp(ozellikIsmi, "basarisizSiparisSayisi"))
    new->basarisizSiparisSayisi = integer;
  else if (!strcmp(ozellikIsmi, "basariliSiparisSayisi"))
    new->basariliSiparisSayisi = integer;
  else if (!strcmp(ozellikIsmi, "beklemedeSiparisSayisi"))
    new->beklemedeSiparisSayisi = integer;
}

void updateUser(kul_node *root, char *email, char veriTuru, char *ozellikIsmi, char *veri)
{
  kul_node *node = findNode_kul(root, email);

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

  updatingProperty_kul(node, ozellikIsmi, integer, string);
}

kul_node *deleteUser(kul_node *root, char *email)
{
  kul_node *silinecek = findNode_kul(root, email);
  if (silinecek == NULL)
  {
    printf("Hata: Silinecek eleman bulunamadi.\n");
    return NULL;
  }

  if (silinecek->ID == 0)
  {
    return deleteFromStart_kul(silinecek);
  }
  else if (silinecek->next != NULL)
  {
    deleteFromBetween_kul(silinecek);
  }
  else
  {
    deleteFromEnd_kul(silinecek);
  }
}

kul_node *deleteFromStart_kul(kul_node *root)
{
  kul_node *sonraki = root->next;
  if (sonraki != NULL)
  {
    sonraki->prev = NULL;
    return sonraki;
  }

  free(root);
}

void deleteFromBetween_kul(kul_node *silinecek)
{
  kul_node *onceki = silinecek->prev, *sonraki = silinecek->next;
  onceki->next = sonraki, sonraki->prev = onceki;
  free(silinecek);
}

void deleteFromEnd_kul(kul_node *silinecek)
{
  kul_node *onceki = silinecek->prev;
  onceki->next = NULL;
  free(silinecek);
}

void completeOrder(kul_node *kullanicilar, char *email, int sip_id, int sip_durumu)
{
  kul_node *kullanici = findNode_kul(kullanicilar, email);
  sip_node *siparis = findNode_sip(kullanici->siparisler, sip_id);
  kur_node *kurye = siparis->kurye;

  if (siparis->sepetToplamFiyat > kullanici->bakiye)
  {
    printf("Yetersiz bakiye. Lütfen bakiye yükledikten sonra tekrar deneyiniz.\n");
    return;
  }

  siparis->siparisDurumu = sip_durumu;
  kurye->aktifTeslimatSayisi -= 1;
  kurye->toplamTeslimatSayisi += 1;

  if (sip_durumu == 1)
  { // Başarılı
    kurye->basariliTeslimatSayisi += 1;
    kurye->puan += 5;
    kullanici->bakiye -= siparis->sepetToplamFiyat;
    kullanici->puan += 5;
  }
  else if (sip_durumu == 2) // Başarısız
    kurye->basarisizTeslimatSayisi += 1;
}

void listUsers(kul_node *root)
{
  kul_node *temp = root;
  printf("ID\tIsim\tSoyisim\tMail Adres\t\t\tBakiye\tPuan\tSifre\n");
  printf("--------------------------------------------------------------\n");
  while (temp != NULL)
  {
    printf("%d\t%s\t%s\t%s\t%d\t%d\t%s\n", temp->ID, temp->isim, temp->soyisim, temp->email, temp->bakiye, temp->puan, temp->sifre);
    temp = temp->next;
  }
  printf("\n");
}