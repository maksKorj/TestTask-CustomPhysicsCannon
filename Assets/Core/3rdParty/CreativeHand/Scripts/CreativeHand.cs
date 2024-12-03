using Core.Scripts.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Utilities.Creatives
{
    public class CreativeHand : MonoBehaviour
    {
        [Title("")]
        [SerializeField, ReadOnly] private RectTransform m_Target;
        [SerializeField, ReadOnly] private Image m_Default;
        [SerializeField, ReadOnly] private Image m_Clicked;

        private bool m_IsShown;
        private Image m_Active;
        private Canvas m_Canvas;

        #region Editor
        [Button]
        private void setRefs()
        {
            m_Target = GetComponent<RectTransform>();
            m_Default = transform.FindDeepChild<Image>("Default");
            m_Clicked = transform.FindDeepChild<Image>("Clicked");
        }
        #endregion

        private void Awake()
        {
            m_Canvas = FindObjectOfType<Canvas>();
        }

        private void Update()
        {
            handleVisibility();

            m_Target.anchoredPosition = Input.mousePosition / m_Canvas.scaleFactor;
            
            handleClickAnimation();
        }

        private void handleVisibility()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                m_Active = m_Default;
                setActive(true);
            }

            if (Input.GetKeyDown(KeyCode.H))
                setActive(false);
        }

        private void handleClickAnimation()
        {
            if (m_IsShown == false)
                return;

            if (Input.GetMouseButtonDown(0))
                updateActive(m_Clicked);

            if (Input.GetMouseButtonUp(0))
                updateActive(m_Default);
        }

        #region Specific
        private void setActive(bool value)
        {
            m_IsShown = value;
            m_Active.gameObject.SetActive(value);
        }

        private void updateActive(Image image)
        {
            if (m_Active != null)
                m_Active.gameObject.SetActive(false);

            m_Active = image;
            m_Active.gameObject.SetActive(true);
        }
        #endregion
    }
}
