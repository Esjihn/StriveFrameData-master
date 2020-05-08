namespace StriveFrameData.Views
{
    partial class MainFrameDataView
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
            this.tabCharacters = new System.Windows.Forms.TabControl();
            this.tabSolPage = new System.Windows.Forms.TabPage();
            this.tabKyPage = new System.Windows.Forms.TabPage();
            this.tabMayPage = new System.Windows.Forms.TabPage();
            this.tabChippPage = new System.Windows.Forms.TabPage();
            this.tabPotemkinPage = new System.Windows.Forms.TabPage();
            this.tabAxlPage = new System.Windows.Forms.TabPage();
            this.tabFaustPage = new System.Windows.Forms.TabPage();
            this.tabCharacters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCharacters
            // 
            this.tabCharacters.Controls.Add(this.tabSolPage);
            this.tabCharacters.Controls.Add(this.tabKyPage);
            this.tabCharacters.Controls.Add(this.tabMayPage);
            this.tabCharacters.Controls.Add(this.tabChippPage);
            this.tabCharacters.Controls.Add(this.tabPotemkinPage);
            this.tabCharacters.Controls.Add(this.tabAxlPage);
            this.tabCharacters.Controls.Add(this.tabFaustPage);
            this.tabCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCharacters.Font = new System.Drawing.Font("Trebuchet MS", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCharacters.HotTrack = true;
            this.tabCharacters.Location = new System.Drawing.Point(0, 0);
            this.tabCharacters.Name = "tabCharacters";
            this.tabCharacters.Padding = new System.Drawing.Point(10, 15);
            this.tabCharacters.SelectedIndex = 0;
            this.tabCharacters.Size = new System.Drawing.Size(1415, 905);
            this.tabCharacters.TabIndex = 0;
            // 
            // tabSolPage
            // 
            this.tabSolPage.AutoScroll = true;
            this.tabSolPage.BackColor = System.Drawing.Color.LightBlue;
            this.tabSolPage.Location = new System.Drawing.Point(4, 79);
            this.tabSolPage.Name = "tabSolPage";
            this.tabSolPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabSolPage.Size = new System.Drawing.Size(1407, 822);
            this.tabSolPage.TabIndex = 1;
            this.tabSolPage.Text = "Sol";
            // 
            // tabKyPage
            // 
            this.tabKyPage.BackColor = System.Drawing.Color.LightBlue;
            this.tabKyPage.Location = new System.Drawing.Point(4, 79);
            this.tabKyPage.Name = "tabKyPage";
            this.tabKyPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabKyPage.Size = new System.Drawing.Size(1407, 822);
            this.tabKyPage.TabIndex = 2;
            this.tabKyPage.Text = "Ky";
            // 
            // tabMayPage
            // 
            this.tabMayPage.BackColor = System.Drawing.Color.LightBlue;
            this.tabMayPage.Location = new System.Drawing.Point(4, 79);
            this.tabMayPage.Name = "tabMayPage";
            this.tabMayPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMayPage.Size = new System.Drawing.Size(1407, 822);
            this.tabMayPage.TabIndex = 3;
            this.tabMayPage.Text = "May";
            // 
            // tabChippPage
            // 
            this.tabChippPage.BackColor = System.Drawing.Color.LightBlue;
            this.tabChippPage.Location = new System.Drawing.Point(4, 79);
            this.tabChippPage.Name = "tabChippPage";
            this.tabChippPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabChippPage.Size = new System.Drawing.Size(1407, 822);
            this.tabChippPage.TabIndex = 4;
            this.tabChippPage.Text = "Chipp";
            // 
            // tabPotemkinPage
            // 
            this.tabPotemkinPage.BackColor = System.Drawing.Color.LightBlue;
            this.tabPotemkinPage.Location = new System.Drawing.Point(4, 79);
            this.tabPotemkinPage.Name = "tabPotemkinPage";
            this.tabPotemkinPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPotemkinPage.Size = new System.Drawing.Size(1407, 822);
            this.tabPotemkinPage.TabIndex = 5;
            this.tabPotemkinPage.Text = "Potemkin";
            // 
            // tabAxlPage
            // 
            this.tabAxlPage.BackColor = System.Drawing.Color.LightBlue;
            this.tabAxlPage.Location = new System.Drawing.Point(4, 79);
            this.tabAxlPage.Name = "tabAxlPage";
            this.tabAxlPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabAxlPage.Size = new System.Drawing.Size(1407, 822);
            this.tabAxlPage.TabIndex = 6;
            this.tabAxlPage.Text = "Axl";
            // 
            // tabFaustPage
            // 
            this.tabFaustPage.BackColor = System.Drawing.Color.LightBlue;
            this.tabFaustPage.Location = new System.Drawing.Point(4, 79);
            this.tabFaustPage.Name = "tabFaustPage";
            this.tabFaustPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabFaustPage.Size = new System.Drawing.Size(1407, 822);
            this.tabFaustPage.TabIndex = 7;
            this.tabFaustPage.Text = "Faust";
            // 
            // MainFrameDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 905);
            this.Controls.Add(this.tabCharacters);
            this.Name = "MainFrameDataView";
            this.Text = "Guilty Gear Strive Frame Data";
            this.Load += new System.EventHandler(this.MainFrameDataView_Load);
            this.tabCharacters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCharacters;
        private System.Windows.Forms.TabPage tabSolPage;
        private System.Windows.Forms.TabPage tabKyPage;
        private System.Windows.Forms.TabPage tabMayPage;
        private System.Windows.Forms.TabPage tabChippPage;
        private System.Windows.Forms.TabPage tabPotemkinPage;
        private System.Windows.Forms.TabPage tabAxlPage;
        private System.Windows.Forms.TabPage tabFaustPage;
    }
}

