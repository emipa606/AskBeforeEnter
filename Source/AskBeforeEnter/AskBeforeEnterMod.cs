using Mlie;
using UnityEngine;
using Verse;

namespace AskBeforeEnter;

[StaticConstructorOnStartup]
internal class AskBeforeEnterMod : Mod
{
    /// <summary>
    ///     The instance of the askBeforeEnterSettings to be read by the mod
    /// </summary>
    public static AskBeforeEnterMod Instance;

    private static string currentVersion;

    /// <summary>
    ///     The private askBeforeEnterSettings
    /// </summary>
    public readonly AskBeforeEnterSettings AskBeforeEnterSettings;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public AskBeforeEnterMod(ModContentPack content) : base(content)
    {
        Instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
        AskBeforeEnterSettings = GetSettings<AskBeforeEnterSettings>();
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
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Gap();
        listingStandard.Label("ABE.Title".Translate());
        listingStandard.CheckboxLabeled("ABE.Traders".Translate(), ref AskBeforeEnterSettings.Traders,
            "ABE.Traders.Tooltip".Translate());
        if (ModLister.RoyaltyInstalled)
        {
            listingStandard.CheckboxLabeled("ABE.TributeCollector".Translate(),
                ref AskBeforeEnterSettings.TributeCollector, "ABE.TributeCollector.Tooltip".Translate());
        }

        listingStandard.CheckboxLabeled("ABE.Travelers".Translate(), ref AskBeforeEnterSettings.Travelers,
            "ABE.Travelers.Tooltip".Translate());
        if (ModLister.GetActiveModWithIdentifier("Orion.Hospitality", true) == null)
        {
            listingStandard.CheckboxLabeled("ABE.Visitors".Translate(), ref AskBeforeEnterSettings.Visitors,
                "ABE.Visitors.Tooltip".Translate());
        }
        else
        {
            listingStandard.Gap();
            listingStandard.Label("ABE.Hospitality".Translate());
        }

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("ABE.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
        AskBeforeEnterSettings.Write();
    }
}