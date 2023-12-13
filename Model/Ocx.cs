using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                // Adicione tratamento de erro adequado conforme necessário
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
                }
            }

            // Exibe a mensagem resultante em uma caixa de diálogo
            MessageBox.Show(resultMessage.ToString(), "Verificação OCX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            if(result.Contains("F"))
            {
                try
                {
                    // Recupera valores de configuração do aplicativo
                    var pathInitial = System.Configuration.ConfigurationManager.AppSettings["pathIni"];

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
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["verOcx"].Value = "false";
                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show($"Erro ao iniciar o processo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

            
        }
    }
}
