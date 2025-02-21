using System;

namespace CipherKit.Core.Exceptions
{
    public class CipherException : Exception
    {
        public CipherException(string message) : base(message) { }
        public CipherException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class CipherParameterException : CipherException
    {
        public CipherParameterException(string message) : base(message) { }
        public CipherParameterException(string message, Exception innerException) : base(message, innerException) { }
    }
}
