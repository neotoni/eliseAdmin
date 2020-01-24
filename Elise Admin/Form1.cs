using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            if (cboDictionnary.SelectedItem == null || cboEliseServer.SelectedItem == null)
            {
                MessageBox.Show("Incomplet");
            }
            else
            {
                //txtStatus.Text = EliseBL.LoadDictionnary(cboDictionnary.SelectedItem.ToString(), cboEliseServer.SelectedItem.ToString());

                bool applyOk = false;

                applyOk = Regex.Matches(txtStatus.Text, "Dictionary parse failed").Count == 0;

                applyOk = (Regex.Matches(txtStatus.Text, "Dictionary version").Count == 1 || Regex.Matches(txtStatus.Text, "ReloadDictionary").Count == 2);

                var snap = EliseBL.CreateSnapshot(cboDictionnary.SelectedItem.ToString(), cboEliseServer.SelectedItem.ToString());

                //string path = $@"y:/EliseDictionnaries/Logs/{cboDictionnary.SelectedItem.ToString().Substring()}--on--{cboEliseServer.SelectedItem.ToString()}--{DateTime.Now.ToShortTimeString()}.txt";

                string path = $@"y:/EliseDictionnaries/Logs/dic1--on--elise1.txt";

                using (StreamWriter file = new StreamWriter(path, true))
                {
                    foreach (string line in snap)
                    {
                        file.WriteLine(line);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cptLine = 2;
            string[] snapshot = new string[400];
            snapshot[cptLine] = "+++++>>>        Fichier                dataobject.ed                <<<+++++";
            cptLine++;
            string[] DataObject = File.ReadAllLines($@"{cboDictionnary.SelectedItem.ToString()}/dataobject.ed");

            for (int i = 0; i < DataObject.Length; i++)
            {
                cptLine++;
                snapshot[cptLine] = DataObject[i];
            }

            var allProducts = Directory.GetFiles($@"{cboDictionnary.SelectedItem.ToString()}/product");

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var allDics = Directory.GetDirectories("y:/EliseDictionnaries");

            foreach (string dic in allDics)
            {
                cboDictionnary.Items.Add(dic);
            }

            cboEliseServer.Items.Add("elise://vwd-elise01:2800");
            cboEliseServer.Items.Add("elise://vwd-elise01:2900");
            cboEliseServer.Items.Add("elise://vwd-elise01:2901");

            cboEliseServer.SelectedIndex = 0;

            cboDictionnary.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}