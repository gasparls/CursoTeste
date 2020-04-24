using System;
using System.Collections.Generic;
using System.Text;
using ISUB.Domain.Entities;

namespace ISUB.Domain.Repositories.Interface
{
    public interface IPlanejamentoRepository
    {
        Planejamento Get(Guid Id);

        void Save(Planejamento plan);
    }
}
