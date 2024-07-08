using System.Diagnostics;

namespace HttpServerDemo
{
    public partial class MainForm : Form
    {
        private HttpServer? _httpServer = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RichTextBoxTraceListener listener = new RichTextBoxTraceListener(richTextBox1);
            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;

            _httpServer = new HttpServer("http://localhost:10011/");
            _httpServer.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _httpServer?.Stop();
        }
    }
}
