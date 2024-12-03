using UnityEditor;
using UnityEngine;

namespace Core.Scripts.Services.StaticDataService.Editor
{
    public class GameConfigEditor : MonoBehaviour
    {
        [MenuItem("SDK/Select GameConfig #%t", false, -2)]
        public static void SelectGameConfig()
        {
            Selection.activeObject = Resources.Load<GameStaticDataService>("GameStaticDataService");
        }
    }
}