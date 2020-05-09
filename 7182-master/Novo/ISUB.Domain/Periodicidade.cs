namespace ISUB.Domain
{
    public class Periodicidade
    {
        private int duracao;
        private bool duracaoEmDias;

        public Periodicidade(int duracao, bool dias = false)
        {
            this.duracao = duracao;
            this.duracaoEmDias = dias;
        }

        public override string ToString()
        {
            if (duracaoEmDias)
            {
                return $"{duracao} dias";
            }
            else
            {
                return $"{duracao} meses";
            }
        }
    }
}
