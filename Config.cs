﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace artsystem_bat
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            var pathInitial = System.Configuration.ConfigurationManager.AppSettings["pathIni"];
            var pathBat = System.Configuration.ConfigurationManager.AppSettings["pathBat"];

            tbPath.Text = (string) pathInitial;
            tbBat.Text = (string) pathBat;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbPath.BackColor = SystemColors.Window;
            tbBat.BackColor = SystemColors.Window;

            tbPath.Enabled = true;
            tbBat.Enabled = true;

            if (btAlterar.Text == "ALTERAR")
            {
                btAlterar.Text = "Salvar";
            } 
            else if (btAlterar.Text == "Salvar" && tbPath.Enabled == true)
            {

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["pathIni"].Value = tbPath.Text;
                config.AppSettings.Settings["pathBat"].Value = tbBat.Text;
                config.Save(ConfigurationSaveMode.Minimal);

                MessageBox.Show("Dados salvos com sucesso", "Config.ini", MessageBoxButtons.OK, MessageBoxIcon.Information);


                tbPath.BackColor = SystemColors.InactiveCaption;
                tbBat.BackColor = SystemColors.InactiveCaption;

                tbPath.Enabled = false;
                tbBat.Enabled = false;
                btAlterar.Text = "ALTERAR";
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = @"C:\";
                ofd.RestoreDirectory = true;

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    tbBat.Text = ofd.FileName;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    tbPath.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
