#include <stdio.h>
#define PI 3.14159

int main()
{
    float raio = scanf("%f", &raio);
    float volumeEsfera = (4.0 / 3.0) * PI * raio * raio * raio;
    printf("%.2fcm^3\n", volumeEsfera);

    return 0;
}