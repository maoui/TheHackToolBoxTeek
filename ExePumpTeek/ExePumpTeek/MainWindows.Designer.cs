namespace EexPumpTeek
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonPump = new System.Windows.Forms.Button();
            this.numericUpDownMo = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKo = new System.Windows.Forms.NumericUpDown();
            this.radioButtonMo = new System.Windows.Forms.RadioButton();
            this.radioButtonKo = new System.Windows.Forms.RadioButton();
            this.buttonBrowsePump = new System.Windows.Forms.Button();
            this.textBoxPump = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.buttonPump);
            this.groupBox3.Controls.Add(this.numericUpDownMo);
            this.groupBox3.Controls.Add(this.numericUpDownKo);
            this.groupBox3.Controls.Add(this.radioButtonMo);
            this.groupBox3.Controls.Add(this.radioButtonKo);
            this.groupBox3.Controls.Add(this.buttonBrowsePump);
            this.groupBox3.Controls.Add(this.textBoxPump);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 182);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File Pumper";
            // 
            // buttonPump
            // 
            this.buttonPump.BackColor = System.Drawing.Color.Black;
            this.buttonPump.ForeColor = System.Drawing.Color.White;
            this.buttonPump.Location = new System.Drawing.Point(89, 144);
            this.buttonPump.Name = "buttonPump";
            this.buttonPump.Size = new System.Drawing.Size(296, 23);
            this.buttonPump.TabIndex = 12;
            this.buttonPump.Text = "Pump";
            this.buttonPump.UseVisualStyleBackColor = false;
            this.buttonPump.Click += new System.EventHandler(this.buttonPump_Click);
            // 
            // numericUpDownMo
            // 
            this.numericUpDownMo.Location = new System.Drawing.Point(89, 104);
            this.numericUpDownMo.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownMo.MinimumSize = new System.Drawing.Size(296, 0);
            this.numericUpDownMo.Name = "numericUpDownMo";
            this.numericUpDownMo.Size = new System.Drawing.Size(296, 22);
            this.numericUpDownMo.TabIndex = 11;
            this.numericUpDownMo.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            // 
            // numericUpDownKo
            // 
            this.numericUpDownKo.Location = new System.Drawing.Point(89, 80);
            this.numericUpDownKo.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numericUpDownKo.Name = "numericUpDownKo";
            this.numericUpDownKo.Size = new System.Drawing.Size(296, 22);
            this.numericUpDownKo.TabIndex = 10;
            this.numericUpDownKo.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // radioButtonMo
            // 
            this.radioButtonMo.AutoSize = true;
            this.radioButtonMo.ForeColor = System.Drawing.Color.White;
            this.radioButtonMo.Location = new System.Drawing.Point(9, 104);
            this.radioButtonMo.Name = "radioButtonMo";
            this.radioButtonMo.Size = new System.Drawing.Size(39, 18);
            this.radioButtonMo.TabIndex = 9;
            this.radioButtonMo.Text = "Mo";
            this.radioButtonMo.UseVisualStyleBackColor = true;
            // 
            // radioButtonKo
            // 
            this.radioButtonKo.AutoSize = true;
            this.radioButtonKo.Checked = true;
            this.radioButtonKo.ForeColor = System.Drawing.Color.White;
            this.radioButtonKo.Location = new System.Drawing.Point(9, 80);
            this.radioButtonKo.Name = "radioButtonKo";
            this.radioButtonKo.Size = new System.Drawing.Size(39, 18);
            this.radioButtonKo.TabIndex = 2;
            this.radioButtonKo.TabStop = true;
            this.radioButtonKo.Text = "Ko";
            this.radioButtonKo.UseVisualStyleBackColor = true;
            // 
            // buttonBrowsePump
            // 
            this.buttonBrowsePump.BackColor = System.Drawing.Color.Black;
            this.buttonBrowsePump.ForeColor = System.Drawing.Color.White;
            this.buttonBrowsePump.Location = new System.Drawing.Point(401, 46);
            this.buttonBrowsePump.Name = "buttonBrowsePump";
            this.buttonBrowsePump.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowsePump.TabIndex = 8;
            this.buttonBrowsePump.Text = "Browse ";
            this.buttonBrowsePump.UseVisualStyleBackColor = false;
            this.buttonBrowsePump.Click += new System.EventHandler(this.buttonBrowsePump_Click);
            // 
            // textBoxPump
            // 
            this.textBoxPump.Location = new System.Drawing.Point(89, 52);
            this.textBoxPump.Name = "textBoxPump";
            this.textBoxPump.Size = new System.Drawing.Size(296, 22);
            this.textBoxPump.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filename:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(524, 204);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 242);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Exe Pump Teek by Teeknofil";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonPump;
        private System.Windows.Forms.NumericUpDown numericUpDownMo;
        private System.Windows.Forms.NumericUpDown numericUpDownKo;
        private System.Windows.Forms.RadioButton radioButtonMo;
        private System.Windows.Forms.RadioButton radioButtonKo;
        private System.Windows.Forms.Button buttonBrowsePump;
        private System.Windows.Forms.TextBox textBoxPump;
        private System.Windows.Forms.Label label1;
    }
}

