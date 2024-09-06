namespace StockManager3
{
    partial class LoginSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginSettingsSaveBtn = new Button();
            servernameinput = new TextBox();
            dbnameinput = new TextBox();
            pswrdinput = new TextBox();
            useridinput = new TextBox();
            splitContainer1 = new SplitContainer();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // LoginSettingsSaveBtn
            // 
            LoginSettingsSaveBtn.Location = new Point(28, 184);
            LoginSettingsSaveBtn.Name = "LoginSettingsSaveBtn";
            LoginSettingsSaveBtn.Size = new Size(75, 23);
            LoginSettingsSaveBtn.TabIndex = 0;
            LoginSettingsSaveBtn.Text = "Save";
            LoginSettingsSaveBtn.UseVisualStyleBackColor = true;
            LoginSettingsSaveBtn.Click += LoginSettingsSaveBtn_Click;
            // 
            // servernameinput
            // 
            servernameinput.Location = new Point(3, 68);
            servernameinput.Name = "servernameinput";
            servernameinput.Size = new Size(100, 23);
            servernameinput.TabIndex = 1;
            servernameinput.Text = "localhost";
            // 
            // dbnameinput
            // 
            dbnameinput.Location = new Point(3, 97);
            dbnameinput.Name = "dbnameinput";
            dbnameinput.Size = new Size(100, 23);
            dbnameinput.TabIndex = 2;
            dbnameinput.Text = "stock_management";
            // 
            // pswrdinput
            // 
            pswrdinput.Location = new Point(3, 155);
            pswrdinput.Name = "pswrdinput";
            pswrdinput.Size = new Size(100, 23);
            pswrdinput.TabIndex = 3;
            // 
            // useridinput
            // 
            useridinput.Location = new Point(3, 126);
            useridinput.Name = "useridinput";
            useridinput.Size = new Size(100, 23);
            useridinput.TabIndex = 4;
            useridinput.Text = "root";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dbnameinput);
            splitContainer1.Panel2.Controls.Add(useridinput);
            splitContainer1.Panel2.Controls.Add(LoginSettingsSaveBtn);
            splitContainer1.Panel2.Controls.Add(pswrdinput);
            splitContainer1.Panel2.Controls.Add(servernameinput);
            splitContainer1.Size = new Size(294, 450);
            splitContainer1.SplitterDistance = 180;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(90, 30);
            label5.TabIndex = 4;
            label5.Text = "Settings";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 158);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 3;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 129);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 2;
            label3.Text = "User ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 100);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 1;
            label2.Text = "Data Base Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 68);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Server Name";
            // 
            // LoginSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 450);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginSettings";
            Text = "Settings";
            Load += LoginSettings_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button LoginSettingsSaveBtn;
        private TextBox servernameinput;
        private TextBox dbnameinput;
        private TextBox pswrdinput;
        private TextBox useridinput;
        private SplitContainer splitContainer1;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}