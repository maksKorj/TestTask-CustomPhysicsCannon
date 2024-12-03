using Core.Scripts.Services.Input.Modules.Joystick;
using Core.Scripts.Services.Input.Modules.MultiTouch;
using Core.Scripts.Services.Input.Modules.SimpleInput;

namespace Core.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        public IBaseInput BaseInput { get; }

        public void SetActive(bool value);

        public bool TryGetJoystick(out IJoystick joystick);
        public bool TryGetMultiTouch(out IMultiTouch multiTouch);
    }
}