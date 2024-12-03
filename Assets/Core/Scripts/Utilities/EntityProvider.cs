using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Scripts.Utilities
{
    public class EntityProvider<T>
    {
        private readonly Dictionary<Type, T> m_Entities;

        public EntityProvider(Dictionary<Type, T> entities)
        {
            m_Entities = entities;
        }

        public EntityProvider(IEnumerable<T> entities)
        {
            m_Entities = new Dictionary<Type, T>();

            foreach (var entity in entities)
            {
                m_Entities.Add(entity.GetType(), entity);
            }
        }

        public bool TryGetEntity<TargetType>(out TargetType targetEntity) where TargetType : T
        {
            if (m_Entities.TryGetValue(typeof(TargetType), out T entity))
            {
                targetEntity = (TargetType) entity;
                return true;
            }

            Debug.LogError($"Entity of type {typeof(TargetType)} doesn't exist!");
            targetEntity = default;
            return false;
        }
    }
}
