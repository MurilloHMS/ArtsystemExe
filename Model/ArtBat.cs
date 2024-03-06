using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

namespace artsystem_bat.Model
{
    internal class ArtBat
    {
         Logs logger = new Logs();
        public void ArtBatExe(string diretorioExe)
        {
            Settings settings = new Settings();
            bool priorizaBat = Convert.ToBoolean(settings.PriorizaBat);
            string tempPath = Path.GetTempPath();
            bool abrirSistema = true;
            int count = 1;
            int abrirSistemaCount = int.Parse(settings.AbrirSistemaQuantidade);

            try
            {
                if (priorizaBat)
                {
                    do
                    {
                        try
                        {
                            var pathBat = settings.PathBat;
                            Process process = new Process();
                            process.StartInfo.FileName = Path.Combine(@pathBat);
                            process.StartInfo.WorkingDirectory = diretorioExe;
                            process.StartInfo.UseShellExecute = true;
                            process.StartInfo.CreateNoWindow = true;
                            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process.Start();
                            logger.LogError("Abrindo o Artsystem.Bat\n\n");
                            abrirSistema = false;
                            Application.Exit();
                            count++;
                        }
                        catch (Exception ex)
                        {
                            logger.LogError($"{ex.Message}");
                        }
                    } while (count < abrirSistemaCount);
                    
                }
                else
                {
                    string tempPathNFeUtil = Path.Combine(Path.GetTempPath(), "NFe_Util");

                    if (!Directory.Exists(tempPathNFeUtil) || TempDirVerification(diretorioExe, "NFe_Util"))
                    {
                        CopyUtility.CopyNFeUtil(diretorioExe, tempPathNFeUtil);
                    }
                    if (TempFileVerification(diretorioExe, "ART_SYSTEM.EXE"))
                    {
                        CopyUtility.CopyFiles(diretorioExe, tempPath, "*.DLL", "*.SQL", "*.APP", "*.FLL");
                        File.Copy(Path.Combine(diretorioExe, "WINRAR.EXE"), Path.Combine(tempPath, "WINRAR.EXE"), true);
                        File.Copy(Path.Combine(diretorioExe, "ART_SYSTEM.EXE"), Path.Combine(tempPath, "ART_SYSTEM.EXE"), true);
                        abrirSistema=true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);                
            }
            if (abrirSistema)
            {
                StartArtSystem(tempPath, diretorioExe, abrirSistema);
            }
        }
        private static bool TempFileVerification(string diretorioExe, string value)
        {
            DateTime dataModificacaoExe = File.GetLastWriteTime(Path.Combine(diretorioExe, value));
            DateTime dataModificacaoTemporaria = File.GetLastWriteTime(Path.Combine(Path.GetTempPath(), value));
            return dataModificacaoExe > dataModificacaoTemporaria;
        }
        private static bool TempDirVerification( string diretorioExe, string value)
        {
            DateTime dataModificacaoExe = Directory.GetLastWriteTime(Path.Combine(diretorioExe, value));
            DateTime dataModificacaoTemporaria = Directory.GetLastWriteTime(Path.Combine(Path.GetTempPath(), value));
            return dataModificacaoExe > dataModificacaoTemporaria;

        }        
        private static void StartArtSystem(string tempPath, string diretorioExe, bool abrirSistema)
        {
            Logs logger = new Logs();
            Settings settings = new Settings();
            int abrirSistemaCount =  int.Parse(settings.AbrirSistemaQuantidade);
            int count = 0;            
            do
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = Path.Combine(tempPath, "ART_SYSTEM.EXE");
                    process.StartInfo.WorkingDirectory = diretorioExe;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    logger.LogError("Finalizando o EXE -> Sistema Aberto\n\n");
                    count++;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao Abrir o Sistema: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.LogError($"Erro ao Abrir o Sistema: {ex.Message}");
                    Application.Exit();
                }
            } while (count <= abrirSistemaCount);

            var usuarios = settings.ListaDeUsuarios;
            List<string> usuariosDesconectar = new List<string>();
            foreach (string s in usuarios) { usuariosDesconectar.Add(s); }// adiciona os usuários na lista
            conectarUsuarios(usuariosDesconectar);

            Application.Exit();
        }
        private static void conectarUsuarios(List<string> usuarios)
        {
            foreach (string usuario in usuarios)
            {
                conectarUsuario(usuario);
            }
        }

        private static void conectarUsuario(string nomeUsuario)
        {
            try
            {
                Settings settings = new Settings();
                var rede = settings.LocalDeRede;

                // Executar o processo do prompt de comando para desconectar o usuário
                Process processo = new Process();
                processo.StartInfo.FileName = "cmd.exe";
                processo.StartInfo.Arguments = $"/C IF /I \"%USERNAME%\"==\"{nomeUsuario}\" NET USE U: \\{rede}\\TPA /user:user sml10 /PERSISTENT:NO";
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.CreateNoWindow = true;
                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.RedirectStandardError = true;

                processo.Start();
                processo.WaitForExit();

                // Registrar qualquer saída ou erros, se necessário
                string saida = processo.StandardOutput.ReadToEnd();
                string erro = processo.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(saida))
                {
                    Console.WriteLine($"Saída do Comando para {nomeUsuario}: {saida}");
                }

                if (!string.IsNullOrEmpty(erro))
                {
                    Console.WriteLine($"Erro do Comando para {nomeUsuario}: {erro}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao desconectar o usuário {nomeUsuario}: {ex.Message}");
            }
        }
    }
    
    internal class CopyUtility
    {
        public static void CopyNFeUtil(string sourcePath, string destPath)
        {
            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }
            CopyDirectory(sourcePath, destPath);

        }
        public static void CopyFiles(string sourcePath, string destPath, params string[] searchPatterns)
        {
            Logs logger = new Logs();
            try
            {
                foreach (string pattern in searchPatterns)
                {
                    string[] files = Directory.GetFiles(sourcePath, pattern);
                    foreach (string file in files)
                    {
                        string destFile = Path.Combine(destPath, Path.GetFileName(file));
                        File.Copy(file, destFile, true);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.LogError($"Erro de autorização: {ex.Message}");
            }
            catch (IOException ex)
            {
                logger.LogError($"IO Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao Copiar o Arquivo: {ex.Message}");
            }

        }
        private static void CopyDirectory(string sourcePath, string destPath)
        {
            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string destFile = Path.Combine(destPath, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (string dir in Directory.GetDirectories(sourcePath))
            {
                string destDir = Path.Combine(destPath, Path.GetFileName(dir));
                CopyDirectory(dir, destDir);
            }
        }

        
    }
}
