using System;
using System.Runtime.Serialization;

namespace Bjss.Library.Cards.Contracts
{
    [Serializable]
    public class InvalidCardException : Exception
    {
        public InvalidCardException()
        {
        }

        public InvalidCardException(string message) : base(message)
        {
        }

        public InvalidCardException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidCardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
