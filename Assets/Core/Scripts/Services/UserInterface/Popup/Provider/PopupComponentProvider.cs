using System.Collections.Generic;
using Core.Scripts.Popups.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.UserInterface.Popup.Provider
{
    public class PopupComponentProvider : MonoBehaviour, IPopupComponentProvider
    {
        [SerializeField, ReadOnly] private PopupBase[] m_Popups;

        public IEnumerable<PopupBase> Popups => m_Popups;

        #region Editor
        [Button]
        protected virtual void setRefs()
        {
            m_Popups = GetComponentsInChildren<PopupBase>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}
