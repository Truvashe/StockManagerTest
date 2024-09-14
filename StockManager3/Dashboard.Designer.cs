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
            button1 = new Button();
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
            label2 = new Label();
            cartesianChartventes = new LiveCharts.WinForms.CartesianChart();
            splitContainerdashboard = new SplitContainer();
            label1 = new Label();
            pieChartProfit = new LiveCharts.WinForms.PieChart();
            label3 = new Label();
            racebar = new LiveCharts.WinForms.CartesianChart();
            bottompanneldashboard = new Panel();
            Menu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            graphventepannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerdashboard).BeginInit();
            splitContainerdashboard.Panel1.SuspendLayout();
            splitContainerdashboard.Panel2.SuspendLayout();
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
            billmakerbtn.Click += billmakerbtn_Click;
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
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            date.Size = new Size(351, 75);
            date.TabIndex = 2;
            date.Text = "Lundi 20:09\r\n07/09/2024";
            date.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // graphventepannel
            // 
            graphventepannel.Controls.Add(label2);
            graphventepannel.Controls.Add(cartesianChartventes);
            graphventepannel.Dock = DockStyle.Top;
            graphventepannel.Location = new Point(200, 75);
            graphventepannel.Name = "graphventepannel";
            graphventepannel.Size = new Size(1064, 288);
            graphventepannel.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(461, 272);
            label2.Name = "label2";
            label2.Size = new Size(151, 15);
            label2.TabIndex = 2;
            label2.Text = "Ventes des 30 derniers jours";
            // 
            // cartesianChartventes
            // 
            cartesianChartventes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cartesianChartventes.BackColor = SystemColors.ControlLight;
            cartesianChartventes.Cursor = Cursors.Cross;
            cartesianChartventes.Location = new Point(6, 3);
            cartesianChartventes.Name = "cartesianChartventes";
            cartesianChartventes.Size = new Size(1046, 266);
            cartesianChartventes.TabIndex = 0;
            cartesianChartventes.Text = "cartesianChart1";
            cartesianChartventes.ChildChanged += cartesianChart1_ChildChanged;
            // 
            // splitContainerdashboard
            // 
            splitContainerdashboard.Dock = DockStyle.Top;
            splitContainerdashboard.IsSplitterFixed = true;
            splitContainerdashboard.Location = new Point(200, 363);
            splitContainerdashboard.Name = "splitContainerdashboard";
            // 
            // splitContainerdashboard.Panel1
            // 
            splitContainerdashboard.Panel1.Controls.Add(label1);
            splitContainerdashboard.Panel1.Controls.Add(pieChartProfit);
            // 
            // splitContainerdashboard.Panel2
            // 
            splitContainerdashboard.Panel2.Controls.Add(label3);
            splitContainerdashboard.Panel2.Controls.Add(racebar);
            splitContainerdashboard.Size = new Size(1064, 232);
            splitContainerdashboard.SplitterDistance = 354;
            splitContainerdashboard.SplitterWidth = 1;
            splitContainerdashboard.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(143, 181);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "Taux de profit";
            // 
            // pieChartProfit
            // 
            pieChartProfit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pieChartProfit.BackColor = SystemColors.ControlLight;
            pieChartProfit.Cursor = Cursors.Cross;
            pieChartProfit.Location = new Point(6, 6);
            pieChartProfit.Name = "pieChartProfit";
            pieChartProfit.Size = new Size(345, 172);
            pieChartProfit.TabIndex = 0;
            pieChartProfit.Text = "Profit from sales";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(306, 181);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 3;
            label3.Text = "Top10 produits vendu";
            // 
            // racebar
            // 
            racebar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            racebar.BackColor = SystemColors.ControlLight;
            racebar.Cursor = Cursors.Cross;
            racebar.Location = new Point(15, 6);
            racebar.Name = "racebar";
            racebar.Size = new Size(682, 172);
            racebar.TabIndex = 0;
            racebar.Text = "racebar";
            // 
            // bottompanneldashboard
            // 
            bottompanneldashboard.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bottompanneldashboard.BackColor = SystemColors.ControlLight;
            bottompanneldashboard.Location = new Point(200, 606);
            bottompanneldashboard.Name = "bottompanneldashboard";
            bottompanneldashboard.Size = new Size(1064, 75);
            bottompanneldashboard.TabIndex = 4;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(splitContainerdashboard);
            Controls.Add(bottompanneldashboard);
            Controls.Add(graphventepannel);
            Controls.Add(panel2);
            Controls.Add(Menu);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
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
            graphventepannel.PerformLayout();
            splitContainerdashboard.Panel1.ResumeLayout(false);
            splitContainerdashboard.Panel1.PerformLayout();
            splitContainerdashboard.Panel2.ResumeLayout(false);
            splitContainerdashboard.Panel2.PerformLayout();
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
        private LiveCharts.WinForms.PieChart pieChartProfit;
        private Label label1;
        private Label label2;
        private LiveCharts.WinForms.CartesianChart racebar;
        private Label label3;
    }
}