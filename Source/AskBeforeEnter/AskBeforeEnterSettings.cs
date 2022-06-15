using Verse;

namespace AskBeforeEnter;

/// <summary>
///     Definition of the askBeforeEnterSettings for the mod
/// </summary>
internal class AskBeforeEnterSettings : ModSettings
{
    public bool Traders = true;
    public bool Travelers = true;
    public bool TributeCollector = true;
    public bool Visitors = true;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref Traders, "Traders", true);
        Scribe_Values.Look(ref TributeCollector, "TributeCollector", true);
        Scribe_Values.Look(ref Visitors, "Visitors", true);
        Scribe_Values.Look(ref Travelers, "Travelers", true);
    }
}