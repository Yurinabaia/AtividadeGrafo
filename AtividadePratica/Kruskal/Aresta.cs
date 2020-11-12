using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadePratica.Kruskal
{
    class Aresta
    {
		public No a, b;
		public No originA, originB;
		public int peso;

		public Aresta(No a, No b, int peso)
		{
			this.a = a;
			this.b = b;
			this.originA = a;
			this.originB = b;
			this.peso = peso;
		}

		public No getOutroFim(No no)
		{
			if (a.Equals(no))
				return b;
			else if (b.Equals(no))
				return a;
			else if (originA.Equals(no))
				return originB;
			else
				return originA;
		}
	}
}
