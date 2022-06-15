using HarmonyLib;
using RimWorld;

namespace AskBeforeEnter;

[HarmonyPatch(typeof(IncidentWorker_TraderCaravanArrival), "TryExecuteWorker", typeof(IncidentParms))]
public static class IncidentWorker_TraderCaravanArrival_TryExecuteWorker
{
    public static bool Prefix(IncidentParms parms, IncidentWorker_TraderCaravanArrival __instance)
    {
        if (!AskBeforeEnterMod.instance.AskBeforeEnterSettings.Traders && (
                !AskBeforeEnterMod.instance.AskBeforeEnterSettings.TributeCollector ||
                __instance.def.defName != "CaravanArrivalTributeCollector") ||
            parms.forced)
        {
            return true;
        }

        Main.AskDialog(parms, __instance);

        return false;
    }
}