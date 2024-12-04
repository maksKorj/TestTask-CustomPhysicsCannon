using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Effects
{
    public class GenericEffectBase : MonoBehaviour
    {
        [SerializeField, ReadOnly] private ParticleSystem[] m_VFXes;

        private ParticleSystem m_MainVFX => m_VFXes[0];

        #region Editor
        [Button]
        private void setRefs()
        {
            m_VFXes = transform.GetComponentsInChildren<ParticleSystem>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion

        public void Play()
        {
            gameObject.SetActive(true);
            m_MainVFX.Play();
        }

        #region SetupColor
        public void SetupColor(Color color)
        {
            foreach (var vfx in m_VFXes)
            {
                setupColor(vfx, color);
            }
        }

        private void setupColor(ParticleSystem vfx, Color color)
        {
            var main = vfx.main;
            main.startColor = color;
        }
        #endregion
    }
}
