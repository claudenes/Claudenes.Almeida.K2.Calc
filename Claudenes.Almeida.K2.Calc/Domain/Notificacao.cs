using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claudenes.Almeida.K2.Calc.Domain
{
    public class Notificacao
    {
        public string Description { get; private set; }

        public Type CommandType { get; private set; }

        #region Factory

        public static class Factory
        {
            public static Notificacao Create(object commandType, string description)
                => new Notificacao()
                {
                    CommandType = commandType.GetType(),
                    Description = description
                };
        }

        #endregion
    }
}
