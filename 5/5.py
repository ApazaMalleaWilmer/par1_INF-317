import multiprocessing

def calcular_pi_parcial(inicio, fin, resultado, indice):
    suma = 0.0
    signo = 1 if inicio % 2 == 0 else -1
    for i in range(inicio, fin):
        suma += signo * (4.0 / (2 * i + 1))
        signo = -signo
    resultado[indice] = suma

if __name__ == "__main__":
    num_terminos = 1000000  
    num_procesos = 4       
    intervalo = num_terminos // num_procesos  

    resultado = multiprocessing.Array('d', num_procesos)  
    procesos = []

    for i in range(num_procesos):
        inicio = i * intervalo
        fin = (i + 1) * intervalo if i != num_procesos - 1 else num_terminos
        p = multiprocessing.Process(target=calcular_pi_parcial, args=(inicio, fin, resultado, i))
        procesos.append(p)
        p.start()

    for p in procesos:
        p.join()  

    pi_total = sum(resultado) 

    print(f"Valor aproximado de pi: {pi_total:.15f}")
