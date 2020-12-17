using System;
using System.Drawing;

namespace Bjss.Library.UI.Adapters
{
    public interface IButton : IControl, IDisposable
    {
        Image Image { get; set; }

        ContentAlignment ImageAlign { get; set; }

        string Text { get; set; }

        ContentAlignment TextAlign { get; set; }

        void PerformClick();
    }
}
