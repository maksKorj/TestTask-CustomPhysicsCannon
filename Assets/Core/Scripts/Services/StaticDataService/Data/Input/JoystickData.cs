using System;

namespace Core.Scripts.Services.StaticDataService.Data.Input
{
    [Serializable]
    public class JoystickData
    {
        public bool IsShowVisuals = false;

        public bool IsStatic = false;

        public bool IsResetDirection = false;

        public float Radius = 120;
        public float HandleRadiusMultiplier = .25f;
    }
}