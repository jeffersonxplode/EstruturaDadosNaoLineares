using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TADgrafo
{
    class Program
    {
        static void Main(string[] args)
        {


            ListaAdjacencia ListaAdj = new ListaAdjacencia();

            ListaAdj.AddVertice("V0");
            ListaAdj.AddVertice("V1");
            ListaAdj.AddVertice("V2");
            ListaAdj.AddVertice("V3");
            ListaAdj.AddVertice("V4");
            ListaAdj.AddVertice("V5");


            ListaAdj.AddArestaVertices("V0", "V1", 3);
            ListaAdj.AddArestaVertices("V0", "V2", 4);
            ListaAdj.AddArestaVertices("V1", "V2", 2);
            ListaAdj.AddArestaVertices("V1", "V3", 10);
            ListaAdj.AddArestaVertices("V2", "V4", 4);
            ListaAdj.AddArestaVertices("V4", "V5", 11);
            ListaAdj.AddArestaVertices("V3", "V5", 5);

            ListaAdj.Dijkstra("V2");


            foreach (Vertice x in ListaAdj.ListarVertices())
            {
                Console.WriteLine("{0} - {1}",x.nome,x.custo);
            }


            Console.ReadKey();




        }
    }
}
