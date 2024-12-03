using System;
using Core.Scripts.Extensions;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Services.UserInterface.TransitionCurtain
{
    public class TransitionCurtain : MonoBehaviour, ITransitionCurtain
    {
        [SerializeField, ReadOnly] private Image m_Background;

        private const float m_TransitionTime = 0.35f;

        #region Editor
        private void setRefs()
        {
            m_Background = GetComponentInChildren<Image>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion

        public void MakeBlack()
        {
            m_Background.gameObject.SetActive(true);
            m_Background.SetAlpha(1);
        }

        public void FadeOut()
        {
            m_Background.DOFade(0, m_TransitionTime).OnComplete(hide);
        }

        public void Transition(Action onBecomeBlack)
        {
            setActiveBackground(true);
            m_Background.SetAlpha(0);
            m_Background.DOFade(1f, m_TransitionTime).OnComplete(() => fadeOutWithCallback(onBecomeBlack));
        }

        #region Specific
        private void fadeOutWithCallback(Action callback)
        {
            callback?.Invoke();
            FadeOut();
        }

        private void hide()
        {
            setActiveBackground(false);
        }

        private void setActiveBackground(bool value)
        {
            m_Background.gameObject.SetActive(value);
        }
        #endregion
    }
}
