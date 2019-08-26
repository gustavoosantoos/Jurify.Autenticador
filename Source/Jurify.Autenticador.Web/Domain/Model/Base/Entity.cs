using System;

namespace Jurify.Autenticador.Web.Domain.Model.Base
{
    public abstract class Entity
    {
        public virtual Guid Codigo { get; private set; }
        public bool Apagado { get; protected set; }

        protected Entity() { }

        public Entity(Guid id)
        {
            Codigo = id;
        }

        public virtual void Ativar()
        {
            Apagado = false;
        }

        public virtual void Desativar()
        {
            Apagado = true;
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

            if (Codigo == default || other == default)
                return false;

            if (Codigo == Guid.Empty || other.Codigo == Guid.Empty)
                return false;

            return Codigo == other.Codigo;
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
            return (GetType().ToString() + Codigo).GetHashCode();
        }
    }
}
