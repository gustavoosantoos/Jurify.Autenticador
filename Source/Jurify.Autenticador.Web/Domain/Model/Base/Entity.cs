using System;

namespace Jurify.Autenticador.Web.Domain.Model.Base
{
    public abstract class Entity
    {
        public virtual Guid Id { get; private set; }
        public bool Deleted { get; protected set; }

        protected Entity() { }

        public Entity(Guid id)
        {
            Id = id;
        }

        public virtual void Activate()
        {
            Deleted = false;
        }

        public virtual void Deativate()
        {
            Deleted = true;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == default || other == default)
                return false;

            if (Id == Guid.Empty || other.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
