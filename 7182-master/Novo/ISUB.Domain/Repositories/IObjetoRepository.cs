using System;
using System.Collections.Generic;
using System.Text;
using ISUB.Domain.Entities;
using ISUB.Domain.Enum;

namespace ISUB.Domain.Repositories.Interface

{
    public interface IObjetoRepository
    {
        IEnumerable<Objeto> Get(IEnumerable<Guid> ids);
    }
}
