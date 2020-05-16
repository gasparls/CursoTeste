using System;
using System.Collections.Generic;

namespace ISUB.Domain
{
    public class PeriodicidadeMeses : Periodicidade
    {
        public PeriodicidadeMeses(int duracao) : base(duracao) { }

        public override bool Equals(object obj)
        {
            return obj is PeriodicidadeMeses meses &&
                   base.Equals(obj) &&
                   duracao == meses.duracao;
        }

        public override int GetHashCode()
        {
            int hashCode = 2000508250;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + duracao.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            var strDuracao = $"{duracao} ";
            strDuracao += (duracao > 1) ? "meses" : "mês";
            return strDuracao;
        }

        public static DateTime operator +(DateTime data, PeriodicidadeMeses periodicidade)
        {
            return data.AddMonths(periodicidade.duracao);
        }

        public static DateTime operator +(PeriodicidadeMeses periodicidade, DateTime data)
        {
            return data + periodicidade;
        }

        public static bool operator ==(PeriodicidadeMeses left, PeriodicidadeMeses right)
        {
            return EqualityComparer<PeriodicidadeMeses>.Default.Equals(left, right);
        }

        public static bool operator !=(PeriodicidadeMeses left, PeriodicidadeMeses right)
        {
            return !(left == right);
        }
    }
}
