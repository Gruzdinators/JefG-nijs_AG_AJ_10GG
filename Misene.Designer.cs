namespace JefGēnija_Aparāts
{
    partial class Misene
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Misene));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btn_tirit = new System.Windows.Forms.Button();
            this.Auksa = new System.Windows.Forms.PictureBox();
            this.Apaksa = new System.Windows.Forms.PictureBox();
            this.AuksaTukss = new System.Windows.Forms.PictureBox();
            this.ApaksaTukss = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Auksa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Apaksa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuksaTukss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApaksaTukss)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(553, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 54);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_tirit
            // 
            this.btn_tirit.BackColor = System.Drawing.Color.Transparent;
            this.btn_tirit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tirit.FlatAppearance.BorderSize = 0;
            this.btn_tirit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_tirit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_tirit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tirit.Location = new System.Drawing.Point(106, 254);
            this.btn_tirit.Name = "btn_tirit";
            this.btn_tirit.Size = new System.Drawing.Size(244, 104);
            this.btn_tirit.TabIndex = 1;
            this.btn_tirit.UseVisualStyleBackColor = false;
            this.btn_tirit.Click += new System.EventHandler(this.btn_tirit_Click);
            // 
            // Auksa
            // 
            this.Auksa.BackColor = System.Drawing.Color.Transparent;
            this.Auksa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Auksa.Image = global::JefGēnija_Aparāts.Properties.Resources.Check;
            this.Auksa.Location = new System.Drawing.Point(55, 56);
            this.Auksa.Name = "Auksa";
            this.Auksa.Size = new System.Drawing.Size(75, 59);
            this.Auksa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Auksa.TabIndex = 2;
            this.Auksa.TabStop = false;
            this.Auksa.Visible = false;
            this.Auksa.Click += new System.EventHandler(this.Auksa_Click);
            // 
            // Apaksa
            // 
            this.Apaksa.BackColor = System.Drawing.Color.Transparent;
            this.Apaksa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Apaksa.Image = global::JefGēnija_Aparāts.Properties.Resources.Check;
            this.Apaksa.Location = new System.Drawing.Point(55, 121);
            this.Apaksa.Name = "Apaksa";
            this.Apaksa.Size = new System.Drawing.Size(75, 59);
            this.Apaksa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Apaksa.TabIndex = 3;
            this.Apaksa.TabStop = false;
            this.Apaksa.Visible = false;
            this.Apaksa.Click += new System.EventHandler(this.Apaksa_Click);
            // 
            // AuksaTukss
            // 
            this.AuksaTukss.BackColor = System.Drawing.Color.Transparent;
            this.AuksaTukss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AuksaTukss.Location = new System.Drawing.Point(55, 56);
            this.AuksaTukss.Name = "AuksaTukss";
            this.AuksaTukss.Size = new System.Drawing.Size(75, 59);
            this.AuksaTukss.TabIndex = 4;
            this.AuksaTukss.TabStop = false;
            this.AuksaTukss.Click += new System.EventHandler(this.AuksaTukss_Click);
            // 
            // ApaksaTukss
            // 
            this.ApaksaTukss.BackColor = System.Drawing.Color.Transparent;
            this.ApaksaTukss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ApaksaTukss.Location = new System.Drawing.Point(55, 121);
            this.ApaksaTukss.Name = "ApaksaTukss";
            this.ApaksaTukss.Size = new System.Drawing.Size(75, 59);
            this.ApaksaTukss.TabIndex = 4;
            this.ApaksaTukss.TabStop = false;
            this.ApaksaTukss.Click += new System.EventHandler(this.ApaksaTukss_Click);
            // 
            // Misene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::JefGēnija_Aparāts.Properties.Resources.Paper;
            this.ClientSize = new System.Drawing.Size(722, 406);
            this.Controls.Add(this.ApaksaTukss);
            this.Controls.Add(this.AuksaTukss);
            this.Controls.Add(this.Apaksa);
            this.Controls.Add(this.Auksa);
            this.Controls.Add(this.btn_tirit);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Misene";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Misene";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.Misene_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Auksa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Apaksa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuksaTukss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApaksaTukss)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_tirit;
        private System.Windows.Forms.PictureBox Auksa;
        private System.Windows.Forms.PictureBox Apaksa;
        private System.Windows.Forms.PictureBox AuksaTukss;
        private System.Windows.Forms.PictureBox ApaksaTukss;
    }
}