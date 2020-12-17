using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bjss.Library.UI.Adapters
{
    public class ControlAdapter : IControl
    {
        private readonly Control _control;

        public ControlAdapter(Control control)
        {
            _control = control ?? throw new ArgumentNullException(nameof(control));
            _control.Click += Control_Click;
            _control.Validating += Control_Validating;
            _control.Validated += Control_Validated;
            _control.KeyDown += Control_KeyDown;
            _control.KeyUp += Control_KeyUp;
        }

        public event EventHandler Click;

        public event EventHandler DoubleClick;

        public event EventHandler Validated;

        public event CancelEventHandler Validating;

        public event KeyEventHandler KeyDown;

        public event KeyEventHandler KeyUp;

        public Color BackColor
        {
            get => _control.BackColor;
            set => _control.BackColor = value;
        }

        public DockStyle Dock
        {
            get => _control.Dock;
            set => _control.Dock = value;
        }

        public bool Enabled
        {
            get => _control.Enabled;
            set => _control.Enabled = value;
        }

        public bool InvokeRequired => _control.InvokeRequired;

        public string Name
        {
            get => _control.Name;
            set => _control.Name = value;
        }

        public object Tag
        {
            get => _control.Tag;
            set => _control.Tag = value;
        }

        public bool Visible
        {
            get => _control.Visible;
            set => _control.Visible = value;
        }

        public IList Controls => _control.Controls;

        public RightToLeft RightToLeft
        {
            get => _control.RightToLeft;
            set => _control.RightToLeft = value;
        }

        public Point Location
        {
            get => _control.Location;
            set => _control.Location = value;
        }

        public Size Size
        {
            get => _control.Size;
            set => _control.Size = value;
        }

        public int TabIndex
        {
            get => _control.TabIndex;
            set => _control.TabIndex = value;
        }

        public static implicit operator Control(ControlAdapter adapter)
        {
            return adapter._control;
        }

        public IAsyncResult BeginInvoke(Delegate method)
        {
            return _control.BeginInvoke(method);
        }

        public IAsyncResult BeginInvoke(Delegate method, params object[] args)
        {
            return _control.BeginInvoke(method, args);
        }

        public void BringToFront()
        {
            _control.BringToFront();
        }

        public object Invoke(Delegate method)
        {
            return _control.Invoke(method);
        }

        public object Invoke(Delegate method, params object[] args)
        {
            return _control.Invoke(method, args);
        }

        public bool Focus()
        {
            return _control.Focus();
        }

        public void ResumeLayout()
        {
            _control.ResumeLayout();
        }

        public void SuspendLayout()
        {
            _control.SuspendLayout();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _control.Dispose();
        }

        protected void OnClick(EventArgs e)
        {
            Click?.Invoke(this, e);
        }

        protected void OnDoubleClick(EventArgs e)
        {
            DoubleClick?.Invoke(this, e);
        }

        protected void OnKeyDown(KeyEventArgs e)
        {
            KeyDown?.Invoke(this, e);
        }

        protected void OnKeyUp(KeyEventArgs e)
        {
            KeyUp?.Invoke(this, e);
        }

        protected void OnValidated(EventArgs e)
        {
            Validated?.Invoke(this, e);
        }

        protected void OnValidating(CancelEventArgs e)
        {
            Validating?.Invoke(this, e);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                _control?.Dispose();
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

        private void Control_Validated(object sender, EventArgs e)
        {
            OnValidated(e);
        }

        private void Control_Validating(object sender, CancelEventArgs e)
        {
            OnValidating(e);
        }
    }
}