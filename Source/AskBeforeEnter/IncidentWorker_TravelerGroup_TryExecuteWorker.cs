using HarmonyLib;
using RimWorld;

namespace AskBeforeEnter;

[HarmonyPatch(typeof(IncidentWorker_TravelerGroup), "TryExecuteWorker", typeof(IncidentParms))]
public static class IncidentWorker_TravelerGroup_TryExecuteWorker
{
    public static bool Prefix(IncidentParms parms, IncidentWorker_TravelerGroup __instance)
    {
        if (parms.forced)
        {
            return true;
        }

        if (!AskBeforeEnterMod.instance.AskBeforeEnterSettings.Travelers)
        {
            return true;
        }


        Main.AskDialog(parms, __instance);

        return false;
    }
}