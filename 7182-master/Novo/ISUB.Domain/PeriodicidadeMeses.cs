using System;

namespace ISUB.Domain
{
    public class PeriodicidadeMeses : Periodicidade
    {
        public PeriodicidadeMeses(int duracao) : base(duracao) { }

        public override string ToString()
        {
            var strDuracao = $"{duracao} ";
            strDuracao += (duracao > 1) ? "meses" : "mês";
            return strDuracao;
        }

        protected override DateTime SomarComDateTime(DateTime data)
        {
            return data.AddMonths(duracao);
        }
    }
}
