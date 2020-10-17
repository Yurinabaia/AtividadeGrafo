using System;
using System.Collections.Generic;
using System.IO;

namespace AtividadePratica
{
    class Program
    {

         static void Main(string[] args)
        {
            Grafo grafo = new Grafo(5, "GrafoDirigido" );//Coloque a quantidade de vertice que possir o grafo
            Console.WriteLine("\n\n\n Tem ciclo ? " +grafo.hasCiclo(grafo));
        }
    }
}
