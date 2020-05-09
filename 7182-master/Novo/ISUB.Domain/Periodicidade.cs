using System;

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
    }
}
