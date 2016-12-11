using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TADgrafo
{
    class Aresta
    {

        public int valor { get; set; }
        public Vertice vertice { get; set; }
        public Vertice origem { get; set; }


        public Aresta (int valor, Vertice vertice, Vertice origem)
        {
            this.origem = origem;
            this.valor = valor;
            this.vertice = vertice;

        }

    }
}
