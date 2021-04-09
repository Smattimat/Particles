
namespace Mondo {
    partial class FormControlli {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.lbNumElementi = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpControlli = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpAbout = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tpControlli.SuspendLayout();
            this.tpAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 1050);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(611, 122);
            this.button1.TabIndex = 0;
            this.button1.Text = "Esegui";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbNumElementi
            // 
            this.lbNumElementi.AutoSize = true;
            this.lbNumElementi.Location = new System.Drawing.Point(44, 105);
            this.lbNumElementi.Name = "lbNumElementi";
            this.lbNumElementi.Size = new System.Drawing.Size(127, 40);
            this.lbNumElementi.TabIndex = 1;
            this.lbNumElementi.Text = "Nessuno";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Nessuna azione"});
            this.comboBox1.Location = new System.Drawing.Point(23, 931);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(572, 48);
            this.comboBox1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpControlli);
            this.tabControl1.Controls.Add(this.tpAbout);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(633, 1389);
            this.tabControl1.TabIndex = 3;
            // 
            // tpControlli
            // 
            this.tpControlli.Controls.Add(this.label1);
            this.tpControlli.Controls.Add(this.label2);
            this.tpControlli.Controls.Add(this.button1);
            this.tpControlli.Controls.Add(this.lbNumElementi);
            this.tpControlli.Controls.Add(this.comboBox1);
            this.tpControlli.Location = new System.Drawing.Point(8, 54);
            this.tpControlli.Name = "tpControlli";
            this.tpControlli.Padding = new System.Windows.Forms.Padding(3);
            this.tpControlli.Size = new System.Drawing.Size(617, 1327);
            this.tpControlli.TabIndex = 0;
            this.tpControlli.Text = "Controlli";
            this.tpControlli.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 861);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Azioni disponibili";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "Elementi nel mondo:";
            // 
            // tpAbout
            // 
            this.tpAbout.Controls.Add(this.label4);
            this.tpAbout.Controls.Add(this.label3);
            this.tpAbout.Controls.Add(this.pictureBox1);
            this.tpAbout.Location = new System.Drawing.Point(8, 54);
            this.tpAbout.Name = "tpAbout";
            this.tpAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tpAbout.Size = new System.Drawing.Size(617, 1327);
            this.tpAbout.TabIndex = 1;
            this.tpAbout.Text = "About";
            this.tpAbout.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 760);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(496, 320);
            this.label4.TabIndex = 2;
            this.label4.Text = "Programma di studio realizzato in C#.\r\n.Net 5\r\nWindowsForm\r\nraylib\r\n..... con l\'a" +
    "ggiunta di qualche \r\nreminiscenza di fisica teorica.\r\n\r\nScritto in collaborazion" +
    "e con:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(14, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 106);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mondo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Mondo.Properties.Resources.BlackHole;
            this.pictureBox1.Location = new System.Drawing.Point(3, 142);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(611, 597);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormControlli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 1413);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormControlli";
            this.Text = "Mondo - FormControlli";
            this.Load += new System.EventHandler(this.FormControlli_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpControlli.ResumeLayout(false);
            this.tpControlli.PerformLayout();
            this.tpAbout.ResumeLayout(false);
            this.tpAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbNumElementi;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpControlli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tpAbout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}