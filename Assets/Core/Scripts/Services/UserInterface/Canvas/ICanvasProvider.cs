using UnityEngine.UI;

namespace Core.Scripts.Services.UserInterface.Canvas
{
    public interface ICanvasProvider
    {
        public UnityEngine.Canvas Canvas { get; }
        public CanvasScaler Scaler { get; }
    }
}