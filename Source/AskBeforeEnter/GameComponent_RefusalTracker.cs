using Verse;

namespace AskBeforeEnter;

public class GameComponent_RefusalTracker : GameComponent
{
    public int guestsRefused;

    public GameComponent_RefusalTracker(Game game)
    {
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref guestsRefused, "guestsRefused");
    }
}