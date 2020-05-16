using ISUB.Domain;
using ISUB.Domain.Entities;
using ISUB.Domain.Enum;
using ISUB.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;

namespace ISUB.Test.Repositories
{
    public class FakeProcedimentoRepository : IProcedimentoRepository
    {
        internal List<Procedimento> Procedimentos = new List<Procedimento>();

        public FakeProcedimentoRepository()
        {
            var procedimentos = new List<Procedimento>();

            Procedimentos.Add(
                new Procedimento("TEADF", new PeriodicidadeMeses(12), AreaNegocio.Flexivel, true));
            Procedimentos.Add(
                new Procedimento("PIDF-1", new PeriodicidadeMeses(24), AreaNegocio.Rigido, true));
            Procedimentos.Add(
                new Procedimento("PIDF-2", new PeriodicidadeMeses(36), AreaNegocio.TopSide, true));
            Procedimentos.Add(
                new Procedimento("PIDR", new PeriodicidadeMeses(48), AreaNegocio.Faixa, true));
            Procedimentos.Add(
                new Procedimento("EQSB", new PeriodicidadeMeses(60), AreaNegocio.Equipamento, true));
            Procedimentos.Add(
                new Procedimento("PIG", new PeriodicidadeMeses(12), AreaNegocio.Flexivel, true));

            this.Procedimentos = procedimentos;
        }

        public IEnumerable<Procedimento> Get(IEnumerable<Guid> ids)
        {
            var Procedimentos = new List<Procedimento>();
            Procedimentos.Add(new Procedimento("TEADF", new PeriodicidadeMeses(12), AreaNegocio.Flexivel, true));
            return Procedimentos;
        }
    }
}