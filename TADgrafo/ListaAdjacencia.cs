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
            vertice2.AddAresta(valor, vertice);


        }

        public void DeleteAresta(string Nvertice, string Nvertice2)
        {

            Vertice vertice = Listaadjacencia.Find(x => x.nome == Nvertice);
            Aresta aresta = vertice.GetArestas().Find(x => x.vertice.nome == Nvertice2);
            vertice.GetArestas().Remove(aresta);

            Vertice vertice2 = Listaadjacencia.Find(x => x.nome == Nvertice2);
            Aresta aresta2 = vertice.GetArestas().Find(x => x.vertice.nome == Nvertice);
            vertice2.GetArestas().Remove(aresta2);

        }

        
        public void DeleteVertice(string Nvertice)
        {

            Vertice vertice = Listaadjacencia.Find(x => x.nome == Nvertice);

            List<Aresta> Arestas = vertice.GetArestas();

            foreach(Aresta x in Arestas)
            {
                Aresta temp = x.vertice.GetArestas().Find(y => y.vertice.nome == Nvertice);
                x.vertice.GetArestas().Remove(temp);

            }
            

            Listaadjacencia.Remove(vertice);

        }


        public List<Aresta> ListArestasVertice(string Nvertice)
        {

            Vertice vertice = Listaadjacencia.Find(x => x.nome == Nvertice);

            return vertice.GetArestas();
            

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


        public List<Vertice> ListarVertices()
        {
            return Listaadjacencia;

        }

        public bool Euleriano()
        {

            int valor = 0;
            
            foreach(Vertice x in Listaadjacencia)
            {
                if (x.Grau() % 2 == 0)
                {
                    continue;
                }
                else
                {
                    valor++;
                }
                if(valor > 2)
                {
                    return false;
                    break;
                }   
            }
            return true;


        }





    }
}
