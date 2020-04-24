using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISUB.Domain.Entities;
using ISUB.Domain.Enum;
using ISUB.Domain.Queries;
using System.Text;
using ISUB.Test.Repositories;

namespace ISUB.Test.Queries
{
    [TestClass]
    public class ObjetosQueriesTests
    {
        private List<Objeto> _objetos = new FakeObjetoRepository().Objetos;

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_area_negocio_2_deve_retornar_2_objetos()
        {
            var result = _objetos.AsQueryable().Where(ObjetosQueries.ObjetosPorAreaNegocio(AreaNegocio.Flexivel));
            Assert.AreEqual(result.Count(), 3);
        }
    }
}
