using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using artsystem_bat.Model;
using artsystem_bat.Data;
using System.Threading;

namespace artsystem_bat
{
    public partial class Form1 : Form
    {
        private bool isWaitingForTextChange = false;
        private TaskCompletionSource<bool> textChangedTaskCompletionSource;
        

        public Form1()
        {
            InitializeComponent();
            
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await RunSetupAsync();
        }

        private async Task RunSetupAsync()
        {
            Setup setup1 = new Setup(progressBar1, 1, Txt_Progressbar);
            await setup1.UpdateProgressBarAsync();

            Setup setup2 = new Setup(progressBar1, 40, Txt_Progressbar);
            await setup2.UpdateProgressBarAsync();

            Setup setup3 = new Setup(progressBar1, 80, Txt_Progressbar);
            await setup3.UpdateProgressBarAsync();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
