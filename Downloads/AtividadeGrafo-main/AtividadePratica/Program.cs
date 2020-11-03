using System;
using System.Collections.Generic;
using System.IO;
using AtividadePratica.Kruskal;
using AtividadePratica;

namespace AtividadePratica
{
    class Program
    {

         static void Main(string[] args)
        {


            int vertices = 1;
            bool primeito = true;

            Grafo grafo = new Grafo(6, "GrafoDirigido", 6, "grafonaodirigido");//Coloque a quantidade de vertice que possir o grafo

            Console.WriteLine(grafo.isConexo());
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
