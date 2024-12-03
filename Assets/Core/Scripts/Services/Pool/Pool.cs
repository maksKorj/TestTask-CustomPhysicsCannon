using System.Collections.Generic;
using Core.Scripts.Services.Pool.Base;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Scripts.Services.Pool
{
    public abstract class Pool<T> : PoolBase, IPool<T> where T : PoolEntity
    {
        [Title("PoolData")]
        [SerializeField] private int m_SpawnAmount;
        [SerializeField] private T m_Prefab;

        [Title("Spawned")]
        [SerializeField, ReadOnly] protected List<T> m_SpawnedEntities;

        private readonly Stack<T> m_Entities = new();

        #region Editor
        [Button]
        private void fill()
        {
            #if UNITY_EDITOR
            while (transform.childCount != 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }

            m_SpawnedEntities = new List<T>();
            for (int i = 0; i < m_SpawnAmount; i++)
            {
                var entity = UnityEditor.PrefabUtility.InstantiatePrefab(m_Prefab, transform) as T;
                entity.name = $"{m_Prefab.name} ({i})";
                resetTransform(entity);

                m_SpawnedEntities.Add(entity);
            }
            #endif
        }
        #endregion

        #region Init
        public override void Init(IServiceLocator serviceLocator)
        {
            base.Init(serviceLocator);
            foreach (var entity in m_SpawnedEntities)
            {
                initCreatedInstance(entity);
            }
        }

        private void OnEnable()
        {
            ResetPool();

            foreach (var entity in m_SpawnedEntities)
                entity.OnTakenBack += resetEntity;
        }

        private void OnDisable()
        {
            foreach (var entity in m_SpawnedEntities)
                entity.OnTakenBack -= resetEntity;
        }
        #endregion

        #region Callbacks
        protected override void resetEntity(PoolEntity poolable)
        {
            base.resetEntity(poolable);

            var target = (T)poolable;
            if (m_Entities.Contains(target))
                return;

            m_Entities.Push(target);
        }
        #endregion

        public T GetPoolable()
        {
            if (m_Entities.Count != 0) 
                return m_Entities.Pop();
            
            var createdInstance = createInstance();
            return createdInstance;
        }

        public override void ResetPool()
        {
            m_Entities.Clear();

            foreach (var entity in m_SpawnedEntities)
            {
                resetEntity(entity);
            }
        }

        private T createInstance()
        {
            var spawnedEntity = Instantiate(m_Prefab, transform);

            resetTransform(spawnedEntity);
            initCreatedInstance(spawnedEntity);

            m_SpawnedEntities.Add(spawnedEntity);
            spawnedEntity.OnTakenBack += resetEntity;

            return spawnedEntity;
        }

        protected abstract void initCreatedInstance(T spawnedEntity);
    }
}
