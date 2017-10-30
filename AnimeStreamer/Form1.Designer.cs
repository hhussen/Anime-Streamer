

namespace AnimeStreamer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.l_Episode = new System.Windows.Forms.Label();
            this.l_AnimeName = new System.Windows.Forms.Label();
            this.t_Episode = new System.Windows.Forms.TextBox();
            this.b_Select = new System.Windows.Forms.Button();
            this.combobox = new System.Windows.Forms.ComboBox();
            this.l_title = new System.Windows.Forms.Label();
            this.cb_Player = new System.Windows.Forms.ComboBox();
            this.l_Player = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.l_version = new System.Windows.Forms.Label();
            this.b_Browser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.wmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).BeginInit();
            this.SuspendLayout();
            // 
            // l_Episode
            // 
            this.l_Episode.AutoSize = true;
            this.l_Episode.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Episode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.l_Episode.Location = new System.Drawing.Point(155, 70);
            this.l_Episode.Name = "l_Episode";
            this.l_Episode.Size = new System.Drawing.Size(73, 19);
            this.l_Episode.TabIndex = 1;
            this.l_Episode.Text = "Episode:";
            this.l_Episode.Click += new System.EventHandler(this.l_Episode_Click);
            // 
            // l_AnimeName
            // 
            this.l_AnimeName.AutoSize = true;
            this.l_AnimeName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_AnimeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.l_AnimeName.Location = new System.Drawing.Point(155, 19);
            this.l_AnimeName.Name = "l_AnimeName";
            this.l_AnimeName.Size = new System.Drawing.Size(118, 19);
            this.l_AnimeName.TabIndex = 2;
            this.l_AnimeName.Text = "Anime Name:";
            this.l_AnimeName.Click += new System.EventHandler(this.label2_Click);
            // 
            // t_Episode
            // 
            this.t_Episode.Location = new System.Drawing.Point(307, 67);
            this.t_Episode.Name = "t_Episode";
            this.t_Episode.Size = new System.Drawing.Size(45, 27);
            this.t_Episode.TabIndex = 4;
            this.t_Episode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.t_Episode.TextChanged += new System.EventHandler(this.t_Episode_TextChanged);
            // 
            // b_Select
            // 
            this.b_Select.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.b_Select.FlatAppearance.BorderSize = 2;
            this.b_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Select.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Select.ForeColor = System.Drawing.Color.White;
            this.b_Select.Location = new System.Drawing.Point(0, 100);
            this.b_Select.Name = "b_Select";
            this.b_Select.Size = new System.Drawing.Size(952, 81);
            this.b_Select.TabIndex = 6;
            this.b_Select.Text = "Select";
            this.b_Select.UseVisualStyleBackColor = true;
            this.b_Select.Click += new System.EventHandler(this.button1_Click);
            // 
            // combobox
            // 
            this.combobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.combobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox.DropDownHeight = 300;
            this.combobox.FormattingEnabled = true;
            this.combobox.IntegralHeight = false;
            this.combobox.Location = new System.Drawing.Point(307, 16);
            this.combobox.Name = "combobox";
            this.combobox.Size = new System.Drawing.Size(447, 29);
            this.combobox.TabIndex = 8;
            this.combobox.SelectedIndexChanged += new System.EventHandler(this.combobox_SelectedIndexChanged);
            // 
            // l_title
            // 
            this.l_title.Font = new System.Drawing.Font("Century Gothic", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.ForeColor = System.Drawing.Color.Cornsilk;
            this.l_title.Location = new System.Drawing.Point(-15, 7);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(952, 81);
            this.l_title.TabIndex = 9;
            this.l_title.Text = "Anime Streamer";
            this.l_title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cb_Player
            // 
            this.cb_Player.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Player.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Player.FormattingEnabled = true;
            this.cb_Player.Location = new System.Drawing.Point(830, 16);
            this.cb_Player.Name = "cb_Player";
            this.cb_Player.Size = new System.Drawing.Size(69, 29);
            this.cb_Player.TabIndex = 12;
            this.cb_Player.Visible = false;
            this.cb_Player.SelectedIndexChanged += new System.EventHandler(this.cb_Player_SelectedIndexChanged);
            // 
            // l_Player
            // 
            this.l_Player.AutoSize = true;
            this.l_Player.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Player.Location = new System.Drawing.Point(754, 50);
            this.l_Player.Name = "l_Player";
            this.l_Player.Size = new System.Drawing.Size(82, 13);
            this.l_Player.TabIndex = 13;
            this.l_Player.Text = "Video Player:";
            this.l_Player.Visible = false;
            this.l_Player.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.l_version);
            this.panel1.Controls.Add(this.b_Browser);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.l_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 84);
            this.panel1.TabIndex = 14;
            // 
            // l_version
            // 
            this.l_version.AutoSize = true;
            this.l_version.ForeColor = System.Drawing.Color.White;
            this.l_version.Location = new System.Drawing.Point(99, 58);
            this.l_version.Name = "l_version";
            this.l_version.Size = new System.Drawing.Size(51, 21);
            this.l_version.TabIndex = 15;
            this.l_version.Text = "v1.10";
            // 
            // b_Browser
            // 
            this.b_Browser.Enabled = false;
            this.b_Browser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Browser.ForeColor = System.Drawing.Color.White;
            this.b_Browser.Image = global::AnimeStreamer.Properties.Resources.globe;
            this.b_Browser.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_Browser.Location = new System.Drawing.Point(756, 3);
            this.b_Browser.Name = "b_Browser";
            this.b_Browser.Size = new System.Drawing.Size(193, 78);
            this.b_Browser.TabIndex = 10;
            this.b_Browser.Text = "Play in Browser";
            this.b_Browser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_Browser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_Browser.UseVisualStyleBackColor = true;
            this.b_Browser.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AnimeStreamer.Properties.Resources.play;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 78);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.combobox);
            this.panel2.Controls.Add(this.b_Select);
            this.panel2.Controls.Add(this.cb_Player);
            this.panel2.Controls.Add(this.l_Player);
            this.panel2.Controls.Add(this.l_AnimeName);
            this.panel2.Controls.Add(this.t_Episode);
            this.panel2.Controls.Add(this.l_Episode);
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 181);
            this.panel2.TabIndex = 15;
            // 
            // wmp
            // 
            this.wmp.Enabled = true;
            this.wmp.Location = new System.Drawing.Point(0, 270);
            this.wmp.Name = "wmp";
            this.wmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmp.OcxState")));
            this.wmp.Size = new System.Drawing.Size(952, 356);
            this.wmp.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(952, 624);
            this.Controls.Add(this.wmp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Anime Streamer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label l_Episode;
        private System.Windows.Forms.Label l_AnimeName;
        private System.Windows.Forms.TextBox t_Episode;
        private System.Windows.Forms.Button b_Select;
        private System.Windows.Forms.ComboBox combobox;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Button b_Browser;
        private System.Windows.Forms.ComboBox cb_Player;
        private System.Windows.Forms.Label l_Player;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AxWMPLib.AxWindowsMediaPlayer wmp;
        private System.Windows.Forms.Label l_version;
    }
}

