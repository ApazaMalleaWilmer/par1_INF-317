#include <stdio.h>

void fibonacci(int n, int terminosFib[]) {

    int primerTerminoFib[1]; 
    int segundoTerminoFib[1]; 

    primerTerminoFib[0] = 0; 
    segundoTerminoFib[0] = 1; 

    terminosFib[0] = primerTerminoFib[0];
    terminosFib[1] = segundoTerminoFib[0];

    for (int i = 2; i < n; i++) {
        terminosFib[i]  = primerTerminoFib[0] + segundoTerminoFib[0];
        primerTerminoFib[0] = segundoTerminoFib[0]; 
        segundoTerminoFib[0] = terminosFib[i]; 
    }
}

int main() {
    int n;

    printf("Ingrese n: ");
    scanf("%d", &n);

    int terminosFib[n];  
    fibonacci(n, terminosFib);
    printf("Términos de Fibonacci:\n");
    for (int i = 0; i < n; i++) {
        printf("F(%d) = %d\n", i, terminosFib[i]);
    }

}
