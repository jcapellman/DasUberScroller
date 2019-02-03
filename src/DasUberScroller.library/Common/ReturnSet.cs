using System;

namespace DasUberScroller.library.Common
{
    public class ReturnSet<T>
    {
        public T Value { get; }

        public Exception Error { get; }

        public bool HasErrorOrNull => Error != null || Value == null;

        public ReturnSet(T objectValue)
        {
            Value = objectValue;
        }

        public ReturnSet(Exception exception, bool logException = true)
        {
            Error = exception;

            if (!logException)
            {
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Error(exception);
        }
    }
}