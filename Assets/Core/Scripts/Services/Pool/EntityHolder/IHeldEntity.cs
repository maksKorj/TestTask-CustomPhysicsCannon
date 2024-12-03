using System;

namespace Core.Scripts.Services.Pool.EntityHolder
{
    public interface IHeldEntity<T> where T : Enum
    {
        public T EntityType { get; }

        public event Action OnOnHidden;
    }
}
