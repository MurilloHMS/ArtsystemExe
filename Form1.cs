using artsystem_bat.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            var verOcx = System.Configuration.ConfigurationManager.AppSettings["verOcx"];
            var pathInitial = System.Configuration.ConfigurationManager.AppSettings["pathIni"];
            if (verOcx == "true")
            {
                RunOcxVerification();

                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = $@"{pathInitial}\REGISTRAR_OCX.bat",
                        Verb = "runas",  // Solicitar privilégios de administrador
                        UseShellExecute = true
                    };

                    Process process = Process.Start(startInfo);
                    process.WaitForExit();
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["verOcx"].Value = "false";

                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show($"Erro ao iniciar o processo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
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
            
            var pathBat =System.Configuration.ConfigurationManager.AppSettings["pathBat"];

            try
            {
               
                Process.Start(new ProcessStartInfo
                {
                    FileName = @pathBat,
                    WorkingDirectory = @pathBat.Substring(0,2), // Informa em qual diretório irá rodar o arquivo
                    WindowStyle = ProcessWindowStyle.Hidden // Esconde o processo a ser executado
                }).WaitForExit(); // Aguarda até que o processo termine
                
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }

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
                    Close();
                }
            }
            else if(Directory.Exists(pathInitial))
            {
                RunAsync();
            }
        }
        static bool IsOCXInstalled(string ocxName)
        {
            bool achou = false;

            try
            {
                RegistryKey key = Registry.ClassesRoot.OpenSubKey("Wow6432Node\\CLSID");
                if (key == null)
                {
                    key = Registry.ClassesRoot.OpenSubKey("CLSID");
                }

                if (key != null)
                {
                    foreach (var subKeyName in key.GetSubKeyNames())
                    {
                        RegistryKey clsidKey = key.OpenSubKey(subKeyName + "\\InprocServer32");
                        if (clsidKey != null)
                        {
                            object value = clsidKey.GetValue("");
                            if (value != null && value.ToString().IndexOf(ocxName, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                achou = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao verificar OCX {ocxName}: {ex.Message}");
                // Adicione tratamento de erro adequado conforme necessário
            }

            return achou;
        }

        static void RunOcxVerification()
        {
            List<string> OcxList = new List<string>
        {
             "mschrt20.ocx",
             "comctl32.ocx",
             "mscomct2.ocx",
             "mscomctl.ocx",
             "mscomm32.ocx",
             "comctl32.ocx"
        };

            StringBuilder resultMessage = new StringBuilder();

            foreach (var ocxName in OcxList)
            {
                if (IsOCXInstalled(ocxName))
                {
                    resultMessage.AppendLine($"A OCX {ocxName} está instalada no sistema. ");
                }
                else
                {
                    resultMessage.AppendLine($"A OCX {ocxName} não está instalada no sistema. ");
                }
            }

            MessageBox.Show(resultMessage.ToString(), "Verificação OCX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
