#include <stdio.h>
#include <string.h>
#include <mpi.h>

#define MAX_CADENA 100  // Longitud máxima de cada cadena
#define TAM_VECTORES 6  // Tamaño del vector de cadenas

int main(int argc, char* argv[]) {
    int procesador, cantidad_procesadores;

    char vector[TAM_VECTORES][MAX_CADENA] = {
        "Elemento 0",
        "Elemento 1",
        "Elemento 2",
        "Elemento 3",
        "Elemento 4",
        "Elemento 5"
    };

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &procesador);
    MPI_Comm_size(MPI_COMM_WORLD, &cantidad_procesadores);

    if (procesador == 0) {
        for (int i = 0; i < TAM_VECTORES; i++) {
           
            MPI_Send(vector[i], MAX_CADENA, MPI_CHAR, (i % 2) + 1, 0, MPI_COMM_WORLD);
        }
    } else if (procesador == 1) {
       
        for (int i = 0; i < TAM_VECTORES; i += 2) {
            char cadena[MAX_CADENA];
            MPI_Recv(cadena, MAX_CADENA, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
            printf("Proceso 1 (Pares) recibe: %s\n", cadena);
        }
    } else if (procesador == 2) {
       
        for (int i = 1; i < TAM_VECTORES; i += 2) {
            char cadena[MAX_CADENA];
            MPI_Recv(cadena, MAX_CADENA, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
            printf("Proceso 2 (Impares) recibe: %s\n", cadena);
        }
    }

    MPI_Finalize();
    return 0;
}
