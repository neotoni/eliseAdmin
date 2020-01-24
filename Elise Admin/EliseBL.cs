using System;
using System.Diagnostics;

namespace Elise_Admin
{
    public static class EliseBL
    {
        public static string LoadDictionnary(string dicPath, string eliseServer)
        {
            try
            {
                Process proc = new Process();

                ProcessStartInfo procStartInfo =
                   new ProcessStartInfo("cmd.exe", $@"/c Y:\ELISE\Bin\dictionaryadmin -l 1:f:\""SuperUser\"" -p Elise --allow-data-conversion-with-loss reload ""{dicPath}"" {eliseServer} --verbose");

                //ProcessStartInfo procStartInfo =
                //new ProcessStartInfo("cmd.exe", $@"/c Y:\ELISE\Bin\dictionaryadmin -l 1:f:\""SuperUser\"" -p Elise --allow-data-conversion-with-loss reload ""y:/EliseDictionnaries/actirismatching_elise1"" {eliseServer} --verbose");

                procStartInfo.UseShellExecute = false;
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.CreateNoWindow = true;
                proc.StartInfo = procStartInfo;
                proc.Start();

                return proc.StandardOutput.ReadToEnd();
            }
            catch (Exception objException)
            {
                // Log the exception
            }
            return "nOK";
        }
    }
}