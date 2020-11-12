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
            Console.WriteLine("Program");
            Console.WriteLine(grafo.isAdjacente(1,5));
            Console.WriteLine(grafo.getGrau(1));
            Console.WriteLine(grafo.getGrau(2));
            Console.WriteLine(grafo.isIsolado(2));
            Console.WriteLine(grafo.isPendente(3));
            Console.WriteLine(grafo.isRegular());
            Console.WriteLine(grafo.isNulo());
            Console.WriteLine(grafo.isParalelo());
            Console.WriteLine(grafo.Loop());
            Console.WriteLine(grafo.isCompleto());
            Console.WriteLine(grafo.isEuleriano());
            Console.WriteLine(grafo.isUnicursal());
            Console.WriteLine(grafo.isConexo());
            grafo.AlgoritmoKurskal(1);
            grafo.AlgoritmoPrim(4);

            Console.WriteLine(grafo.getCutVertices());




            Console.WriteLine("\n\n\n///////////////Dirigido////////////////");
            Console.WriteLine(grafo.getGrauEntrada(3) );
            Console.WriteLine(grafo.getGrauSaida(3));
            Console.WriteLine(grafo.hasCiclo());

        }
    }
}
