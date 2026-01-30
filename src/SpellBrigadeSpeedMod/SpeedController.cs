using BepInEx;
using BepInEx.Unity.IL2CPP;
using UnityEngine;

namespace SpellBrigadeSpeedMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class SpeedController : BasePlugin
    {
        private float currentSpeed = 1.0f;
        private const float MIN_SPEED = 1.0f;
        private const float MAX_SPEED = 10.0f;
        private const float SPEED_INCREMENT = 0.5f;

        public override void Load()
        {
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Log.LogInfo($"Speed control initialized. Current speed: {currentSpeed}x");

            // Register Update callback
            AddComponent<SpeedControllerBehaviour>();
        }
    }

    public class SpeedControllerBehaviour : MonoBehaviour
    {
        private SpeedController controller;

        public SpeedControllerBehaviour(System.IntPtr ptr) : base(ptr) { }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            // Input detection will be added in next task
        }
    }
}
