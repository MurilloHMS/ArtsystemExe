using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using artsystem_bat.Model;
using System.Diagnostics;

namespace artsystem_bat
{
    public partial class Config : Form 
    {
        public Config()
        {
            InitializeComponent();
        }

        private void updateForms(bool value)
        {
            tbPath.Enabled = value;
            tbBat.Enabled = value;
            cbOcx.Enabled = value;
            cbVMapped.Enabled = value;
            cbRemoveUX.Enabled = value;
            cbx_LoadingSpeed.Enabled = value;
        }

        private void Config_Load(object sender, EventArgs e)
        {
            
            Settings settings = new Settings();

            //salva configurações em variaveis
            var pathInitial = settings.PathInitial;
            var pathBat =  settings.PathBat;
            var verOcx = settings.VerOcx;
            var removeUx = settings.RemoveUX;
            var loadingSpeed = settings.LoadingSpeed;

            // Atribua os valores aos controles da interface
            tbPath.Text = pathInitial;
            tbBat.Text = pathBat;

            cbOcx.Checked = Convert.ToBoolean(verOcx);
            cbRemoveUX.Checked = Convert.ToBoolean(removeUx);
            cbx_LoadingSpeed.Text = loadingSpeed;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            tbPath.BackColor = SystemColors.Window;
            tbBat.BackColor = SystemColors.Window;

            updateForms(true);

            switch (btAlterar.Text)
            {
                case string value when value == "ALTERAR":
                    btAlterar.Text = "Salvar";
                    break;

                case string value when value == "Salvar":

                    Settings settings = new Settings();
                    //Atualiza as propriedades usando os setters
                    settings.PathInitial = tbPath.Text;
                    settings.PathBat = tbBat.Text;
                    settings.VerOcx = cbOcx.Checked ? "true" : "false";
                    settings.LoadingSpeed = cbx_LoadingSpeed.Text;
                    settings.RemoveUX = cbRemoveUX.Checked ? "true" : "false";

                    MessageBox.Show("Dados salvos com sucesso", "Config.ini", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    tbPath.BackColor = SystemColors.InactiveCaption;
                    tbBat.BackColor = SystemColors.InactiveCaption;

                    updateForms(false);
                    btAlterar.Text = "ALTERAR";
                    break;

                case string value when value == "Mapear":

                    if (!string.IsNullOrEmpty(cbxLetter.Text) && string.IsNullOrEmpty(tbPath.Text))
                    {
                        try
                        {
                            string networkPath = tbPath.Text;
                            string driveLetter = cbxLetter.Text;

                            NetworkDrive mappedDrive = new NetworkDrive(networkPath, driveLetter);

                            mappedDrive.MapDrive();

                            btAlterar.Text = "Salvar";

                            tbPath.Text = mappedDrive.GetMappedPath();

                            cbxLetter.Visible = false;
                            cbVMapped.Checked = false;
                        }
                        catch (Exception ex) 
                        {
                            MessageBox.Show($"Ocorreu um erro ao mapear a unidade {ex.Message}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Atenção\n insira a letra da unidade e o Path para mapear", "Mapeamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        private void cbVMapped_CheckedChanged(object sender, EventArgs e)
        {
            if(cbVMapped.Checked)
            {
                cbxLetter.Enabled = true;
                btAlterar.Text = "Mapear";
            }
            else
            {
                cbxLetter.Enabled = false;
                btAlterar.Text = "Salvar";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var logDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogsArtBat");
            var logFilePath = Path.Combine(logDirectoryPath, "ErrorLog.txt");
            
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(logFilePath);
            process.Start();
        }
    }
}
