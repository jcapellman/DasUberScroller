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

        public ReturnSet(Exception exception)
        {
            Error = exception;
        }
    }
}