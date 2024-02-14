using artsystem_bat.Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace artsystem_bat.Model
{
    internal class Ocx
    {
        private static bool IsOCXInstalled(string ocxName)
        {
            try
            {
                RegistryKey key = Registry.ClassesRoot.OpenSubKey("Wow6432Node\\CLSID") ?? Registry.ClassesRoot.OpenSubKey("CLSID");

                if (key != null)
                {
                    foreach (var subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey clsidKey = key.OpenSubKey(subKeyName + "\\InprocServer32"))
                        {
                            if (clsidKey != null)
                            {
                                object value = clsidKey.GetValue("");

                                if (value != null && value.ToString().IndexOf(ocxName, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs logger = new Logs();
                logger.LogError($"Erro ao verificar OCX {ocxName}: {ex.Message}");
            }

            return false;
        }

        private static void RegisterOCX(string ocxName)
        {
            Settings settings = new Settings();
            var pathBat = settings.PathBat;
            Logs logger = new Logs();

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "regsvr32.exe",
                    Verb = "runas",
                    WorkingDirectory = Path.GetDirectoryName(pathBat),
                    Arguments = $"/s {ocxName}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                Process process = Process.Start(startInfo);
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    MessageBox.Show($"Falha ao registrar o arquivo: {ocxName}");
                    logger.LogError($"Falha ao registrar o arquivo: {ocxName}");

                    // Se o registro direto falhou, chama o arquivo .bat
                    ExecuteRegisterOCXBatch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar a OCX {ocxName}: {ex.Message}");
                logger.LogError($"Erro ao registrar a OCX {ocxName}: {ex.Message}");
            }
        }

        private static void ExecuteRegisterOCXBatch()
        {

            // Recupera valores de configuração do aplicativo                        
            Settings settings = new Settings();

            //salva configurações em variaveis
            var pathInitial = settings.PathInitial;
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = $@"{pathInitial}\REGISTRAR_OCX.bat",
                    Verb = "runas",
                    UseShellExecute = true
                };

                Process process = Process.Start(startInfo);
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar o arquivo .bat: {ex.Message}");
            }
        }

        public void RunOcxVerification()
        {
            List<string> OcxList = new List<string>
            {
                "mschrt20.ocx",
                "comctl32.ocx",
                "mscomct2.ocx",
                "mscomctl.ocx",
                "mscomm32.ocx",
                "comctl32.ocx",
            };

            StringBuilder resultMessage = new StringBuilder();
            Logs logger = new Logs();

            foreach (var ocxName in OcxList)
            {
                bool isInstalled = IsOCXInstalled(ocxName);

                if (isInstalled)
                {
                    resultMessage.AppendLine($"O Arquivo {ocxName} está instalado no sistema.");
                }
                else
                {
                    resultMessage.AppendLine($"O Arquivo {ocxName} não está instalado no sistema.");
                    RegisterOCX(ocxName); // Tentar registrar a OCX
                }
            }

            logger.LogError(resultMessage.ToString());
        }
    }
}
