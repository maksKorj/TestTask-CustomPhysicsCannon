using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.Controlling.Data
{
    [CreateAssetMenu(fileName = nameof(MovementControlSettings), menuName = "Gameplay/" + nameof(MovementControlSettings))]
    public class MovementControlSettings : ScriptableObject
    {
        [field: SerializeField] public MovementAxisData Vertical {get; private set;}
        [field: SerializeField] public MovementAxisData Horizontal {get; private set;}
    }
}