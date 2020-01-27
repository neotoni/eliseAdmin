using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace Elise_Admin
{
    public static class EliseBL
    {
        public static string LoadDictionnary(string dicPath, string eliseServer)
        {
            try
            {
                string processPath = ConfigurationManager.AppSettings["processPath"];

                Process proc = new Process();

                ProcessStartInfo procStartInfo =
                   new ProcessStartInfo("cmd.exe", $@"/c {processPath} -l 1:f:\""SuperUser\"" -p Elise --allow-data-conversion-with-loss reload ""{dicPath}"" {eliseServer} --verbose");

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

        public static string[] CreateSnapshot(string dicPath, string eliseServer)
        {
            int cptLine = 2;
            string[] snapshot = new string[400];
            snapshot[cptLine] = "+++++>>>        Fichier                dataobject.ed                <<<+++++";
            cptLine++;
            string[] DataObject = File.ReadAllLines($@"{dicPath}/dataobject.ed");

            for (int i = 0; i < DataObject.Length; i++)
            {
                cptLine++;
                snapshot[cptLine] = DataObject[i];
            }

            var allProducts = Directory.GetFiles($@"{dicPath}/product");

            foreach (string prod in allProducts)
            {
                cptLine++;
                snapshot[cptLine] = $"+++++>>>                     Fichier      {prod}            <<< +++++";
                string[] prodContent = File.ReadAllLines($@"{prod}");
                cptLine++;
                for (int i = 0; i < prodContent.Length; i++)
                {
                    cptLine++;
                    snapshot[cptLine] = prodContent[i];
                }
            }

            return snapshot;
        }
    }
}