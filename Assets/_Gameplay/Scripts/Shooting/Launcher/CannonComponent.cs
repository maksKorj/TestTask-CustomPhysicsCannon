using _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering;
using Unity.Collections;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher
{
    public class CannonComponent : MonoBehaviour, ITrajectoryRenderingContext
    {
        [field: SerializeField, ReadOnly] public Transform Barrel {get; private set;}
        [field: SerializeField, ReadOnly] public Transform FirePoint {get; private set;}
        [field: SerializeField, ReadOnly] public LineRenderer LineRenderer {get; private set;}
    }
}