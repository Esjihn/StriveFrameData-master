using System.Windows.Forms;

namespace StriveFrameData.Views
{
    partial class ExternalAdditionalNotesView
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDock = new System.Windows.Forms.Button();
            this.txtExternalAdditionalNotes = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(12, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(168, 53);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDock
            // 
            this.btnDock.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDock.Location = new System.Drawing.Point(898, 12);
            this.btnDock.Name = "btnDock";
            this.btnDock.Size = new System.Drawing.Size(101, 53);
            this.btnDock.TabIndex = 5;
            this.btnDock.Text = "Dock";
            this.btnDock.UseVisualStyleBackColor = true;
            this.btnDock.Click += new System.EventHandler(this.btnDock_Click);
            // 
            // txtExternalAdditionalNotes
            // 
            this.txtExternalAdditionalNotes.Font = new System.Drawing.Font("Arial", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExternalAdditionalNotes.Location = new System.Drawing.Point(12, 78);
            this.txtExternalAdditionalNotes.Name = "txtExternalAdditionalNotes";
            this.txtExternalAdditionalNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtExternalAdditionalNotes.Size = new System.Drawing.Size(987, 1372);
            this.txtExternalAdditionalNotes.TabIndex = 1;
            this.txtExternalAdditionalNotes.Text = "";
            // 
            // ExternalAdditionalNotesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 1501);
            this.ControlBox = false;
            this.Controls.Add(this.txtExternalAdditionalNotes);
            this.Controls.Add(this.btnDock);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExternalAdditionalNotesView";
            this.Text = "External Additional Notes";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDock;
        private System.Windows.Forms.RichTextBox txtExternalAdditionalNotes;
    }
}