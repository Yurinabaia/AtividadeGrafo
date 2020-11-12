﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AtividadePratica
{
	class GrafoM
	{

		public static byte branco = 0;
		public static byte cinza = 1;
		public static byte preto = 2;
		private int[] d, t, antecessor;
		private String saida;
		private Grafoc grafo;
		private Grafo grafoV;
		public int componentes = 1;
		private int contador =0;


		public GrafoM(Grafoc g)
		{
			this.grafo = g;
			int n = grafo.numeroVertices;
			d = new int[n];
			t = new int[n];
			antecessor = new int[n];
			saida = "";
		}
		public GrafoM(Grafo g)
		{
			this.grafoV = g;
			int n = grafoV.NumeroVerticesNaoDirigido;
			d = new int[n];
			t = new int[n];
			antecessor = new int[n];
			saida = "";
		}

		private int visitaDfs(int u, int tempo,  int[] cor)
		{
			contador++;
			saida += u + ", ";  //Armazena a ordem de visita dos vertices em uma string
			cor[u] = cinza;
			this.d[u] = ++tempo;


				List<int> listaAdj = grafo.vertices[u];
				foreach (int v in listaAdj)
				{
				 listaAdj = grafo.vertices[u];
				if (cor[v] == branco)
					{
						this.antecessor[v] = u;
						tempo = this.visitaDfs(v, tempo,  cor);
					}
				}
			cor[u] = preto;
			this.t[u] = ++tempo;
			return tempo;
		}

		private int visitaDfsV(int u, int tempo, int[] cor)
		{
			contador++;
			saida += u + ", ";  //Armazena a ordem de visita dos vertices em uma string
			cor[u] = cinza;
			this.d[u] = ++tempo;
			List<int> listaAdjq = grafoV.verticesV[u];
			foreach (int v in listaAdjq)
			{
				listaAdjq = grafoV.verticesV[u];
				if (cor[v] == branco)
				{
					this.antecessor[v] = u;
					tempo = this.visitaDfsV(v, tempo, cor);
				}
			}
			cor[u] = preto;
			this.t[u] = ++tempo;
			return tempo;
		}

		public void buscaProfundidade()
		{

			int tempo = 0;
			componentes = 1;
			int[] cor = new int[this.grafo.numeroVertices];
			for (int u = 0; u < this.grafo.numeroVertices; u++)
			{
				cor[u] = branco;
				this.antecessor[u] = -1;
			}
			for (int u = 0; u < grafo.numeroVertices; u++)
			{
				if (cor[u] == branco)
				{
					tempo = this.visitaDfs(u, tempo,  cor);
				}
				if (contador != grafo.numeroVertices)
				{
					componentes++;
					break;
				}

			}
		}

		public void buscaProfundidadeV()
		{

			int tempo = 0;
			componentes = 1;
			int[] cor = new int[this.grafoV.NumeroV];
			for (int u = 0; u < this.grafoV.NumeroV; u++)
			{
				cor[u] = branco;
				this.antecessor[u] = -1;
			}
			for (int u = 0; u < grafoV.NumeroV; u++)
			{
				if (cor[u] == branco)
				{
					tempo = this.visitaDfsV(u, tempo, cor);
				}
				if (contador != grafoV.maior)
				{
					//Console.WriteLine("entrou");
					componentes++;
					//Console.WriteLine("vvv" + componentes);
				}
				break;
			}
			//Console.Write("\n Ordem de visita: ");
			//Console.WriteLine(saida.Substring(0, saida.LastIndexOf(",")));
			//Console.Write("\n");
		}

	}
}
