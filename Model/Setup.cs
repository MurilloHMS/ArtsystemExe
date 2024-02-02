using artsystem_bat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace artsystem_bat.Model
{
    public class Setup
    {
        private ProgressBar ProgressBar { get; }
        private int ValueToStop { get; }
        private TextBox TXT_ProgressBar { get; }
        private readonly Settings settings = new Settings();

        private readonly Dictionary<int, string> keyValues = new Dictionary<int, string>
        {
            {1, "Verificando OCX"},
            {40, "Verificando diretórios"},
            {60, "Verificação concluída"},
            {80, "Abrindo Artsystem"},
        };

        public Setup(ProgressBar progressBar, int valueToStop, TextBox txt_ProgressBar)
        {
            ProgressBar = progressBar ?? throw new ArgumentNullException(nameof(progressBar));
            ValueToStop = valueToStop;
            TXT_ProgressBar = txt_ProgressBar ?? throw new ArgumentNullException(nameof(txt_ProgressBar));
        }

        public async Task UpdateProgressBarAsync()
        {
            TXT_ProgressBar.Text = keyValues[ValueToStop];

            Settings settings = new Settings();
            bool RemoveUx;
            if (Convert.ToBoolean(settings.RemoveUX))
            {
                RemoveUx = true;
            }
            else
            {
                RemoveUx = false;
            }
            int LoadingSpeed = int.Parse(settings.LoadingSpeed);
            

            while (ProgressBar.Value < ValueToStop)
            {
                ProgressBar.Value++;
                if (!RemoveUx)
                {
                    await Task.Delay(LoadingSpeed); // Adiciona um pequeno atraso para a progressbar ser atualizada
                    
                }
            }          

            switch (TXT_ProgressBar.Text)
            {
                case "Verificando OCX":
                    await VerifyOcxAsync();
                    break;

                case "Verificando diretórios":
                    await RunDirectoryVerificationAsync();
                    break;

                case "Abrindo Artsystem":
                    await RunArtsystemAsync();
                    break;
            }
        }

        private async Task VerifyOcxAsync()
        {
            var verOcx = settings.VerOcx;

            if (verOcx == "true")
            {
                Ocx ocx = new Ocx();
                ocx.RunOcxVerification();
            }
        }

        private async Task RunDirectoryVerificationAsync()
        {
            var pathInitial = settings.PathInitial;

            if (!Directory.Exists(pathInitial))
            {
                var dialogResult = MessageBox.Show($"Falha ao encontrar o diretório:\n\n {pathInitial}",
                    "Verificação de diretório", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else
            {
                TXT_ProgressBar.Text = keyValues[60];
            }
        }

        private async Task RunArtsystemAsync()
        {
            var pathBat = settings.PathBat;
            var directory = Path.GetDirectoryName(@pathBat);

            try
            {
                ArtBat art = new ArtBat();
                art.ArtBatExe(directory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await Task.Run(() =>
                {
                    Application.Exit();
                });
            }
        }
    }
}
