using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AtividadePratica
{
	public class graf
	{
		public List<int>[] vertices = new List<int>[10];
		public int numeroVertices;

		public graf(int numVertices, List<int> GRAFOA)
		{
			for (int i = 0; i < numVertices; i++)
				vertices[i] = new List<int>(0);
			numeroVertices = numVertices;
			criarGrafo();
		}

		public void addArestas(int i, params int[] j)
		{
			foreach (int k in j)
			{
				vertices[i].Add(k);
			}
		}

		//Cria o Digrafo 'G'
		public void criarGrafo()
		{
			bool pulou = false;
			using (StreamReader sw = new StreamReader("grafonaodirigido" + ".txt"))
			{
				string ler = sw.ReadLine();

				while (ler != null)
				{
					if (pulou)
					{
						string[] splitando = ler.Split(';');
						Console.WriteLine(splitando[0] + " " + int.Parse(splitando[1]));
						addArestas(int.Parse(splitando[0]) - 1, int.Parse(splitando[1]) - 1);
					}
					pulou = true;
					ler = sw.ReadLine();
				}
			}
		}

	}
}
