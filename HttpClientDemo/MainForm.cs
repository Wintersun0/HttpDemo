using System.Diagnostics;

namespace HttpClientDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RichTextBoxTraceListener listener = new RichTextBoxTraceListener(richTextBox1);
            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.SendMessage("test", "http://localhost:10011/");
        }

        private void btnGetMsg_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.GetMessage("", "http://localhost:10011/start");
        }
    }
}
