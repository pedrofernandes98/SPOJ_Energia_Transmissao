using System;

namespace ConsoleApp2
{
    class Program
    {
        //Declaração das estruturas utilizadas para modelar o grafo e a Busca em Profundidade
        private const int NMAX = 101;
        static int[,] g = new int[NMAX,NMAX];
        static int[] achou = new int[NMAX];
        static int e, achados;

        //Algoritmo de Busca em Profundidade
        static void acha(int x)
        {
            int i;
            achou[x] = 1;
            achados++;
            for (i = 1; i <= e; i++)
            {
                
                int v1 = g[x, i];
                int v2 = achou[i];
                if (v1 == 1 && v2 == 0)
                {
                    acha(i);
                }
            }
        }

        static void Main(string[] args)
        {
            //Declaração de Variáveis
            int l, i, j, x, y, teste = 1;
            
            e = 1;
            l = 1;

            //Loop que testa o Final da Entrada
            while (e != 0 && l != 0)
            {
                //Entrada de dados - 1ª Linha
                string entrada = Console.ReadLine();
                e = int.Parse(entrada.Split(' ')[0]);
                l = int.Parse(entrada.Split(' ')[1]);
                achados = 0;
                if (e != 0 && l != 0)
                {
                    //Cria a lista de Adjascência do Grafo
                    for (i = 1; i <= e; i++)
                    {
                        achou[i] = 0;
                        for (j = 1; j <= e; j++)
                        {
                            g[i, j] = 0;
                        }
                    }
                    //Entrada de dados - Arestas - Linhas de transmissão que interligam duas estações
                    for (i = 1; i <= l; i++)
                    {
                        
                        string entradaAresta = Console.ReadLine();
                        x = int.Parse(entradaAresta.Split(' ')[0]);
                        y = int.Parse(entradaAresta.Split(' ')[1]);
                        g[x, y] = 1;
                        g[y, x] = 1;
                    }
                    //Chama a função que executa a Busca em Profundidade
                    acha(1);

                    //Execução do teste para definar o status do sistema
                    Console.Write("Teste {0}\n", teste++);
                    if (achados == e)
                    {
                        Console.Write("normal");
                    }
                    else
                    {
                        Console.Write("falha");
                    }
                    Console.Write("\n\n");
                }
                
            }

        }
    }
}