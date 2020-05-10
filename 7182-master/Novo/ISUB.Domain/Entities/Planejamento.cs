using Flunt.Validations;
using ISUB.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ISUB.Domain.Entities
{
    public class Planejamento : Entity
    {
        public Planejamento(List<Objeto> objetos, Procedimento procedimento, DateTime data_inicio, Periodicidade periodicidade)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(procedimento, "Procedimento", "Procedimento Inválido")
                .IsNotNull(periodicidade, "Periodicidade", "Periocidade inválida")
                );
            DataInicio = data_inicio;
            Periodicidade = periodicidade;
            Objetos = objetos;
            Procedimento = procedimento;
            StatusPlanejamento = StatusPlanejamento.Ativo;
        }

        public DateTime DataInicio { get; private set; }
        public Periodicidade Periodicidade { get; private set; }
        public Procedimento Procedimento { get; private set; }
        public List<Objeto> Objetos { get; private set; }
        public StatusPlanejamento StatusPlanejamento { get; private set; }

        public bool IsValid()
        {
            return this.IsValid();
        }

        public void AlterarStatus(StatusPlanejamento novoStatus)
        {
            //  if (novoStatus.Atendido && Procedimento.ExecutaVariasVezes)
            if (Procedimento.ExecutaVariasVezes)
            {
                StatusPlanejamento = novoStatus;
            }
        }

        public DateTime DataPlanejada()
        {
            return DataInicio + Periodicidade;
        }

        public void AddObjeto(Objeto objeto)
        {
            if (objeto.Valid)
                Objetos.Add(objeto);
        }

        public void RemoveObjeto(Objeto objeto)
        {
            if (Objetos.Count >= 2)
                Objetos.Remove(objeto);
        }
    }
}
