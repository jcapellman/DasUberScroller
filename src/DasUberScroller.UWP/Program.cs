using DasUberScroller.lib;
using DasUberScroller.lib.DI;

using DasUberScroller.UWP.PlatformImplementations;

namespace DasUberScroller.UWP
{
    public static class Program
    {
        static void Main()
        {
            DIContainer.Initialize(new UWPFileSystem());

            var factory = new MonoGame.Framework.GameFrameworkViewSource<MainGame>();

            Windows.ApplicationModel.Core.CoreApplication.Run(factory);
        }
    }
}