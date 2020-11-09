using AtividadePratica.Kruskal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AtividadePratica
{
    public class Grafo
    {
		private Prim prim = new Prim();
		public List<string>[] vertices = new List<string>[20];
		public List<string>[] verticesNaoDirigido = new List<string>[20];


		public List<string> NOMESVERTICE = new List<string>();
		public List<string> NOMESVERTICENaoDirigido = new List<string>();
		public List<int> TodosVertice = new List<int>();
		public List<int>[] verticesV = new List<int>[20];

		public int numeroVertices { get; set; }
		public int NumeroVerticesNaoDirigido { get; set; }
		public int NumeroV = 0, maior = 0;
		public Grafo(int numVertices, string nomeArquivo, int numeroVerticesNaoDirigido, string NomeArquivoNaoDirigido)
		{
			Console.WriteLine(NumeroVerticesNaoDirigido);
			for (int i = 0; i < numVertices; i++)
				vertices[i] = new List<string>();

			for (int i = 0; i < numeroVerticesNaoDirigido; i++)
				verticesNaoDirigido[i] = new List<string>();



			NumeroVerticesNaoDirigido = numeroVerticesNaoDirigido;
			criarGrafoNaoDirigido(NomeArquivoNaoDirigido);


			numeroVertices = numVertices;
			criarGrafo(nomeArquivo);
		}

		public void addArestas(int i, int s, int j)
		{
		     vertices[i].Add(j + " ---> " + s);
		}

		public void addArestasNaoDirigido(int i, int s, int j)
		{
			if(verticesNaoDirigido[i] != null)
			verticesNaoDirigido[i].Add(j + " Peso ==> " + s);
		}
		public void IMPRIMIR()
		{
			Console.WriteLine("Grafo Dirigido \n\n\n");
			int a = 0;
			foreach (var item in vertices)
			{
				if (a < numeroVertices)
				{
					Console.WriteLine("VERTICE Origem " + " = " + a);
					foreach (var s in vertices[a])
					{
						Console.WriteLine("Vertice destino ---> " + s );
					}
					Console.WriteLine("\n\n\n\n");
					a++;
				}
			}
			foreach (var item in NOMESVERTICE)
			{
				Console.WriteLine(item);

			}
			Console.WriteLine();
			
        }

		public void IMPRIMIRNaoDirigido()
		{
			int a = 0;
            Console.WriteLine("Grafo não dirigido \n\n\n");
			foreach (var item in verticesNaoDirigido)
			{
				if (a < NumeroVerticesNaoDirigido)
				{
					foreach (var s in verticesNaoDirigido[a])
					{
						string[] splitando = s.Split(" ");
						Console.WriteLine(a +" ------- " + s);
					
                        Console.WriteLine(splitando[0] + " ---------- " + a + " " + splitando[1] + " " + splitando[2] + " " + splitando[3]);

					}
					a++;
				}
			}
			foreach (var item in NOMESVERTICENaoDirigido)
			{
				Console.WriteLine(item);

			}
			Console.WriteLine();

		}


		public void criarGrafoNaoDirigido(string nomeArquivo)
		{
			bool pulou = false;
			using (StreamReader sw = new StreamReader(nomeArquivo + ".txt"))
			{
				string ler = sw.ReadLine();
				while (ler != null)
				{
					string[] splitando = ler.Split(';');
					if(!pulou)
					NumeroV = int.Parse(splitando[0]);
					if (pulou)
					{
						if (ler.Split(';')[1] == "")
						{
							addArestasNaoDirigido(int.Parse(splitando[0]), -1, int.Parse(splitando[0]));
							TodosVertice.Add(int.Parse(splitando[0]));
						}
						else
						{
							Console.WriteLine(splitando[0] + " " + splitando[2] + " " + splitando[1]);
							if(int.Parse(splitando[0]) < int.Parse(splitando[0]))
								addArestasNaoDirigido(int.Parse(splitando[0]), int.Parse(splitando[2]), int.Parse(splitando[1]));
							else
								addArestasNaoDirigido(int.Parse(splitando[1]), int.Parse(splitando[2]), int.Parse(splitando[0]));

							NOMESVERTICENaoDirigido.Add(splitando[0] + "-" + splitando[1] + "-" + splitando[2]);
							TodosVertice.Add(int.Parse(splitando[0]));
							TodosVertice.Add(int.Parse(splitando[1]));
						}
					}
					pulou = true;
					ler = sw.ReadLine();
				}
			}

			TodosVertice = TodosVertice.Distinct().ToList();
			TodosVertice.Sort();
			IMPRIMIRNaoDirigido();
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
		
		public bool isAdjacente(int v1, int v2) 
        {
			int v3 = v1;
			if (v1 > v2)
			{
				return false;
			}

			if (TodosVertice.Exists(x => x == v1) && TodosVertice.Exists(x => x == v2))
			{
				bool adjacencia = false;

				adjacencia = verticesNaoDirigido[v1].Exists(x => x.Split(" ")[0] == v2.ToString());
				if (!adjacencia && v2 < NumeroV)
					adjacencia = verticesNaoDirigido[v2].Exists(x => x.Split(" ")[0] == v1.ToString());
				return adjacencia;
			}
			return false;
		}      
		
        public int getGrau(int v1)
        {
			int cont = 0;
			foreach (var item in NOMESVERTICENaoDirigido)
			{
				foreach (var s in NOMESVERTICENaoDirigido)
				{
					if(item.Split("-")[0] !=  )
				}
			}
			return cont++;
        }

		public void getGrauS(int v1, ref int graNaoDirecionado)
		{
			int a = 0;
			foreach (var item in verticesNaoDirigido)
			{
				if (a < NumeroVerticesNaoDirigido)
				{
					if (a == v1)
					{
						foreach (var s in verticesNaoDirigido[a])
						{
							graNaoDirecionado++;
						}
					}
					a++;
				}
			}
		}


		
        public bool isIsolado(int v1) 
        {
			return getGrau(v1) == 0;
		}

	


		
        public bool isPendente(int v1) 
        {
			return getGrau(v1) == 1;
        }        

		
        public bool isRegular()
        {
			int qtdGrau = getGrau(TodosVertice[0]);//1 vertice

			foreach (var item in TodosVertice)
			{
				if (qtdGrau != getGrau(item))
					return false;
			}
			return true;
        }     
		
        public bool isNulo()
        {
			int qtdGrau = 0;

			foreach (var item in TodosVertice)
			{
				if (qtdGrau != getGrau(item))
					return false;
			}
			return true;
        }
		public bool Loop() 
		{
			foreach (var item in NOMESVERTICENaoDirigido)
			{
				if (item.Split("-")[0] == item.Split("-")[1])
					return true;
			}
			return false;
		}

		public bool isParalelo() 
		{
			List<string> VALORESINVERTIDOS = new List<string>();
			foreach (var item in NOMESVERTICENaoDirigido)
			{
				int valor1 = int.Parse(item.Split("-")[0]);
				int valor2 = int.Parse(item.Split("-")[1]);
				if (valor2 < valor1)
					VALORESINVERTIDOS.Add(valor2 + "-" + valor1);
				else
					VALORESINVERTIDOS.Add(valor1 + "-" + valor2);
					
			}
			VALORESINVERTIDOS = VALORESINVERTIDOS.Distinct().ToList();
		return VALORESINVERTIDOS.Count != NOMESVERTICENaoDirigido.Count;

		}
		
        public bool isCompleto()
        {

			foreach (var item in NOMESVERTICENaoDirigido)
			{
				Console.WriteLine(item);
			}
			return true;
        }
        public bool isConexo()
        {
			
			Grafoc G = new Grafoc(NumeroV);
			GrafoM solucao = new GrafoM(G);
			solucao.buscaProfundidade();
			if (solucao.componentes == 1)
				return true;
			else
				return false;
			
		}
		

		
        public bool isEuleriano()
        {
			for (int i = 0; i <= NumeroV; i++)
			{
				if (getGrau(i)%2 == 1)
				{
					return false;
				}
			}
			return true;
        }
	
        public bool isUnicursal()
        {
			int contV = 0;
			for (int i = 0; i <= NumeroV; i++)
			{
				if (getGrau(i) % 2 == 1)
				{
					contV++;
				}
			}
			if (contV == 2)
				return true;
			else
			return false;
        }
		public void DeletarV(List<string>[] G, int valorvertice) 
		{
			int a = 0;
			foreach (var item in verticesNaoDirigido)
			{
				if (a < NumeroVerticesNaoDirigido)
				{
					foreach (var s in verticesNaoDirigido[a])
					{
						string[] splitando = s.Split(" ");
						//Console.WriteLine(a + " " + splitando[0]);
						//Console.WriteLine(s);
						if (a != valorvertice && splitando[0] != valorvertice.ToString())
						{
							Console.WriteLine(a + " " + splitando[0]);
							G[a].Add(s);
						}
					}
					a++;
				}
			}
		}


		public int getCutVertices() 
		{
			int contageCutV = 0;
				

			List<string>[] grafoclonado = new List<string>[20];

			for (int j = 2; j < NumeroV; j++)
			{
				if(j == 6)
				{

				}

				for (int i = 0; i < NumeroVerticesNaoDirigido; i++)
					grafoclonado[i] = new List<string>();

				for (int i = 0; i < NumeroVerticesNaoDirigido; i++)
					verticesV[i] = new List<int>();

				DeletarV(grafoclonado, j);

				int a = 0;

				Console.WriteLine("Grafo não dirigido \n\n\n");
				foreach (var item in grafoclonado)
				{
					if (a < NumeroVerticesNaoDirigido)
					{
						foreach (var s in grafoclonado[a])
						{
							string[] splitando = s.Split(" ");
							Console.WriteLine(a + " ------- " + s);
							verticesV[a - 1].Add(int.Parse(splitando[0].Trim()) - 1);
							Console.WriteLine(splitando[0] + " ---------- " + a + " " + splitando[1] + " " + splitando[2] + " " + splitando[3]);
							if (maior < a)
								maior = a;
							if (maior < int.Parse(splitando[0].Trim()))
								maior = int.Parse(splitando[0].Trim());
						}
						a++;
					}
				}
				GrafoM solucao = new GrafoM(this);
				solucao.buscaProfundidadeV();
				if (solucao.componentes != 1)
					contageCutV++;
			}
			return contageCutV;
		}

		public void AlgoritmoPrim(int vertice) 
		{
			//Raiz da Ã¡rvore
			int r = prim.destrocar(LETRA(vertice).ToLower()[0]);
			int a = 0;
			int[,] matriz = new int[NumeroV, NumeroV];

			List<string> guardaPosicao = new List<string>();
			foreach (var item in verticesNaoDirigido)
			{
				if (a < NumeroVerticesNaoDirigido)
				{
					foreach (var s in verticesNaoDirigido[a])
					{
						string[] splitando = s.Split(" ");
						guardaPosicao.Add(a.ToString() + " " + splitando[0] + " "+ splitando[3]);
						guardaPosicao.Add(splitando[0] + " " + a.ToString() + " "+splitando[3]);
					}
					a++;
				}
			}
            foreach (string item in guardaPosicao)
            {
				string[] splita = item.Split(" ");
				matriz[int.Parse(splita[0]) -1, int.Parse(splita[1]) -1] = int.Parse(splita[2]);
            }
			for (int Linha = 0; Linha < matriz.GetLength(0); Linha++)
			{
				for (int Coluna = 0; Coluna < matriz.GetLength(1); Coluna++)
				{
                    Console.Write(matriz[Linha, Coluna] + " ");
				}
				Console.WriteLine("");
			}

			prim.algoritmoPrim(matriz, r, NumeroV);

			//Mostra o menor caminho
			prim.mostrarCaminho(matriz, NumeroV);
		}
		public void AlgoritmoKurskal(int vertice) 
		{
			int contador = 1;
			bool entrou = false;
			Func of = new Func();
			using (StreamReader sw = new StreamReader("grafonaodirigido" + ".txt"))
			{
				sw.ReadLine();
				string ler = sw.ReadLine();
				while (ler != null)
				{
					if (contador == vertice)
					{
						of.addAOGrafo(ler);
						entrou = true;
					}
					if(entrou)
						of.addAOGrafo(ler);
					contador++;

					ler = sw.ReadLine();
				}
			}
			of.ExecFunc();
		}





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


		public bool hasCiclo() 
		{
			BuscaEmProfundidade solucao = new BuscaEmProfundidade(this);
			solucao.buscaProfundidade();
			return solucao.hasCicle;
		}



	}
}
