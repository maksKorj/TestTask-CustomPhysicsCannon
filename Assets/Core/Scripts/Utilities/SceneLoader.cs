using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Scripts.Utilities
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner m_CoroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            m_CoroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onLoaded = null)
        {
            m_CoroutineRunner.TryStartCoroutine(loadScene(name, onLoaded));
        }

        private IEnumerator loadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}