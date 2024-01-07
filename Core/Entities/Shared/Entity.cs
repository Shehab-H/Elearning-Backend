using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Shared
{
    public abstract class Entity : IEquatable<Entity>
    {    
        public Guid Id { get; private init; } 
        protected Entity(Guid id) 
        {
            Id = id;
        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            if(obj is not Entity entity)
            {
                return false;
            }

            return Id == entity.Id;
        }      

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }
   
            if (other is not Entity entity)
            {
                return false;
            }

            return Id == entity.Id;
        } // useful for operations collections that equates entities 

    }
}
