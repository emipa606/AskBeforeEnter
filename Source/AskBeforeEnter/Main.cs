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

    public static void AskDialog(IncidentParms parms, IncidentWorker incident)
    {
        var text = $"ABE.{incident.def.defName}".Translate();
        if (text.RawText.StartsWith("ABE."))
        {
            text = "ABE.GenericGroup".Translate();
        }

        var diaNode = new DiaNode(text);
        var optionSendAway = new DiaOption("ABE.SendAway".Translate()) { action = null, resolveTree = true };
        diaNode.options.Add(optionSendAway);
        if (incident.def.defName != "TravelerGroup")
        {
            var optionLater = new DiaOption("ABE.Later".Translate())
            {
                action = () =>
                    Find.Storyteller.incidentQueue.Add(incident.def,
                        Find.TickManager.TicksGame + (GenDate.TicksPerHour * 6), parms),
                resolveTree = true
            };
            diaNode.options.Add(optionLater);
        }

        var optionEnter = new DiaOption("ABE.Enter".Translate())
        {
            action = () =>
            {
                parms.forced = true;
                incident.TryExecute(parms);
            },
            resolveTree = true
        };
        diaNode.options.Add(optionEnter);

        Find.WindowStack.Add(new Dialog_NodeTree(diaNode, true, true, "ABE.Approching".Translate()));
    }
}