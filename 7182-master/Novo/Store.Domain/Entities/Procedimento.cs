using Store.Domain.Enum;
using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class Procedimento : Entity
    {
        public Procedimento(string nome, int periodicidadePadrao, AreaNegocio areaNegocio, bool executaVariasVezes)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(nome,"Nome","Favor Informar o Nome")
                .IsNotNull(periodicidadePadrao,"PeriodicidadePadrao","Favor Informar a Periodicidade Padrão")
                .IsNotNull(areaNegocio,"AreaNegocio","Favor Informar a Área de Negócio")
                .IsNotNull(executaVariasVezes,"ExecutaVariasVezes","Favor informar se o procedimento se repete")
                );
            Nome = nome;
            PeriodicidadePadrao = periodicidadePadrao;
            AreaNegocio = areaNegocio;
            ExecutaVariasVezes = executaVariasVezes;
        }

        public string Nome { get; private set; }
        public int PeriodicidadePadrao { get; private set; }
        public AreaNegocio AreaNegocio { get; private set; }
        public bool ExecutaVariasVezes { get; internal set; }
    }
}