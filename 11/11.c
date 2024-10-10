#include <stdio.h>
#include <mpi.h>

#define N 4

int main(int argc, char** argv) {
    int procesador, cantidad; 
    int vector1[N] = {5, 2, 6 ,10};     
    int vector2[N] = {3, 8, -1, 0};     
    int resultado[N]={0}; 
    int suma_pares = 0, suma_impares = 0;

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &procesador);
    MPI_Comm_rank(MPI_COMM_WORLD, &cantidad);  


    if (procesador == 0) {
        for (int i = 0; i < N; i++) {
            if (i % 2 == 0) {
                MPI_Send(&vector1[i], 1, MPI_INT, 1, 0, MPI_COMM_WORLD); 
                MPI_Send(&vector2[i], 1, MPI_INT, 1, 0, MPI_COMM_WORLD);
            } else {
                MPI_Send(&vector1[i], 1, MPI_INT, 2, 0, MPI_COMM_WORLD); 
                MPI_Send(&vector2[i], 1, MPI_INT, 2, 0, MPI_COMM_WORLD);
            }
        }
        

        
        MPI_Recv(&suma_pares, 1, MPI_INT, 1, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        MPI_Recv(&suma_impares, 1, MPI_INT, 2, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        

        for (int i = 0; i < N; i++) {
            resultado[i] = vector1[i] + vector2[i]; 
        }

        
        printf("Suma de los vectores:\n");
        for (int i = 0; i < N; i++) {
            printf("resultado[%d] = %d\n", i, resultado[i]);
        }
    }


    if (procesador == 1) {
        for (int i = 0; i < (N + 1) / 2; i++) {  
            int valor1, valor2;
            MPI_Recv(&valor1, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
            MPI_Recv(&valor2, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
            suma_pares += valor1 + valor2; 
        }
        MPI_Send(&suma_pares, 1, MPI_INT, 0, 0, MPI_COMM_WORLD); 
    }

    if (procesador == 2) {
        for (int i = 0; i < N / 2; i++) { 
            int valor1, valor2;
            MPI_Recv(&valor1, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
            MPI_Recv(&valor2, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
            suma_impares += valor1 + valor2; 
        }
        MPI_Send(&suma_impares, 1, MPI_INT, 0, 0, MPI_COMM_WORLD); 
    }


    MPI_Finalize();
}
