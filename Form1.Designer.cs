namespace StaticWebServerManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.FlowLayoutPanel flpServers;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnAddServer = new Button();
            flpServers = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnAddServer
            // 
            btnAddServer.BackColor = SystemColors.ActiveCaptionText;
            btnAddServer.ForeColor = SystemColors.ButtonFace;
            btnAddServer.Location = new Point(22, 23);
            btnAddServer.Margin = new Padding(6);
            btnAddServer.Name = "btnAddServer";
            btnAddServer.Size = new Size(183, 58);
            btnAddServer.TabIndex = 0;
            btnAddServer.Text = "添加服务器";
            btnAddServer.UseVisualStyleBackColor = false;
            // 
            // flpServers
            // 
            flpServers.Location = new Point(22, 96);
            flpServers.Margin = new Padding(6);
            flpServers.Name = "flpServers";
            flpServers.Size = new Size(733, 577);
            flpServers.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 694);
            Controls.Add(flpServers);
            Controls.Add(btnAddServer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            Name = "Form1";
            Text = "静态网站服务管理器";
            Load += Form1_Load;
            ResumeLayout(false);
        }
    }
}
