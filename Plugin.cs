using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace EasyTame
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Rune Factory 5.exe")]
    public class Plugin : BasePlugin
    {
        internal static new ManualLogSource Log;
        private Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

        public override void Load()
        {
            // Plugin startup logic
            Log = base.Log;
            harmony.PatchAll();
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_NAME} is loaded!");
        }
    }

    [HarmonyPatch(typeof(Calc.CalcStatus), nameof(Calc.CalcStatus.CalcTame))]
    public class CalcTamePatch
    {
        static bool Prefix(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}
