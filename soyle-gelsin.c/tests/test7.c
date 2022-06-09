#include <stdio.h>
#include <stdlib.h>
#include "../models/kullanici/kul_linkedList.c"

int main(void)
{
  urun_node *urunler = addProduct(NULL, "Mercimek Çorbası", "Yemek", 10, 50);
  addProduct(urunler, "Pilav", "Yemek", 15, 50);
  addProduct(urunler, "Kola", "İçecek", 5, 20);
  addProduct(urunler, "Hamburger", "Yemek", 30, 20);
  addProduct(urunler, "Kiymali Pide", "Yemek", 20, 20);

  kur_node *kuryeler = addCourier(NULL, "Mert Can", "Yılmaz", "mertcanyilmaz261@gmail.com", "ABCD");
  addCourier(kuryeler, "Ufuk Can", "Deniz", "ufukcandeniz@gmail.com", "1234");

  kul_node *kullanicilar = addUser(NULL, "Esra", "Turk", "esra.turk@bil.omu.edu.tr", "ABCD");
  addUser(kullanicilar, "Berkay", "Gebes", "berkay.gebes@bil.omu.edu.tr", "1234");
  addUser(kullanicilar, "Caner", "Tas", "caner.tas@bil.omu.edu.tr", "=?_:");
  listUsers(kullanicilar);

  deleteUser(kullanicilar, "berkay.gebes@bil.omu.edu.tr");
  listUsers(kullanicilar);

  updateUser(kullanicilar, "esra.turk@bil.omu.edu.tr", 'I', "bakiye", "5000");
  updateUser(kullanicilar, "caner.tas@bil.omu.edu.tr", 'S', "isim", "Ali");
  listUsers(kullanicilar);

  kul_node *seciliKullanici = findNode_kul(kullanicilar, "esra.turk@bil.omu.edu.tr");
  sip_node *seciliKullanici_Siparisler = seciliKullanici -> siparisler;
  addOrder(seciliKullanici_Siparisler, kuryeler, "mertcanyilmaz261@gmail.com");
  addOrder(seciliKullanici_Siparisler, kuryeler, "ufukcandeniz@gmail.com");
  listOrders(seciliKullanici_Siparisler);

  addProductToOrder(seciliKullanici_Siparisler, 1, urunler, "Kola");
  addProductToOrder(seciliKullanici_Siparisler, 1, urunler, "Kiymali Pide");
  listOrders(seciliKullanici_Siparisler);

  completeOrder(kullanicilar, "esra.turk@bil.omu.edu.tr", 1, 1);
  listOrders(seciliKullanici_Siparisler);

  listCouriers(kuryeler);

  printf("Test 7 basarili!\n");
  return 0;
}