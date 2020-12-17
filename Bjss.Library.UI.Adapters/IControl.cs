using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bjss.Library.UI.Adapters
{
    public interface IControl
    {
        event EventHandler Click;

        event EventHandler DoubleClick;

        event KeyEventHandler KeyDown;

        event KeyEventHandler KeyUp;

        event CancelEventHandler Validating;

        event EventHandler Validated;

        Color BackColor { get; set; }

        bool Enabled { get; set; }

        bool InvokeRequired { get; }

        string Name { get; set; }

        object Tag { get; set; }

        bool Visible { get; set; }

        DockStyle Dock { get; set; }

        IList Controls { get; }

        RightToLeft RightToLeft { get; set; }

        Point Location { get; set; }

        Size Size { get; set; }

        int TabIndex { get; set; }

        IAsyncResult BeginInvoke(Delegate method);

        IAsyncResult BeginInvoke(Delegate method, params object[] args);

        void BringToFront();

        object Invoke(Delegate method);

        object Invoke(Delegate method, params object[] args);

        bool Focus();

        void ResumeLayout();

        void SuspendLayout();
    }
}