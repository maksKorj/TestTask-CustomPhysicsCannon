using UnityEngine;

namespace Core.Scripts.Services.Input.Base.Data
{
    [System.Serializable]
    public class ScreenData
    {
        private Vector2 m_OriginalRes;
        private float m_OriginalDPI;

        private Vector2 m_ScreenSizeInch;
        private Vector2 m_ScreenSizeCm;

        private Vector2 m_ScalingVector;
        private float m_Scaling;

        public float FinalDPI { get; private set; }

        public float ScreenDiagonalSizeInches
        {
            get
            {
                CalculateData();
                return m_ScreenSizeInch.magnitude;
            }
        }

        public Vector2 ScreenSizeInch => m_ScreenSizeInch;

        public void CalculateData(bool i_LogData = false)
        {
            m_OriginalRes = new Vector2(Screen.width, Screen.height); ;
            m_OriginalDPI = getDPI();

            #if UNITY_EDITOR
            m_ScalingVector = GameViewEditorRes.GetGameViewScale();
            #else
            m_ScalingVector = Vector3.one;
            #endif
            m_Scaling = (m_ScalingVector.x + m_ScalingVector.y) * .5f;

            if (m_OriginalDPI == 0)
            {
                FinalDPI = 320;
            }
            else
            {
                FinalDPI = Screen.dpi / m_Scaling;
            }

            m_ScreenSizeInch = new Vector2(m_OriginalRes.x / FinalDPI, m_OriginalRes.y / FinalDPI);
            m_ScreenSizeCm = m_ScreenSizeInch * 2.54f;

            if (!i_LogData)
                return;

            Debug.LogError("Original Resolution - " + m_OriginalRes);
            Debug.LogError("Original DPI - " + m_OriginalDPI);
            Debug.LogError("DPI - " + FinalDPI);
            Debug.LogError("Size Inches - " + m_ScreenSizeInch);
            Debug.LogError("Size Cm - " + m_ScreenSizeCm);

            Debug.LogError("Scaling Vector - " + m_ScalingVector);
            Debug.LogError("Scaling - " + m_Scaling);
        }

        private float getDPI()
        {
            #if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass  activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity      = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
     
            AndroidJavaObject metrics = new AndroidJavaObject("android.util.DisplayMetrics");
            activity.Call<AndroidJavaObject>("getWindowManager").Call<AndroidJavaObject>("getDefaultDisplay").Call("getMetrics", metrics);
     
            return (metrics.Get<float>("xdpi") + metrics.Get<float>("ydpi")) * 0.5f;
            #else
            return Screen.dpi;
            #endif
        }

    }
}
