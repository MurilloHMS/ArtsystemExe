using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace artsystem_bat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RunDirectoryVerification();
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                if (progressBar1.Value < 40)
                {
                    textBox1.Text = "Carregando arquivos";
                }
                else if (progressBar1.Value > 40 && progressBar1.Value < 60)
                {
                    textBox1.Text = "Verificando diretórios";
                }
                else if (progressBar1.Value > 60 && progressBar1.Value < 80)
                {
                    textBox1.Text = "Verificação concluida";
                }
                else if (progressBar1.Value > 80)
                {
                    textBox1.Text = "Abrindo Artsystem";
                }
                progressBar1.Value++;
            }
        }

        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        

        private async void RunAsync()
        {
            await Task.Delay(2000);
            
            var pathBat =new ProcessStartInfo( System.Configuration.ConfigurationManager.AppSettings["pathBat"]);
            pathBat.WindowStyle = ProcessWindowStyle.Hidden;

            object value = Process.Start($"@{pathBat}");
            Application.Exit();
        }

        private async void RunDirectoryVerification()
        {
            await Task.Delay(1700);

            var pathInitial = System.Configuration.ConfigurationManager.AppSettings["pathIni"];

            if (!Directory.Exists(pathInitial))
            {
                timer1.Stop();
                DialogResult dialog = MessageBox.Show($"Falha ao encontrar o diretório:\n\n {pathInitial}", "Verificação de diretório", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else if(Directory.Exists(pathInitial))
            {
                RunAsync();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
