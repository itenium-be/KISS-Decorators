using Autofac;
using Kiss.Decorators.Domain;

namespace Kiss.Decorators.App;

public static class SetupAutofac
{
    public static IContainer Init()
    {
        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterType<Doer>().As<IDoer>();
        containerBuilder.RegisterDecorator<LoopingDoer, IDoer>();
        containerBuilder.RegisterType<MyController>();

        return containerBuilder.Build();
    }
}