using System;
using AchievementsExpanded;
using Verse;

namespace AskBeforeEnter;

public class RefusalTracker : TrackerBase
{
    public int count = 1;

    [Unsaved] protected int triggeredCount; //Only for display

    public RefusalTracker()
    {
    }

    public RefusalTracker(RefusalTracker reference) : base(reference)
    {
        count = reference.count;
    }

    public override string Key => "RefusalCurrentTracker";

    public override Func<bool> AttachToLongTick => Trigger;

    protected override string[] DebugText => new[] { $"Count: {count}" };

    public override (float percent, string text) PercentComplete => count > 1
        ? ((float)triggeredCount / count,
            $"{(float)triggeredCount} / {count}")
        : base.PercentComplete;


    public override bool UnlockOnStartup => Trigger();


    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref count, "count", 1);
    }

    public override bool Trigger()
    {
        base.Trigger();
        triggeredCount = Current.Game.GetComponent<GameComponent_RefusalTracker>().guestsRefused;

        return triggeredCount >= count;
    }
}