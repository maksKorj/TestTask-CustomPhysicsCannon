using System;

namespace Core.Scripts.Services.Input.Modules.MultiTouch
{
    public interface IMultiTouch
    {
        public float TouchZoom { get; }
        public float TouchZoomDelta { get; }

        public event Action<float> OnTouchZoomDelta;
        public event Action<float> OnTouchZoom;
    }
}