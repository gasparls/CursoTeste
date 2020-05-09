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
    }
}
