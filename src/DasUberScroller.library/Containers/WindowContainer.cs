﻿using DasUberScroller.lib.Common;

namespace DasUberScroller.lib.Containers
{
    public class WindowContainer
    {
        public int ResolutionX { get; set; }

        public int ResolutionY { get; set; }

        public float ScaleResolutionX => ResolutionX / (float)Constants.BASE_RESOLUTION_X;

        public float ScaleResolutionY => ResolutionY / (float)Constants.BASE_RESOLUTION_Y;
    }
}