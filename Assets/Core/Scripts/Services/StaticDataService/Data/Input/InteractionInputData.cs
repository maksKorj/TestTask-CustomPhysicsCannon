using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.StaticDataService.Data.Input
{
    [Serializable]
    public class InteractionInputData
    {
        [field: SerializeField] public float CheckingDistance { get; private set; } = 40f;
        
        [field: Title("Layers")]
        [field: SerializeField] public LayerData Interactable { get; private set; }
        [field: SerializeField] public LayerData Overlay { get; private set; }
    }

    [Serializable]
    public class LayerData
    {
        [field: SerializeField] public LayerMask LayerMask { get; private set; }
        [field: SerializeField, ReadOnly] public int LayerInt { get; private set; }

        [Button]
        private void setupLayerInt()
        {
            LayerInt = (int)Mathf.Log(LayerMask.value, 2);
        }
    }
}
