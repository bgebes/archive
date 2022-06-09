#include <stdio.h>
#include <stdlib.h>
#include "../models/siparis/aktifSiparisler_queue.c"


int main(void){
  kur_node *kuryeler = addCourier(NULL, "Burak", "Yılmaz", "burakyilmaz@gmail.com", "AB2313D");
  addCourier(kuryeler, "Muhammed", "Ali", "muhali@gmail.com", "1234");
  addCourier(kuryeler, "Serdar", "Dursun", "serdur@gmail.com", "23124115");
  addCourier(kuryeler, "Halil", "Derviş", "halder@gmail.com", "A1231fdbf");
  listCouriers(kuryeler);

  sip_node *siparisler = addOrder(NULL, kuryeler, "burakyilmaz@gmail.com");
  addOrder(siparisler, kuryeler, "muhali@gmail.com");
  addOrder(siparisler, kuryeler, "serdur@gmail.com");
  addOrder(siparisler, kuryeler, "halder@gmail.com");

  fillQueue_AktSip(siparisler);
  printQueue_AktSip();

  leaveQueue_AktSip();
  printQueue_AktSip();

  // Sipariş tamamlandığı için aktif siparişler tablosuna alınmadığını gösterdik.
  sip_node *eklenecekSiparis = addOrder(siparisler, kuryeler, "burakyilmaz@gmail.com");
  updateOrder(siparisler, 4, 'I', "siparisDurumu", "1"); 
  joinQueue_AktSip(eklenecekSiparis);
  printQueue_AktSip();

  printf("1. sirada ID: %d, sonuncu sirada ID: %d bulunmaktadir.\n", getFront_AktSip() -> ID, getRear_AktSip() -> ID);

  printf("Test 9 basarili!\n");
  return 0;
}