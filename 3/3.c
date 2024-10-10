#include <stdio.h>

void suma(int a, int b, int *resultado) {
    *resultado = a + b;
}

void resta(int a, int b, int *resultado) {
    *resultado = a - b;
}

void multiplicacion(int a, int b, int *resultado) {
    int i;
    *resultado = 0;  
    for (i = 0; i < b; i++) {
        suma(a, *resultado, &*resultado);  
    }
}

void division(int a, int b, float *resultado) {
    if (b != 0) {
        *resultado = (float) a / b;
    } else {
        printf("Error: División por cero.\n");
    }
}

int main() {
    int a, b, res;
    float div_res;

    printf("Ingresa el valor de a: ");
    scanf("%d", &a);

    printf("Ingresa el valor de b: ");
    scanf("%d", &b);

    suma(a, b, &res);
    printf("Suma: %d\n", res);

    resta(a, b, &res);
    printf("Resta: %d\n", res);

    multiplicacion(a, b, &res);
    printf("Multiplicación : %d\n", res);

    division(a, b, &div_res);
    if (b != 0) {
        printf("División: %.2f\n", div_res);
    }

    return 0;
}
