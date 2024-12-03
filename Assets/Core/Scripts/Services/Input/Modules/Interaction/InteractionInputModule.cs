using Core.Scripts.Services.Input.Modules.Interaction.Interfaces;
using Core.Scripts.Services.StaticDataService.Data.Input;
using UnityEngine;

namespace Core.Scripts.Services.Input.Modules.Interaction
{
    public class InteractionInputModule
    {
        private readonly bool m_NeedInteraction;
        private readonly bool m_NeedDragging;
        
        private readonly Camera m_MainCamera;
        private readonly InteractionInputData m_Data;

        private Vector3 m_TargetPosition;
        private IDraggable m_CurrentTarget;

        public InteractionInputModule(Camera mainCamera, InputDataConfig config)
        {
            m_NeedInteraction = config.NeedInteraction;
            m_NeedDragging = config.CheckDragging;

            m_MainCamera = mainCamera;
            m_Data = config.InteractionInputData;
        }

        #region Taps
        public void OnInputDown(Vector2 position)
        {
            if (Physics.Raycast(m_MainCamera.ScreenPointToRay(position), out RaycastHit raycastHit, m_Data.CheckingDistance, m_Data.Interactable.LayerMask))
            {
                if(m_NeedInteraction)
                    tryInteract(raycastHit);
                
                if(m_NeedDragging)
                    tryGrab(raycastHit);
            }
        }

        public void OnInputUp(Vector2 position)
        {
            if (m_CurrentTarget == null)
                return;

            var hits = Physics.RaycastAll(m_MainCamera.ScreenPointToRay(position), m_Data.CheckingDistance);
            foreach (var hit in hits)
            {
                if (hit.collider.TryGetComponent(out IDraggableReceiver interactable))
                {
                    interactable.Receive(m_CurrentTarget);
                    m_CurrentTarget = null;

                    return;
                }
            }

            removeTarget();
        }
        #endregion

        #region Loops
        public void Process()
        {
            if (m_CurrentTarget == null)
                return;

            setPosition();

            m_CurrentTarget.Drag(m_TargetPosition);
        }

        private void setPosition()
        {
            if (Physics.Raycast(m_MainCamera.ScreenPointToRay(UnityEngine.Input.mousePosition), out RaycastHit raycastHit, m_Data.CheckingDistance, ~m_Data.Overlay.LayerMask))
            {
                m_TargetPosition = raycastHit.point;
            }
        }
        #endregion

        #region Specific
        private void tryInteract(RaycastHit raycastHit)
        {
            if (raycastHit.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }

        private void tryGrab(RaycastHit raycastHit)
        {
            if (raycastHit.collider.TryGetComponent(out IDraggable draggable))
            {
                grab(draggable);
            }
        }

        protected virtual void grab(IDraggable draggable)
        {
            m_CurrentTarget = draggable;
            m_CurrentTarget.Grab();
        }

        private void removeTarget()
        {
            m_CurrentTarget.Release(false);
            m_CurrentTarget = null;
        }
        #endregion
    }
}
