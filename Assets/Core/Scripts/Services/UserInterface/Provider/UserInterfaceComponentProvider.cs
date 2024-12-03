using System.Collections.Generic;
using Core.Scripts.Services.UserInterface.Canvas;
using Core.Scripts.Services.UserInterface.Hud.Provider;
using Core.Scripts.Services.UserInterface.Popup.Provider;
using Core.Scripts.Services.UserInterface.TransitionCurtain;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.UserInterface.Provider
{
    public class UserInterfaceComponentProvider : MonoBehaviour, IUserInterfaceComponentProvider
    {
        [field: SerializeField, ReadOnly] public CanvasProvider CanvasProvider { get; private set; }

        [field: Title("")]
        [field: SerializeField, ReadOnly] public HudComponentProvider HudComponentProvider { get; private set; }
        [field: SerializeField, ReadOnly] public PopupComponentProvider PopupComponentProvider { get; private set; }
        
        [field: Title("")]
        [field: SerializeField, ReadOnly] public TransitionCurtain.TransitionCurtain TransitionCurtain { get; private set; }
        
        ICanvasProvider IUserInterfaceComponentProvider.CanvasProvider => CanvasProvider;
        IHudComponentProvider IUserInterfaceComponentProvider.HudComponentProvider => HudComponentProvider;
        IPopupComponentProvider IUserInterfaceComponentProvider.PopupComponentProvider => PopupComponentProvider;
        ITransitionCurtain IUserInterfaceComponentProvider.TransitionCurtain => TransitionCurtain;
        
        #region Editor
        [Button]
        private void setRefs()
        {
            CanvasProvider = GetComponentInChildren<CanvasProvider>(true);
            HudComponentProvider = GetComponentInChildren<HudComponentProvider>(true);
            PopupComponentProvider = GetComponentInChildren<PopupComponentProvider>(true);
            TransitionCurtain = GetComponentInChildren<TransitionCurtain.TransitionCurtain>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}
