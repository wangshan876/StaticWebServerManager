namespace StaticWebServerManager
{
    partial class ServerCard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOpenInWebView; // 新增的按钮
 //       private System.Windows.Forms.WebBrowser webBrowser; // 新增的 WebBrowser 控件

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblServerName = new Label();
            btnStartStop = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnOpenInWebView = new Button();
            SuspendLayout();
            // 
            // lblServerName
            // 
            lblServerName.AutoSize = true;
            lblServerName.Location = new Point(6, 19);
            lblServerName.Margin = new Padding(6, 0, 6, 0);
            lblServerName.Name = "lblServerName";
            lblServerName.Size = new Size(88, 25);
            lblServerName.TabIndex = 0;
            lblServerName.Text = "服务器名";
            // 
            // btnStartStop
            // 
            btnStartStop.BackColor = SystemColors.ActiveCaptionText;
            btnStartStop.ForeColor = SystemColors.ButtonFace;
            btnStartStop.Location = new Point(6, 58);
            btnStartStop.Margin = new Padding(6);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(138, 44);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "启动";
            btnStartStop.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ActiveCaptionText;
            btnEdit.ForeColor = SystemColors.ButtonFace;
            btnEdit.Location = new Point(154, 58);
            btnEdit.Margin = new Padding(6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(138, 44);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "编辑";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ActiveCaptionText;
            btnDelete.ForeColor = SystemColors.ButtonFace;
            btnDelete.Location = new Point(302, 58);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(138, 44);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnOpenInWebView
            // 
            btnOpenInWebView.BackColor = SystemColors.ActiveCaptionText;
            btnOpenInWebView.ForeColor = SystemColors.ButtonFace;
            btnOpenInWebView.Location = new Point(451, 58);
            btnOpenInWebView.Margin = new Padding(6);
            btnOpenInWebView.Name = "btnOpenInWebView";
            btnOpenInWebView.Size = new Size(222, 44);
            btnOpenInWebView.TabIndex = 4;
            btnOpenInWebView.Text = "在WebView中打开";
            btnOpenInWebView.UseVisualStyleBackColor = false;
            // 
            // ServerCard
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(btnOpenInWebView);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnStartStop);
            Controls.Add(lblServerName);
            ForeColor = SystemColors.ButtonFace;
            Margin = new Padding(6);
            Name = "ServerCard";
            Size = new Size(733, 124);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
