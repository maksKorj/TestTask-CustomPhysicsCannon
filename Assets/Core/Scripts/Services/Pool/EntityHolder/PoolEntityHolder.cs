using System;
using Core.Scripts.Services.Pool.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.Pool.EntityHolder
{
    public abstract class PoolEntityHolder<TEntity, TEntityType> : PoolEntity
        where TEntity : MonoBehaviour, IHeldEntity<TEntityType> 
        where TEntityType : Enum
    {
        [SerializeField, ReadOnly] private TEntity[] m_Entities;

        private TEntity m_CurrentEntity;

        #region Editor
        [Button]
        private void setRefs()
        {
            m_Entities = GetComponentsInChildren<TEntity>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion

        #region Init
        private void OnDisable()
        {
            if (m_CurrentEntity != null)
            {
                m_CurrentEntity.OnOnHidden -= onHidden;
                m_CurrentEntity.gameObject.SetActive(false);

                m_CurrentEntity = null;
            }
        }
        #endregion

        #region Callbacks
        private void onHidden()
        {
            m_CurrentEntity.OnOnHidden -= onHidden;
            m_CurrentEntity = null;

            takeBack();
        }
        #endregion

        public TEntity GetEntity(TEntityType entityType)
        {
            m_CurrentEntity = getEntity(entityType);
            m_CurrentEntity.OnOnHidden += onHidden;
            gameObject.SetActive(true);

            return m_CurrentEntity;
        }

        #region Specific
        private TEntity getEntity(TEntityType entityType)
        {
            foreach (var entity in m_Entities)
            {
                if (entity.EntityType.Equals(entityType))
                {
                    return entity;
                }
            }

            Debug.LogError($"There isn't any entity with type {entityType}!");
            return null;
        }
        #endregion
    }
}
