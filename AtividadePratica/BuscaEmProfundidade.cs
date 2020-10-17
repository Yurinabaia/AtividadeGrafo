using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadePratica
{
    public class BuscaEmProfundidade
    {
		public static byte branco = 0;
		public static byte cinza = 1;
		public static byte preto = 2;
		private int[] d, t, antecessor;
		private String saida;
		private Grafo grafo;
		private List<string> asd = new List<string>();
		List<int>[] VERTICE = new List<int>[10];
		public bool hasCicle =false;

		public BuscaEmProfundidade(Grafo g)
		{
			this.grafo = g;
			int n = grafo.numeroVertices;
			d = new int[n];
			t = new int[n];
			antecessor = new int[n];
			saida = "";
			for (int i = 0; i < grafo.numeroVertices; i++)
				VERTICE[i] = new List<int>();
		}


	 ///Metodo auxiliar da busca em profundidade.
	 // u
	// tempo

		private int visitaDfs(int u, int tempo, int[] cor)
		{
			//Console.WriteLine("Tempo " + tempo);

				saida += u + ", ";  //Armazena a ordem de visita dos vertices em uma string
			cor[u] = cinza;
			string cl = "";
			this.d[u] = ++tempo;


			foreach (var item in grafo.vertices[u])
			{
				string[] splitando = item.Split(" ");
				VERTICE[u].Add(int.Parse(splitando[0]));
			}

			if (VERTICE[u].Count != 0)
			{
				//Console.WriteLine(" Visitando o vertice: " + grafo.NOMESVERTICE[u] + " == " + (u));


				List<int> listaAdj = VERTICE[u];
				//Console.WriteLine("\nTempo do vertice " + u + " = " + tempo);

				foreach (int v in listaAdj)
				{

					if (CORES(cor[u]) == "Cinza" && CORES(cor[v]) == "Preto")
					{
						if (asd.Exists(a => a == LETRA(u)))
						{
							cl = classificacaoAresta(CORES(cor[v]), CORES(cor[u]));
							//Console.WriteLine("Coluna " + u + " --> " + v + " COR " + CORES(cor[v]) + " TEMPO " + (tempo + 1) + " CLASSIFICAÇÃO " + cl);
						}
						else
						{
							asd.Add(LETRA(u));
							cl = classificacaoAresta(CORES(cor[u]), CORES(cor[v]));
							//Console.WriteLine("Coluna " + u + " --> " + v + " COR " + CORES(cor[v]) + " TEMPO " + (tempo + 1) + " CLASSIFICAÇÃO " + cl);
						}
						
					}
					else
					{

						cl = classificacaoAresta(CORES(cor[u]), CORES(cor[v]));
						//Console.WriteLine("Coluna " + u + " --> " + v + " COR " + CORES(cor[v]) + " TEMPO " + (tempo + 1) + " CLASSIFICAÇÃO " + cl);
					}

					if (!asd.Exists(a => a == LETRA(u)))
					{
						asd.Add(LETRA(u));
					}
					if (cor[v] == branco)
					{
						this.antecessor[v] = u;
						tempo = this.visitaDfs(v, tempo, cor);

					}
					
				}
				//Console.WriteLine("\nTEMPO do vertice " +u + " = " + (tempo + 1));

			}



			cor[u] = preto;
			this.t[u] = ++tempo;
			return tempo;
		}

		//Metodo da busca de profundidade.
		public void buscaProfundidade()
		{
			int tempo = 0;
			int[] cor = new int[this.grafo.numeroVertices];
			for (int u = 0; u < this.grafo.numeroVertices; u++)
			{
				cor[u] = branco;
				this.antecessor[u] = -1;
			}
			for (int u = 0; u < grafo.numeroVertices; u++)
			{
				if (cor[u] == branco)
					tempo = this.visitaDfs(u, tempo, cor);
			}
			//Console.WriteLine("\n Ordem de visita: ");
			string a = saida.Substring(0, saida.LastIndexOf(""));
			string[] splitando = saida.Split(',');
			//for (int i = 0; i < splitando.Length - 1; i++)
			//{
				//Console.Write(LETRA(int.Parse(splitando[i])));
				//if(i != splitando.Length - 2)
				//Console.Write(", ");

			//}
			//Console.WriteLine();

			//Console.WriteLine(saida.Substring(0, saida.LastIndexOf(",")));
			//Console.WriteLine("\n");
		}

		public static string LETRA(int pos)
		{
			if (pos > -1)
			{
				string palavra = "ABCDEFGHIJKLMNOPQRSTUVXWYZ";
				return palavra.ToCharArray()[pos].ToString();
			}
			else
				return "-1";
		}
		public static string CORES(int s) 
		{
			string cor = "";
			if (s == 0)
			{
				cor = "Branco";
			}
			else if (s == 1)
			{
				cor = "Cinza";
			}
			else
				cor = "Preto";

			return cor;
		}
		public string classificacaoAresta(string a, string b) 
		{
			string saidas = "";
			if (a == "Cinza" && b == "Branco")
				saidas = "Arvore";
			else if (a == "Cinza" && b == "Cinza") 
			{
				saidas = "Retorno";
				hasCicle = true;
			}
			else if (a == "Cinza" && b == "Preto")
				saidas = "Cruzamento";
			else if(a == "Preto" && b == "Cinza")
				saidas = "Avanço";
			return saidas;
		}
	}
}
