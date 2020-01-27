using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;

namespace Elise_Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void applyDic(object sender, EventArgs e)
        {
            txtStatus.Text = string.Empty;

            Cursor.Current = Cursors.WaitCursor;

            if (cboDictionnary.SelectedItem == null || cboEliseServer.SelectedItem == null)
            {
                MessageBox.Show("Incomplet");
            }
            else
            {
                txtStatus.Text = EliseBL.LoadDictionnary(cboDictionnary.SelectedItem.ToString(), cboEliseServer.SelectedItem.ToString());

                bool updateDicStatus = CheckUpdate(txtStatus.Text);

                string dtCreation = (DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).Replace(':', 'h');

                string dic = cboDictionnary.SelectedItem.ToString().Replace('\\', ' ').Replace('/', ' ').Replace(':', ' ');

                string server = cboEliseServer.SelectedItem.ToString().Replace('\\', ' ').Replace('/', ' ').Replace(':', ' ');

                LogGeneral(server, dic, txtStatus.Text, dtCreation, updateDicStatus);

                LogCurrent(server, dic, dtCreation);
            }
            Cursor.Current = Cursors.Default;
        }

        private bool CheckUpdate(string text)
        {
            bool applyOk = false;

            applyOk = Regex.Matches(text, "Dictionary parse failed").Count == 0;

            applyOk = (Regex.Matches(text, "Dictionary version").Count == 1 || Regex.Matches(text, "ReloadDictionary").Count == 2);

            return applyOk;
        }

        private void LogCurrent(string server, string dic, string dtCreation)
        {
            var snap = EliseBL.CreateSnapshot(cboDictionnary.SelectedItem.ToString(), cboEliseServer.SelectedItem.ToString());

            string path = $@" {ConfigurationManager.AppSettings["logPath"]}/{dic} on {server} at {dtCreation}.txt";

            using (StreamWriter file = new StreamWriter(path, true))
            {
                foreach (string line in snap)
                {
                    file.WriteLine(line);
                }
            }
        }

        private void LogGeneral(string server, string dic, string cmdResult, string dtCreation, bool updateDicStatus)
        {
            string path = $@" {ConfigurationManager.AppSettings["logPath"]}/GeneralLog.txt";

            string status = updateDicStatus ? "OK" : "! NO OK";

            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine($"{status} Dic {dic} deployed on {server} at {dtCreation}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var allDics = Directory.GetDirectories(ConfigurationManager.AppSettings["dicPath"]);

            foreach (string dic in allDics)
            {
                if (!dic.Contains("Logs"))
                    cboDictionnary.Items.Add(dic);
            }

            cboEliseServer.Items.Add(ConfigurationManager.AppSettings["srvDEV"]);
            cboEliseServer.Items.Add(ConfigurationManager.AppSettings["srvTEST"]);
            cboEliseServer.Items.Add(ConfigurationManager.AppSettings["srvPROD"]);
            cboEliseServer.Items.Add(ConfigurationManager.AppSettings["srvS1"]);
            cboEliseServer.Items.Add(ConfigurationManager.AppSettings["srvS2"]);

            cboEliseServer.SelectedIndex = 0;

            cboDictionnary.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}