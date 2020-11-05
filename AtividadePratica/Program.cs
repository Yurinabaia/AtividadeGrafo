using System;
using System.Collections.Generic;
using System.IO;
using AtividadePratica.Kruskal;
using AtividadePratica;

namespace AtividadePratica
{
    class Program
    {
        static int MaiorVertice() 
        {
            int maior = 0;

            using (StreamReader SW = new StreamReader("grafonaodirigido.txt"))
            {
                SW.ReadLine();//7
                string letra = SW.ReadLine();
                while (letra != null) 
                {
                    if (maior < int.Parse(letra.Split(';')[0])) 
                    {
                        maior = int.Parse(letra.Split(';')[0]);
                    }
                    if (maior < int.Parse(letra.Split(';')[1])) 
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




            Grafo grafo = new Grafo(MaiorVertice(), "GrafoDirigido", MaiorVertice(), "grafonaodirigido");//Coloque a quantidade de vertice que possir o grafo

            Console.WriteLine(grafo.getCutVertices());
            /*

            Func of = new Func();
            using (StreamReader sw = new StreamReader("grafonaodirigido" + ".txt"))
            {
                string ler = sw.ReadLine();
                while (ler != null)
                {
                    if(!primeito)
                    of.addAOGrafo(ler);
                    ler = sw.ReadLine();
                    primeito = false;
                }

            }
            of.ExecFunc();
        

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
