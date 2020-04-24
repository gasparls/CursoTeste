using System;
using System.Collections.Generic;
using System.Text;
using ISUB.Domain.Enum;
using ISUB.Domain.Entities;

namespace ISUB.Domain.Repositories.Interface
{
    public interface IProcedimentoRepository
    {
        IEnumerable<Procedimento> Get(IEnumerable<Guid>  ids);
    }
}
