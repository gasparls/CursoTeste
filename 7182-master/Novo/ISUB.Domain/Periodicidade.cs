namespace ISUB.Domain
{
    public class Periodicidade
    {
        private int duracao;

        public Periodicidade(int duracao)
        {
            this.duracao = duracao;
        }

        public override string ToString()
        {
            return $"{duracao} meses";
        }
    }
}
