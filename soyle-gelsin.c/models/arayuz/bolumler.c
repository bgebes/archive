#include "arayuz_stack.c"
#include "../kurye/kuryeSirasi_queue.c"

arayuz *bolum_uyelik(kul_node *);
arayuz *bolum_anaMenu(char);
arayuz *bolum_siparis(kul_node *, kul_node *, kur_node *, mag_node *);
arayuz *bolum_kullanicilar(kul_node *);
arayuz *bolum_kuryeler(kur_node *);
arayuz *bolum_magazalar(mag_node *);
arayuz *bolum_urunler(urun_node *);
arayuz *bolum_hesapIslemleri(kul_node *, kul_node *);

kul_node *girisYap(kul_node *), *kayitOl(kul_node *);

arayuz *bolum_uyelik(kul_node *kullanicilar)
{
  arayuz *bolum = (arayuz *)malloc(sizeof(arayuz));

  char *bolumBasligi = "\n---Uyelik islemleri---\n";
  char *bolumMetni = "Uyeliginiz varsa giris yapiniz, yoksa kayit olunuz. Giris yapmak icin 0, kayit olmak icin 1 yaziniz.\n";

  printf("%s%s", bolumBasligi, bolumMetni);

  char secim;

  kul_node *aktifKullanici;

  printf("Seciminiz: ");
  scanf("%c", &secim);

  if (secim == '0')
  { // Giris yapmak.
    aktifKullanici = girisYap(kullanicilar);
  }
  else if (secim == '1')
  { // Kayıt olmak.
    aktifKullanici = kayitOl(kullanicilar);
  }
  else
    exit(0);

  bolum->bolumID = 0;
  bolum->aktifKullanici = aktifKullanici;

  return bolum;
}

kul_node *girisYap(kul_node *kullanicilar)
{
  char email[50], sifre[64];

  printf("E-mail adresiniz: ");
  scanf("%s", email);

  printf("Sifreniz: ");
  scanf("%s", sifre);

  kul_node *arananKullanici = findNode_kul(kullanicilar, email);

  if (arananKullanici != NULL)
  { // Böyle e-mail adresli birisinin olduğu saptandı.
    char dogruluk = !strcmp(sifrele(sifre), arananKullanici->sifre);
    if (dogruluk == 1)
    {
      return arananKullanici;
    }
    else
    {
      printf("Parola yanlis!!!\n");
      girisYap(kullanicilar);
    }
  }
  else
  {
    printf("Bu e-mail adresine bagli kullanici bulunamadi.\n");
    girisYap(kullanicilar);
  }
}

kul_node *kayitOl(kul_node *kullanicilar)
{
  char isim[20], soyisim[20], email[50], sifre[64];

  printf("Isminiz: ");
  scanf("%s", isim);

  printf("Soyisminiz: ");
  scanf("%s", soyisim);

  printf("E-mail adresiniz: ");
  scanf("%s", email);

  printf("Sifreniz: ");
  scanf("%s", sifre);

  kul_node *kullanici = addUser(kullanicilar, isim, soyisim, email, sifre);
  printf("Sayin %s, basari ile kayit oldunuz.\n", kullanici->isim);
  return kullanici;
}

// --------------------------------------------------------------------

arayuz *bolum_anaMenu(char secim)
{
  arayuz *bolum = (arayuz *)malloc(sizeof(arayuz));

  char *bolumBasligi = "\n--------------Ana Menu--------------------\n";
  char *bolumMetni = "1-)Siparis ver\n2-)Kullanicilari gor\n3-)Kuryeleri Gor\n4-)Magazalari Gor\n5-)Urunleri gor\n6-)Cikis\n";

  if(secim == '0' || secim == '1' || secim == '2' || secim == '3' || secim == '4' || secim == '5')
    printf("%s%s", bolumBasligi, bolumMetni);
  bolum->bolumID = 1;
  return bolum;
}

// --------------------------------------------------------------------

