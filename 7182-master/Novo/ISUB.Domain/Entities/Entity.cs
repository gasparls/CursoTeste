using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace ISUB.Domain.Entities
{
    public class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}