#include <stdio.h>

int suma(int a, int b) {
    return a + b;
}

int resta(int a, int b) {
    return a - b;
}

int multiplicacion(int a, int b) {
    return a * b;
}

float division(int a, int b) {
    if (b != 0) {
        return (float)a / b;
    } else {
        printf("Error: División por cero\n");
        return 0.0;
    }
}

int main() {
    int a, b;
    
 
    printf("Ingresa el valor de a: ");
    scanf("%d", &a);
    
    printf("Ingresa el valor de b: ");
    scanf("%d", &b);

    printf("Suma: %d\n", suma(a, b));
    printf("Resta: %d\n", resta(a, b));
    printf("Multiplicación: %d\n", multiplicacion(a, b));
    printf("División: %.2f\n", division(a, b));

}
