using System;

namespace Bjss.Library.Cards.Domain
{
    public class ShuffleCompletedEventArgs : EventArgs
    {
        public TimeSpan TimeTaken { get; }

        public ShuffleCompletedEventArgs(TimeSpan timeTaken)
        {
            TimeTaken = timeTaken;
        }
    }
}
