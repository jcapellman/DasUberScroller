using DasUberScroller.lib.PlatformAbstractions;

using Microsoft.Extensions.DependencyInjection;

namespace DasUberScroller.lib.DI
{
    public class DIContainer
    {
        private static ServiceProvider _container;

        public static T GetDIService<T>() => _container.GetService<T>();

        public static void Initialize(IFileSystem fileSystem)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton(fileSystem);

            _container = serviceCollection.BuildServiceProvider();
        }
    }
}