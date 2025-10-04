using HarmonyLib;
using RimWorld;

namespace AskBeforeEnter;

[HarmonyPatch(typeof(IncidentWorker_Raid), "TryExecuteWorker", typeof(IncidentParms))]
public static class IncidentWorker_Raid_TryExecuteWorker
{
    public static bool Prefix(IncidentParms parms, IncidentWorker_Raid __instance)
    {
        if (parms.forced)
        {
            return true;
        }

        if (!AskBeforeEnterMod.Instance.AskBeforeEnterSettings.Allies)
        {
            return true;
        }

        if (__instance is not IncidentWorker_RaidFriendly friendlyRaid)
        {
            return true;
        }

        Main.AskDialog(parms, friendlyRaid);

        return false;
    }
}