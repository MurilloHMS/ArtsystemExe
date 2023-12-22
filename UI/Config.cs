using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using artsystem_bat.Data;

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
            //Instancia propriedades entities
            Entities entities = new Entities();

            //salva configurações em variaveis
            var pathInitial = entities.PathInitial;
            var pathBat = entities.PathBat;
            var verOcx = entities.VerOcx;

            // Atribua os valores aos controles da interface
            tbPath.Text = pathInitial;
            tbBat.Text = pathBat;

            cbOcx.Checked = Convert.ToBoolean(verOcx);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            tbPath.BackColor = SystemColors.Window;
            tbBat.BackColor = SystemColors.Window;

            tbPath.Enabled = true;
            tbBat.Enabled = true;
            cbOcx.Enabled = true;

            switch (btAlterar.Text)
            {
                case string value when value == "ALTERAR":
                    btAlterar.Text = "Salvar";
                    break;

                case string value when value == "Salvar":
                    Entities entities = new Entities();

                    //Atualiza as propriedades usando os setters
                    entities.PathInitial = tbPath.Text;
                    entities.PathBat = tbBat.Text;
                    entities.VerOcx = cbOcx.Checked ? "true" : "false"; // Substitui o if abaixo

                    MessageBox.Show("Dados salvos com sucesso", "Config.ini", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    tbPath.BackColor = SystemColors.InactiveCaption;
                    tbBat.BackColor = SystemColors.InactiveCaption;

                    tbPath.Enabled = false;
                    tbBat.Enabled = false;
                    cbOcx.Enabled = false;
                    btAlterar.Text = "ALTERAR";
                    break;

            }            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (tbPath.Enabled)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.InitialDirectory = tbPath.Text;
                    ofd.RestoreDirectory = true;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        tbBat.Text = ofd.FileName;
                    }
                }
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbBat.Enabled)
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
}
