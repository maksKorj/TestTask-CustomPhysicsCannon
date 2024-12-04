using System.Collections.Generic;
using Core.Scripts.Services;
using Core.Scripts.Services.Level.Level;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Levels
{
    public class LevelComponent : LevelComponentBase
    {
        [field: SerializeField, ReadOnly] public Transform CannonPoint { get; private set; }
        [SerializeField, ReadOnly] private LevelActor[] m_Actors;

        public IEnumerable<LevelActor> Actors => m_Actors;
        
        #region Editor
        [Button]
        private void setRefs()
        {
            CannonPoint = transform.Find("CannonPoint");
            m_Actors = GetComponentsInChildren<LevelActor>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
        
        public override LevelBase CreateLevel(IServiceLocator serviceLocator)
        {
            return new Level(this, serviceLocator);
        }
    }
}
