#include <stdio.h>
#include <stdlib.h>
#include "../scripts/usAl.c"

#define sayi 3
#define us 4

int main(void){
  int sonuc = usAl(sayi, us);
  printf("%d ussu %d = %d\n", sayi, us, sonuc);

  printf("Test 1 basarili!\n");
  return 0;
}