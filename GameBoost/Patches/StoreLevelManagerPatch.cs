using HarmonyLib;
using System;

namespace GameBoost.Patches
{
    [HarmonyPatch(typeof(StoreLevelManager))]
    internal class StoreLevelManagerPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(StoreLevelManager.AddPoint))]
        public static void AddPoint(ref int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            amount = (int)Math.Ceiling(amount * Plugin.StorePointMultiplier.Value);
        }
    }
}
