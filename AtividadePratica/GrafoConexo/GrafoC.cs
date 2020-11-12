using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AtividadePratica
{
	public class Grafoc
	{
		public List<int>[] vertices = new List<int>[10];
		public int numeroVertices;

		public Grafoc(int numVertices)
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
				if(vertices[i] != null)
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
						addArestas(int.Parse(splitando[0]) -1, int.Parse(splitando[1]) - 1);
					}
					pulou = true;
					ler = sw.ReadLine();
				}
			}
		}

	}
}
