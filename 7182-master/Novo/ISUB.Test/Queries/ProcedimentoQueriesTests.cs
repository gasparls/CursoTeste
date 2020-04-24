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
    public class ProcedimentoQueriesTests
    {
        internal List<Procedimento> _procedimentos = new FakeProcedimentoRepository().Procedimentos;

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_area_negocio_2_deve_retornar_2_procedimentos()
        {
            var result = _procedimentos.AsQueryable().Where(ProcedimentoQueries.ProcedimentosPorAreaNegocio(AreaNegocio.Flexivel));
            Assert.AreEqual(result.Count(), 3);
        }
    }
}
