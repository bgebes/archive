#include <stdio.h>
#include <stdlib.h>

int usAl(int sayi, int us){
  int sonuc = 1;
  char usNegatif = 0;

  if(sayi == 0)
    return sayi;
  
  if(us < 0){
    us *= -1;
    usNegatif = 1;
  }
    
  for(int i = 0; i < us; i++)
    sonuc *= sayi;
  
  return (usNegatif == 1) ? 1.0 / sonuc : sonuc;
}


