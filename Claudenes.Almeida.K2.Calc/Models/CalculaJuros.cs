using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claudenes.Almeida.K2.Calc.Models
{
    public class CalculaJuros
    {
        public long Id { get; set; }
        public decimal ValorInicial { get; set; }

        public int QuantidadeMeses { get; set; }

        public decimal TaxaJuros { get; set; }
    }
}
