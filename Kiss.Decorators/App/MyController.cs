using Kiss.Decorators.App;

namespace Kiss.Decorators.Domain;

/// <summary>
/// Fake Controller with Fake Post Action Method
/// </summary>
public class MyController
{
    private readonly IDoer _doer;

    public MyController(IDoer doer)
    {
        _doer = doer;
    }

    public void Post()
    {
        _doer.DoIt();
    }
}