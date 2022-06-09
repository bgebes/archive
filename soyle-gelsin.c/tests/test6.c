#include <stdio.h>
#include <stdlib.h>
#include "../models/siparis/sip_linkedList.c"

int main(void)
{
  urun_node *urunler = addProduct(NULL, "Mercimek Çorbası", "Yemek", 10, 50);
  addProduct(urunler, "Pilav", "Yemek", 15, 50);
  addProduct(urunler, "Kola", "İçecek", 5, 20);
  addProduct(urunler, "Hamburger", "Yemek", 30, 20);
  addProduct(urunler, "Kiymali Pide", "Yemek", 20, 20);

  kur_node *kuryeler = addCourier(NULL, "Mert Can", "Yılmaz", "mertcanyilmaz261@gmail.com", "ABCD");
  addCourier(kuryeler, "Ufuk Can", "Deniz", "ufukcandeniz@gmail.com", "1234");

  sip_node *siparisler = addOrder(NULL, kuryeler, "mertcanyilmaz261@gmail.com");
  addOrder(siparisler, kuryeler, "ufukcandeniz@gmail.com");
  listOrders(siparisler);

  deleteOrder(siparisler, 1);
  listOrders(siparisler);

  updateOrder(siparisler, 0, 'I', "siparisDurumu", "5");
  listOrders(siparisler);

  addProductToOrder(siparisler, 0, urunler, "Kola");
  addProductToOrder(siparisler, 0, urunler, "Kiymali Pide");
  listOrders(siparisler);

  printf("Test 6 basarili!\n");
  return 0;
}