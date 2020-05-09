using ISUB.Domain;
using ISUB.Domain.Entities;
using ISUB.Domain.Enum;
using ISUB.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;

namespace ISUB.Test.Repositories
{
    public class FakePlanejamentoRepository : IPlanejamentoRepository
    {
        private Procedimento _procedimento = new Procedimento("TEADF", 12, AreaNegocio.Flexivel, true);
        //private Objeto _objeto = new Objeto(AreaNegocio.Flexivel, "TR500101");
        private List<Objeto> _objetos = new List<Objeto>() { new Objeto(AreaNegocio.Flexivel, "TR500101") };
        //_objetos.Add(_objeto);

        public Planejamento Get(Guid Id)
        {
            var planejamento = new Planejamento(_objetos, _procedimento, new DateTime(2018, 01, 15), new Periodicidade(12));
            return planejamento;
        }

        public void Save(Planejamento plan)
        {

        }
    }
}
