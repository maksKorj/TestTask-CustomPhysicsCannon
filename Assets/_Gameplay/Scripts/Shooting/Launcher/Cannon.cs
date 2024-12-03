using _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering;

namespace _Gameplay.Scripts.Shooting.Launcher
{
    public class Cannon
    {
        private readonly ITrajectoryRenderingContext m_Component;
        private readonly ITrajectoryRenderer m_TrajectoryRenderer;

        public Cannon(ITrajectoryRenderingContext component, ITrajectoryRenderer trajectoryRenderer)
        {
            m_Component = component;
            m_TrajectoryRenderer = trajectoryRenderer;
        }
    }
}
