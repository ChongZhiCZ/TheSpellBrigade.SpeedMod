using UnityEngine;

namespace SpellBrigadeSpeedMod
{
    public class SpeedDisplay : MonoBehaviour
    {
        private GUIStyle textStyle;
        private bool styleInitialized = false;

        public SpeedDisplay(System.IntPtr ptr) : base(ptr) { }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void InitializeStyle()
        {
            if (styleInitialized) return;

            textStyle = new GUIStyle();
            textStyle.fontSize = 20;
            textStyle.normal.textColor = Color.white;
            textStyle.alignment = TextAnchor.UpperRight;

            // Add shadow/outline for better visibility
            textStyle.fontStyle = FontStyle.Bold;

            styleInitialized = true;
        }

        private void OnGUI()
        {
            InitializeStyle();

            float currentSpeed = Time.timeScale;
            string displayText = $"Speed: {currentSpeed:F1}x";

            // Position in top-right corner with padding
            float width = 150f;
            float height = 30f;
            float padding = 10f;

            Rect rect = new Rect(
                Screen.width - width - padding,
                padding,
                width,
                height
            );

            // Draw shadow for better visibility
            GUI.color = new Color(0, 0, 0, 0.5f);
            GUI.Label(new Rect(rect.x + 2, rect.y + 2, rect.width, rect.height), displayText, textStyle);

            // Draw main text
            GUI.color = Color.white;
            GUI.Label(rect, displayText, textStyle);
        }
    }
}
