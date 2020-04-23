using Store.Domain.Enum;
using Flunt.Validations;

namespace Store.Domain.Entities
    {
    public class Objeto : Entity
    {
        public Objeto(AreaNegocio areaNegocio, string nome)
        {
               AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(areaNegocio,"AreaNegocio","Favor Informar a Área de Negócio")
                .IsNotNull(nome,"Nome","Favor informar o Nome")
                );
            AreaNegocio = AreaNegocio.Flexivel;
            Nome = nome;
        }

        public AreaNegocio AreaNegocio {get; private set;}
        public string Nome {get; private set;}

    }
}