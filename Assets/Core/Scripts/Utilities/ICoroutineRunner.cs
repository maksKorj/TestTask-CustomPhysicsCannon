using System.Collections;
using UnityEngine;

namespace Core.Scripts.Utilities
{
    public interface ICoroutineRunner
    {
        public Coroutine TryStartCoroutine(IEnumerator coroutine);
        public void StopCoroutine(Coroutine coroutine);
    }
}