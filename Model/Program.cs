using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace artsystem_bat
{
    internal static class Program
    {
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length < 1 || !new List<string> { "config", "CONFIG", "-c", "-C", "as_install", "AS_INSTALL" }.Any(s => args[0].Contains(s)))  //Valores para abri as configurações do sistema ex: artsystem_bat.exe config 
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1()); //Chama o programa
                Application.Run(new Config()); //Chama as configurações
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
