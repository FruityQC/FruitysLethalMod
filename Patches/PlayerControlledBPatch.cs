using GameNetcodeStuff;
using HarmonyLib;
using LethalCompanyInputUtils;
using LethalCompanyInputUtils.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitysLethalMod.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControlledBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void ModifySprint(ref float ___sprintMeter, ref bool ___isSprinting, ref float ___sprintMultiplier)
        {
            // Infinite Sprint
            ___sprintMeter = 1f;

            // Faster Sprint when sprinting
            float sprintMultiplier = FruitysModBase.configSprinting;
            if (___isSprinting)
            {
                ___sprintMultiplier = sprintMultiplier;
            }
        }
    }
}
