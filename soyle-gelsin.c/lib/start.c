#include <stdio.h>
#include <stdlib.h>
#include "../models/arayuz/bolumler.c"

void programiHazirla();

urun_node *urunler;
mag_node *magazalar;
kur_node *kuryeler;
kul_node *kullanicilar;

kul_node *aktifKullanici;

int main(void)
{
  //Program sahte verilerle hazırlanılıyor.
  programiHazirla(kullanicilar, kuryeler, magazalar, urunler);

  // Uyelik ekranı
  arayuz *bolum1 = bolum_uyelik(kullanicilar);
  addStack(bolum1);
  aktifKullanici = bolum1->aktifKullanici;
  aktifKullanici->bakiye = 5000;

  char secim = '0';
  while (1)
  {
    arayuz *bolum2 = bolum_anaMenu(secim);
    
    printf("Seciminiz: ");
    scanf("%c", &secim);

    if (secim == '1') // Siparis ver
    {
      arayuz *bolum3 = bolum_siparis(kullanicilar, aktifKullanici, kuryeler, magazalar);
      addStack(bolum3);
      leaveStack();
    }
    else if (secim == '2')
    {
      arayuz *bolum4 = bolum_kullanicilar(kullanicilar); // Kullanıcıları göster
      addStack(bolum4);
      leaveStack();
    }
    else if (secim == '3') // Kuryeleri göster
    {
      arayuz *bolum5 = bolum_kuryeler(kuryeler);
      addStack(bolum5);
      leaveStack();
    }
    else if (secim == '4') // Mağazaları göster
    {
      arayuz *bolum6 = bolum_magazalar(magazalar);
      addStack(bolum6);
      leaveStack();
    }
    else if (secim == '5') // Ürünleri göster
    {
      arayuz *bolum7 = bolum_urunler(urunler);
      addStack(bolum7);
      leaveStack();
    }
    else if (secim == '6') // Çıkış yap
      break;
  }
  return 0;
}

void programiHazirla()
{
  // Sahte verilerle hazırlamak.
  urunler = addProduct(NULL, "Mercimek Çorbası", "Yemek", 10, 50);
  addProduct(urunler, "Pilav", "Yemek", 15, 50);
  addProduct(urunler, "Kola", "İçecek", 5, 20);
  addProduct(urunler, "Hamburger", "Yemek", 30, 20);
  addProduct(urunler, "Kıymalı Pide", "Yemek", 20, 20);

  magazalar = addStore(NULL, "Lokanta");
  addProductToStore(magazalar, "Lokanta", urunler, "Kola");
  addProductToStore(magazalar, "Lokanta", urunler, "Pilav");

  addStore(magazalar, "Hamburgerci");
  addProductToStore(magazalar, "Hamburgerci", urunler, "Hamburger");
  addProductToStore(magazalar, "Hamburgerci", urunler, "Kola");

  addStore(magazalar, "Pideci");
  addProductToStore(magazalar, "Pideci", urunler, "Kıymalı Pide");
  addProductToStore(magazalar, "Pideci", urunler, "Kola");

  kuryeler = addCourier(NULL, "Mert Can", "Yılmaz", "mertcanyilmaz261@gmail.com", "ABCD");
  addCourier(kuryeler, "Ufuk Can", "Deniz", "ufukcandeniz@gmail.com", "1234");
  joinQueue_kur("mertcanyilmaz261@gmail.com");
  joinQueue_kur("ufukcandeniz@gmail.com");

  kullanicilar = addUser(NULL, "Esra", "Turk", "esra.turk@bil.omu.edu.tr", "ABCD");
  addUser(kullanicilar, "Berkay", "Gebes", "berkay.gebes@bil.omu.edu.tr", "1234");
  addUser(kullanicilar, "Caner", "Tas", "caner.tas@bil.omu.edu.tr", "=?_:");
}