namespace Djursomtexas_hater
{
    partial class Adoptionssida
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
            this.Djurlista = new System.Windows.Forms.ListBox();
            this.FörnamnBox = new System.Windows.Forms.TextBox();
            this.EfternamnBox = new System.Windows.Forms.TextBox();
            this.PersonnummerBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AdoptBtn = new System.Windows.Forms.Button();
            this.HistoryBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Djurlista
            // 
            this.Djurlista.FormattingEnabled = true;
            this.Djurlista.ItemHeight = 16;
            this.Djurlista.Location = new System.Drawing.Point(30, 24);
            this.Djurlista.Name = "Djurlista";
            this.Djurlista.Size = new System.Drawing.Size(722, 164);
            this.Djurlista.TabIndex = 0;
            this.Djurlista.SelectedIndexChanged += new System.EventHandler(this.Djurlista_SelectedIndexChanged);
            // 
            // FörnamnBox
            // 
            this.FörnamnBox.Location = new System.Drawing.Point(37, 31);
            this.FörnamnBox.Name = "FörnamnBox";
            this.FörnamnBox.Size = new System.Drawing.Size(100, 22);
            this.FörnamnBox.TabIndex = 1;
            // 
            // EfternamnBox
            // 
            this.EfternamnBox.Location = new System.Drawing.Point(216, 31);
            this.EfternamnBox.Name = "EfternamnBox";
            this.EfternamnBox.Size = new System.Drawing.Size(100, 22);
            this.EfternamnBox.TabIndex = 2;
            // 
            // PersonnummerBox
            // 
            this.PersonnummerBox.Location = new System.Drawing.Point(68, 100);
            this.PersonnummerBox.Name = "PersonnummerBox";
            this.PersonnummerBox.Size = new System.Drawing.Size(220, 22);
            this.PersonnummerBox.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.FörnamnBox);
            this.panel1.Controls.Add(this.PersonnummerBox);
            this.panel1.Controls.Add(this.EfternamnBox);
            this.panel1.Location = new System.Drawing.Point(30, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 179);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Persons nummer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Efternamn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Förnamn";
            // 
            // AdoptBtn
            // 
            this.AdoptBtn.BackgroundImage = global::Djursomtexas_hater.Properties.Resources.innocent;
            this.AdoptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdoptBtn.Location = new System.Drawing.Point(422, 210);
            this.AdoptBtn.Name = "AdoptBtn";
            this.AdoptBtn.Size = new System.Drawing.Size(330, 179);
            this.AdoptBtn.TabIndex = 5;
            this.AdoptBtn.Text = "Adoptera";
            this.AdoptBtn.UseVisualStyleBackColor = true;
            this.AdoptBtn.Click += new System.EventHandler(this.AdoptBtn_Click);
            // 
            // HistoryBtn
            // 
            this.HistoryBtn.Location = new System.Drawing.Point(230, 395);
            this.HistoryBtn.Name = "HistoryBtn";
            this.HistoryBtn.Size = new System.Drawing.Size(356, 53);
            this.HistoryBtn.TabIndex = 6;
            this.HistoryBtn.Text = "View History";
            this.HistoryBtn.UseVisualStyleBackColor = true;
            this.HistoryBtn.Click += new System.EventHandler(this.HistoryBtn_Click);
            // 
            // Adoptionssida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HistoryBtn);
            this.Controls.Add(this.AdoptBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Djurlista);
            this.Name = "Adoptionssida";
            this.Text = "Adoptionssida";
            this.Load += new System.EventHandler(this.Adoptionssida_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Djurlista;
        private System.Windows.Forms.TextBox FörnamnBox;
        private System.Windows.Forms.TextBox EfternamnBox;
        private System.Windows.Forms.TextBox PersonnummerBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AdoptBtn;
        private System.Windows.Forms.Button HistoryBtn;
    }
}