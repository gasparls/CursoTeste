using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ISUB.Domain.Entities;

namespace ISUB.Domain.Queries
{
    public static class PlanejamentoQueries
    {
        public static Expression<Func<Planejamento,bool>> PlanejamentoAtivo(Procedimento proc, Objeto obj)
        {
            return x => x.StatusPlanejamento == Enum.StatusPlanejamento.Ativo
                     && x.Procedimento == proc
                     && x.Objetos.Contains(obj);
        }
    }
}
