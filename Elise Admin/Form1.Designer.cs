namespace Elise_Admin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnApplyDic = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.cboDictionnary = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEliseServer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnApplyDic
            // 
            this.btnApplyDic.Location = new System.Drawing.Point(1108, 112);
            this.btnApplyDic.Name = "btnApplyDic";
            this.btnApplyDic.Size = new System.Drawing.Size(209, 23);
            this.btnApplyDic.TabIndex = 0;
            this.btnApplyDic.Text = "applydic";
            this.btnApplyDic.UseVisualStyleBackColor = true;
            this.btnApplyDic.Click += new System.EventHandler(this.applyDic);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(673, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(51, 47);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(588, 401);
            this.txtStatus.TabIndex = 2;
            // 
            // cboDictionnary
            // 
            this.cboDictionnary.FormattingEnabled = true;
            this.cboDictionnary.Location = new System.Drawing.Point(673, 63);
            this.cboDictionnary.Name = "cboDictionnary";
            this.cboDictionnary.Size = new System.Drawing.Size(644, 21);
            this.cboDictionnary.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(670, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dictionnary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(670, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "EliseServer";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cboEliseServer
            // 
            this.cboEliseServer.FormattingEnabled = true;
            this.cboEliseServer.Location = new System.Drawing.Point(673, 112);
            this.cboEliseServer.Name = "cboEliseServer";
            this.cboEliseServer.Size = new System.Drawing.Size(296, 21);
            this.cboEliseServer.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 540);
            this.Controls.Add(this.cboEliseServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDictionnary);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnApplyDic);
            this.Name = "Form1";
            this.Text = "Elise Admin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApplyDic;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ComboBox cboDictionnary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEliseServer;
    }
}

