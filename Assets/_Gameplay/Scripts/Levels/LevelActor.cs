using Core.Scripts.Services;
using UnityEngine;

namespace _Gameplay.Scripts.Levels
{
    public abstract class LevelActor : MonoBehaviour
    {
        public abstract void Init(IServiceLocator serviceLocator);
    }
}