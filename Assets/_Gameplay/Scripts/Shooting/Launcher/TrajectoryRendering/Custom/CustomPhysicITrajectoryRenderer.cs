using _Gameplay.Scripts.Shooting.PhysicTypes.Custom;

namespace _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering.Custom
{
    public class CustomPhysicITrajectoryRenderer : ITrajectoryRenderer
    {
        private readonly int m_TrajectorySegments;
        private readonly ITrajectoryRenderingContext m_Context;
        private readonly CustomPhysicsSettings m_Settings;

        public CustomPhysicITrajectoryRenderer(int trajectorySegments, ITrajectoryRenderingContext context, CustomPhysicsSettings settings)
        {
            m_TrajectorySegments = trajectorySegments;
            m_Context = context;
            m_Settings = settings;
        }

        public void DrawTrajectory(float currentForce)
        {
            var lineRenderer = m_Context.LineRenderer;
            lineRenderer.positionCount = m_TrajectorySegments;
            
            var currentPosition = m_Context.FirePoint.position;
            var currentVelocity = m_Context.Barrel.forward * currentForce;

            for (var i = 0; i < m_TrajectorySegments; i++)
            {
                lineRenderer.SetPosition(i, currentPosition);
                currentVelocity += m_Settings.Gravity * (m_Settings.TimeStep / 2);
                currentPosition += currentVelocity * m_Settings.TimeStep; 
            }
        }
    }
}