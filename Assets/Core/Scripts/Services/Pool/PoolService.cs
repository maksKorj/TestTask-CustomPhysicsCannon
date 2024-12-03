using System.Collections.Generic;
using Core.Scripts.Services.Pool.Base;
using Core.Scripts.Utilities;
using UnityEngine;

namespace Core.Scripts.Services.Pool
{
    public class PoolService : IPoolService
    {
        private readonly IEnumerable<PoolBase> _pools;
        private readonly EntityProvider<PoolBase> m_EntityProvider;

        public PoolService(IEnumerable<PoolBase> pools)
        {
            _pools = pools;
            m_EntityProvider = new EntityProvider<PoolBase>(pools);
        }

        public void InitPools(IServiceLocator serviceLocator)
        {
            foreach (var pool in _pools)
            {
                pool.Init(serviceLocator);
            }
        }

        public void Reset()
        {
            foreach (var pool in _pools)
            {
                pool.ResetPool();
            }
        }

        public IPool<EntityType> GetPoolByEntity<EntityType>() where EntityType : PoolEntity
        {
            if (m_EntityProvider.TryGetEntity(out Pool<EntityType> entity))
                return entity;

            Debug.LogError("Pool not found!");
            return null;
        }

        public T GetPool<T>() where T : PoolBase
        {
            if (m_EntityProvider.TryGetEntity(out T entity))
                return entity;

            Debug.LogError("Pool not found!");
            return null;
        }
    }
}
