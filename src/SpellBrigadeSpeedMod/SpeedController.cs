using BepInEx;
using BepInEx.Unity.IL2CPP;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;

namespace SpellBrigadeSpeedMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class SpeedController : BasePlugin
    {
        public override void Load()
        {
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Log.LogInfo("本mod免费开源 | This mod is free and open source");
            Log.LogInfo("GitHub: https://github.com/ChongZhiCZ/TheSpellBrigade.SpeedMod");

            // Use BasePlugin.AddComponent to properly register and add the MonoBehaviour
            // This ensures Update() will be called by Unity's message system
            AddComponent<SpeedControllerBehaviour>();
            AddComponent<SpeedDisplay>();

            Log.LogInfo("Speed control initialized. Use Numpad+/- or =/- to change speed, R or Backspace to reset");
        }
    }

    public class SpeedControllerBehaviour : MonoBehaviour
    {
        private float currentSpeed = 1.0f;
        private const float MIN_SPEED = 1.0f;
        private const float MAX_SPEED = 10.0f;
        private const float SPEED_INCREMENT = 0.5f;
        private bool wasPaused = false;

        public SpeedControllerBehaviour(System.IntPtr ptr) : base(ptr) { }

        private void Awake()
        {
            Debug.Log("[SpeedMod] SpeedControllerBehaviour Awake called");
            SetSpeed(1.0f);
        }

        private void Update()
        {
            // Detect if game was paused (Time.timeScale == 0) and is now resuming
            bool isPaused = Time.timeScale == 0f;

            if (wasPaused && !isPaused)
            {
                // Game just resumed from pause, reapply our speed
                Time.timeScale = currentSpeed;
                Debug.Log($"[SpeedMod] Game resumed, reapplied speed: {currentSpeed:F1}x");
            }

            // Detect if Time.timeScale was changed by game (not 0 and not our speed)
            // Allow small tolerance for floating point comparison
            if (!isPaused && Mathf.Abs(Time.timeScale - currentSpeed) > 0.01f)
            {
                Debug.Log($"[SpeedMod] Time.timeScale changed externally from {Time.timeScale:F1} to {currentSpeed:F1}, reapplying");
                Time.timeScale = currentSpeed;
            }

            wasPaused = isPaused;

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
            Debug.Log($"[SpeedMod] Speed changed to: {currentSpeed:F1}x");
        }
    }
}
