using UnityEngine;

namespace Core.Scripts.Services.Input.Modules.Joystick
{
    public interface IJoystick
    {
        public Vector2 JoystickDirection { get; }
    }
}