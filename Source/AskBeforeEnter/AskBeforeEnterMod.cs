using UnityEngine;
using Verse;

namespace AskBeforeEnter;

[StaticConstructorOnStartup]
internal class AskBeforeEnterMod : Mod
{
    /// <summary>
    ///     The instance of the askBeforeEnterSettings to be read by the mod
    /// </summary>
    public static AskBeforeEnterMod instance;

    /// <summary>
    ///     The private askBeforeEnterSettings
    /// </summary>
    private AskBeforeEnterSettings askBeforeEnterSettings;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public AskBeforeEnterMod(ModContentPack content) : base(content)
    {
        instance = this;
    }

    /// <summary>
    ///     The instance-askBeforeEnterSettings for the mod
    /// </summary>
    internal AskBeforeEnterSettings AskBeforeEnterSettings
    {
        get
        {
            if (askBeforeEnterSettings == null)
            {
                askBeforeEnterSettings = GetSettings<AskBeforeEnterSettings>();
            }

            return askBeforeEnterSettings;
        }
        set => askBeforeEnterSettings = value;
    }

    /// <summary>
    ///     The title for the mod-askBeforeEnterSettings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Ask Before Enter";
    }

    /// <summary>
    ///     The askBeforeEnterSettings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.Label("ABE.Title".Translate());
        listing_Standard.CheckboxLabeled("ABE.Traders".Translate(), ref AskBeforeEnterSettings.Traders,
            "ABE.Traders.Tooltip".Translate());
        if (ModLister.RoyaltyInstalled)
        {
            listing_Standard.CheckboxLabeled("ABE.TributeCollector".Translate(),
                ref AskBeforeEnterSettings.TributeCollector, "ABE.TributeCollector.Tooltip".Translate());
        }

        listing_Standard.CheckboxLabeled("ABE.Travelers".Translate(), ref AskBeforeEnterSettings.Travelers,
            "ABE.Travelers.Tooltip".Translate());
        if (ModLister.GetActiveModWithIdentifier("Orion.Hospitality") == null)
        {
            listing_Standard.CheckboxLabeled("ABE.Visitors".Translate(), ref AskBeforeEnterSettings.Visitors,
                "ABE.Visitors.Tooltip".Translate());
        }
        else
        {
            listing_Standard.Gap();
            listing_Standard.Label("ABE.Hospitality".Translate());
        }

        listing_Standard.End();
        AskBeforeEnterSettings.Write();
    }
}