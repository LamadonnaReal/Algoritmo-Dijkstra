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

        public static int[] visitati = new int[1];

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
            int nodi, nodoIniziale, nodoFinale, partenza, arrivo, peso, nodoIntermedio;
            string continuo = "s";
            Console.WriteLine("Inserire il numero di nodi: ");
            Int32.TryParse(Console.ReadLine(), out nodi);
            visitati = new int[nodi];
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
            /*Console.Write("\nMatrice adiacenze dopo primo passo Dijkstra: \n");
            Dijkstra(matriceAdiacenze, nodi, 0, 0);*/
            stampa(matriceNuova, nodi);
            Console.WriteLine("\nPremi un tasto per continuare: ");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Inserisci il nodo iniziale: ");
            Int32.TryParse(Console.ReadLine(), out nodoIniziale);
            Console.Write("Inserisci il nodo finale: ");
            Int32.TryParse(Console.ReadLine(), out nodoFinale);
            Dijkstra(matriceAdiacenze, nodi, nodoIniziale, nodoFinale);
            /*int min = 9999;
            for (int i = 0; i <= nodi; i++)
            {
                for (int j = 0; j <= nodi; j++)
                {
                    if (matriceNuova[i, j] < min)
                        min = matriceNuova[i, j];
                }
            }*/
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
                    if (l[i, j] > 100)
                        Console.Write(l[i, j] + " ");
                    else
                        Console.Write(l[i, j] + "    ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
            Console.Write("\n");

        }

        static void Dijkstra(int[,] l, int n, int nodoI, int nodoF)
        {
            int i = nodoI, j = 0;
            int iteratore = 0, c = 0;
            int costoAggiunto = 0;
            int min = INF;
            bool controllo = false;
            visitati[c] = i;
            while (!controllo)
            {
                /*for(int i = 1; i <= n; i ++)
                {*/
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
                i = vett[min].nodoFine;
                visitati[c] = i;
                c++;
                shiftSx(min);
                dim--;
                //}
            }
        }

        public static void shiftSx(int copia)
        {
<<<<<<< HEAD
            for(int i = copia; i < dim-1; i++)
=======
            for (int i = copia; i < dim; i++)
>>>>>>> f85adc8c587e2f4e4f67bd1ccd43e4e97a8218c6
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
