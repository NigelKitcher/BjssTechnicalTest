using System;
using System.Runtime.Serialization;

namespace Bjss.Library.Cards.Contracts
{
    [Serializable]
    public class DeckNotOpenedException : Exception
    {
        public DeckNotOpenedException()
        {
        }

        public DeckNotOpenedException(string message) : base(message)
        {
        }

        public DeckNotOpenedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DeckNotOpenedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
