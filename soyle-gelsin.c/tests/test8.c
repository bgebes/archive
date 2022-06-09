#include <stdio.h>
#include <stdlib.h>
#include "../models/kurye/kuryeSirasi_queue.c"
#include "../models/kullanici/kul_linkedList.c"


int main(void){
  kur_node *kuryeler = addCourier(NULL, "Burak", "Yılmaz", "burakyilmaz@gmail.com", "AB2313D");
  addCourier(kuryeler, "Muhammed", "Ali", "muhali@gmail.com", "1234");
  addCourier(kuryeler, "Serdar", "Dursun", "serdur@gmail.com", "23124115");
  addCourier(kuryeler, "Halil", "Derviş", "halder@gmail.com", "A1231fdbf");
  addCourier(kuryeler, "Merih", "Demiral", "merderr@gmail.com", "1234316ğ");

  leaveQueue_kur();

  kur_node *eklenecekKurye = addCourier(kuryeler, "Oğuzcan", "Türk", "oguzturk@gmail.com", "32113213");
  joinQueue_kur(eklenecekKurye->email);

  printf("1. sirada %s, sonuncu sirada %s bulunmaktadir.\n", getFront_kur(), getRear_kur());

  printf("Test 8 basarili!\n");
  return 0;
}