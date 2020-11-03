using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadePratica.Kruskal
{
    class GrafoK
    {
		public List<No> nodosList;
		public List<Aresta> arestasList;
		public int noDosNodos;
		public int noDasArestas;
		public Dictionary<int, No> nodosHashMap;

		public List<Aresta> mstArvArestasList;

		public GrafoK()
		{
			nodosList = new List<No>();
			arestasList = new List<Aresta>();
			nodosHashMap = new Dictionary<int, No>();
			noDosNodos = 0;
			noDasArestas = 0;
			mstArvArestasList = new List<Aresta>();

		}


		/**
		 * Add os nodos e arestas no grafo
		 * @param no1
		 * @param no2
		 * @param peso
		 */
		public void AddNoEAresta(No no1, No no2, int peso)
		{
			if (nodosHashMap.ContainsKey(no1.id))
			{
				no1 = nodosHashMap.GetValueOrDefault(no1.id);
			}
			else
			{
				nodosList.Add(no1);
				nodosHashMap.Add(no1.id, no1);
			}

			if (nodosHashMap.ContainsKey(no2.id))
			{
				no2 = nodosHashMap.GetValueOrDefault(no2.id);
			}
			else
			{
				nodosList.Add(no2);
				nodosHashMap.Add(no2.id, no2);
			}

			Aresta aresta = new Aresta(no1, no2, peso);
			arestasList.Add(aresta);    // Add a aresta na lista
			no1.addNoAdj(aresta);       // Add a lista da matriz de adjacencia no no1
			no2.addNoAdj(aresta);       // adicionar a matriz de lista de adjacÃªncia para no2
		}

		public void Kruskal()
		{

			No ru, rv;

            foreach (var no in nodosList)
            {
				MakeSet(no);
			}
           
            {

            }
			foreach (Aresta aresta in arestasList)
			{                   // arestas jÃ¡ estarÃ£o em ordem decrescente
				ru = Buscar(aresta.originA);
				rv = Buscar(aresta.originB);
				if (!ru.Equals(rv))
				{
					mstArvArestasList.Add(aresta);
					aresta.originA.mstAresta.Add(aresta);
					aresta.originB.mstAresta.Add(aresta);
					Union(ru, rv);
				}
			}
		}
		private void Union(No ru, No rv)
		{
			if (ru.rank > rv.rank)
				rv.mstPai = ru;
			else if (rv.rank > ru.rank)
				ru.mstPai = rv;
			else
			{
				rv.mstPai = ru;
				++ru.rank;
			}
		}
		private No Buscar(No no)
		{
			if (no.mstPai.Equals(no))
				return no;
			return Buscar(no.mstPai);
		}
		private void MakeSet(No no)
		{
			no.mstPai = no;
		}
	}
}
