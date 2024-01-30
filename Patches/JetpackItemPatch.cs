using GameNetcodeStuff;
using HarmonyLib;
using LethalCompanyInputUtils;
using LethalCompanyInputUtils.Api;
/* TODO
 * [X] Infinite battery
 * [] No Explosion
 */

namespace FruitysLethalMod.Patches
{
    [HarmonyPatch(typeof(JetpackItem))]
    internal class JetpackItemPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void ModifyJetpack(ref Battery ___insertedBattery)
        {
            ___insertedBattery.charge = 1.0f;
        }

    }
}