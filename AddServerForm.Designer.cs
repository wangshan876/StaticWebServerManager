namespace StaticWebServerManager
{
    partial class AddServerForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtWebsiteDirectory;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtEntryPoint;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblWebsiteDirectory;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblEntryPoint;
        private System.Windows.Forms.CheckBox chkScriptMode; // 新增的复选框
        private System.Windows.Forms.Label lblCmd; // 启动命令标签
        private System.Windows.Forms.TextBox txtCmd; // 启动命令文本框
        private System.Windows.Forms.Button btnDelete;

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
            txtEntryPoint = new TextBox();
            lblEntryPoint = new Label();
            btnDelete = new Button();
            lblCmd = new Label();
            txtCmd = new TextBox();
            chkScriptMode = new CheckBox();
            SuspendLayout();
            // 
            // txtServerName
            // 
            txtServerName.BackColor = SystemColors.InactiveCaption;
            txtServerName.Location = new Point(191, 113);
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(296, 32);
            txtServerName.TabIndex = 0;
            // 
            // txtWebsiteDirectory
            // 
            txtWebsiteDirectory.BackColor = SystemColors.InactiveCaption;
            txtWebsiteDirectory.Location = new Point(191, 173);
            txtWebsiteDirectory.Name = "txtWebsiteDirectory";
            txtWebsiteDirectory.Size = new Size(200, 32);
            txtWebsiteDirectory.TabIndex = 1;
            // 
            // txtPort
            // 
            txtPort.BackColor = SystemColors.InactiveCaption;
            txtPort.Location = new Point(191, 229);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(296, 32);
            txtPort.TabIndex = 2;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = SystemColors.InactiveCaptionText;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Location = new Point(72, 403);
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
            btnBrowse.Location = new Point(397, 173);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(90, 34);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "浏览";
            btnBrowse.UseVisualStyleBackColor = false;
            // 
            // lblServerName
            // 
            lblServerName.AutoSize = true;
            lblServerName.BackColor = Color.FromArgb(50, 60, 50);
            lblServerName.Location = new Point(72, 116);
            lblServerName.Name = "lblServerName";
            lblServerName.Size = new Size(93, 25);
            lblServerName.TabIndex = 5;
            lblServerName.Text = "服务器名:";
            // 
            // lblWebsiteDirectory
            // 
            lblWebsiteDirectory.AutoSize = true;
            lblWebsiteDirectory.BackColor = Color.FromArgb(50, 60, 50);
            lblWebsiteDirectory.Location = new Point(72, 173);
            lblWebsiteDirectory.Name = "lblWebsiteDirectory";
            lblWebsiteDirectory.Size = new Size(93, 25);
            lblWebsiteDirectory.TabIndex = 6;
            lblWebsiteDirectory.Text = "网站目录:";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.BackColor = Color.FromArgb(50, 60, 50);
            lblPort.Location = new Point(110, 232);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(55, 25);
            lblPort.TabIndex = 7;
            lblPort.Text = "端口:";
            // 
            // txtEntryPoint
            // 
            txtEntryPoint.BackColor = SystemColors.InactiveCaption;
            txtEntryPoint.Location = new Point(191, 285);
            txtEntryPoint.Name = "txtEntryPoint";
            txtEntryPoint.Size = new Size(296, 32);
            txtEntryPoint.TabIndex = 9;
            // 
            // lblEntryPoint
            // 
            lblEntryPoint.AutoSize = true;
            lblEntryPoint.BackColor = Color.FromArgb(50, 60, 50);
            lblEntryPoint.Location = new Point(72, 288);
            lblEntryPoint.Name = "lblEntryPoint";
            lblEntryPoint.Size = new Size(93, 25);
            lblEntryPoint.TabIndex = 10;
            lblEntryPoint.Text = "入口文件:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.InactiveCaptionText;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(330, 403);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(157, 45);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "关闭";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblCmd
            // 
            lblCmd.AutoSize = true;
            lblCmd.BackColor = Color.FromArgb(50, 60, 50);
            lblCmd.Location = new Point(72, 194);
            lblCmd.Name = "lblCmd";
            lblCmd.Size = new Size(93, 25);
            lblCmd.TabIndex = 12;
            lblCmd.Text = "启动命令:";
            lblCmd.Visible = false;
            // 
            // txtCmd
            // 
            txtCmd.BackColor = SystemColors.InactiveCaption;
            txtCmd.Location = new Point(191, 191);
            txtCmd.Name = "txtCmd";
            txtCmd.Size = new Size(296, 32);
            txtCmd.TabIndex = 11;
            txtCmd.Visible = false;
            // 
            // chkScriptMode
            // 
            chkScriptMode.AutoSize = true;
            chkScriptMode.BackColor = Color.FromArgb(50, 60, 50);
            chkScriptMode.Location = new Point(72, 51);
            chkScriptMode.Name = "chkScriptMode";
            chkScriptMode.Size = new Size(202, 29);
            chkScriptMode.TabIndex = 13;
            chkScriptMode.Text = "是否为脚本命令启动";
            chkScriptMode.UseVisualStyleBackColor = false;
            // 
            // AddServerForm
            // 
            BackColor = SystemColors.InactiveCaptionText;
            ClientSize = new Size(615, 528);
            Controls.Add(lblCmd);
            Controls.Add(txtCmd);
            Controls.Add(chkScriptMode);
            Controls.Add(btnDelete);
            Controls.Add(lblPort);
            Controls.Add(lblWebsiteDirectory);
            Controls.Add(lblServerName);
            Controls.Add(btnBrowse);
            Controls.Add(btnCreate);
            Controls.Add(txtPort);
            Controls.Add(lblEntryPoint);
            Controls.Add(txtEntryPoint);
            Controls.Add(txtWebsiteDirectory);
            Controls.Add(txtServerName);
            ForeColor = SystemColors.ButtonHighlight;
            Name = "AddServerForm";
            Text = "新建服务器";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
