using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Services.UserInterface.Canvas
{
    public class CanvasProvider : MonoBehaviour, ICanvasProvider
    {
        [field: SerializeField, ReadOnly] public UnityEngine.Canvas Canvas { get; private set; }
        [field: SerializeField, ReadOnly] public CanvasScaler Scaler { get; private set; }

        #region Editor
        [Button]
        private void setRefs()
        {
            Canvas = GetComponent<UnityEngine.Canvas>();
            Scaler = GetComponent<CanvasScaler>();
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}
