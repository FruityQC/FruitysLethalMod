using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using FruitysLethalMod.Patches;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitysLethalMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class FruitysModBase : BaseUnityPlugin
    {
        private const string modGUID = "Fruity.LethalMod";
        private const string modName = "FruitysLethalMod";
        private const string modVersion = "0.0.1";

        public static ConfigEntry<float> configSprintingMultiplier;
        public static ConfigEntry<bool> configInfiniteSprint;
        
        private readonly Harmony harmony = new Harmony(modGUID);

        private static FruitysModBase Instance;

        internal ManualLogSource mls;

        // 

        void Awake()
        {
            if (Instance == null) 
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Fruitys mod has loaded");
    
            harmony.PatchAll(typeof(FruitysModBase));

            harmony.PatchAll(typeof(PlayerControlledBPatch));
            harmony.PatchAll(typeof(JetpackItemPatch));

            //Config Shits
            configSprintingMultiplier = Config.Bind("Sprinting", "SprintMultiplier", 2f, "The multiplier you want applied when sprinting."); //Category, Name, Value, Desc
            configInfiniteSprint = Config.Bind("Sprinting", "InfiniteSprint", true, "Infinitely sprint?"); //Category, Name, Value, Desc 
        }
    }
}