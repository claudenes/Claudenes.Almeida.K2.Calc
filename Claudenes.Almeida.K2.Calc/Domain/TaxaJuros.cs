using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Claudenes.Almeida.K2.Calc.Interface;

namespace Claudenes.Almeida.K2.Calc.Domain
{
  
    public class TaxaJuros : iTaxaJuros
    {
        public decimal ObterTaxaDeJuros() => 0.01M;
    }
}
