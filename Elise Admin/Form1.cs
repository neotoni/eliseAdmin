using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Elise_Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // var res = System.Diagnostics.Process.Start("CMD", @"/k Y:\ELISE\Bin\dictionaryadmin -l 1:f:\""SuperUser\"" -p Elise --allow-data-conversion-with-loss reload ""y:/ELISE/actirismatching_elise1"" elise://vwd-elise01:2800 --verbose");

                System.Diagnostics.Process proc = new Process();

                System.Diagnostics.ProcessStartInfo procStartInfo =
                   new System.Diagnostics.ProcessStartInfo("cmd.exe", @"/c Y:\ELISE\Bin\dictionaryadmin -l 1:f:\""SuperUser\"" -p Elise --allow-data-conversion-with-loss reload ""y:/ELISE/actirismatching_elise1"" elise://vwd-elise01:2800 --verbose");

                procStartInfo.UseShellExecute = false;

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;

                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it

                proc.StartInfo = procStartInfo;
                proc.Start();

                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.

                txtStatus.Text = result;
            }
            catch (Exception objException)
            {
                // Log the exception
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utility.NetworkDrive.MapNetworkDrive("R", @"\\vwd-elise01\c$");
            var dirs1 = Directory.GetDirectories("R:");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}