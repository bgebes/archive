#include <stdio.h>
#include <stdlib.h>
#include "../models/urun/urun_linkedList.c"

int main(void)
{
  urun_node *urunler = addProduct(NULL, "Çikolatali Gofret", "Aburcubur", 1, 20);
  addProduct(urunler, "Ayran", "İçecek", 2, 20);
  addProduct(urunler, "Tost", "Yemek", 8, 10);
  listProducts(urunler);

  deleteProduct(urunler, "Ayran");
  listProducts(urunler);

  updateProduct(urunler, "Tost", 'I', "fiyat", "10");
  updateProduct(urunler, "Çikolatali Gofret", 'I', "yildizPuani", "5");
  listProducts(urunler);

  printf("Test 3 basarili!\n");
  return 0;
}