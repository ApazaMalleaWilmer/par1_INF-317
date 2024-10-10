#include <stdio.h>
#include <omp.h>

#define N 20 

int main() {
    int fib[N];
    int i;


    fib[0] = 0;
    fib[1] = 1;

    #pragma omp parallel shared(fib) private(i)
    {
        #pragma omp for
        for (i = 2; i < N; i++) {
            fib[i] = fib[i-1] + fib[i-2];
        }
    }


    printf("Serie de Fibonacci:\n");
    for (i = 0; i < N; i++) {
        printf("%d ", fib[i]);
    }
    printf("\n");

}
