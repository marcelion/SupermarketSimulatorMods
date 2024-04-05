using HarmonyLib;

namespace GameBoost.Patches
{
    [HarmonyPatch(typeof(CustomerSpawnSettingManager))]
    internal static class CustomerSpawnPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(CustomerSpawnSettingManager.GetCustomerSpawningTime))]
        public static void GetCustomerSpawningTime(ref float __result)
        {
            __result *= Plugin.CustomerSpawnMultiplier.Value;
        }
    }
}
