#include <stdio.h>
#include <stdlib.h>
#include "../scripts/sifrelemeAlgoritmasi.c"

int main(void){
  char * yazi = "ABCD?/";
  char * sifrelenmisYazi = sifrele(yazi);
  printf("Yazi: %s, Sifre: %s\n", yazi, sifrelenmisYazi);
  
  printf("Test 2 basarili!\n");
  return 0;
}