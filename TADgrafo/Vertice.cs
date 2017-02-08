using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TADgrafo
{
    class Vertice
    {

        public string nome { get; set; }
        private List<Aresta> Arestas = new List<Aresta>();
        public bool trancado { get; set; }
        public int custo { get; set; }
        public bool saida { get; set; }

        
        public Vertice(string nome)
        {
            this.nome = nome;
            trancado = false;
            custo = int.MaxValue;
            saida = false;

        }

        public List<Aresta> GetArestas()
        {
            return Arestas;
            
        }


        public void AddAresta(int valor, Vertice vertice)
        {
            
            Aresta aresta = new Aresta(valor, vertice);
            Arestas.Add(aresta);

        }


        public int Grau()
        {
            return Arestas.Count();
        }


    }
}
