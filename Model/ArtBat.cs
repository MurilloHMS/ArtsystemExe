using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace artsystem_bat.Model
{
    internal class ArtBat
    {
        public void ArtBatExe(string diretorioExe)
        {
                Logs logger = new Logs();
                string tempPath = Path.GetTempPath();
            try
            {
                string tempPathNFeUtil = Path.Combine(Path.GetTempPath(), "NFe_Util");
                

                if (!Directory.Exists(tempPathNFeUtil) || TempDirVerification(diretorioExe, "NFe_Util"))
                {
                    CopyUtility.CopyNFeUtil(diretorioExe, tempPathNFeUtil);
                    CopyUtility.CopyFiles(diretorioExe, tempPath, "*.DLL", "*.SQL", "*.APP", "*.FLL");
                }
                if(TempFileVerification(diretorioExe, "ART_SYSTEM.EXE"))
                {
                    File.Copy(Path.Combine(diretorioExe, "WINRAR.EXE"), Path.Combine(tempPath, "WINRAR.EXE"), true);
                    File.Copy(Path.Combine(diretorioExe, "ART_SYSTEM.EXE"), Path.Combine(tempPath, "ART_SYSTEM.EXE"),true);

                }

               
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                Application.Exit();
            }
            finally
            {
                StartArtSystem(tempPath, diretorioExe);
            }
        }
        private static bool TempFileVerification(string diretorioExe, string value)
        {
            DateTime dataModificacaoExe = File.GetLastAccessTime(Path.Combine(diretorioExe, value));
            DateTime dataModificacaoTemporaria = File.GetLastAccessTime(Path.Combine(Path.GetTempPath(), value));
            return dataModificacaoExe > dataModificacaoTemporaria;
        }

        private static bool TempDirVerification( string diretorioExe, string value)
        {
            DateTime dataModificacaoExe = Directory.GetLastAccessTime(Path.Combine(diretorioExe, value));
            DateTime dataModificacaoTemporaria = Directory.GetLastAccessTime(Path.Combine(Path.GetTempPath(), value));
            return dataModificacaoExe > dataModificacaoTemporaria;

        }
        
        private static void StartArtSystem(string tempPath, string diretorioExe)
        {
            Logs logger = new Logs();
            Process process = new Process();
            process.StartInfo.FileName = Path.Combine(tempPath, "ART_SYSTEM.EXE");
            process.StartInfo.WorkingDirectory = diretorioExe;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            logger.LogError("Finalizando o EXE -> Sistema Aberto\n\n");
            Application.Exit();
            
        }
    }

    internal static class CopyUtility
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
