using Core.Scripts.Extensions;
using Core.Scripts.Popups.Base;
using Core.Scripts.Services.StaticDataService.Data;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.Scripts.Popups.GameStart.Start
{
    public class StartView : View
    {
        [SerializeField, ReadOnly] private Button m_ButtonPlay;
        [SerializeField, ReadOnly] private TextMeshProUGUI m_StageDisplay;

        #region Editor
        protected override void setRefs()
        {
            base.setRefs();
            m_ButtonPlay = transform.FindDeepChild<Button>("ButtonPlay");
            m_StageDisplay = transform.FindDeepChild<TextMeshProUGUI>("StageDisplay");
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
