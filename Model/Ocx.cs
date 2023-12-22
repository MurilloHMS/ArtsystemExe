using artsystem_bat.Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace artsystem_bat.Model
{
    internal class Ocx
    {

        // Método estático para verificar se uma OCX está instalada no sistema
        static bool IsOCXInstalled(string ocxName)
        {
            bool achou = false;

            try
            {
                // Abre a chave do registro Wow6432Node\\CLSID, que armazena informações sobre objetos COM.
                // Se essa chave não existir, tenta abrir a chave CLSID diretamente.
                RegistryKey key = Registry.ClassesRoot.OpenSubKey("Wow6432Node\\CLSID");
                if (key == null)
                {
                    key = Registry.ClassesRoot.OpenSubKey("CLSID");
                }

                // Se a chave do registro for encontrada
                if (key != null)
                {
                    // Itera sobre as subchaves (CLSIDs) encontradas
                    foreach (var subKeyName in key.GetSubKeyNames())
                    {
                        // Abre a subchave InprocServer32 associada ao CLSID
                        RegistryKey clsidKey = key.OpenSubKey(subKeyName + "\\InprocServer32");

                        // Se a subchave InprocServer32 for encontrada
                        if (clsidKey != null)
                        {
                            // Obtém o valor padrão da subchave InprocServer32, que contém o caminho da DLL ou OCX
                            object value = clsidKey.GetValue("");

                            // Verifica se o valor contém o nome da OCX procurada
                            if (value != null && value.ToString().IndexOf(ocxName, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                achou = true;  // OCX encontrada
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao verificar OCX {ocxName}: {ex.Message}");
            }

            return achou;
        }

        // Método estático para executar a verificação de OCX
        public void RunOcxVerification()
        {
            // Lista de OCXs a serem verificadas
            List<string> OcxList = new List<string>
            {
                "mschrt20.ocx",
                "comctl32.ocx",
                "mscomct2.ocx",
                "mscomctl.ocx",
                "mscomm32.ocx",
                "comctl32.ocx"
            };

            List<string> result = new List<string>();
            List<string> ocxNotInstalled = new List<string>();

            StringBuilder resultMessage = new StringBuilder();

            // Para cada OCX na lista, verifica se está instalada e gera uma mensagem correspondente
            foreach (var ocxName in OcxList)
            {
                if (IsOCXInstalled(ocxName))
                {
                    resultMessage.AppendLine($"A OCX {ocxName} está instalada no sistema. ");
                    result.Add("T");
                }
                else
                {
                    resultMessage.AppendLine($"A OCX {ocxName} não está instalada no sistema. ");
                    result.Add("F");
                    ocxNotInstalled.Add(ocxName);
                }
            }

            // Exibe a mensagem resultante em uma caixa de diálogo
            //MessageBox.Show(resultMessage.ToString(), "Verificação OCX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            if(result.Contains("F"))
            {
                if (IsRunAsAdministrator())
                {
                    foreach(string ocxName in OcxList)
                    {
                        RegisterOCX(ocxName);
                    }
                }
                else
                {
                    try
                    {
                        // Recupera valores de configuração do aplicativo
                        Entities entities = new Entities();

                        //salva configurações em variaveis
                        var pathInitial = entities.PathInitial;

                        // Inicia o processo de registro de OCX
                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = $@"{pathInitial}\REGISTRAR_OCX.bat",
                            Verb = "runas",  // Solicitar privilégios de administrador
                            UseShellExecute = true
                        };

                        Process process = Process.Start(startInfo);
                        process.WaitForExit();

                        // Atualiza a configuração para desativar a verificação de OCX
                        //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //config.AppSettings.Settings["verOcx"].Value = "false";
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show($"Erro ao iniciar o processo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }            
        }

        static void RegisterOCX(string ocxName)
        {
            Entities entities = new Entities();

            //salva configurações em variaveis
            var pathBat = entities.PathBat;

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "regsvr32.exe";
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(pathBat);
                process.StartInfo.Arguments = $"/s {ocxName}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                //Aguarda o termino do processo
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    MessageBox.Show($"Erro ao registrar o arquivo: {ocxName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static bool IsRunAsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
