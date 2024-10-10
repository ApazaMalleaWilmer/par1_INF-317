#include <stdio.h>
#include <stdlib.h>
#include <mpi.h>

#define N1 3
#define M1 2
#define N2 2
#define M2 3


void imprimirMatriz(int *matriz, int filas, int columnas) {
    for (int i = 0; i < filas; i++) {
        for (int j = 0; j < columnas; j++) {
            printf("%d ", matriz[i * columnas + j]);
        }
        printf("\n");
    }
}

int main(int argc, char **argv) {
    int procesador, cantidad_procesadores;

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &procesador);
    MPI_Comm_size(MPI_COMM_WORLD, &cantidad_procesadores);

 
    int A[N1][M1] = {{1, 2}, {3, 4}, {5, 6}};
    int B[N2][M2] = {{1, 2, 3}, {3, 4, 5}};
    int C[N1][M2] = {0}; 


    if (procesador == 0) {
        printf("Matriz A:\n");
        imprimirMatriz((int *)A, N1, M1);
        printf("\nMatriz B:\n");
        imprimirMatriz((int *)B, N2, M2);


        for (int destino = 1; destino < cantidad_procesadores; destino++) {
            MPI_Send(B, N2 * M2, MPI_INT, destino, 0, MPI_COMM_WORLD);
        }
    } else {

        MPI_Recv(B, N2 * M2, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
    }


    int filas_por_procesador = N1 / cantidad_procesadores;
    int resto_filas = N1 % cantidad_procesadores;

    int fila_inicio;
    int filas_asignadas;

    if (procesador < resto_filas) {
        fila_inicio = procesador * (filas_por_procesador + 1);
        filas_asignadas = filas_por_procesador + 1;
    } else {
        fila_inicio = procesador * filas_por_procesador + resto_filas;
        filas_asignadas = filas_por_procesador;
    }

    if (procesador == 0) {
        for (int destino = 1; destino < cantidad_procesadores; destino++) {
            int inicio, filas_enviar;

            if (destino < resto_filas) {
                inicio = destino * (filas_por_procesador + 1);
                filas_enviar = filas_por_procesador + 1;
            } else {
                inicio = destino * filas_por_procesador + resto_filas;
                filas_enviar = filas_por_procesador;
            }

            MPI_Send(&A[inicio][0], filas_enviar * M1, MPI_INT, destino, 0, MPI_COMM_WORLD);
        }
    } else {

        MPI_Recv(&A[fila_inicio][0], filas_asignadas * M1, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
    }

    for (int i = fila_inicio; i < fila_inicio + filas_asignadas; i++) {
        for (int j = 0; j < M2; j++) {
            C[i][j] = 0;
            for (int k = 0; k < M1; k++) {
                C[i][j] += A[i][k] * B[k][j];
            }
        }
    }


    if (procesador != 0) {

        MPI_Send(&C[fila_inicio][0], filas_asignadas * M2, MPI_INT, 0, 0, MPI_COMM_WORLD);
    } else {
        for (int fuente = 1; fuente < cantidad_procesadores; fuente++) {
            int inicio, filas_recibir;

            if (fuente < resto_filas) {
                inicio = fuente * (filas_por_procesador + 1);
                filas_recibir = filas_por_procesador + 1;
            } else {
                inicio = fuente * filas_por_procesador + resto_filas;
                filas_recibir = filas_por_procesador;
            }

            MPI_Recv(&C[inicio][0], filas_recibir * M2, MPI_INT, fuente, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        }


        printf("\nResultado de la multiplicación de matrices A y B:\n");
        imprimirMatriz((int *)C, N1, M2);
    }

    MPI_Finalize();
    return 0;
}
