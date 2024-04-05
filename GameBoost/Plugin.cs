using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using MyBox;
using System;

namespace GameBoost
{
    [BepInPlugin(PluginName, PluginName, PluginVersion)]
    [BepInProcess("Supermarket Simulator.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginName = "GameBoost";

        public const string PluginVersion = "1.0.0";

        internal static ConfigEntry<KeyboardShortcut> ReloadKeyboardShortcut { get; set; }

        internal static ConfigEntry<float> CustomerSpawnMultiplier { get; set; }

        internal static ConfigEntry<float> CheckoutIncomeMultiplier { get; set; }

        internal static ConfigEntry<float> StorePointMultiplier { get; set; }

        public Plugin()
        {
            ReloadKeyboardShortcut = Config.Bind("GameBoost", nameof(ReloadKeyboardShortcut), new KeyboardShortcut(UnityEngine.KeyCode.G, UnityEngine.KeyCode.LeftControl), "The keyboard shortcut to reload the settings.");
            CustomerSpawnMultiplier = Config.Bind("GameBoost", nameof(CustomerSpawnMultiplier), 1.0f, "The multiplier for the spawn time of customers. E.g.: A value of 0.5 means that the spawn time will be halfed.");
            CheckoutIncomeMultiplier = Config.Bind("GameBoost", nameof(CheckoutIncomeMultiplier), 1.0f, "The multiplier for the money received by customer checkouts. E.g.: A value of 2.0 means that you will receive double the money when a customers pays.");
            StorePointMultiplier = Config.Bind("GameBoost", nameof(StorePointMultiplier), 1.0f, "The multiplier for the earned store points. The amoutn of lost of store points is not affected. E.g.: A value of 2.0 means that you will receive double the amount of store points.");
        }

        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginName} is loaded!");
            PrintCurrentSettings();

            var harmony = new Harmony(PluginName);
            harmony.PatchAll();
        }

        private void PrintCurrentSettings()
        {
            Logger.LogInfo($"{nameof(CustomerSpawnMultiplier)} is set to {CustomerSpawnMultiplier.Value}");
            Logger.LogInfo($"{nameof(CheckoutIncomeMultiplier)} is set to {CheckoutIncomeMultiplier.Value}");
            Logger.LogInfo($"{nameof(StorePointMultiplier)} is set to {StorePointMultiplier.Value}");
        }

        private void Update()
        {
            if(ReloadKeyboardShortcut.Value.IsDown())
            {
                Logger.LogInfo($"Reloading settings!");
                Config.Reload();
                PrintCurrentSettings();
            }
        }
    }
}