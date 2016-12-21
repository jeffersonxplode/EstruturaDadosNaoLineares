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

            ListaAdj.AddVertice("V1");
            ListaAdj.AddVertice("V2");
            ListaAdj.AddVertice("V3");
            ListaAdj.AddVertice("V4");

            foreach(Vertice x in ListaAdj.ListarVertices())
            {
                Console.WriteLine(x.nome);
            }


            ListaAdj.AddArestaVertices("V1", "V2", 10);
            ListaAdj.AddArestaVertices("V1", "V3", 20);
            ListaAdj.AddArestaVertices("V2", "V4", 5);
            ListaAdj.AddArestaVertices("V4", "V3", 30);

            foreach(Aresta x in ListaAdj.ListArestasVertice("V1"))
            {
                Console.WriteLine(x.vertice.nome);
                Console.WriteLine(x.valor);
               
            }

            foreach (Aresta x in ListaAdj.ListArestasVertice("V2"))
            {
                Console.WriteLine(x.vertice.nome);
                Console.WriteLine(x.valor);

            }


            ListaAdj.DeleteVertice("V2");

            foreach (Aresta x in ListaAdj.ListArestasVertice("V1"))
            {
                Console.WriteLine(x.vertice.nome);
                Console.WriteLine(x.valor);

            }

            foreach (Vertice x in ListaAdj.ListarVertices())
            {
                Console.WriteLine(x.nome);
            }


            Console.ReadKey();




        }
    }
}
