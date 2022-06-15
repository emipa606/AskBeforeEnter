using HarmonyLib;
using RimWorld;

namespace AskBeforeEnter;

[HarmonyPatch(typeof(IncidentWorker_VisitorGroup), "TryExecuteWorker", typeof(IncidentParms))]
public static class IncidentWorker_VisitorGroup_TryExecuteWorker
{
    public static bool Prefix(IncidentParms parms, IncidentWorker_VisitorGroup __instance)
    {
        if (!AskBeforeEnterMod.instance.AskBeforeEnterSettings.Visitors || parms.forced)
        {
            return true;
        }

        Main.AskDialog(parms, __instance);

        return false;
    }
}