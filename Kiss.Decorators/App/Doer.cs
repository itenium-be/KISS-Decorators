namespace Kiss.Decorators.App;

public class Doer : IDoer
{
    public void DoIt()
    {
        Logger.LogCount++;
    }
}