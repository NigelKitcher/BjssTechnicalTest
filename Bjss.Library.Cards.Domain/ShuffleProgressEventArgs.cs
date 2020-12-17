using System;

namespace Bjss.Library.Cards.Domain
{
    public class ShuffleProgressEventArgs : EventArgs
    {
        public int PercentageComplete { get; }

        public ShuffleProgressEventArgs(int percentageComplete)
        {
            PercentageComplete = percentageComplete;
        }
    }
}
