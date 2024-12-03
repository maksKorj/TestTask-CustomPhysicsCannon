using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering
{
    public interface ITrajectoryRenderingContext
    {
        public Transform Barrel { get; }
        public Transform FirePoint { get; }
        public LineRenderer LineRenderer { get; }
    }
}