namespace Kiss.Decorators.App;

public class LoopingDoer : IDoer
{
    private readonly IDoer _inner;

    public LoopingDoer(IDoer inner)
    {
        _inner = inner;
    }

    public void DoIt()
    {
        for (int i = 0; i < 10; i++)
        {
            _inner.DoIt();
        }
    }
}