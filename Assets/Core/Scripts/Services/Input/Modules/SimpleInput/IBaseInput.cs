using System;
using UnityEngine;

namespace Core.Scripts.Services.Input.Modules.SimpleInput
{
    public interface IBaseInput
    {
        public Vector2 DeltaDrag { get; }
        public Vector2 Drag { get; }
        public bool IsInputDown { get; }
        public Vector3 MousePosNormalized { get; }
        
        public event Action<Vector2> OnDrag;
        public event Action<Vector2> OnDragDelta;
        public event Action<Vector2> OnInputDown;
        public event Action<Vector2> OnInputUp;
    }
}