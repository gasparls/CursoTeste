using System;

namespace ISUB.Domain
{
    public class PeriodicidadeDias : Periodicidade
    {
        public PeriodicidadeDias(int duracao) : base(duracao) { }

        public override string ToString()
        {
            var strDuracao = $"{duracao} ";
            strDuracao += (duracao > 1) ? "dias" : "dia";
            return strDuracao;
        }

        protected override DateTime SomarComDateTime(DateTime data)
        {
            return data.AddDays(duracao);
        }
    }
}
