using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace artsystem_bat.Model
{
    public class NetworkDrive
    {
        public string NetworkPath { get; set; }
        public string DriveLetter { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public NetworkDrive(string networkPath, string driveLetter)
        {
            NetworkPath = networkPath;
            DriveLetter = driveLetter;
        }

        public NetworkDrive(string networkPath, string driveLetter, string username, string password)
            : this(networkPath, driveLetter)
        {
            Username = username;
            Password = password;
        }

        // Método para mapear a unidade de rede
        public void MapDrive()
        {
            Process process = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "net",
                Arguments = BuildArguments(),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            process.StartInfo = startInfo;
            process.Start();

            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (process.ExitCode != 0)
            {
                MessageBox.Show($"Erro ao mapear unidade: {error}");
            }
        }

        // Método para desmapear a unidade de rede
        public void UnmapDrive()
        {
            Process process = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "net",
                Arguments = $"use {DriveLetter} /delete",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            process.StartInfo = startInfo;
            process.Start();

            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (process.ExitCode != 0)
            {
                MessageBox.Show($"Erro ao desmapear a unidade: {error}");
            }
        }

        // Método para obter o caminho do drive mapeado
        public string GetMappedPath()
        {
            DriveInfo driveInfo = new DriveInfo(DriveLetter);

            // Verifica se o drive está mapeado e pronto
            if (driveInfo.IsReady)
            {
                return driveInfo.RootDirectory.FullName;
            }

            return null; // Retorna null se o drive não estiver mapeado ou pronto
        }

        // Método para construir os argumentos para o comando "net"
        private string BuildArguments()
        {
            string arguments = $"use {DriveLetter} {NetworkPath}";

            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                arguments += $" /user:{Username} {Password}";
            }

            return arguments;
        }
    }
}
