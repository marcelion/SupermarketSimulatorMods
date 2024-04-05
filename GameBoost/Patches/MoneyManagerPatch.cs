using HarmonyLib;

namespace GameBoost.Patches
{
    [HarmonyPatch(typeof(MoneyManager))]
    internal static class MoneyManagerPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(MoneyManager.MoneyTransition))]
        public static void MoneyTransition(ref float amount, ref MoneyManager.TransitionType type)
        {
            if (type == MoneyManager.TransitionType.CHECKOUT_INCOME)
            {
                amount *= Plugin.CheckoutIncomeMultiplier.Value;
            }
        }
    }
}
