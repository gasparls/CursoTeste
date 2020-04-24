using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ISUB.Domain.Entities;
using ISUB.Domain.Enum;

namespace ISUB.Domain.Queries
{
    public static class ObjetosQueries
    {
        public static Expression<Func<Objeto, bool>> ObjetosPorAreaNegocio(AreaNegocio area)
        {
            return x => x.AreaNegocio == area;
        }
    }
}
