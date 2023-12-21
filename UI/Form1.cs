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
using artsystem_bat.Model;
using artsystem_bat.Data;

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
            //Instancia a classe entidades
            Entities entities = new Entities();
            // Recupera valores de configuração do aplicativo
            var verOcx = entities.VerOcx;

            // Executa a verificação da OCX se estiver ativada
            if (verOcx == "true")
            {
                Ocx ocx = new Ocx();
                ocx.RunOcxVerification();

            }

            // Executa a verificação e execução do diretório
            RunDirectoryVerification();

            // Inicia o temporizador para atualizar a barra de progresso
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Atualiza a barra de progresso e exibe mensagens com base no progresso
            if (progressBar1.Value < 100)
            {
                switch (progressBar1.Value)
                {
                    case int value when value < 40:
                        textBox1.Text = "Carregando arquivos";
                        break;

                    case int value when value >= 40 && value < 60:
                        textBox1.Text = "Verificando diretórios";
                        break;

                    case int value when value >= 60 && value < 80:
                        textBox1.Text = "Verificação concluída";
                        break;

                    case int value when value >= 80:
                        textBox1.Text = "Abrindo Artsystem";
                        break;
                }
                progressBar1.Value++;
            }
        }

        // Importa uma função da DLL user32.dll
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        // Método assíncrono para execução de um processo após um atraso
        private async void RunAsync()
        {
            await Task.Delay(2000);

            //Instancia a classe entidades
            Entities entities = new Entities();

            // Obtém o caminho do arquivo bat a ser executado
            var pathBat = entities.PathBat;

            try
            {
                // Inicia o processo do arquivo bat
                Process.Start(new ProcessStartInfo
                {
                    FileName = @pathBat,
                    WorkingDirectory = Path.GetDirectoryName(@pathBat), // Informa em qual diretório irá rodar o arquivo
                    WindowStyle = ProcessWindowStyle.Hidden // Esconde o processo a ser executado
                }).WaitForExit(); // Aguarda até que o processo termine
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close(); // Fecha o formulário após a conclusão do processo
            }
        }

        // Método assíncrono para verificação do diretório
        private async void RunDirectoryVerification()
        {
            await Task.Delay(1700);

            //Instancia a classe entidades
            Entities entities = new Entities();

            // Obtém o caminho do diretório a ser verificado
            var pathInitial = entities.PathInitial;

            // Verifica se o diretório existe
            if (!Directory.Exists(pathInitial))
            {
                // Se o diretório não existir, exibe uma mensagem de erro e fecha o formulário
                timer1.Stop();
                DialogResult dialog = MessageBox.Show($"Falha ao encontrar o diretório:\n\n {pathInitial}", "Verificação de diretório", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dialog == DialogResult.OK)
                {
                    Close();
                }
            }
            else if (Directory.Exists(pathInitial))
            {
                // Se o diretório existir, executa o método assíncrono para execução de um processo
                RunAsync();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
