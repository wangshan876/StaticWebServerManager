namespace StaticWebServerManager
{
    partial class AddServerForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtWebsiteDirectory;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblWebsiteDirectory;
        private System.Windows.Forms.Label lblPort;

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
            txtServerName = new TextBox();
            txtWebsiteDirectory = new TextBox();
            txtPort = new TextBox();
            btnCreate = new Button();
            btnBrowse = new Button();
            lblServerName = new Label();
            lblWebsiteDirectory = new Label();
            lblPort = new Label();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // txtServerName
            // 
            txtServerName.BackColor = SystemColors.InactiveCaption;
            txtServerName.Location = new Point(191, 69);
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(296, 32);
            txtServerName.TabIndex = 0;
            // 
            // txtWebsiteDirectory
            // 
            txtWebsiteDirectory.BackColor = SystemColors.InactiveCaption;
            txtWebsiteDirectory.Location = new Point(191, 129);
            txtWebsiteDirectory.Name = "txtWebsiteDirectory";
            txtWebsiteDirectory.Size = new Size(200, 32);
            txtWebsiteDirectory.TabIndex = 1;
            // 
            // txtPort
            // 
            txtPort.BackColor = SystemColors.InactiveCaption;
            txtPort.Location = new Point(191, 185);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(296, 32);
            txtPort.TabIndex = 2;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = SystemColors.InactiveCaptionText;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Location = new Point(155, 262);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(144, 45);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "创建";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = SystemColors.Desktop;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Location = new Point(397, 129);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(90, 34);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "浏览";
            btnBrowse.UseVisualStyleBackColor = false;
            // 
            // lblServerName
            // 
            lblServerName.AutoSize = true;
            lblServerName.BackColor = System.Drawing.Color.FromArgb(50, 60, 50);
            lblServerName.Location = new Point(72, 72);
            lblServerName.Name = "lblServerName";
            lblServerName.Size = new Size(93, 25);
            lblServerName.TabIndex = 5;
            lblServerName.Text = "服务器名:";
            // 
            // lblWebsiteDirectory
            // 
            lblWebsiteDirectory.AutoSize = true;
            lblWebsiteDirectory.BackColor = System.Drawing.Color.FromArgb(50, 60, 50);
            lblWebsiteDirectory.Location = new Point(72, 129);
            lblWebsiteDirectory.Name = "lblWebsiteDirectory";
            lblWebsiteDirectory.Size = new Size(93, 25);
            lblWebsiteDirectory.TabIndex = 6;
            lblWebsiteDirectory.Text = "网站目录:";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.BackColor = System.Drawing.Color.FromArgb(50, 60, 50);
            lblPort.Location = new Point(110, 188);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(55, 25);
            lblPort.TabIndex = 7;
            lblPort.Text = "端口:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.InactiveCaptionText;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(330, 262);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(157, 45);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "关闭";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // AddServerForm
            // 
            BackColor = SystemColors.InactiveCaptionText;
            ClientSize = new Size(581, 378);
            Controls.Add(btnDelete);
            Controls.Add(lblPort);
            Controls.Add(lblWebsiteDirectory);
            Controls.Add(lblServerName);
            Controls.Add(btnBrowse);
            Controls.Add(btnCreate);
            Controls.Add(txtPort);
            Controls.Add(txtWebsiteDirectory);
            Controls.Add(txtServerName);
            ForeColor = SystemColors.ButtonHighlight;
            Name = "AddServerForm";
            Text = "新建服务器";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnDelete;
    }
}
