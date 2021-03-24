using System;

namespace Algoritmo_Dijkstra
{
    class Program
    {
        const int INF = 9999;
        int[,] matriceNuova = new int[1, 1];

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
        static void Main(string[] args)
        {
            int[,] matriceAdiacenze = new int[1, 1];
            int nodi, nodoIniziale, nodoFinale, partenza, arrivo, peso;
            string continuo = "s";
            Console.WriteLine("Inserire il numero di nodi: ");
            Int32.TryParse(Console.ReadLine(), out nodi);
            matriceAdiacenze = new int[nodi, nodi];
            matriceNuova = new int[nodi, nodi];
            while (continuo == "s")
            {
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
            stampa(matriceAdiacenze, nodi);
        }

        static void stampa(int[,] l, int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                    Console.Write(l[i, j] + " ");
                Console.Write("\n");
            }
        }

        static void Dijkstra(int[,] l, int n)
        {
            int j = 0;
            int min = INF;
            for(int i = 0; i < nodi; i++)
            {
                if (l[i, j] < min)
                    min = l[i, j];
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
        int minimo(vettorecosto[] x)
        {
            int min = INF, copia = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (min > x[i].costo)
                {
                    min = x[i].costo;
                    copia = i;
                }
            }
            return copia;
        }
    }
}
