#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "usAl.c"

char *sifrele(char *metin)
{
  int diziBoyutu = strlen(metin);
  char temp[diziBoyutu];
  strcpy(temp, metin);
  for (int i = 0; i < 2; i++)
  {
    for (int j = 0; j < diziBoyutu; j++)
    {
      int number = (int)temp[j];
      temp[j] = (char)(number + 3 * usAl(j, i));
    }
  }

  // CHAR TO CHAR*
  char *sifre = (char *)malloc(sizeof(char));
  sifre = temp;

  return sifre;
}