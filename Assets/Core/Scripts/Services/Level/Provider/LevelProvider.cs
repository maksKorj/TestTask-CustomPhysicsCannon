using System.Collections.Generic;
using Core.Scripts.Services.Level.Level;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.Level.Provider
{
    public class LevelProvider : MonoBehaviour, ILevelProvider
    {
        [SerializeField, ReadOnly] private LevelComponentBase[] m_Levels;

        public int Amount => m_Levels.Length;
        public IEnumerable<LevelComponentBase> Levels => m_Levels;

        #region Editor
        [Button]
        private void setRefs()
        {
            m_Levels = GetComponentsInChildren<LevelComponentBase>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}
