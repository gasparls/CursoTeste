using System;
using System.Collections.Generic;
using Flunt.Validations;
using ISUB.Domain.Enum;

namespace ISUB.Domain.Entities
{
    public class Planejamento : Entity
    {
        public Planejamento(List<Objeto> objetos, Procedimento procedimento,  DateTime data_inicio, int periodicidade, TipoPeriodicidade tipoPeriodicidade)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(procedimento,"Procedimento","Procedimento Inválido")
                .IsNotNull(tipoPeriodicidade,"TipoPeriodicidade","Tipo de periocidade inválido")
                );
            Data_Inicio = data_inicio;
            Periodicidade = periodicidade;
            Objetos = objetos;
            Procedimento = procedimento;
            TipoPeriodicidade = tipoPeriodicidade;
            StatusPlanejamento = StatusPlanejamento.Ativo;
        }

        public DateTime Data_Inicio { get; private set; }
        public int Periodicidade { get; private set; }
        public Procedimento Procedimento { get; private set; }
        public List<Objeto> Objetos { get; private set; }
        public TipoPeriodicidade TipoPeriodicidade { get; private set; }
        public StatusPlanejamento StatusPlanejamento{get; private set;}

        public bool IsValid()
        {
            return this.IsValid();
        }

        public void AlterarStatus(StatusPlanejamento novoStatus)
        {
          //  if (novoStatus.Atendido && Procedimento.ExecutaVariasVezes)
            if ( Procedimento.ExecutaVariasVezes)
            {
                StatusPlanejamento = novoStatus;
            }
        }

        public DateTime DataPlanejada()
        {
            if (TipoPeriodicidade==TipoPeriodicidade.Dia)
            {
                return Data_Inicio.AddDays(Periodicidade);
            }
            else
            {
                return Data_Inicio.AddMonths(Periodicidade);
            }
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