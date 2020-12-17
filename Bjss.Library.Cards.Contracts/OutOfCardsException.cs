using System;
using System.Runtime.Serialization;

namespace Bjss.Library.Cards.Contracts
{
    [Serializable]
    public class OutOfCardsException : Exception
    {
        public OutOfCardsException()
        {
        }

        public OutOfCardsException(string message) : base(message)
        {
        }

        public OutOfCardsException(string message, Exception inner) : base(message, inner)
        {
        }

        protected OutOfCardsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
