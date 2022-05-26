using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace AskBeforeEnter;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("Mlie.AskBeforeEnter").PatchAll(Assembly.GetExecutingAssembly());
    }

    public static void AskDialog(IncidentParms parms, IncidentWorker_TraderCaravanArrival incident)
    {
        parms.forced = true;
        Find.WindowStack.Add(new Dialog_MessageBox(
            "ABE.CaravanArrival".Translate(),
            "ABE.SendAway".Translate(), null, "ABE.Enter".Translate(),
            delegate { incident.TryExecute(parms); }));
    }
}