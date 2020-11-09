using System;
using System.Collections.Generic;
using System.IO;
using AtividadePratica.Kruskal;
using AtividadePratica;

namespace AtividadePratica
{
    class Program
    {
        public static int MaiorVertice() 
        {
            int maior = 0;

            using (StreamReader SW = new StreamReader("grafonaodirigido.txt"))
            {
                SW.ReadLine();//7
                string letra = SW.ReadLine();
                while (letra != null) 
                {
                    int valorEsquerda = int.Parse(letra.Split(';')[0]);
                    int valorDireita = letra.Split(';')[1] == "" ? -1 : int.Parse(letra.Split(';')[1]);
                    if (maior < valorEsquerda) 
                    {
                        maior = int.Parse(letra.Split(';')[0]);
                    }
                    if (maior < valorDireita) 
                    {
                        maior = int.Parse(letra.Split(';')[1]);
                    }
                    letra = SW.ReadLine();
                }

            }
            return maior;
        }

         static void Main(string[] args)
        {




            Grafo grafo = new Grafo(4, "GrafoDirigido", MaiorVertice(), "grafonaodirigido");//Coloque a quantidade de vertice que possir o grafo
            Console.WriteLine(grafo.isAdjacente(1,2));
            Console.WriteLine(grafo.getGrau(1));
            Console.WriteLine(grafo.isIsolado(2));
            Console.WriteLine(grafo.isPendente(3));
            Console.WriteLine(grafo.isRegular());
            Console.WriteLine(grafo.isNulo());



            //  Console.WriteLine("Quantidade de getCutVertice " + grafo.getCutVertices());



            /*

                Grafo grafo = new Grafo(6, "GrafoDirigido", 6, "grafonaodirigido" );//Coloque a quantidade de vertice que possir o grafo

                Console.WriteLine("aaass " + grafo.isUnicursal() +"\n");
                grafo.AlgoritmoPrim(1);

                Console.WriteLine($"\nQuantidade de graus de entrada do {vertices} =  {grafo.getGrauEntrada(vertices)}");
                Console.WriteLine($"Quantidade de graus de saida do {vertices} =  {grafo.getGrauSaida(vertices)}");


                Console.WriteLine("\n\n\n Tem ciclo ? " + (grafo.hasCiclo() ? "sim" : "não")  );

                */



        }
    }
}
