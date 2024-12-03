using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.Gameplay
{
    public class GameplayObjectProvider : MonoBehaviour
    {
        #region Editor
        [Button]
        private void setRefs()
        {
            //
        }

        private void OnValidate()
        {
            setRefs();
        }

        #endregion
    }
}
