using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ISUB.Domain.Entities;
using ISUB.Domain.Enum;

namespace ISUB.Domain.Queries
{
    public static class ProcedimentoQueries
    {
        public static Expression<Func<Procedimento, bool>> ProcedimentosPorAreaNegocio(AreaNegocio area)
        {
            return x => x.AreaNegocio == area;
        }
    }
}
