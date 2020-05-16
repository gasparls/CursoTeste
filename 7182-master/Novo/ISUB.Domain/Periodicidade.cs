using System;
using System.Collections.Generic;

namespace ISUB.Domain
{
    public abstract class Periodicidade
    {
        protected readonly int duracao;

        public Periodicidade(int duracao)
        {
            if (duracao < 1)
            {
                var message = $"Periodicidade deve ser positiva. Duração informada: {duracao}.";
                throw new ArgumentException(message);
            }
            this.duracao = duracao;
        }

        public override bool Equals(object obj)
        {
            return obj is Periodicidade periodicidade &&
                   duracao == periodicidade.duracao &&
                   GetType() == periodicidade.GetType();
        }

        public override int GetHashCode()
        {
            int hashCode = 1034465429;
            hashCode = hashCode * -1521134295 + duracao.GetHashCode();
            hashCode = hashCode * -1521134295 + GetType().GetHashCode();
            return hashCode;
        }

        protected abstract DateTime SomarComDateTime(DateTime data);

        public static DateTime operator +(DateTime data, Periodicidade periodicidade)
        {
            return periodicidade.SomarComDateTime(data);
        }

        public static DateTime operator +(Periodicidade periodicidade, DateTime data)
        {
            return periodicidade.SomarComDateTime(data);
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
