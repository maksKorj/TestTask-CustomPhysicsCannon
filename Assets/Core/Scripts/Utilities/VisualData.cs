using System;
using UnityEngine;

namespace Core.Scripts.Utilities
{
    [Serializable]
    public class VisualData<T>
    {
        [field: SerializeField] public T Active { get; private set; }
        [field: SerializeField] public T Passive { get; private set; }
    }
}