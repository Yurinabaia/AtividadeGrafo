using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AtividadePratica
{
    public class Grafo
    {
		public List<string>[] vertices = new List<string>[10];

		public List<string> NOMESVERTICE = new List<string>();
		public List<int> PESO = new List<int>();
		public int numeroVertices { get; set; }
		public Grafo(int numVertices, string nomeArquivo)
		{
			for (int i = 0; i < numVertices; i++)
				vertices[i] = new List<string>();

			numeroVertices = numVertices;
			criarGrafo(nomeArquivo);
		}

		public void addArestas(int i, int s, params int[] j)
		{
			foreach (var item in j)
			{
				vertices[i].Add(item + " Peso ==> " + s);
			}
		}
		public void IMPRIMIR()
		{
			int a = 0;
			foreach (var item in vertices)
			{
				if (a < numeroVertices)
				{
					Console.WriteLine("VERTICE Origem " + " = " + a);
					foreach (var s in vertices[a])
					{
						//NOMESVERTICE.Add(a + "-" + s + "-" + PESO[cont]);
						Console.WriteLine("Vertice destino ---> " + s );
					}
					Console.WriteLine("\n\n\n\n");
					a++;
				}
			}
			int v = 0;
			foreach (var item in NOMESVERTICE)
			{
				Console.WriteLine(item);

			}
			Console.WriteLine();
			foreach (var item in NOMESVERTICE)
			{
				Console.WriteLine("Quantidade de graus de entrada do vertice " + v + " = " + getGrauEntrada(v));
				v++;
			}

			Console.WriteLine("\n\n\n\n###########################################################\n\n\n");
			v = 0;
			foreach (var item in NOMESVERTICE)
			{
				Console.WriteLine("Quantidade de graus de saida do vertice " + v + " = " + getGrauSaida(v));
				v++;
			}

		}


		//Cria o Digrafo 'G'
		public void criarGrafo(string nomeArquivo)
		{
			bool pulou = false;
			using (StreamReader sw = new StreamReader(nomeArquivo + ".txt"))
			{
				string ler = sw.ReadLine();
				while (ler != null)
				{
					string[] splitando = ler.Split(';');
					if (pulou)
					{
						if (int.Parse(splitando[3]) == 1)
						{
							addArestas(int.Parse(splitando[0]), int.Parse(splitando[2]), int.Parse(splitando[1]));
							NOMESVERTICE.Add(splitando[0] + "-" + splitando[1] + "-" + splitando[2]);
						}
						else 
						{
							addArestas(int.Parse(splitando[1]), int.Parse(splitando[2]),  int.Parse(splitando[0]));
							NOMESVERTICE.Add(splitando[1] + "-" + splitando[0] + "-" + splitando[2]);
						}


					}
					pulou = true;
					ler = sw.ReadLine();
				}
			}
			IMPRIMIR();
		}

		public static string LETRA(int pos)
		{
			if (pos > -1)
			{
				string palavra = "-ABCDEFGHIJKLMNOPQRSTUVXWYZ";
				return palavra.ToCharArray()[pos].ToString();
			}
			else
				return "-1";
		}
		/*
		public bool isAdjacente(Vertice v1, Vertice v2) 
        {
            return false;
        }        
        public int getGrau(Vertice v1)
        {
            return 0;
        }        
        public bool isIsolado(Vertice v1) 
        {
            return false;
        }       
        public bool isPendente(Vertice v1) 
        {
            return false;
        }        
        public bool isRegular()
        {
            return false;
        }       
        public bool isNulo()
        {
            return false;
        }        
        public bool isCompleto()
        {
            return false;
        }       
        public bool isConexo()
        {
            return false;
        }        
        public bool isEuleriano()
        {
            return false;
        }
        public bool isUnicursal()
        {
            return false;
        }
*/



		//Metodos para digrafos.
		public int getGrauEntrada(int vertice) 
		{
			int a = 0, graucont = 0;
			foreach (var item in vertices)
			{
				if (a < numeroVertices)
				{
						foreach (var s in vertices[a])
						{
						string[] splitando = s.Split(" ");
							if(vertice == int.Parse(splitando[0]))
							graucont++;
						}
					a++;
				}
			}
			return graucont;
		}
		public int getGrauSaida(int vertice) 
		{
			int a = 0, graucont = 0;
			foreach (var item in vertices)
			{
				if (a < numeroVertices)
				{
					if (a == vertice)
					{
						foreach (var s in vertices[a])
						{
							graucont++;
						}
					}
					a++;
				}
			}
			return graucont;
		}


		public bool hasCiclo(Grafo grafo) 
		{
			BuscaEmProfundidade solucao = new BuscaEmProfundidade(grafo);
			solucao.buscaProfundidade();
			return solucao.hasCicle;
		}



	}
}
