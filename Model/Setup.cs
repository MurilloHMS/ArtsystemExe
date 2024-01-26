using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace artsystem_bat.Model
{
    internal class Setup
    {

        public static void UpadateProgressBar(ProgressBar progressBar, int valueToStop, TextBox TXT_ProgressBar)
        {
            Dictionary<int, string> keyValues = new Dictionary<int, string>
            {
                {1 ,"Verificando OCX" },
                {40, "Verificando diretórios"},
                {60, "Verificação concluída" },
                {80, "Abrindo Artsystem" },
            };

            if (progressBar.Value < valueToStop)
            {
                
                progressBar.Value++;
            }
        }
    }
}
