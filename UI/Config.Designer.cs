namespace artsystem_bat
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBat = new System.Windows.Forms.TextBox();
            this.btAlterar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbOcx = new System.Windows.Forms.CheckBox();
            this.cbVMapped = new System.Windows.Forms.CheckBox();
            this.cbxLetter = new System.Windows.Forms.ComboBox();
            this.cbRemoveUX = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_LoadingSpeed = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CbPriorizaBat = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            this.tbPath.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(12, 39);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(391, 22);
            this.tbPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pasta Mapeada ou Artsystem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Artsystem.Bat Path";
            // 
            // tbBat
            // 
            this.tbBat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbBat.Enabled = false;
            this.tbBat.Location = new System.Drawing.Point(12, 116);
            this.tbBat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBat.Name = "tbBat";
            this.tbBat.Size = new System.Drawing.Size(391, 22);
            this.tbBat.TabIndex = 2;
            // 
            // btAlterar
            // 
            this.btAlterar.Location = new System.Drawing.Point(59, 184);
            this.btAlterar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(144, 28);
            this.btAlterar.TabIndex = 5;
            this.btAlterar.Text = "ALTERAR";
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(211, 184);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(144, 28);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(359, 39);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Location = new System.Drawing.Point(359, 116);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // cbOcx
            // 
            this.cbOcx.AutoSize = true;
            this.cbOcx.Enabled = false;
            this.cbOcx.Location = new System.Drawing.Point(8, 48);
            this.cbOcx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbOcx.Name = "cbOcx";
            this.cbOcx.Size = new System.Drawing.Size(108, 20);
            this.cbOcx.TabIndex = 10;
            this.cbOcx.Text = "Verificar OCX";
            this.cbOcx.UseVisualStyleBackColor = true;
            // 
            // cbVMapped
            // 
            this.cbVMapped.AutoSize = true;
            this.cbVMapped.Enabled = false;
            this.cbVMapped.Location = new System.Drawing.Point(8, 27);
            this.cbVMapped.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbVMapped.Name = "cbVMapped";
            this.cbVMapped.Size = new System.Drawing.Size(131, 20);
            this.cbVMapped.TabIndex = 10;
            this.cbVMapped.Text = "Mapear Unidade";
            this.cbVMapped.UseVisualStyleBackColor = true;
            this.cbVMapped.CheckedChanged += new System.EventHandler(this.cbVMapped_CheckedChanged);
            // 
            // cbxLetter
            // 
            this.cbxLetter.Enabled = false;
            this.cbxLetter.FormattingEnabled = true;
            this.cbxLetter.Items.AddRange(new object[] {
            "Z:",
            "Y:",
            "X:",
            "W:",
            "V:",
            "U:",
            "T:",
            "S:",
            "R:",
            "Q:",
            "P:",
            "O:",
            "N:",
            "M:",
            "L:",
            "K:",
            "J:",
            "I:",
            "H:",
            "G:",
            "F:",
            "E:",
            "D:",
            "C:",
            "B:",
            "A:"});
            this.cbxLetter.Location = new System.Drawing.Point(5, 211);
            this.cbxLetter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxLetter.Name = "cbxLetter";
            this.cbxLetter.Size = new System.Drawing.Size(113, 24);
            this.cbxLetter.TabIndex = 12;
            // 
            // cbRemoveUX
            // 
            this.cbRemoveUX.AutoSize = true;
            this.cbRemoveUX.Enabled = false;
            this.cbRemoveUX.Location = new System.Drawing.Point(8, 70);
            this.cbRemoveUX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbRemoveUX.Name = "cbRemoveUX";
            this.cbRemoveUX.Size = new System.Drawing.Size(109, 20);
            this.cbRemoveUX.TabIndex = 13;
            this.cbRemoveUX.Text = "Remover UX ";
            this.cbRemoveUX.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 191);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Letra da Unidade";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbPriorizaBat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbx_LoadingSpeed);
            this.groupBox1.Controls.Add(this.cbRemoveUX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbOcx);
            this.groupBox1.Controls.Add(this.cbVMapped);
            this.groupBox1.Controls.Add(this.cbxLetter);
            this.groupBox1.Location = new System.Drawing.Point(464, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(225, 243);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações Adicionais";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Log";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::artsystem_bat.Properties.Resources.Event_Log;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(162, 204);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 37);
            this.button3.TabIndex = 18;
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Ms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tempo de Carregamento";
            // 
            // cbx_LoadingSpeed
            // 
            this.cbx_LoadingSpeed.Enabled = false;
            this.cbx_LoadingSpeed.FormattingEnabled = true;
            this.cbx_LoadingSpeed.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50 (Padrão)"});
            this.cbx_LoadingSpeed.Location = new System.Drawing.Point(5, 161);
            this.cbx_LoadingSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_LoadingSpeed.Name = "cbx_LoadingSpeed";
            this.cbx_LoadingSpeed.Size = new System.Drawing.Size(75, 24);
            this.cbx_LoadingSpeed.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.tbPath);
            this.groupBox2.Controls.Add(this.btAlterar);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.tbBat);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(16, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(444, 243);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados do Sistema";
            // 
            // CbPriorizaBat
            // 
            this.CbPriorizaBat.AutoSize = true;
            this.CbPriorizaBat.Enabled = false;
            this.CbPriorizaBat.Location = new System.Drawing.Point(9, 92);
            this.CbPriorizaBat.Margin = new System.Windows.Forms.Padding(4);
            this.CbPriorizaBat.Name = "CbPriorizaBat";
            this.CbPriorizaBat.Size = new System.Drawing.Size(107, 20);
            this.CbPriorizaBat.TabIndex = 20;
            this.CbPriorizaBat.Text = "Priorizar .Bat ";
            this.CbPriorizaBat.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 269);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artsystem Configurações";
            this.Load += new System.EventHandler(this.Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBat;
        private System.Windows.Forms.Button btAlterar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbOcx;
        private System.Windows.Forms.CheckBox cbVMapped;
        private System.Windows.Forms.ComboBox cbxLetter;
        private System.Windows.Forms.CheckBox cbRemoveUX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_LoadingSpeed;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CbPriorizaBat;
    }
}