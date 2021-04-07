﻿using System;

namespace Algoritmo_Dijkstra
{
    class Program
    {
        const int INF = 9999;
        public static int[,] matriceNuova = new int[1, 1];
        public struct vettorepercorso
        {
            int[] nodi;
            int costo;
        };

        public struct vettorecosto
        {
            public int nodoInizio;
            public int nodoFine;
            public int costo;
        };

        public static vettorecosto[] vett = new vettorecosto[1];
        public static int dim = 0;

        static void Main(string[] args)
        {
            int[,] matriceAdiacenze = new int[1, 1];
            int nodi, nodoIniziale, nodoFinale, partenza, arrivo, peso;
            string continuo = "s";
            Console.WriteLine("Inserire il numero di nodi: ");
            Int32.TryParse(Console.ReadLine(), out nodi);
            matriceAdiacenze = new int[nodi + 1, nodi + 1];
            matriceNuova = new int[nodi + 1, nodi + 1];
            vett = new vettorecosto[nodi * nodi];
            while (continuo == "s")
            {
                Console.Clear();
                Console.WriteLine("Inserisci il nodo di partenza:  ");
                Int32.TryParse(Console.ReadLine(), out partenza);
                Console.WriteLine("Inserisci il nodo di arrivo:  ");
                Int32.TryParse(Console.ReadLine(), out arrivo);
                Console.WriteLine("Inserisci il peso del tratto: ");
                Int32.TryParse(Console.ReadLine(), out peso);
                matriceAdiacenze[partenza, arrivo] = peso;
                matriceAdiacenze[arrivo, partenza] = peso;
                Console.WriteLine("Vuoi continuare? (s-n): ");
                continuo = Console.ReadLine();
            }

            for (int i = 0; i <= nodi; i++)
            {
                matriceAdiacenze[0, i] = i;
                for (int j = 0; j <= nodi; j++)
                {
                    if (j == 0)
                        matriceAdiacenze[i, j] = i;
                    if (matriceAdiacenze[i, j] == 0 && i != j)
                        matriceAdiacenze[i, j] = INF;
                }
            }
            riempimento(nodi);
            Console.Clear();
            Console.Write("Matrice adiacenze: \n");
            stampa(matriceAdiacenze, nodi);
            Console.Write("\nMatrice adiacenze dopo primo passo Dijkstra: \n");
            Dijkstra(matriceAdiacenze, nodi);
            stampa(matriceNuova, nodi);
            Console.WriteLine("\nPremi un tasto per continuare: ");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Inserisci il nodo iniziale: ");
            Int32.TryParse(Console.ReadLine(), out nodoIniziale);
            Console.Write("Inserisci il nodo finale: ");
            Int32.TryParse(Console.ReadLine(), out nodoFinale);
        }

        public static void riempimento(int nodi)
        {
            for (int i = 0; i <= nodi; i++)
            {
                matriceNuova[0, i] = i;
                for (int j = 0; j <= nodi; j++)
                {
                    if (j == 0)
                        matriceNuova[i, j] = i;
                }
            }
        }

        static void stampa(int[,] l, int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if(l[i,j]>100)
                        Console.Write(l[i, j] + " ");
                    else
                        Console.Write(l[i, j] + "    ");
                }
                Console.Write("\n");
            }
        }

        static void Dijkstra(int[,] l, int n)
        {
            int j = 0;
            int iteratore = 0;
            int costoAggiunto = 0;
            int min = INF;
            for(int i = 1; i <= n; i ++)
            {
                for (j = 1; j <= n; j++)
                {
                    if (l[i, j] != INF && l[i, j] != 0)
                    {
                        vett[iteratore].nodoInizio = i;
                        vett[iteratore].nodoFine = j;
                        vett[iteratore].costo = l[i, j] + costoAggiunto;
                        dim++;
                        iteratore++;
                    }
                }
                min = minimo();
                matriceNuova[vett[min].nodoInizio, vett[min].nodoFine] = vett[min].costo;
                matriceNuova[vett[min].nodoFine, vett[min].nodoInizio] = vett[min].costo;
                shiftSx(min);
                dim--;
            }
            /*int copiaNum, copiaInd, i, i2 = 0, j = 0, somma;
            int[,] m = new int[n, n];
            int[,] copiaMat = new int[n, n];
            int[] somme = new int[n];
            int[] puntatori = new int[INF];
            vettorecosto[] percorso = new vettorecosto[INF];
            int copia = l[0, 0];
            for (j = 0; j < n; j++)
            {
                for (i = 1; i < n; i++)
                {
                    if (m[i, j] < copia)
                    {
                        copiaInd = i;
                        somme[i2] = somme[i2 + m[i, j]];
                    }
                }
                i2++;
            }*/
        }

        public static void shiftSx(int copia)
        {
            for(int i = copia; i < dim; i++)
            {
                vett[i].nodoInizio = vett[i + 1].nodoInizio;
                vett[i].nodoFine = vett[i + 1].nodoFine;
                vett[i].costo = vett[i + 1].costo;
            }
        }

        public static int minimo()
        {
            int min = INF, copia = 0;
            for (int i = 0; i < dim; i++)
            {
                if (min > vett[i].costo)
                {
                    min = vett[i].costo;
                    copia = i;
                }
            }
            return copia;
        }
    }
}
