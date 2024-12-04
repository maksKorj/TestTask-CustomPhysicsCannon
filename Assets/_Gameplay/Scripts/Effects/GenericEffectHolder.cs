using Core.Scripts.Services.Pool.Base;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Effects
{
    public class GenericEffectHolder : PoolEntity
    {
        [SerializeField, ReadOnly] private GenericEffect[] m_VFXes;

        private Tween m_Timer;
        private GenericEffect m_CurrentVFX;

        private readonly float m_Duration = 4f;

        #region Editor
        [Button]
        private void setRefs()
        {
            m_VFXes = transform.GetComponentsInChildren<GenericEffect>(true);   
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion

        #region Init
        protected void OnEnable()
        {
            m_Timer = DOVirtual.DelayedCall(m_Duration, takeBack);
        }

        protected void OnDisable()
        {
            m_Timer?.Kill();

            if(m_CurrentVFX != null)
            {
                m_CurrentVFX.gameObject.SetActive(false);
                m_CurrentVFX = null;
            }
        }
        #endregion

        public void Play(GenericEffect.EntityType entityType)
        {
            m_CurrentVFX = getVfx(entityType);
            play();
        }

        public void Play(Color color, GenericEffect.EntityType entityType)
        {
            m_CurrentVFX = getVfx(entityType);
            m_CurrentVFX.SetupColor(color);

            play();
        }

        #region Specific
        private void play()
        {
            gameObject.SetActive(true);

            m_CurrentVFX.Play();
        }

        private GenericEffect getVfx(GenericEffect.EntityType entityType)
        {
            foreach (var vfx in m_VFXes)
            {
                if (vfx.VfxType == entityType)
                {
                    return vfx;
                }
            }

            Debug.LogError($"There isn't any vfx with type {entityType}!");
            return null;
        }
        #endregion
    }
}
