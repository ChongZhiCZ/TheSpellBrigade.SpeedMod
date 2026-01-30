using BepInEx;
using BepInEx.Unity.IL2CPP;
using UnityEngine;

namespace SpellBrigadeSpeedMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class SpeedController : BasePlugin
    {
        public override void Load()
        {
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Log.LogInfo($"Speed control initialized. Current speed: 1.0x");

            // Create persistent GameObject with both components
            var go = new GameObject("SpeedModController");
            GameObject.DontDestroyOnLoad(go);
            go.AddComponent<SpeedControllerBehaviour>();
            go.AddComponent<SpeedDisplay>();

            Log.LogInfo("Speed display UI initialized");
        }
    }

    public class SpeedControllerBehaviour : MonoBehaviour
    {
        private float currentSpeed = 1.0f;
        private const float MIN_SPEED = 1.0f;
        private const float MAX_SPEED = 10.0f;
        private const float SPEED_INCREMENT = 0.5f;

        public SpeedControllerBehaviour(System.IntPtr ptr) : base(ptr) { }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SetSpeed(1.0f); // Ensure we start at normal speed
        }

        private void Update()
        {
            // Increase speed: Numpad+ or =
            if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals))
            {
                IncreaseSpeed();
            }

            // Decrease speed: Numpad- or -
            if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
            {
                DecreaseSpeed();
            }

            // Reset speed: Backspace or R
            if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.R))
            {
                ResetSpeed();
            }
        }

        private void IncreaseSpeed()
        {
            float newSpeed = currentSpeed + SPEED_INCREMENT;
            SetSpeed(Mathf.Min(newSpeed, MAX_SPEED));
        }

        private void DecreaseSpeed()
        {
            float newSpeed = currentSpeed - SPEED_INCREMENT;
            SetSpeed(Mathf.Max(newSpeed, MIN_SPEED));
        }

        private void ResetSpeed()
        {
            SetSpeed(1.0f);
        }

        private void SetSpeed(float speed)
        {
            currentSpeed = speed;
            Time.timeScale = currentSpeed;
            Debug.Log($"Speed changed to: {currentSpeed}x");
        }
    }
}
