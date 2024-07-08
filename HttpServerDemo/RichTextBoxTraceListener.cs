using System.Diagnostics;

namespace HttpServerDemo
{
    internal class RichTextBoxTraceListener : TraceListener
    {
        private RichTextBox _richTextBox;

        public RichTextBoxTraceListener(RichTextBox richTextBox)
        {
            this._richTextBox = richTextBox;
        }

        public override void Write(string? message)
        {
            if (_richTextBox.InvokeRequired)
            {
                _richTextBox.Invoke(new Action<string>(Write), new object[] { message ?? "" });
            }
            else
            {
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                _richTextBox.AppendText($"[{dateTime}]: {message}");
                _richTextBox.ScrollToCaret();
            }
        }

        public override void WriteLine(string? message)
        {
            Write(message + Environment.NewLine);
        }
    }
}
