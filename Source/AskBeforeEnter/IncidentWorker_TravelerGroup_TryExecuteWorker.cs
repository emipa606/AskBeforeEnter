using HarmonyLib;
using RimWorld;

namespace AskBeforeEnter;

[HarmonyPatch(typeof(IncidentWorker_TravelerGroup), "TryExecuteWorker", typeof(IncidentParms))]
public static class IncidentWorker_TravelerGroup_TryExecuteWorker
{
    public static bool Prefix(IncidentParms parms, IncidentWorker_TravelerGroup __instance)
    {
        if (!AskBeforeEnterMod.instance.AskBeforeEnterSettings.Travelers || parms.forced)
        {
            return true;
        }

        Main.AskDialog(parms, __instance);

        return false;
    }
}