using System;
using System.Collections.Generic;
using System.Text;
using ISUB.Domain.Entities;
using ISUB.Domain.Enum;
using ISUB.Domain.Repositories.Interface;

namespace ISUB.Test.Repositories
{
    public class FakeObjetoRepository : IObjetoRepository
    {
        internal List<Objeto> Objetos = new List<Objeto>();

        public FakeObjetoRepository()
        {
            var objetos = new List<Objeto>();

            objetos.Add(new Objeto(AreaNegocio.Flexivel, "TR500101"));
            objetos.Add(new Objeto(AreaNegocio.Flexivel, "TR500102"));
            objetos.Add(new Objeto(AreaNegocio.Rigido, "TR500103"));
            objetos.Add(new Objeto(AreaNegocio.Rigido, "TR500104"));
            objetos.Add(new Objeto(AreaNegocio.Equipamento, "TR500105"));
            objetos.Add(new Objeto(AreaNegocio.TopSide, "TR5001026"));
            objetos.Add(new Objeto(AreaNegocio.Faixa, "TR500107"));

            this.Objetos = objetos;
        }

        public IEnumerable<Objeto> Get(IEnumerable<Guid> ids)
        {
            var objetos = new List<Objeto>();
            objetos.Add(new Objeto(AreaNegocio.Flexivel, "TR500101"));

            return Objetos;
        }
    }
}
