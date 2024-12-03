using Core.Scripts.Extensions;
using Core.Scripts.Popups.Base;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.Scripts.Popups.GameStart.Start
{
    public class StartView : View
    {
        [SerializeField, ReadOnly] private Button m_ButtonPlay;

        #region Editor
        protected override void setRefs()
        {
            base.setRefs();
            m_ButtonPlay = transform.FindDeepChild<Button>("ButtonPlay");
        }
        #endregion

        public void BindStartButtonClick(UnityAction action)
        {
            m_ButtonPlay.Set(action);
        }

        public override void Open()
        {
            if (gameObject.activeInHierarchy)
                return;

            gameObject.SetActive(true);

            m_CanvasGroup.alpha = 1;
            m_CanvasGroup.interactable = true;
        }
    }
}
