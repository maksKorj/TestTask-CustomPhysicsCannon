using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.Pool.Base.Provider
{
    public class PoolProvider : MonoBehaviour, IPoolProvider
    {
        [SerializeField, ReadOnly] private PoolBase[] m_Pools;

        public IEnumerable<PoolBase> Pools => m_Pools;

        #region Editor
        [Button]
        private void setRefs()
        {
            m_Pools = GetComponentsInChildren<PoolBase>();
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}
