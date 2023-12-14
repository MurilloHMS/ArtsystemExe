using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace artsystem_bat
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length < 1 || args[0] != "config" && args[0] != "CONFIG" && args[0] !="-c" && args[0] != "-C") //Valores para abri as configurações do sistema ex: artsystem_bat.exe config 
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1()); //Chama o programa
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Config()); //Chama as configurações
            }

        }
    }
}
