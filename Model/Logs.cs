using System;
using System.ComponentModel;
using System.IO;

namespace artsystem_bat.Model
{
    internal class Logs
    {
        private string logFilePath;
        private string logDirectoryPath;

        public Logs()
        {
            logDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogsArtBat");
            logFilePath = Path.Combine(logDirectoryPath, "ErrorLog.txt");
        }

        public void LogError(string errorMessage)
        {
            try
            {
                string logEntry = $"{DateTime.Now} - {errorMessage}";

                // Verifica se o diretório existe, se não, cria
                if (!Directory.Exists(logDirectoryPath))
                {
                    Directory.CreateDirectory(logDirectoryPath);
                }

                // Verifica se o arquivo existe, se não, cria
                if (!File.Exists(logFilePath))
                {
                    using (File.Create(logFilePath)) { }
                }

                // Escreve no arquivo de log
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (UnauthorizedAccessException ex)
            {
                System.Windows.Forms.MessageBox.Show($"Acesso não autorizado ao acessar o arquivo: {ex.Message}", "UnauthorizedAccessException", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch (Win32Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Windows Error: {ex.Message}", "Win32Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro ao salvar Log: {ex.Message}", "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
