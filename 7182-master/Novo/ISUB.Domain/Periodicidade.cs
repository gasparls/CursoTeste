using System;
using System.Collections.Generic;

namespace ISUB.Domain
{
    public class Periodicidade
    {
        private int duracao;
        private bool duracaoEmDias;

        public Periodicidade(int duracao, bool dias = false)
        {
            if (duracao < 1)
            {
                var message = $"Periodicidade deve ser positiva. Duração informada: {duracao}.";
                throw new ArgumentException(message);
            }
            this.duracao = duracao;
            this.duracaoEmDias = dias;
        }

        public override bool Equals(object obj)
        {
            return obj is Periodicidade periodicidade &&
                   duracao == periodicidade.duracao &&
                   duracaoEmDias == periodicidade.duracaoEmDias;
        }

        public override int GetHashCode()
        {
            int hashCode = 1034465429;
            hashCode = hashCode * -1521134295 + duracao.GetHashCode();
            hashCode = hashCode * -1521134295 + duracaoEmDias.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            var strDuracao = $"{duracao} ";
            if (duracaoEmDias)
            {
                strDuracao += (duracao > 1) ? "dias" : "dia";
            }
            else
            {
                strDuracao += (duracao > 1) ? "meses" : "mês";
            }
            return strDuracao;
        }

        public static DateTime operator +(DateTime data, Periodicidade periodicidade)
        {
            if (periodicidade.duracaoEmDias)
            {
                return data.AddDays(periodicidade.duracao);
            }
            else
            {
                return data.AddMonths(periodicidade.duracao);
            }
        }

        public static DateTime operator +(Periodicidade periodicidade, DateTime data)
        {
            return data + periodicidade;
        }

        public static bool operator ==(Periodicidade left, Periodicidade right)
        {
            return EqualityComparer<Periodicidade>.Default.Equals(left, right);
        }

        public static bool operator !=(Periodicidade left, Periodicidade right)
        {
            return !(left == right);
        }
    }
}
