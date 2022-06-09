#include <stdio.h>
#include <stdlib.h>
#include "../models/magaza/mag_linkedList.c"

int main(void)
{
  urun_node *urunler = addProduct(NULL, "Mercimek Çorbası", "Yemek", 10, 50);
  addProduct(urunler, "Pilav", "Yemek", 15, 50);
  addProduct(urunler, "Kola", "İçecek", 5, 20);
  addProduct(urunler, "Hamburger", "Yemek", 30, 20);
  addProduct(urunler, "Kiymali Pide", "Yemek", 20, 20);

  mag_node *magazalar = addStore(NULL, "Lokanta");
  addStore(magazalar, "Hamburgerci");
  addStore(magazalar, "Pideci");
  listStores(magazalar);

  magazalar = deleteStore(magazalar, "Lokanta");
  listStores(magazalar);

  updateStore(magazalar, "Pideci", 'I', "toplamCalisanSayisi", "10");
  updateStore(magazalar, "Pideci", 'I', "calisanMaasi", "5000");
  listStores(magazalar);

  addProductToStore(magazalar, "Pideci", urunler, "Kola");
  addProductToStore(magazalar, "Pideci", urunler, "Kiymali Pide");
  listStores(magazalar);
  listProductsInStore(magazalar, "Pideci");

  printf("Test 4 basarili!\n");
  return 0;
}