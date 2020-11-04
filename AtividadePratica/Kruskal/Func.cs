using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadePratica.Kruskal
{
    class Func
    {
		public GrafoK raiz;
		public No noRaiz;

		/**
		 * Construtor á¹”adrÃ£o
		 */
		public Func()
		{
			raiz = new GrafoK();
			noRaiz = null;
		}

		public void analisarEntradaPrimeiraLinha(String linha)
		{
			String[] splitStr = linha.Split(";");
			raiz.noDosNodos = int.Parse(splitStr[0]);
			raiz.noDasArestas = int.Parse(splitStr[1]);
		}


		public void addAOGrafo(String str)
		{
			String[] splitStr = str.Trim().Split(";");

			No a, b;
			int id1 = int.Parse(splitStr[0]);
			int id2 = int.Parse(splitStr[1]);
			if (raiz.nodosHashMap.ContainsKey(id1))
			{
				a = raiz.nodosHashMap.GetValueOrDefault(id1);
			}
			else
			{
				a = new No(id1);
			}
			if (raiz.nodosHashMap.ContainsKey(id2))
			{
				b = raiz.nodosHashMap.GetValueOrDefault(id2);
			}
			else
			{
				b = new No(id2);
			}

			if (noRaiz == null)
			{
				noRaiz = a;
			}
			raiz.AddNoEAresta(a, b, int.Parse(splitStr[2]));     // add NÃ³ e Aresta (mostra no console)
		}

		public Double Custo(Double custo)
		{
            foreach (Aresta aresta in raiz.mstArvArestasList)
            {
				custo += aresta.peso;

			}
			return custo;
		}

		public void ExecFunc()
		{

			// 1) Algoritmo de Kruskal para encontrar a MST

			int custo = 0;
			raiz.Kruskal();                     // mstTree contÃªm as arestas da arv MST
			Console.WriteLine("---------------------------------------------------------------------------------------------------------");
			Console.WriteLine("\nArestas na Arv. MST por Algoritmo de  Kruskal :");
            foreach (Aresta aresta in raiz.mstArvArestasList)
			{
				Console.WriteLine("(" + aresta.a.id + "," + aresta.b.id + ") = " + aresta.peso);
				custo = custo + aresta.peso;
			}
			Console.WriteLine("\n---------------------------------------------------------------------------------------------------------");
			Console.WriteLine("Custo :" + custo);
			Console.WriteLine("---------------------------------------------------------------------------------------------------------");

		}
	}
}
