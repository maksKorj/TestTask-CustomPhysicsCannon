using Core.Scripts.Services.Input.Base;
using Core.Scripts.Services.Input.Modules.Joystick.Provider;

namespace Core.Scripts.Services.Input.Provider
{
    public interface IInputComponentProvider
    {
        InputListener InputListener { get; }
        JoystickComponentProvider JoystickComponentProvider { get; }
    }
}