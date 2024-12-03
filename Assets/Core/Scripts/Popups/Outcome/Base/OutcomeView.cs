using Core.Scripts.Extensions;
using Core.Scripts.Popups.Base;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Core.Scripts.Popups.Outcome.Base
{
    public class OutcomeView : View
    {
        [Title("Title")]
        [SerializeField, ReadOnly] private TextMeshProUGUI[] m_LevelTitles;
        [Title("Earning")]
        [SerializeField, ReadOnly] private TextMeshProUGUI m_EarningDisplay;
        [SerializeField, ReadOnly] private RectTransform m_SendingPoint;

        public RectTransform SendingPoint => m_SendingPoint;

        #region Editor
        protected override void setRefs()
        {
            base.setRefs();
            
            m_LevelTitles = transform.FindDeepChild("Title").GetComponentsInChildren<TextMeshProUGUI>(true);

            m_EarningDisplay = transform.FindDeepChild<TextMeshProUGUI>("EarningDisplay");
            m_SendingPoint = transform.FindDeepChild<RectTransform>("CollectableIcon");
        }
        #endregion

        public void UpdateLevelTitle(string title)
        {
            foreach (var display in m_LevelTitles)
            {
                display.text = title;
            }
        }

        public void UpdateEarningDisplay(int earnings)
        {
            m_EarningDisplay.text = $"+{earnings}";
        }
    }
}
