using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace artsystem_bat.Model
{
    internal class ArtBat
    {
        public void ArtBatExe(string diretorioExe) 
        {
            //Caminho do diretório temporario da pasta NFe_util
            string tempPathNFeUtil = Path.Combine(Path.GetTempPath(), "NFe_Util");

            //verifica se a data de modificação do diretório NFe_Util na pasta raiz é maior que na pasta temporária
            DateTime dataModificacaoExe = Directory.GetLastAccessTime(Path.Combine(diretorioExe, "NFe_Util"));
            DateTime dataModificacaoTemporaria = Directory.GetLastAccessTime(tempPathNFeUtil);

            if (!Directory.Exists(tempPathNFeUtil) || dataModificacaoExe > dataModificacaoTemporaria)
            {
                //copia o diretório NFe_util para o diretório temporário
                CopyDirectory(Path.Combine(diretorioExe, "NFe_Util"), tempPathNFeUtil);
            }

            //lista de arquivos para copiar
            List<string> files = new List<string>() { "*.DLL", "*.SQL" , "*.APP", "*.FLL" };

            //copia os arquivos DLL, SQL e ART_SYSTEM.EXE para o diretório temporário
            string tempPath = Path.GetTempPath();
            foreach(string file in files)
            {
                CopyFiles(diretorioExe, tempPath, file);
            }
            File.Copy(Path.Combine(diretorioExe, "WINRAR.EXE"), Path.Combine(tempPath, "WINRAR.EXE"), true);
            File.Copy(Path.Combine(diretorioExe, "ART_SYSTEM.EXE"), Path.Combine(tempPath, "ART_SYSTEM.EXE"), true);

            //Inicia o sistema no diretório temporário
            Process process = new Process();
            process.StartInfo.FileName = Path.Combine(tempPath, "ART_SYSTEM.EXE");
            process.StartInfo.WorkingDirectory = diretorioExe;
            process.EnableRaisingEvents = true;
            
            try
            {
                //Inicia o artsystem
                process.Start();

                //fecha o programa
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o processo: {ex.Message}");
            }
        }

        //Método para copiar um diretório e seu conteúdo para outro local
        static void CopyDirectory(string sourcePath, string destPath)
        {
            if(!Directory.Exists(destPath)) 
            {
                Directory.CreateDirectory(destPath);
            }

            foreach(string file in Directory.GetFiles(sourcePath))
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

        //Método para copiar arquivos correspondentes ao padrão especificado
        static void CopyFiles(string sourcePath, string destPath, string searchPattern)
        {
            string[] files = Directory.GetFiles(sourcePath, searchPattern);
            foreach (string file in files)
            {
                string destFile = Path.Combine(destPath, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }
        }
    }
}
