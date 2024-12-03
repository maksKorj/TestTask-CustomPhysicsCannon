using Core.Scripts.Services.Pool.Base;

namespace Core.Scripts.Services.Pool
{
    public interface IPoolService : IService
    {
        public T GetPool<T>() where T : PoolBase;

        public IPool<EntityType> GetPoolByEntity<EntityType>() where EntityType : PoolEntity;

        public void Reset();
    }
}