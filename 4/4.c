#include <stdio.h>

void calcular_pi_iterativo(int n, double *resultado) {
    double pi = 0.0;
    for (int i = 0; i < n; i++) {
        if (i % 2 == 0) {
            pi += 1.0 / (2 * i + 1);
        } else {
            pi -= 1.0 / (2 * i + 1);
        }
    }

    *resultado = 4.0 * pi;  
}

void calcular_pi_recursivo(int n, double* resultado) {
    if (n == 0) {
        return;
    }
    double term = (n % 2 == 0) ? -1.0 / (2 * n - 1) : 1.0 / (2 * n - 1);
 
    *resultado += term;
    calcular_pi_recursivo(n - 1, &*resultado); 
}

int main() {
    double pi = 0.0; 
    calcular_pi_iterativo(100000, &pi);
    printf("Valor de pi (iterativo): %.10f\n", pi);
    

    pi = 0.0; 
    calcular_pi_recursivo(100000, &pi); 
    pi *= 4.0; 
    printf("Valor de pi (recursivo): %.10f\n", pi);

    return 0;
}
