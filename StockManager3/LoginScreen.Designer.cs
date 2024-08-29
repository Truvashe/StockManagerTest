namespace StockManager3
{
    partial class LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            label2 = new Label();
            idtxtbox = new TextBox();
            mdptxtbox = new TextBox();
            connect_loginscrn = new Button();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Location = new Point(350, 176);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 1;
            label2.Text = "MOT DE PASS";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // idtxtbox
            // 
            idtxtbox.Location = new Point(350, 150);
            idtxtbox.Name = "idtxtbox";
            idtxtbox.Size = new Size(100, 23);
            idtxtbox.TabIndex = 2;
            idtxtbox.TextChanged += IDENTIFIANTtxtbox_TextChanged;
            // 
            // mdptxtbox
            // 
            mdptxtbox.Location = new Point(350, 194);
            mdptxtbox.Name = "mdptxtbox";
            mdptxtbox.Size = new Size(100, 23);
            mdptxtbox.TabIndex = 3;
            // 
            // connect_loginscrn
            // 
            connect_loginscrn.BackColor = Color.PaleGreen;
            connect_loginscrn.Cursor = Cursors.Hand;
            connect_loginscrn.FlatStyle = FlatStyle.System;
            connect_loginscrn.ForeColor = SystemColors.ActiveCaptionText;
            connect_loginscrn.Location = new Point(350, 223);
            connect_loginscrn.Name = "connect_loginscrn";
            connect_loginscrn.Size = new Size(100, 23);
            connect_loginscrn.TabIndex = 4;
            connect_loginscrn.Text = "connect";
            connect_loginscrn.UseVisualStyleBackColor = false;
            connect_loginscrn.Click += connect_loginscrn_Click;
            // 
            // label1
            // 
            label1.Location = new Point(350, 124);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 5;
            label1.Text = "IDENTIFIANT";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Transparent;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(25, 25);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = false;
            // 
            // LoginScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(784, 361);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(connect_loginscrn);
            Controls.Add(mdptxtbox);
            Controls.Add(idtxtbox);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginScreen";
            Text = "Stock Manager Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox idtxtbox;
        private TextBox mdptxtbox;
        private Button connect_loginscrn;
        private Label label1;
        private Button button1;
    }
}
