using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TADgrafo
{
    class ListaAdjacencia
    {

        private List<Vertice> Listaadjacencia = new List<Vertice>();


        public void AddVertice(string nome)
        {

            Vertice vertice = new Vertice(nome);
            Listaadjacencia.Add(vertice);

        }

        internal void AddVertice(object vertice)
        {
            throw new NotImplementedException();
        }

        public void AddArestaVertices(string Nvertice, string Nvertice2, int valor)
        {

            Vertice vertice = Listaadjacencia.Find(x => x.nome == Nvertice);
            Vertice vertice2 = Listaadjacencia.Find(x => x.nome == Nvertice2);

            vertice.AddAresta(valor, vertice2);


        }

        public void DeleteAresta(string Nvertice, string Nvertice2)
        {

            Vertice vertice = Listaadjacencia.Find(x => x.nome == Nvertice);
            Aresta aresta = vertice.GetArestas().Find(x => x.vertice.nome == Nvertice2);
            vertice.GetArestas().Remove(aresta);

        }

        
        public void DeleteVertice(string Nvertice)
        {

            Vertice vertice = Listaadjacencia.Find(x => x.nome == Nvertice);

            foreach (Vertice x in Listaadjacencia)
            {
                Aresta aresta = x.GetArestas().Find(y => y.vertice.nome == Nvertice);

                if (aresta != null)
                {
                    x.GetArestas().Remove(aresta);
                }

                else
                {
                    continue;
                }
            }


            Listaadjacencia.Remove(vertice);

        }


        public void ListVertices(string Nvertice)
        {

            Vertice vertice = Listaadjacencia.Find(x => x.nome == Nvertice);

            Console.WriteLine("Arestas de {0}",vertice.nome);

            foreach (Aresta x in vertice.GetArestas())
            {

                Console.WriteLine("Aresta com o vertice {0} de valor {1}", x.vertice.nome,x.valor); 
                
            }

            

        }

        public bool Adjacente(string nvertice, string nvertice2)
        {

            Vertice vertice = Listaadjacencia.Find(x => x.nome == nvertice);
            Aresta aresta = vertice.GetArestas().Find(x => x.vertice.nome == nvertice2);

            if (aresta != null)
            {
                return true;
            }

            else

                return false;
        }


        public void ListarVertices()
        {
            Console.WriteLine("Lista de Vertices:");
            foreach(Vertice x in Listaadjacencia)
            {
                Console.WriteLine(x.nome);
            }

        }




    }
}
