#include <stdio.h>

int main()
{
    float precoEUA, taxaDolar, precoBR;
    float quantidadeGalao = 3.7854f;

    scanf("%f %f", &precoEUA, &taxaDolar);

    precoBR = (precoEUA * taxaDolar) / quantidadeGalao;
    printf("R$ %.2f\n", precoBR);

    return 0;
}