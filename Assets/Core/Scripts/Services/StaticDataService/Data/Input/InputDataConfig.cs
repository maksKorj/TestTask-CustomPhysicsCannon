using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.StaticDataService.Data.Input
{
    public class InputDataConfig : ScriptableObject
    {
        [field: Title("Touch")]
        [field: SerializeField] public Vector2 DragSensitivity { get; private set; } = new Vector2(1, 1);
        [field: SerializeField] public bool CalculateMultiTouch { get; private set; } = false;

        [field: Title("Joystic")]
        [field: SerializeField] public bool IsUseJoystick { get; private set; }
        [field: SerializeField, ShowIf(nameof(IsUseJoystick))] public JoystickData Joystick { get; private set; }

        [field: Title("Interaction")]
        [field: SerializeField] public bool CheckInteraction { get; private set; }
        [field: SerializeField] public bool CheckDragging { get; private set; }
        [field: SerializeField, ShowIf(nameof(NeedInteraction))] public InteractionInputData InteractionInputData { get; private set; }

        public bool NeedInteraction => CheckInteraction || CheckDragging;
    }
}