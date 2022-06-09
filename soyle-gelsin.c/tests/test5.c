#include <stdio.h>
#include <stdlib.h>
#include "../models/kurye/kur_linkedList.c"

int main(void){
  kur_node *kuryeler = addCourier(NULL, "Mert Can", "Yılmaz", "mertcanyilmaz261@gmail.com", "ABCD");
  addCourier(kuryeler, "Ufuk Can", "Deniz", "ufukcandeniz@gmail.com", "1234");
  addCourier(kuryeler, "Hasan", "Yüksek", "hasanyuksek@gmail.com", "?Ew312");
  listCouriers(kuryeler);

  kuryeler = deleteCourier(kuryeler, "mertcanyilmaz261@gmail.com");
  listCouriers(kuryeler);

  updateCourier(kuryeler, "hasanyuksek@gmail.com", 'S', "email", "hasan.yuksek@gmail.com");
  updateCourier(kuryeler, "hasan.yuksek@gmail.com", 'I', "puan", "5000");
  listCouriers(kuryeler);

  printf("Test 5 basarili!\n");
  return 0;
}