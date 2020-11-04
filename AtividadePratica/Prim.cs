using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadePratica
{
    class Prim
    {
        private static int BRANCO = 0;
        private static int CINZA = 1; 

        static int[] pi;
        static int[] chave;

        static int[] cor;

       
        public static String trocar(int i)
        {
            String letras = "abcdefghi";
            if ((i >= 0) && (i <= letras.Length))
            {
                return letras[i] + "";
            }
            else
            {
                return "-";
            }
        }

        public int destrocar(char v)
        {
            String letras = "abcdefghi";
            int pos = -1;
            for (int i = 0; i < letras.Length; i++)
            {
                if (letras[i] == v)
                {
                    pos = i;
                }
            }
            return pos;
        }


        public int extrairMenor(int n)
        {
            int menorValor = int.MaxValue;
            int indiceMenor = -1;
            for (int i = 0; i < n; i++)
            {
                if (cor[i] == BRANCO && chave[i] < menorValor)
                {
                    indiceMenor = i;
                    menorValor = chave[i];
                }
            }
            return indiceMenor;
        }


        public  void mostrarCaminho(int[,] G, int qtd)
        {
            int n = qtd;
            int custo = 0;
            for (int v = 1; v < n; v++)
            {
                Console.WriteLine(trocar(pi[v]) + " -> " + trocar(v) + " custo: " + G[pi[v], v]);
                custo = custo + G[pi[v], v];
            }
            Console.WriteLine("Custo Total:" + custo);
        }


        public  void algoritmoPrim(int[,] G, int r, int qtd)
        {
            int n = qtd;
            chave = new int[n];
            pi = new int[n];
            cor = new int[n];
            for (int u = 0; u < n; u++)
            {
                chave[u] = int.MaxValue;
                pi[u] = -1;
                cor[u] = BRANCO;
            }
            chave[r] = 0;

            for (int i = 0; i < n; i++)
            {
                int u = extrairMenor(n);
               cor[u] = CINZA;
                for (int v = 0; v < n; v++)
                {
                        if (G[u, v] != 0)
                        {
                            if (cor[v] == BRANCO && G[u, v] < chave[v])
                            {
                                pi[v] = u;
                                chave[v] = G[u, v];
                            }
                        }
                }
            }
        }
    }
}
