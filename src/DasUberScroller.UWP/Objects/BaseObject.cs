using DasUberScroller.UWP.Containers;

namespace DasUberScroller.UWP.Objects
{
    public class BaseObject
    {
        protected readonly WindowContainer WindowContainer;

        protected BaseObject(WindowContainer windowContainer)
        {
            WindowContainer = windowContainer;
        }
    }
}