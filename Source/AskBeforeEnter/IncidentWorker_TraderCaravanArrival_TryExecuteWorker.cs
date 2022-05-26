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

        Main.AskDialog(parms, __instance);

        return false;
    }
}