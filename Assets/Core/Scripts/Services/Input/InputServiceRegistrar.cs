using Core.Scripts.Services.Input.Base.Data;
using Core.Scripts.Services.Input.Modules.Interaction;
using Core.Scripts.Services.Input.Modules.Joystick;
using Core.Scripts.Services.Input.Modules.MultiTouch;
using Core.Scripts.Services.Input.Provider;
using Core.Scripts.Services.Resettable;
using Core.Scripts.Services.StaticDataService;
using Core.Scripts.Services.StaticDataService.Data.Input;
using Core.Scripts.Services.TickProcessor;
using Core.Scripts.Services.UserInterface;
using UnityEngine;

namespace Core.Scripts.Services.Input
{
    public class InputServiceRegistrar
    {
        private readonly IServiceLocator m_ServiceLocator;
        
        private InputDataConfig m_InputData;

        public InputServiceRegistrar(IServiceLocator serviceLocator)
        {
            m_ServiceLocator = serviceLocator;
        }

        public IInputService RegisterService(IInputComponentProvider inputComponentProvider, Camera camera)
        {
            m_InputData = m_ServiceLocator.GetSingle<IGameStaticDataService>().Input;

            var screenData = createScreenData();

            var inputService = new InputService(m_InputData.DragSensitivity, screenData.FinalDPI, inputComponentProvider.InputListener);
            
            tryAddMultiTouch(inputService, screenData.FinalDPI);
            tryAddJoystick(inputService, screenData, inputComponentProvider);
            tryAddInteractionInput(inputService, camera);

            m_ServiceLocator.GetSingle<IResettableService>().Add(inputService);
            m_ServiceLocator.GetSingle<ITickProcessorService>().AddInput(inputService);

            return inputService;
        }

        private void tryAddMultiTouch(InputService inputService, float finalDPI) 
        {
            if (m_InputData.CalculateMultiTouch == false)
                return;

            inputService.AddModule(new MultiTouchModule(finalDPI));
        }

        #region Joystick
        private void tryAddJoystick(InputService inputService, ScreenData screenData, IInputComponentProvider componentProvider)
        {
            if (m_InputData.IsUseJoystick == false)
                return;

            var joystick = new JoystickModule(m_InputData, screenData.FinalDPI);
            tryAddUiJoystic(joystick, screenData, componentProvider);

            inputService.AddModule(joystick);
        }

        private void tryAddUiJoystic(JoystickModule joystick, ScreenData screenData, IInputComponentProvider componentProvider)
        {
            if (m_InputData.Joystick.IsShowVisuals == false)
            {
                return;
            }
            
            var userInterfaceService = m_ServiceLocator.GetSingle<IUserInterfaceService>();

            var uiJoystick = new JoystickUI(componentProvider.JoystickComponentProvider, 
                userInterfaceService.CanvasProvider,
                screenData,
                m_InputData.Joystick);

            joystick.AddJoystickUi(uiJoystick);
        }
        #endregion

        private void tryAddInteractionInput(InputService inputService, Camera camera)
        {
            if (m_InputData.NeedInteraction == false)
                return;

            inputService.AddModule(new InteractionInputModule(camera, m_InputData));
        }

        private ScreenData createScreenData()
        {
            var screenData = new ScreenData();
            screenData.CalculateData();

            return screenData;
        }
    }
}
