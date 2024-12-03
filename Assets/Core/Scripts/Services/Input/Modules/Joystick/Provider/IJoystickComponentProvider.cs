using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Services.Input.Modules.Joystick.Provider
{
    public interface IJoystickComponentProvider
    {
        GameObject GameObject { get; }
        Image JoystickHandle { get; }
        Image JoystickOutline { get; }
    }
}