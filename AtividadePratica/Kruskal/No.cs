using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadePratica.Kruskal
{
    class No
    {
		public int id;
		public List<Aresta> listaArestasAdj;

		public No mstPai;
		public int rank;
		public List<Aresta> mstAresta;
		public double L;


		public No(int id)
		{
			this.id = id;
			listaArestasAdj = new List<Aresta>();
			mstPai = null;
			rank = 0;
			mstAresta = new List<Aresta>();
			L = 0;
		}


		public void addNoAdj(Aresta adj)
		{
			this.listaArestasAdj.Add(adj);
		}
	}
}
