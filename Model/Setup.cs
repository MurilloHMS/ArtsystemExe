﻿using System;
using System.Collections.Generic;
using System.IO;
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
                    Task.Delay(LoadingSpeed); // Adiciona um pequeno atraso para a progressbar ser atualizada

                }
            }          

            switch (TXT_ProgressBar.Text)
            {
                case "Verificando OCX":
                    VerifyOcxAsync();
                    break;

                case "Verificando diretórios":
                    RunDirectoryVerificationAsync();
                    break;

                case "Abrindo Artsystem":
                    RunArtsystemAsync();
                    break;
            }
        }

        private void VerifyOcxAsync()
        {
            var verOcx = settings.VerOcx;

            if (verOcx == "true")
            {
                Ocx ocx = new Ocx();
                ocx.RunOcxVerification();
            }
        }

        private void RunDirectoryVerificationAsync()
        {
            var pathInitial = settings.PathInitial;

            if (!Directory.Exists(pathInitial))
            {
                var dialogResult = MessageBox.Show($"Falha ao encontrar o diretório:\n\n {pathInitial}",
                    "Verificação de diretório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logs logger = new Logs();
                logger.LogError($"Falha ao encontrar o diretório: {pathInitial}");
                logger.LogError("Finalizando EXE por falha no Diretório\n\n");

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

        private void RunArtsystemAsync()
        {
            var pathBat = settings.PathBat;
            var directory = Path.GetDirectoryName(@pathBat);

            ArtBat art = new ArtBat();
            art.ArtBatExe(directory);
            
            
        }
    }
}
