using System;
using System.Runtime.Serialization;

namespace Bjss.Library.Cards.Contracts
{
    [Serializable]
    public class NotFullDeckException : Exception
    {
        public NotFullDeckException()
        {
        }

        public NotFullDeckException(string message) : base(message)
        {
        }

        public NotFullDeckException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NotFullDeckException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
