using HarmonyLib;
using RimWorld;

namespace AskBeforeEnter;

[HarmonyPatch(typeof(IncidentWorker_TraderCaravanArrival), "TryExecuteWorker", typeof(IncidentParms))]
public static class IncidentWorker_TraderCaravanArrival_TryExecuteWorker
{
    public static bool Prefix(IncidentParms parms, IncidentWorker_TraderCaravanArrival __instance)
    {
        if (parms.forced)
        {
            return true;
        }

        if (!AskBeforeEnterMod.instance.AskBeforeEnterSettings.TributeCollector &&
            __instance.def.defName == "CaravanArrivalTributeCollector")
        {
            return true;
        }

        if (!AskBeforeEnterMod.instance.AskBeforeEnterSettings.Traders)
        {
            return true;
        }

        Main.AskDialog(parms, __instance);

        return false;
    }
}