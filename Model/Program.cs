using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace artsystem_bat
{
    internal static class Program
    {
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length < 1 || !new List<string> {"CONFIG", "-C", "AS_INSTALL" }.Any(s => args[0].Contains(s.ToUpper())))  //Valores para abrir as configurações do sistema ex: artsystem_bat.exe config 
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1()); //Chama o formulário de loading
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
