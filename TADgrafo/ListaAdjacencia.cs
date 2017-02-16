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
                }   
            }
            return true;


        }

        public List<Vertice> Dijkstra(string nvertice)
        {
            ReiniciarValores();

            List<Vertice> ListaTemporaria = Listaadjacencia;

            Vertice verticeinicial = ListaTemporaria.Find(x => x.nome == nvertice);

            verticeinicial.custo = 0;

            while (true)
            {

                List<Vertice> ListaMenores = ListaTemporaria.FindAll(x => x.trancado == false);

                if (ListaMenores.Any() == false)
                {
                    break;
                }

                Vertice MenorVertice = ListaMenores.Find(x => x.custo == ListaMenores.Min(y => y.custo));

                MenorVertice.trancado = true;

                List<Aresta> ArestasMenores = MenorVertice.GetArestas();

                for (int x = 0; x < ArestasMenores.Count();x++)
                {
                     
                    int CustoNovo = ArestasMenores[x].valor + MenorVertice.custo;

                    if (CustoNovo < ArestasMenores[x].vertice.custo)
                    {
                        ArestasMenores[x].vertice.custo = CustoNovo;

                    }

                    else
                    {
                        continue;
                    }
                }

            }

            return ListaTemporaria;

        }

        public List<Vertice> MelhorPontoAMB()
        {

            int Nvertices = this.Listaadjacencia.Count();
            List<Vertice> VerticesTemp = this.Listaadjacencia;
            List<Vertice> MenorCaminhoAtual;
            string NomeVerticeMelhor = null;
            int MenorCusto = int.MaxValue, MenorCustoAtual;

            for (int x = 0; x < Nvertices; x++)
            {
                
                MenorCaminhoAtual = Dijkstra(VerticesTemp[x].nome);
                MenorCustoAtual = SomatoriaCustos(MenorCaminhoAtual);

                if(MenorCustoAtual < MenorCusto)
                {
                    MenorCusto = MenorCustoAtual;
                    NomeVerticeMelhor = VerticesTemp[x].nome;
                }

            }

            return Dijkstra(NomeVerticeMelhor);

        }
        public void ReiniciarValores()
        {
            for (int x =0; x < Listaadjacencia.Count(); x++)
            {
                Listaadjacencia[x].custo = int.MaxValue;
                Listaadjacencia[x].trancado = false;
            }

        }

        public int SomatoriaCustos(List<Vertice> ListaVertices)
        {

            int Nvertices = ListaVertices.Count();
            int SomatoriaCustosV = 0;

            for (int x = 0; x < Nvertices; x++)
            {

                SomatoriaCustosV = ListaVertices[x].custo + SomatoriaCustosV;

            }

            return SomatoriaCustosV;
        }

    }
}
