using System;

namespace Algoritmo_Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[,] matriceAdiacenze = new int[1, 1];
            int nodi, nodoIniziale, nodoFinale, partenza, arrivo, costo;
            string continuo = "s";
            Console.WriteLine("Inserire il numero di nodi: ");
            nodi = Console.Read();
            matriceAdiacenze = new int[nodi, nodi];
            while (continuo == "s")
            {
                Console.WriteLine("Inserisci arco in terna(partenza arrivo costo): ");
                partenza = Console.Read();
                arrivo = Console.Read();
                costo = Console.Read();
                matriceAdiacenze[partenza, arrivo] = costo;
                matriceAdiacenze[arrivo, partenza] = costo;
                Console.WriteLine("Vuoi continuare? (s,n)");
                continuo = Console.ReadLine();

            }
        }
        static void stampa(int[,]l)
        {
            for(int i=0;i<)
        }
    }
}
