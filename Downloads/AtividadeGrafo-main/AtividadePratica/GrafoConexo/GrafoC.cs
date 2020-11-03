using System;
using System.Collections.Generic;
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
				vertices[i].Add(k);
			}
		}

		//Cria o Digrafo 'G'
		public void criarGrafo()
		{
			addArestas(0, 1);
			addArestas(2, 3);
			addArestas(3, 0);
		}
	}
}
