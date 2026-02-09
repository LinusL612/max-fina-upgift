namespace Djursomtexas_hater
{
    partial class Historik
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
            this.HistoriaList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HistoriaList
            // 
            this.HistoriaList.FormattingEnabled = true;
            this.HistoriaList.ItemHeight = 16;
            this.HistoriaList.Location = new System.Drawing.Point(12, 51);
            this.HistoriaList.Name = "HistoriaList";
            this.HistoriaList.Size = new System.Drawing.Size(776, 340);
            this.HistoriaList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Historik";
            // 
            // Historik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HistoriaList);
            this.Name = "Historik";
            this.Text = "Historik";
            this.Load += new System.EventHandler(this.Historik_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox HistoriaList;
        private System.Windows.Forms.Label label1;
    }
}