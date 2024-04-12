using HarmonyLib;
using RimWorld;

namespace AskBeforeEnter;

[HarmonyPatch(typeof(IncidentWorker_VisitorGroup), "TryExecuteWorker", typeof(IncidentParms))]
public static class IncidentWorker_VisitorGroup_TryExecuteWorker
{
    public static bool Prefix(IncidentParms parms, IncidentWorker_VisitorGroup __instance)
    {
        if (parms.forced)
        {
            return true;
        }

        if (!AskBeforeEnterMod.instance.AskBeforeEnterSettings.Visitors)
        {
            return true;
        }

        Main.AskDialog(parms, __instance);

        return false;
    }
}