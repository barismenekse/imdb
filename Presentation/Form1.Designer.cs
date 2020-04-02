namespace Presentation
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
            this.txtBxMovieName = new System.Windows.Forms.TextBox();
            this.btnListele = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lbMovies = new System.Windows.Forms.ListBox();
            this.lbCasts = new System.Windows.Forms.ListBox();
            this.lbDirectors = new System.Windows.Forms.ListBox();
            this.lbWriters = new System.Windows.Forms.ListBox();
            this.lbStars = new System.Windows.Forms.ListBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblBio = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBxMovieName
            // 
            this.txtBxMovieName.Location = new System.Drawing.Point(26, 100);
            this.txtBxMovieName.Margin = new System.Windows.Forms.Padding(6);
            this.txtBxMovieName.Name = "txtBxMovieName";
            this.txtBxMovieName.Size = new System.Drawing.Size(196, 31);
            this.txtBxMovieName.TabIndex = 0;
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(274, 100);
            this.btnListele.Margin = new System.Windows.Forms.Padding(6);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(150, 44);
            this.btnListele.TabIndex = 1;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_ClickAsync);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(470, 100);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(6);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(150, 44);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(647, 100);
            this.btnSil.Margin = new System.Windows.Forms.Padding(6);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(150, 44);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lbMovies
            // 
            this.lbMovies.FormattingEnabled = true;
            this.lbMovies.ItemHeight = 25;
            this.lbMovies.Location = new System.Drawing.Point(26, 261);
            this.lbMovies.Margin = new System.Windows.Forms.Padding(6);
            this.lbMovies.Name = "lbMovies";
            this.lbMovies.Size = new System.Drawing.Size(398, 229);
            this.lbMovies.TabIndex = 4;
            this.lbMovies.SelectedIndexChanged += new System.EventHandler(this.lbMovies_SelectedIndexChanged);
            // 
            // lbCasts
            // 
            this.lbCasts.FormattingEnabled = true;
            this.lbCasts.ItemHeight = 25;
            this.lbCasts.Location = new System.Drawing.Point(470, 261);
            this.lbCasts.Margin = new System.Windows.Forms.Padding(6);
            this.lbCasts.Name = "lbCasts";
            this.lbCasts.Size = new System.Drawing.Size(349, 229);
            this.lbCasts.TabIndex = 5;
            this.lbCasts.SelectedIndexChanged += new System.EventHandler(this.lbCasts_SelectedIndexChanged);
            // 
            // lbDirectors
            // 
            this.lbDirectors.FormattingEnabled = true;
            this.lbDirectors.ItemHeight = 25;
            this.lbDirectors.Location = new System.Drawing.Point(879, 59);
            this.lbDirectors.Margin = new System.Windows.Forms.Padding(6);
            this.lbDirectors.Name = "lbDirectors";
            this.lbDirectors.Size = new System.Drawing.Size(378, 204);
            this.lbDirectors.TabIndex = 6;
            // 
            // lbWriters
            // 
            this.lbWriters.FormattingEnabled = true;
            this.lbWriters.ItemHeight = 25;
            this.lbWriters.Location = new System.Drawing.Point(879, 280);
            this.lbWriters.Margin = new System.Windows.Forms.Padding(6);
            this.lbWriters.Name = "lbWriters";
            this.lbWriters.Size = new System.Drawing.Size(378, 229);
            this.lbWriters.TabIndex = 7;
            // 
            // lbStars
            // 
            this.lbStars.FormattingEnabled = true;
            this.lbStars.ItemHeight = 25;
            this.lbStars.Location = new System.Drawing.Point(879, 539);
            this.lbStars.Margin = new System.Windows.Forms.Padding(6);
            this.lbStars.Name = "lbStars";
            this.lbStars.Size = new System.Drawing.Size(378, 204);
            this.lbStars.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 496);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDescription.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(120, 25);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Description";
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.Location = new System.Drawing.Point(453, 496);
            this.lblBio.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBio.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(43, 25);
            this.lblBio.TabIndex = 10;
            this.lblBio.Text = "Bio";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(40, 202);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(69, 25);
            this.lblRate.TabIndex = 11;
            this.lblRate.Text = "Rate :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1826, 1129);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblBio);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lbStars);
            this.Controls.Add(this.lbWriters);
            this.Controls.Add(this.lbDirectors);
            this.Controls.Add(this.lbCasts);
            this.Controls.Add(this.lbMovies);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.txtBxMovieName);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBxMovieName;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.ListBox lbMovies;
        private System.Windows.Forms.ListBox lbCasts;
        private System.Windows.Forms.ListBox lbDirectors;
        private System.Windows.Forms.ListBox lbWriters;
        private System.Windows.Forms.ListBox lbStars;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.Label lblRate;
    }
}

