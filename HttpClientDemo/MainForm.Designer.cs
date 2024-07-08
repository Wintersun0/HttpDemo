namespace HttpClientDemo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSendMsg = new Button();
            richTextBox1 = new RichTextBox();
            btnGetMsg = new Button();
            SuspendLayout();
            // 
            // btnSendMsg
            // 
            btnSendMsg.Location = new Point(12, 12);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(112, 38);
            btnSendMsg.TabIndex = 0;
            btnSendMsg.Text = "发送";
            btnSendMsg.UseVisualStyleBackColor = true;
            btnSendMsg.Click += btnSendMsg_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 56);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(760, 493);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // btnGetMsg
            // 
            btnGetMsg.Location = new Point(130, 12);
            btnGetMsg.Name = "btnGetMsg";
            btnGetMsg.Size = new Size(112, 38);
            btnGetMsg.TabIndex = 2;
            btnGetMsg.Text = "GET";
            btnGetMsg.UseVisualStyleBackColor = true;
            btnGetMsg.Click += btnGetMsg_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(btnGetMsg);
            Controls.Add(richTextBox1);
            Controls.Add(btnSendMsg);
            Font = new Font("Microsoft YaHei UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Http client";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnSendMsg;
        private RichTextBox richTextBox1;
        private Button btnGetMsg;
    }
}
