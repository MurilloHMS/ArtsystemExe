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
            this.Cb_Usuarios = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RbUser = new System.Windows.Forms.RadioButton();
            this.RbMachine = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.CbSistemaQuant = new System.Windows.Forms.ComboBox();
            this.CbPriorizaBat = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_LoadingSpeed = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_mapear = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.Txb_Mapear = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_mapeamentoUsuarios = new System.Windows.Forms.TextBox();
            this.CkLb_Usuários = new System.Windows.Forms.CheckedListBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            this.tbPath.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(9, 32);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(294, 20);
            this.tbPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pasta Mapeada ou Artsystem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Artsystem.Bat Path";
            // 
            // tbBat
            // 
            this.tbBat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbBat.Enabled = false;
            this.tbBat.Location = new System.Drawing.Point(9, 82);
            this.tbBat.Name = "tbBat";
            this.tbBat.Size = new System.Drawing.Size(294, 20);
            this.tbBat.TabIndex = 2;
            // 
            // btAlterar
            // 
            this.btAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAlterar.Location = new System.Drawing.Point(336, 231);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(108, 23);
            this.btAlterar.TabIndex = 5;
            this.btAlterar.Text = "ALTERAR";
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Location = new System.Drawing.Point(450, 231);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(269, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(269, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // cbOcx
            // 
            this.cbOcx.AutoSize = true;
            this.cbOcx.Enabled = false;
            this.cbOcx.Location = new System.Drawing.Point(6, 39);
            this.cbOcx.Name = "cbOcx";
            this.cbOcx.Size = new System.Drawing.Size(89, 17);
            this.cbOcx.TabIndex = 10;
            this.cbOcx.Text = "Verificar OCX";
            this.cbOcx.UseVisualStyleBackColor = true;
            // 
            // cbVMapped
            // 
            this.cbVMapped.AutoSize = true;
            this.cbVMapped.Enabled = false;
            this.cbVMapped.Location = new System.Drawing.Point(6, 22);
            this.cbVMapped.Name = "cbVMapped";
            this.cbVMapped.Size = new System.Drawing.Size(105, 17);
            this.cbVMapped.TabIndex = 10;
            this.cbVMapped.Text = "Mapear Unidade";
            this.cbVMapped.UseVisualStyleBackColor = true;
            this.cbVMapped.CheckedChanged += new System.EventHandler(this.cbVMapped_CheckedChanged);
            // 
            // cbxLetter
            // 
            this.cbxLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbxLetter.Location = new System.Drawing.Point(220, 65);
            this.cbxLetter.Name = "cbxLetter";
            this.cbxLetter.Size = new System.Drawing.Size(77, 21);
            this.cbxLetter.TabIndex = 12;
            // 
            // cbRemoveUX
            // 
            this.cbRemoveUX.AutoSize = true;
            this.cbRemoveUX.Enabled = false;
            this.cbRemoveUX.Location = new System.Drawing.Point(6, 57);
            this.cbRemoveUX.Name = "cbRemoveUX";
            this.cbRemoveUX.Size = new System.Drawing.Size(90, 17);
            this.cbRemoveUX.TabIndex = 13;
            this.cbRemoveUX.Text = "Remover UX ";
            this.cbRemoveUX.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Letra da Unidade";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cb_Usuarios);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CbSistemaQuant);
            this.groupBox1.Controls.Add(this.CbPriorizaBat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbx_LoadingSpeed);
            this.groupBox1.Controls.Add(this.cbRemoveUX);
            this.groupBox1.Controls.Add(this.cbOcx);
            this.groupBox1.Controls.Add(this.cbVMapped);
            this.groupBox1.Location = new System.Drawing.Point(348, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 214);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações Adicionais";
            // 
            // Cb_Usuarios
            // 
            this.Cb_Usuarios.AutoSize = true;
            this.Cb_Usuarios.Enabled = false;
            this.Cb_Usuarios.Location = new System.Drawing.Point(7, 92);
            this.Cb_Usuarios.Name = "Cb_Usuarios";
            this.Cb_Usuarios.Size = new System.Drawing.Size(132, 17);
            this.Cb_Usuarios.TabIndex = 25;
            this.Cb_Usuarios.Text = "Mapeamento Usuários";
            this.Cb_Usuarios.UseVisualStyleBackColor = true;
            this.Cb_Usuarios.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RbUser);
            this.groupBox4.Controls.Add(this.RbMachine);
            this.groupBox4.Location = new System.Drawing.Point(6, 110);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(263, 95);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dados de Salvamento das Configurações";
            // 
            // RbUser
            // 
            this.RbUser.AutoSize = true;
            this.RbUser.Enabled = false;
            this.RbUser.Location = new System.Drawing.Point(6, 42);
            this.RbUser.Name = "RbUser";
            this.RbUser.Size = new System.Drawing.Size(109, 17);
            this.RbUser.TabIndex = 26;
            this.RbUser.TabStop = true;
            this.RbUser.Text = "Salvar no Usuário";
            this.RbUser.UseVisualStyleBackColor = true;
            // 
            // RbMachine
            // 
            this.RbMachine.AutoSize = true;
            this.RbMachine.Enabled = false;
            this.RbMachine.Location = new System.Drawing.Point(6, 22);
            this.RbMachine.Name = "RbMachine";
            this.RbMachine.Size = new System.Drawing.Size(114, 17);
            this.RbMachine.TabIndex = 25;
            this.RbMachine.TabStop = true;
            this.RbMachine.Text = "Salvar na Maquina";
            this.RbMachine.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Abrir Sistema";
            // 
            // CbSistemaQuant
            // 
            this.CbSistemaQuant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbSistemaQuant.Enabled = false;
            this.CbSistemaQuant.FormattingEnabled = true;
            this.CbSistemaQuant.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.CbSistemaQuant.Location = new System.Drawing.Point(157, 37);
            this.CbSistemaQuant.Name = "CbSistemaQuant";
            this.CbSistemaQuant.Size = new System.Drawing.Size(86, 21);
            this.CbSistemaQuant.TabIndex = 21;
            // 
            // CbPriorizaBat
            // 
            this.CbPriorizaBat.AutoSize = true;
            this.CbPriorizaBat.Enabled = false;
            this.CbPriorizaBat.Location = new System.Drawing.Point(6, 75);
            this.CbPriorizaBat.Name = "CbPriorizaBat";
            this.CbPriorizaBat.Size = new System.Drawing.Size(88, 17);
            this.CbPriorizaBat.TabIndex = 20;
            this.CbPriorizaBat.Text = "Priorizar .Bat ";
            this.CbPriorizaBat.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Carregamento em Ms";
            // 
            // cbx_LoadingSpeed
            // 
            this.cbx_LoadingSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbx_LoadingSpeed.Location = new System.Drawing.Point(157, 83);
            this.cbx_LoadingSpeed.Name = "cbx_LoadingSpeed";
            this.cbx_LoadingSpeed.Size = new System.Drawing.Size(86, 21);
            this.cbx_LoadingSpeed.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::artsystem_bat.Properties.Resources.Event_Log;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(982, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 30);
            this.button3.TabIndex = 18;
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbPath);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.tbBat);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 214);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados do Sistema";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Btn_mapear);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.Txb_Mapear);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbxLetter);
            this.groupBox3.Location = new System.Drawing.Point(9, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 95);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mapeamento";
            // 
            // Btn_mapear
            // 
            this.Btn_mapear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_mapear.Enabled = false;
            this.Btn_mapear.Location = new System.Drawing.Point(11, 65);
            this.Btn_mapear.Name = "Btn_mapear";
            this.Btn_mapear.Size = new System.Drawing.Size(108, 23);
            this.Btn_mapear.TabIndex = 18;
            this.Btn_mapear.Text = "MAPEAR";
            this.Btn_mapear.UseVisualStyleBackColor = true;
            this.Btn_mapear.Click += new System.EventHandler(this.Btn_mapear_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Endereço Para Mapear Unidade";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(263, 36);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Txb_Mapear
            // 
            this.Txb_Mapear.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Txb_Mapear.Enabled = false;
            this.Txb_Mapear.Location = new System.Drawing.Point(6, 38);
            this.Txb_Mapear.Name = "Txb_Mapear";
            this.Txb_Mapear.Size = new System.Drawing.Size(291, 20);
            this.Txb_Mapear.TabIndex = 15;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txt_mapeamentoUsuarios);
            this.groupBox5.Controls.Add(this.CkLb_Usuários);
            this.groupBox5.Location = new System.Drawing.Point(639, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(379, 210);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Usuários";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(297, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Informe o Mapeamento para impressoras(Ex: 192.168.10.100)";
            // 
            // txt_mapeamentoUsuarios
            // 
            this.txt_mapeamentoUsuarios.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_mapeamentoUsuarios.Enabled = false;
            this.txt_mapeamentoUsuarios.Location = new System.Drawing.Point(6, 169);
            this.txt_mapeamentoUsuarios.Name = "txt_mapeamentoUsuarios";
            this.txt_mapeamentoUsuarios.Size = new System.Drawing.Size(367, 20);
            this.txt_mapeamentoUsuarios.TabIndex = 19;
            // 
            // CkLb_Usuários
            // 
            this.CkLb_Usuários.Enabled = false;
            this.CkLb_Usuários.FormattingEnabled = true;
            this.CkLb_Usuários.HorizontalScrollbar = true;
            this.CkLb_Usuários.Location = new System.Drawing.Point(3, 16);
            this.CkLb_Usuários.Name = "CkLb_Usuários";
            this.CkLb_Usuários.Size = new System.Drawing.Size(373, 124);
            this.CkLb_Usuários.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(564, 231);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 23);
            this.button5.TabIndex = 20;
            this.button5.Text = "Extras";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 266);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btAlterar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artsystem Configurações";
            this.Load += new System.EventHandler(this.Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_LoadingSpeed;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox CbPriorizaBat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbSistemaQuant;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Btn_mapear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Txb_Mapear;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton RbUser;
        private System.Windows.Forms.RadioButton RbMachine;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox CkLb_Usuários;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_mapeamentoUsuarios;
        private System.Windows.Forms.CheckBox Cb_Usuarios;
        private System.Windows.Forms.Button button5;
    }
}