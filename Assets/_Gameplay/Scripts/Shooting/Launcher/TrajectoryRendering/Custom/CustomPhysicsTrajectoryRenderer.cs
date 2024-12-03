using _Gameplay.Scripts.Shooting.PhysicsTypes.Custom;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering.Custom
{
    public class CustomPhysicsTrajectoryRenderer : ITrajectoryRenderer
    {
        private readonly int m_TrajectorySegments;
        private readonly ITrajectoryRenderingContext m_Context;
        private readonly CustomPhysicsSettings m_Settings;

        public CustomPhysicsTrajectoryRenderer(int trajectorySegments, ITrajectoryRenderingContext context, CustomPhysicsSettings settings)
        {
            m_TrajectorySegments = trajectorySegments;
            m_Context = context;
            m_Settings = settings;
        }
        
        public void DrawTrajectory(float currentPower)
        {
            var lineRenderer = m_Context.LineRenderer;
            lineRenderer.positionCount = m_TrajectorySegments;

            var currentPosition = m_Context.FirePoint.position;
            var currentVelocity = m_Context.FirePoint.forward * currentPower;

            int segmentCount = 0;

            for (var i = 0; i < m_TrajectorySegments; i++)
            {
                lineRenderer.SetPosition(segmentCount, currentPosition);
                segmentCount++;

                var nextPosition = currentPosition + currentVelocity * m_Settings.TimeStep 
                                                   + m_Settings.Gravity * (0.5f * m_Settings.TimeStep * m_Settings.TimeStep);

                if (Physics.Linecast(currentPosition, nextPosition, out var hit, m_Settings.CollisionMask))
                {
                    if(segmentCount >= m_TrajectorySegments)
                        break;
                    
                    lineRenderer.SetPosition(segmentCount, hit.point); 
                    segmentCount++;
                    break; 
                }

                currentPosition = nextPosition;
                currentVelocity += m_Settings.Gravity * m_Settings.TimeStep;
            }

            lineRenderer.positionCount = segmentCount;
        }
    }
}