namespace StockManager3
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            Menu = new Panel();
            setingsbtn = new Button();
            stockbtn = new Button();
            Hotelbtn = new Button();
            billmakerbtn = new Button();
            panel1 = new Panel();
            rolelabel = new Label();
            usernamelabel = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            date = new Label();
            graphventepannel = new Panel();
            splitContainerdashboard = new SplitContainer();
            bottompanneldashboard = new Panel();
            button1 = new Button();
            cartesianChartventes = new LiveCharts.WinForms.CartesianChart();
            Menu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            graphventepannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerdashboard).BeginInit();
            splitContainerdashboard.SuspendLayout();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.BackColor = SystemColors.ButtonHighlight;
            Menu.Controls.Add(button1);
            Menu.Controls.Add(setingsbtn);
            Menu.Controls.Add(stockbtn);
            Menu.Controls.Add(Hotelbtn);
            Menu.Controls.Add(billmakerbtn);
            Menu.Controls.Add(panel1);
            Menu.Dock = DockStyle.Left;
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(200, 681);
            Menu.TabIndex = 0;
            // 
            // setingsbtn
            // 
            setingsbtn.BackColor = Color.White;
            setingsbtn.BackgroundImageLayout = ImageLayout.None;
            setingsbtn.Cursor = Cursors.Hand;
            setingsbtn.Dock = DockStyle.Bottom;
            setingsbtn.FlatStyle = FlatStyle.System;
            setingsbtn.ImageAlign = ContentAlignment.MiddleRight;
            setingsbtn.Location = new Point(0, 606);
            setingsbtn.Name = "setingsbtn";
            setingsbtn.Size = new Size(200, 75);
            setingsbtn.TabIndex = 4;
            setingsbtn.Text = "Settings";
            setingsbtn.UseVisualStyleBackColor = false;
            // 
            // stockbtn
            // 
            stockbtn.Cursor = Cursors.Hand;
            stockbtn.Dock = DockStyle.Top;
            stockbtn.FlatStyle = FlatStyle.System;
            stockbtn.Location = new Point(0, 275);
            stockbtn.Name = "stockbtn";
            stockbtn.Size = new Size(200, 100);
            stockbtn.TabIndex = 3;
            stockbtn.Text = "Stock";
            stockbtn.UseVisualStyleBackColor = true;
            // 
            // Hotelbtn
            // 
            Hotelbtn.Cursor = Cursors.Hand;
            Hotelbtn.Dock = DockStyle.Top;
            Hotelbtn.FlatStyle = FlatStyle.System;
            Hotelbtn.Location = new Point(0, 175);
            Hotelbtn.Name = "Hotelbtn";
            Hotelbtn.Size = new Size(200, 100);
            Hotelbtn.TabIndex = 2;
            Hotelbtn.Text = "Hotel";
            Hotelbtn.UseVisualStyleBackColor = true;
            // 
            // billmakerbtn
            // 
            billmakerbtn.BackgroundImageLayout = ImageLayout.None;
            billmakerbtn.Cursor = Cursors.Hand;
            billmakerbtn.Dock = DockStyle.Top;
            billmakerbtn.FlatStyle = FlatStyle.System;
            billmakerbtn.Location = new Point(0, 75);
            billmakerbtn.Name = "billmakerbtn";
            billmakerbtn.Size = new Size(200, 100);
            billmakerbtn.TabIndex = 1;
            billmakerbtn.Text = "Bill Maker";
            billmakerbtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(rolelabel);
            panel1.Controls.Add(usernamelabel);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 75);
            panel1.TabIndex = 1;
            // 
            // rolelabel
            // 
            rolelabel.AutoSize = true;
            rolelabel.Location = new Point(68, 47);
            rolelabel.Name = "rolelabel";
            rolelabel.Size = new Size(30, 15);
            rolelabel.TabIndex = 2;
            rolelabel.Text = "Role";
            rolelabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernamelabel
            // 
            usernamelabel.AutoSize = true;
            usernamelabel.FlatStyle = FlatStyle.Flat;
            usernamelabel.Location = new Point(68, 32);
            usernamelabel.Name = "usernamelabel";
            usernamelabel.Size = new Size(62, 15);
            usernamelabel.TabIndex = 1;
            usernamelabel.Text = "UserName";
            usernamelabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.user_profile_icon_profile_avatar_user_icon_male_icon_face_icon_profile_icon_free_png;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(date);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(200, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1064, 75);
            panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1027, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // date
            // 
            date.Dock = DockStyle.Left;
            date.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            date.Location = new Point(0, 0);
            date.Name = "date";
            date.Size = new Size(137, 75);
            date.TabIndex = 2;
            date.Text = "Lundi 20:09\r\n07/09/2024";
            date.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // graphventepannel
            // 
            graphventepannel.Controls.Add(cartesianChartventes);
            graphventepannel.Dock = DockStyle.Top;
            graphventepannel.Location = new Point(200, 75);
            graphventepannel.Name = "graphventepannel";
            graphventepannel.Size = new Size(1064, 350);
            graphventepannel.TabIndex = 2;
            // 
            // splitContainerdashboard
            // 
            splitContainerdashboard.Dock = DockStyle.Top;
            splitContainerdashboard.Location = new Point(200, 425);
            splitContainerdashboard.Name = "splitContainerdashboard";
            splitContainerdashboard.Size = new Size(1064, 175);
            splitContainerdashboard.SplitterDistance = 354;
            splitContainerdashboard.TabIndex = 3;
            // 
            // bottompanneldashboard
            // 
            bottompanneldashboard.Dock = DockStyle.Fill;
            bottompanneldashboard.Location = new Point(200, 600);
            bottompanneldashboard.Name = "bottompanneldashboard";
            bottompanneldashboard.Size = new Size(1064, 81);
            bottompanneldashboard.TabIndex = 4;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Top;
            button1.FlatStyle = FlatStyle.System;
            button1.Location = new Point(0, 375);
            button1.Name = "button1";
            button1.Size = new Size(200, 100);
            button1.TabIndex = 5;
            button1.Text = "Bills";
            button1.UseVisualStyleBackColor = true;
            // 
            // cartesianChartventes
            // 
            cartesianChartventes.Location = new Point(361, 6);
            cartesianChartventes.Name = "cartesianChartventes";
            cartesianChartventes.Size = new Size(691, 338);
            cartesianChartventes.TabIndex = 0;
            cartesianChartventes.Text = "cartesianChart1";
            cartesianChartventes.ChildChanged += cartesianChart1_ChildChanged;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(bottompanneldashboard);
            Controls.Add(splitContainerdashboard);
            Controls.Add(graphventepannel);
            Controls.Add(panel2);
            Controls.Add(Menu);
            Name = "Dashboard";
            Text = "StockManager V0.2";
            Load += Dashboard_Load;
            Menu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            graphventepannel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerdashboard).EndInit();
            splitContainerdashboard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Menu;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label rolelabel;
        private Label usernamelabel;
        private Button billmakerbtn;
        private Button setingsbtn;
        private Button stockbtn;
        private Button Hotelbtn;
        private Panel panel2;
        private Label date;
        private PictureBox pictureBox2;
        private Panel graphventepannel;
        private SplitContainer splitContainerdashboard;
        private Panel bottompanneldashboard;
        private Button button1;
        private LiveCharts.WinForms.CartesianChart cartesianChartventes;
    }
}