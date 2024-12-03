using Core.Scripts.Extensions;
using Core.Scripts.Services.StaticDataService.Data.PopupData;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Popups.Base
{
    public abstract class View : MonoBehaviour
    {
        [Title("")]
        [SerializeField, ReadOnly, PropertyOrder(10)] protected CanvasGroup m_CanvasGroup;

        private IFadeData m_FadeData;

        #region Editor
        [Button, PropertyOrder(11)]
        protected virtual void setRefs()
        {
            m_CanvasGroup = transform.FindDeepChild<CanvasGroup>("Group");
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion

        #region Init
        public virtual void Init(IFadeData fadeData)
        {
            m_FadeData = fadeData;
        }
        #endregion

        public virtual void Open()
        {
            if (gameObject.activeInHierarchy)
                return;

            gameObject.SetActive(true);

            m_CanvasGroup.alpha = 0;
            m_CanvasGroup.interactable = false;

            if(m_FadeData == null)
            {
                Debug.LogError($"View of type {GetType()} wasn't initialized!");
                return;
            }

            m_CanvasGroup.DOFade(1, m_FadeData.FadeInTime).OnComplete(onEndOpeningAnimation);
        }

        public virtual void Close(bool closeInstantly = false)
        {
            if (gameObject.activeInHierarchy == false)
                return;

            if (closeInstantly)
            {
                this.closeInstantly();
            }
            else
            {
                m_CanvasGroup.interactable = false;
                m_CanvasGroup.DOFade(0, m_FadeData.FadeOutTime).OnComplete(hide);
            }
        }

        public void SetInteractable(bool value)
        {
            m_CanvasGroup.interactable = value;
        }

        #region Callbacks
        protected virtual void onEndOpeningAnimation() 
        {
            m_CanvasGroup.interactable = true;
        }
        #endregion

        #region Specific
        private void closeInstantly()
        {
            m_CanvasGroup.alpha = 0;
            m_CanvasGroup.interactable = false;
            hide();
        }

        private void hide()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}