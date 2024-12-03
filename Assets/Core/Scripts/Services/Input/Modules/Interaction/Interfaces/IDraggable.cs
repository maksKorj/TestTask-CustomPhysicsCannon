using UnityEngine;

namespace Core.Scripts.Services.Input.Modules.Interaction.Interfaces
{
    public interface IDraggable
    {
        public void Grab();
        public void Drag(Vector3 position);
        public void Release(bool isTarget = false);
    }
}
