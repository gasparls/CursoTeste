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

        public static DateTime operator +(DateTime data, PeriodicidadeDias periodicidade)
        {
            return data.AddDays(periodicidade.duracao);
        }

        public static DateTime operator +(PeriodicidadeDias periodicidade, DateTime data)
        {
            return data + periodicidade;
        }
    }
}