arayuz *bolum_siparis(kul_node *kullanicilar, kul_node *kullanici, kur_node *kuryeler, mag_node *magazalar)
{
  arayuz *bolum = (arayuz *)malloc(sizeof(arayuz));

  char *bolumBasligi = "\n---Siparis Verme---\n";
  char *bolumMetni = "Oncelikle istediginiz magazayi, daha sonrada magazanin bulundurdugu urunlerden istediklerinizi seciniz.\n";
  printf("%s%s", bolumBasligi, bolumMetni);

  // Sipariş sırada bekleyen kuryeye atandı.
  kur_node *kurye = findNode_kur(kuryeler, getFront_kur());
  sip_node *siparis = addOrder(kullanici->siparisler, kuryeler, kurye->email);

  listStores(magazalar);

  char magazaSecimi[255];
  printf("Secmek istediginiz magazanin tam ismini yaziniz: ");
  scanf("%s", magazaSecimi);

  mag_node *secilenMagaza = findNode_mag(magazalar, magazaSecimi);
  if (secilenMagaza == NULL)
  {
    printf("Hatali giris yaptiniz! Programdan cikartiliyorsunuz.\n");
    exit(0);
  }

  listProductsInStore(magazalar, secilenMagaza->isim);
  kullanici->beklemedeSiparisSayisi += 1;
  secilenMagaza->aktifSatisSayisi += 1;
  secilenMagaza->toplamSatisSayisi += 1;

  int sepetFiyati = 0;

  while (1)
  {
    char urunSecimi[255];
    printf("Eklemek istediginiz urunun tam ismini yaziniz(ekleme islemini durdurmak icin 0 yaziniz): ");
    scanf("%s", urunSecimi);
    if (!strcmp(urunSecimi, "0"))
      break;
    urun_node *urun = findNode_urun(secilenMagaza->urunler, urunSecimi);
    if (urun == NULL)
    {
      printf("Hatali giris yaptiniz! Programdan cikartiliyorsunuz.\n");
      exit(0);
    }
    addProductToOrder(kullanici->siparisler, siparis->ID, secilenMagaza->urunler, urunSecimi);
    sepetFiyati += findNode_urun(secilenMagaza->urunler, urunSecimi)->fiyat;
  }

  printf("\n---Siparisi Teslim Etme---\n");

  kullanici->beklemedeSiparisSayisi -= 1;
  secilenMagaza->aktifSatisSayisi -= 1;
  kurye->aktifTeslimatSayisi -= 1;
  leaveQueue_kur();

  kullanici->basariliSiparisSayisi += 1;
  secilenMagaza->basariliSatisSayisi += 1;
  completeOrder(kullanicilar, kullanici->email, siparis->ID, 1);
  printf("Siparis basariyla teslim edildi!\n");
  printf("Kullanici ve kuryeye +5 puan verildi!\n");

  bolum->bolumID = 2;
  return bolum;
}

// --------------------------------------------------------------------

arayuz *bolum_kullanicilar(kul_node *kullanicilar)
{
  arayuz *bolum = (arayuz *)malloc(sizeof(arayuz));

  listUsers(kullanicilar);

  bolum->bolumID = 3;
  return bolum;
}

// --------------------------------------------------------------------

arayuz *bolum_kuryeler(kur_node *kuryeler)
{
  arayuz *bolum = (arayuz *)malloc(sizeof(arayuz));

  listCouriers(kuryeler);

  bolum->bolumID = 4;
  return bolum;
}

// --------------------------------------------------------------------

arayuz *bolum_magazalar(mag_node *magazalar)
{
  arayuz *bolum = (arayuz *)malloc(sizeof(arayuz));

  listStores(magazalar);

  bolum->bolumID = 5;
  return bolum;
}

// --------------------------------------------------------------------

arayuz *bolum_urunler(urun_node *urunler)
{
  arayuz *bolum = (arayuz *)malloc(sizeof(arayuz));

  listProducts(urunler);

  bolum->bolumID = 6;
  return bolum;
}