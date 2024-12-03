using Cinemachine;
using Core.Scripts.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.CameraService
{
    public class CameraProvider : MonoBehaviour
    {
        [SerializeField, ReadOnly] private Camera m_MainCamera;
        [SerializeField, ReadOnly] private CinemachineVirtualCamera m_PlayerCamera;

        public Camera MainCamera => m_MainCamera;
        public CinemachineVirtualCamera PlayerCamera => m_PlayerCamera;

        #region Editor
        [Button]
        private void setRefs()
        {
            m_MainCamera = transform.FindDeepChild<UnityEngine.Camera>("Main Camera");
            m_PlayerCamera = transform.FindDeepChild<CinemachineVirtualCamera>("PlayerCamera");
        }
        #endregion
    }
}
