using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace AtividadePratica
{
    public class Grafo
    {
		private Prim prim = new Prim();
		public List<string>[] vertices = new List<string>[20];
		public List<string>[] verticesNaoDirigido = new List<string>[20];


		public List<string> NOMESVERTICE = new List<string>();
		public List<string> NOMESVERTICENaoDirigido = new List<string>();
		public List<int>[] verticesV = new List<int>[20];

		public int numeroVertices { get; set; }
		public int NumeroVerticesNaoDirigido { get; set; }
		private int graNaoDirecionado = 0;
		private bool isolado = true;
		public int NumeroV = 0;
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
                        Console.WriteLine(splitando[0] + " " + splitando[2] + " " + splitando[1]);
						addArestasNaoDirigido(int.Parse(splitando[0]), int.Parse(splitando[2]), int.Parse(splitando[1]));
						NOMESVERTICENaoDirigido.Add(splitando[0] + "-" + splitando[1] + "-" + splitando[2]);
					}

					pulou = true;
					ler = sw.ReadLine();
				}
			}
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
			bool adjacencia = false;
			int a = 0;
			foreach (var item in verticesNaoDirigido)
			{
				if (a < NumeroVerticesNaoDirigido && v1 == a)
				{
					
					adjacencia = verticesNaoDirigido[a].Exists(x => x.Split(" ")[0] == v2.ToString());
				}
				a++;
			}
			a = 0;
			foreach (var item in verticesNaoDirigido)
			{
				if (a < NumeroVerticesNaoDirigido && v2 == a)
				{

					adjacencia = verticesNaoDirigido[a].Exists(x => x.Split(" ")[0] == v1.ToString());
				}
				a++;
			}
			return adjacencia;
        }      
		
        public int getGrau(int v1)
        {
			int a = 0;
			foreach (var item in verticesNaoDirigido)
			{
				if (a < NumeroVerticesNaoDirigido)
				{
					foreach (var s in verticesNaoDirigido[a])
					{
						string[] splitando = s.Split(" ");
						if (v1 == int.Parse(splitando[0]))
							graNaoDirecionado++;
					}
					a++;
				}
			}
			getGrauS(v1);
			return graNaoDirecionado;
        }

		public void getGrauS(int v1)
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

			int a = 0;
			foreach (var item in verticesNaoDirigido)
			{
				if (a < NumeroVerticesNaoDirigido)
				{
					foreach (var s in verticesNaoDirigido[a])
					{
						string[] splitando = s.Split(" ");
						if (v1 == int.Parse(splitando[0]))
							isolado = false;
					}
					a++;
				}
			}
			isoladoS(v1);
			return isolado;
        }

		public void isoladoS(int v1)
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
							isolado = false;
						}
					}
					a++;
				}
			}
		}


		
        public bool isPendente(int v1) 
        {
			bool pendente = false;
			if (getGrau(v1) == 1)
				pendente = true;


			return pendente;
        }        

		
        public bool isRegular()
        {
			int qtdGrau = getGrau(1);
			bool grafoRegular = true;

			for (int i = 1; i <= numeroVertices - 1; i++)
            {
				graNaoDirecionado = 0;
				if (getGrau(i) != qtdGrau)
				{
                    Console.WriteLine(i);
					grafoRegular = false;
				}
            }
			return grafoRegular;
        }     
		
        public bool isNulo()
        {
			bool grafoNulo = true;

			for (int i = 0; i <= numeroVertices - 1; i++)
			{
				if (getGrau(i) >  0)
				{
					grafoNulo = false;
				}
			}
			return grafoNulo;
        }   
		
        public bool isCompleto()
        {

			bool grafoCompleto = true;

			for (int i = 1; i <= numeroVertices - 1; i++)
			{
				if (getGrau(i) == 0)
				{
					grafoCompleto = false;
				}
			}
			return grafoCompleto;
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



		public int getCutVertices() 
		{
			List<string>[] grafoclonado = new List<string>[20];
			for (int i = 0; i < NumeroVerticesNaoDirigido; i++)
				grafoclonado[i] = new List<string>();

			for (int i = 0; i < NumeroVerticesNaoDirigido; i++)
				verticesV[i] = new List<int>();


			int a = 0;
			//verticesNaoDirigido[i].Add(j + " Peso ==> " + s);

			foreach (var item in verticesNaoDirigido)
			{
				if (a < NumeroVerticesNaoDirigido)
				{
					foreach (var s in verticesNaoDirigido[a])
					{
						string[] splitando = s.Split(" ");
						//Console.WriteLine(a + " " + splitando[0]);
						//Console.WriteLine(s);
						if (a != 5 && splitando[0] != "5") 
						{
							grafoclonado[a].Add(s);
						}
					}
					a++;
				}
			}
			a = 0;

			Console.WriteLine("Grafo não dirigido \n\n\n");
			foreach (var item in grafoclonado)
			{
				if (a < NumeroVerticesNaoDirigido)
				{
					foreach (var s in grafoclonado[a])
					{
						string[] splitando = s.Split(" ");
						Console.WriteLine(a + " ------- " + s);
						verticesV[a].Add(int.Parse(splitando[0].Trim()));
						Console.WriteLine(splitando[0] + " ---------- " + a + " " + splitando[1] + " " + splitando[2] + " " + splitando[3]);

					}
					a++;
				}
			}
			GrafoM solucao = new GrafoM(this);
			solucao.buscaProfundidadeV();
			if (solucao.componentes == 1)
				return 0;
			else
				return 1;
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
		public void AlgoritmoKurskal() 
		{
			
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
