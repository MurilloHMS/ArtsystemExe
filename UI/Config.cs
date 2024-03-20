using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using artsystem_bat.Model;
using artsystem_bat.UI;
using System.Diagnostics;
using System.Management;
using System.Collections.Generic;
using artsystem_bat.Data;

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
            CbPriorizaBat.Enabled = value;
            CbSistemaQuant.Enabled = value;
            RbMachine.Enabled = value;
            RbUser.Enabled = value;
            ;// Cb_Usuarios.Enabled = value;


        }

        private void Config_Load(object sender, EventArgs e)
        {
            //getUsers();
            Settings settings = new Settings();
            Entities entities = new Entities();

            //salva configurações em variaveis
            var pathInitial = settings.PathInitial;
            var pathBat =  settings.PathBat;
            var verOcx = settings.VerOcx;
            var removeUx = settings.RemoveUX;
            var loadingSpeed = settings.LoadingSpeed;
            var priorizaBat = settings.PriorizaBat;
            var localSalvamento =Convert.ToBoolean(settings.LocalSalvamento);
            var abrirSistema = settings.AbrirSistemaQuantidade;

            if (localSalvamento)
            {
                pathInitial = entities.PathInitial;
                pathBat = entities.PathBat;
                verOcx = entities.VerOcx;
                removeUx = entities.RemoveUX;
                loadingSpeed = entities.LoadingSpeed;
                priorizaBat = entities.PriorizaBat;
                localSalvamento = Convert.ToBoolean(entities.LocalSalvamento);
                abrirSistema = entities.AbrirSistemaQuantidade;
            }
            //var localDeRede = settings.LocalDeRede;
            //List<string> usuarios = settings.ListaDeUsuarios;

            // Atribua os valores aos controles da interface
            tbPath.Text = pathInitial;
            tbBat.Text = pathBat;

            cbOcx.Checked = Convert.ToBoolean(verOcx);
            cbRemoveUX.Checked = Convert.ToBoolean(removeUx);
            CbPriorizaBat.Checked = Convert.ToBoolean(priorizaBat);
            for (int i = 0; i < cbx_LoadingSpeed.Items.Count; i++)
            {
                if (cbx_LoadingSpeed.Items[i].ToString() == loadingSpeed)
                {
                    cbx_LoadingSpeed.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < CbSistemaQuant.Items.Count; i++)
            {
                if (CbSistemaQuant.Items[i].ToString() == abrirSistema)
                {
                    CbSistemaQuant.SelectedIndex = i;
                    break;
                }
            }
            if (localSalvamento)
            {
                RbUser.Checked = false;
                RbMachine.Checked = true;
            }
            else
            {
                RbMachine.Checked = false;
                RbUser.Checked = true;
            }
            /*if (usuarios != null)
            {
                foreach (string users in usuarios)
                {
                    int index = CkLb_Usuários.Items.IndexOf(users);
                    if (index != -1)
                    {
                        CkLb_Usuários.SetItemChecked(index, true);
                    }
                }
            }   */
        }

        private void getUsers()
        {
            try
            {
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_UserAccount");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection queryCollection = searcher.Get();

                foreach (ManagementObject m in queryCollection)
                {
                    // Adiciona informações sobre cada usuário ao CheckedListBox
                    //CkLb_Usuários.Items.Add($"{m["Name"]}");
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("Erro: " + e.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            tbPath.BackColor = SystemColors.Window;
            tbBat.BackColor = SystemColors.Window;
            List<string> users = new List<string>();

            updateForms(true);

            switch (btAlterar.Text)
            {
                case string value when value == "ALTERAR":
                    btAlterar.Text = "Salvar";
                    break;

                case string value when value == "Salvar":

                    var pathInitial = tbPath.Text;
                    var pathBat = tbBat.Text;
                    var verOCX = cbOcx.Checked ? "true" : "false";
                    var loading = cbx_LoadingSpeed.SelectedItem.ToString();
                    var removeUX = cbRemoveUX.Checked ? "true" : "false";
                    var priorizaBat = CbPriorizaBat.Checked ? "true" : "false";
                    var abrirSistemaQuant = CbSistemaQuant.SelectedItem.ToString();

                    Settings settings = new Settings();
                    Entities entities = new Entities();
                    //Atualiza as propriedades usando os setters
                    settings.PathInitial = pathInitial;
                    entities.PathInitial = pathInitial;
                    //
                    settings.PathBat = pathBat;
                    entities.PathBat = pathBat;
                    //
                    settings.VerOcx = verOCX;
                    entities.VerOcx = verOCX;
                    //
                    settings.LoadingSpeed = loading;
                    entities.LoadingSpeed = loading;
                    //
                    settings.RemoveUX = removeUX;
                    entities.RemoveUX = removeUX;
                    //
                    settings.PriorizaBat = priorizaBat;
                    entities.PriorizaBat = priorizaBat;
                    //
                    settings.AbrirSistemaQuantidade = abrirSistemaQuant;
                    entities.AbrirSistemaQuantidade = abrirSistemaQuant;
                    if (RbMachine.Checked) 
                    {
                        settings.LocalSalvamento = "true";
                        entities.LocalSalvamento = "true";
                    } else if (RbUser.Checked) 
                    {
                        settings.LocalSalvamento = "false";
                        entities.LocalSalvamento = "false";
                    }
                    /*foreach (object item in CkLb_Usuários.CheckedItems)
                    {
                        users.Add(item.ToString());
                    }
                    settings.ListaDeUsuarios = users;*/
                    MessageBox.Show("Dados salvos com sucesso", "Config.ini", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                    tbPath.BackColor = SystemColors.InactiveCaption;
                    tbBat.BackColor = SystemColors.InactiveCaption;

                    updateForms(false);
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

        private void cbVMapped_CheckedChanged(object sender, EventArgs e)
        {
            if(cbVMapped.Checked)
            {
                cbxLetter.Enabled = true;
                Txb_Mapear.Enabled =true;
                Btn_mapear.Enabled =true;
                Txb_Mapear.BackColor = SystemColors.Window;
            }
            else
            {
                cbxLetter.Enabled = false;
                Txb_Mapear.Enabled = false;
                Btn_mapear.Enabled = false;
                Txb_Mapear.BackColor = SystemColors.InactiveCaption;
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

        private void button4_Click(object sender, EventArgs e)
        {

            if (Txb_Mapear.Enabled)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);
                        Txb_Mapear.Text = fbd.SelectedPath;
                    }
                }
            }
        }

        private void Btn_mapear_Click(object sender, EventArgs e)
        {
            if ((cbxLetter.Items.Count > 0 && cbxLetter.SelectedItem != null) && !string.IsNullOrEmpty(Txb_Mapear.Text))
            {
                try
                {
                    string networkPath = Txb_Mapear.Text;
                    string driveLetter = cbxLetter.SelectedItem.ToString();

                    NetworkDrive mappedDrive = new NetworkDrive(networkPath, driveLetter);

                    mappedDrive.MapDrive();

                    tbPath.Text = mappedDrive.GetMappedPath();
                    tbBat.Text = string.Empty;

                    
                    cbVMapped.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao mapear a unidade {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show($"Insira os dados corretos");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /*if (Cb_Usuarios.Checked)
            {

                CkLb_Usuários.Enabled = true;
                
            }
            else 
            {
                CkLb_Usuários.Enabled = false;
            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Em desenvolvimento");
            return;
            DadosExtras dados = new DadosExtras();
            dados.ShowDialog();
        }
    }
}
