using UnityEngine;

namespace Core.Scripts.Services.Level.Level
{
    public abstract class LevelComponentBase : MonoBehaviour
    {
        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public abstract LevelBase CreateLevel(IServiceLocator serviceLocator);
    }
}
