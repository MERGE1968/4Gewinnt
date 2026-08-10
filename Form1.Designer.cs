
namespace Win4Gewinnt
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbGelb = new System.Windows.Forms.RadioButton();
            this.rbRot = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(167, 15);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(83, 22);
            this.btnSet.TabIndex = 0;
            this.btnSet.Text = "Setzen";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "X / Y :";
            // 
            // textBoxX
            // 
            this.textBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.textBoxX.Location = new System.Drawing.Point(72, 12);
            this.textBoxX.MaxLength = 1;
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(34, 22);
            this.textBoxX.TabIndex = 2;
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.textBoxY.Location = new System.Drawing.Point(112, 12);
            this.textBoxY.MaxLength = 1;
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(34, 22);
            this.textBoxY.TabIndex = 3;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(395, 15);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(83, 22);
            this.btnAnalysis.TabIndex = 4;
            this.btnAnalysis.Text = "Analysieren";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.BtnAnalysis_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(395, 61);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(83, 23);
            this.btnLoadFile.TabIndex = 5;
            this.btnLoadFile.Text = "Load";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Spieler beginnt:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbGelb);
            this.groupBox1.Controls.Add(this.rbRot);
            this.groupBox1.Location = new System.Drawing.Point(21, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 38);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // rbGelb
            // 
            this.rbGelb.AutoSize = true;
            this.rbGelb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGelb.Location = new System.Drawing.Point(99, 10);
            this.rbGelb.Name = "rbGelb";
            this.rbGelb.Size = new System.Drawing.Size(55, 20);
            this.rbGelb.TabIndex = 10;
            this.rbGelb.Text = "Gelb";
            this.rbGelb.UseVisualStyleBackColor = true;
            // 
            // rbRot
            // 
            this.rbRot.AutoSize = true;
            this.rbRot.Checked = true;
            this.rbRot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRot.Location = new System.Drawing.Point(38, 10);
            this.rbRot.Name = "rbRot";
            this.rbRot.Size = new System.Drawing.Size(47, 20);
            this.rbRot.TabIndex = 9;
            this.rbRot.TabStop = true;
            this.rbRot.Text = "Rot";
            this.rbRot.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Datei:";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFileName.Location = new System.Drawing.Point(72, 61);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(317, 22);
            this.textBoxFileName.TabIndex = 11;
            this.textBoxFileName.Text = "C:\\Temp\\4Gewinnt\\Stellung1.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 177);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSet);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4 Gewinnt";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbGelb;
        private System.Windows.Forms.RadioButton rbRot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFileName;
    }
}

