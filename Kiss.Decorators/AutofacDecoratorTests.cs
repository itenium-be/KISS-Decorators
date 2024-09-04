using Autofac;
using Kiss.Decorators.App;
using Kiss.Decorators.Domain;

namespace Kiss.Decorators
{
    public class AutofacDecoratorTests
    {
        [Fact]
        public void RegisterDecorator_InjectsTheInterfaceDecorated()
        {
            var container = SetupAutofac.Init();
            var controller = container.Resolve<MyController>();

            controller.Post();
            
            // You'd expect this to be "1" but it's 10!?
            // One needs to look at the Autofac registration before this makes sense...
            Assert.Equal(10, Logger.LogCount);
        }
    }
}