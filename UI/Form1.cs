using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using artsystem_bat.Model;
using artsystem_bat.Data;
using System.Threading;

namespace artsystem_bat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Logs logger = new Logs();
            logger.LogError("Abrindo Sistema");
            Settings settings = new Settings();
            var pathinitial = settings.PathInitial;
            var pathBat = settings.PathBat;
            if (!(string.IsNullOrEmpty(pathBat)) && !(string.IsNullOrEmpty(pathinitial)))
            {
                await RunSetupAsync();
            }
            else
            {
                var message = "Atenção os dados das configurações estão vazios\n\nPara acessar as configurações abra no CMD : Artsystem_bat.exe -c\n\nFechando o sistema...";
                logger.LogError(message);
                DialogResult msg =  MessageBox.Show("Deseja abrir as configurações?", "Configurações Nulas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    Config config = new Config();                    
                    config.ShowDialog();
                    
                }
                Application.Exit();
            }
        }

        private async Task RunSetupAsync()
        {
            Setup setup1 = new Setup(progressBar1, 1, Txt_Progressbar);
            await setup1.UpdateProgressBarAsync();

            Setup setup2 = new Setup(progressBar1, 40, Txt_Progressbar);
            await setup2.UpdateProgressBarAsync();

            Setup setup3 = new Setup(progressBar1, 80, Txt_Progressbar);
            await setup3.UpdateProgressBarAsync();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
