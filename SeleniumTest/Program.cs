using Autofac;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Drivers;
using SeleniumTest.Interfaces;

namespace SeleniumTest
{
    public class Program
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ChromeDriver>().AsSelf().SingleInstance();
            builder.RegisterType<MainController>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<LoginDriver>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AlertCloserDriver>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<PlantDriver>().AsImplementedInterfaces().InstancePerLifetimeScope();
            _container = builder.Build();

            using (_container.BeginLifetimeScope())
            {
                var controller = _container.Resolve<IMainController>();
                controller.Run();
            }
        }
    }
}
