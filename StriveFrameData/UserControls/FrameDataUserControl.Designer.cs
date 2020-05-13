using System.Drawing;

namespace StriveFrameData.UserControls
{
    partial class FrameDataUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblStandCloseHeader = new System.Windows.Forms.Label();
            this.lblStandFarHeader = new System.Windows.Forms.Label();
            this.lblCrouchMovesHeader = new System.Windows.Forms.Label();
            this.lblAdditionalNotes = new System.Windows.Forms.Label();
            this.txtAdditionalNotes = new System.Windows.Forms.RichTextBox();
            this.lblStandingPunch = new System.Windows.Forms.Label();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnUnderline = new System.Windows.Forms.Button();
            this.cbxStandingPunch = new System.Windows.Forms.ComboBox();
            this.cbxStandingDust = new System.Windows.Forms.ComboBox();
            this.cbxHeavySlash = new System.Windows.Forms.ComboBox();
            this.cbxStandingSlash = new System.Windows.Forms.ComboBox();
            this.cbxStandingKick = new System.Windows.Forms.ComboBox();
            this.cbxStandingNA = new System.Windows.Forms.ComboBox();
            this.cbxStandingCloseNotApplicable = new System.Windows.Forms.ComboBox();
            this.cbxStandingCloseKick = new System.Windows.Forms.ComboBox();
            this.cbxStandingCloseSlash = new System.Windows.Forms.ComboBox();
            this.cbxStandingCloseHeavySlash = new System.Windows.Forms.ComboBox();
            this.cbxStandingCloseDust = new System.Windows.Forms.ComboBox();
            this.cbxStandingClosePunch = new System.Windows.Forms.ComboBox();
            this.cbxCrouchingNotApplicable = new System.Windows.Forms.ComboBox();
            this.cbxCrouchKick = new System.Windows.Forms.ComboBox();
            this.cbxCrouchSlash = new System.Windows.Forms.ComboBox();
            this.cbxCrouchHeavySlash = new System.Windows.Forms.ComboBox();
            this.cbxCrouchingDust = new System.Windows.Forms.ComboBox();
            this.cbxCrouchingPunch = new System.Windows.Forms.ComboBox();
            this.lblStandingKick = new System.Windows.Forms.Label();
            this.lblStandingSlash = new System.Windows.Forms.Label();
            this.lblStandingHeavySlash = new System.Windows.Forms.Label();
            this.lblStandingDust = new System.Windows.Forms.Label();
            this.lblStandingNA = new System.Windows.Forms.Label();
            this.lblCloseStandingPunch = new System.Windows.Forms.Label();
            this.lblCloseStandingKick = new System.Windows.Forms.Label();
            this.lblCloseStandingSlash = new System.Windows.Forms.Label();
            this.lblCloseStandingHardSlash = new System.Windows.Forms.Label();
            this.lblCloseStandingDust = new System.Windows.Forms.Label();
            this.lblClosePunch = new System.Windows.Forms.Label();
            this.lblCrouchPunch = new System.Windows.Forms.Label();
            this.lblCrouchKick = new System.Windows.Forms.Label();
            this.lblCrouchSlash = new System.Windows.Forms.Label();
            this.lblCrouchHeavySlash = new System.Windows.Forms.Label();
            this.lblCrouchDust = new System.Windows.Forms.Label();
            this.lblCrouchNA = new System.Windows.Forms.Label();
            this.fldrBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtImportExportFileLocation = new System.Windows.Forms.RichTextBox();
            this.lblFileLocation = new System.Windows.Forms.Label();
            this.btnFolderBrowse = new System.Windows.Forms.Button();
            this.btnOpenExternalNotesForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(909, 618);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(172, 102);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(1106, 618);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(172, 102);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export Data";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblStandCloseHeader
            // 
            this.lblStandCloseHeader.AutoSize = true;
            this.lblStandCloseHeader.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandCloseHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandCloseHeader.Location = new System.Drawing.Point(473, 19);
            this.lblStandCloseHeader.Name = "lblStandCloseHeader";
            this.lblStandCloseHeader.Size = new System.Drawing.Size(338, 38);
            this.lblStandCloseHeader.TabIndex = 2;
            this.lblStandCloseHeader.Text = "Standing Close Moves";
            // 
            // lblStandFarHeader
            // 
            this.lblStandFarHeader.AutoSize = true;
            this.lblStandFarHeader.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandFarHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandFarHeader.Location = new System.Drawing.Point(99, 19);
            this.lblStandFarHeader.Name = "lblStandFarHeader";
            this.lblStandFarHeader.Size = new System.Drawing.Size(311, 38);
            this.lblStandFarHeader.TabIndex = 3;
            this.lblStandFarHeader.Text = "Standing Far Moves";
            // 
            // lblCrouchMovesHeader
            // 
            this.lblCrouchMovesHeader.AutoSize = true;
            this.lblCrouchMovesHeader.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrouchMovesHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCrouchMovesHeader.Location = new System.Drawing.Point(935, 19);
            this.lblCrouchMovesHeader.Name = "lblCrouchMovesHeader";
            this.lblCrouchMovesHeader.Size = new System.Drawing.Size(274, 38);
            this.lblCrouchMovesHeader.TabIndex = 4;
            this.lblCrouchMovesHeader.Text = "Crouching Moves";
            // 
            // lblAdditionalNotes
            // 
            this.lblAdditionalNotes.AutoSize = true;
            this.lblAdditionalNotes.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionalNotes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAdditionalNotes.Location = new System.Drawing.Point(60, 488);
            this.lblAdditionalNotes.Name = "lblAdditionalNotes";
            this.lblAdditionalNotes.Size = new System.Drawing.Size(260, 38);
            this.lblAdditionalNotes.TabIndex = 5;
            this.lblAdditionalNotes.Text = "Additional Notes";
            // 
            // txtAdditionalNotes
            // 
            this.txtAdditionalNotes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalNotes.Location = new System.Drawing.Point(56, 529);
            this.txtAdditionalNotes.Name = "txtAdditionalNotes";
            this.txtAdditionalNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtAdditionalNotes.Size = new System.Drawing.Size(767, 191);
            this.txtAdditionalNotes.TabIndex = 6;
            this.txtAdditionalNotes.Text = "";
            // 
            // lblStandingPunch
            // 
            this.lblStandingPunch.AutoSize = true;
            this.lblStandingPunch.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandingPunch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandingPunch.Location = new System.Drawing.Point(71, 85);
            this.lblStandingPunch.Name = "lblStandingPunch";
            this.lblStandingPunch.Size = new System.Drawing.Size(55, 38);
            this.lblStandingPunch.TabIndex = 28;
            this.lblStandingPunch.Text = "5P";
            // 
            // btnBold
            // 
            this.btnBold.Location = new System.Drawing.Point(0, 0);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(75, 23);
            this.btnBold.TabIndex = 73;
            // 
            // btnItalic
            // 
            this.btnItalic.Location = new System.Drawing.Point(0, 0);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(75, 23);
            this.btnItalic.TabIndex = 72;
            // 
            // btnUnderline
            // 
            this.btnUnderline.Location = new System.Drawing.Point(0, 0);
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(75, 23);
            this.btnUnderline.TabIndex = 71;
            // 
            // cbxStandingPunch
            // 
            this.cbxStandingPunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingPunch.FormattingEnabled = true;
            this.cbxStandingPunch.Location = new System.Drawing.Point(132, 81);
            this.cbxStandingPunch.Name = "cbxStandingPunch";
            this.cbxStandingPunch.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingPunch.TabIndex = 32;
            // 
            // cbxStandingDust
            // 
            this.cbxStandingDust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingDust.FormattingEnabled = true;
            this.cbxStandingDust.Location = new System.Drawing.Point(132, 289);
            this.cbxStandingDust.Name = "cbxStandingDust";
            this.cbxStandingDust.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingDust.TabIndex = 33;
            // 
            // cbxHeavySlash
            // 
            this.cbxHeavySlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHeavySlash.FormattingEnabled = true;
            this.cbxHeavySlash.Location = new System.Drawing.Point(132, 237);
            this.cbxHeavySlash.Name = "cbxHeavySlash";
            this.cbxHeavySlash.Size = new System.Drawing.Size(278, 40);
            this.cbxHeavySlash.TabIndex = 34;
            // 
            // cbxStandingSlash
            // 
            this.cbxStandingSlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingSlash.FormattingEnabled = true;
            this.cbxStandingSlash.Location = new System.Drawing.Point(132, 185);
            this.cbxStandingSlash.Name = "cbxStandingSlash";
            this.cbxStandingSlash.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingSlash.TabIndex = 35;
            // 
            // cbxStandingKick
            // 
            this.cbxStandingKick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingKick.FormattingEnabled = true;
            this.cbxStandingKick.Location = new System.Drawing.Point(132, 133);
            this.cbxStandingKick.Name = "cbxStandingKick";
            this.cbxStandingKick.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingKick.TabIndex = 36;
            // 
            // cbxStandingNA
            // 
            this.cbxStandingNA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingNA.FormattingEnabled = true;
            this.cbxStandingNA.Location = new System.Drawing.Point(132, 341);
            this.cbxStandingNA.Name = "cbxStandingNA";
            this.cbxStandingNA.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingNA.TabIndex = 37;
            // 
            // cbxStandingCloseNotApplicable
            // 
            this.cbxStandingCloseNotApplicable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingCloseNotApplicable.FormattingEnabled = true;
            this.cbxStandingCloseNotApplicable.Location = new System.Drawing.Point(546, 341);
            this.cbxStandingCloseNotApplicable.Name = "cbxStandingCloseNotApplicable";
            this.cbxStandingCloseNotApplicable.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingCloseNotApplicable.TabIndex = 43;
            // 
            // cbxStandingCloseKick
            // 
            this.cbxStandingCloseKick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingCloseKick.FormattingEnabled = true;
            this.cbxStandingCloseKick.Location = new System.Drawing.Point(546, 133);
            this.cbxStandingCloseKick.Name = "cbxStandingCloseKick";
            this.cbxStandingCloseKick.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingCloseKick.TabIndex = 42;
            // 
            // cbxStandingCloseSlash
            // 
            this.cbxStandingCloseSlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingCloseSlash.FormattingEnabled = true;
            this.cbxStandingCloseSlash.Location = new System.Drawing.Point(546, 185);
            this.cbxStandingCloseSlash.Name = "cbxStandingCloseSlash";
            this.cbxStandingCloseSlash.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingCloseSlash.TabIndex = 41;
            // 
            // cbxStandingCloseHeavySlash
            // 
            this.cbxStandingCloseHeavySlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingCloseHeavySlash.FormattingEnabled = true;
            this.cbxStandingCloseHeavySlash.Location = new System.Drawing.Point(546, 237);
            this.cbxStandingCloseHeavySlash.Name = "cbxStandingCloseHeavySlash";
            this.cbxStandingCloseHeavySlash.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingCloseHeavySlash.TabIndex = 40;
            // 
            // cbxStandingCloseDust
            // 
            this.cbxStandingCloseDust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingCloseDust.FormattingEnabled = true;
            this.cbxStandingCloseDust.Location = new System.Drawing.Point(546, 289);
            this.cbxStandingCloseDust.Name = "cbxStandingCloseDust";
            this.cbxStandingCloseDust.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingCloseDust.TabIndex = 39;
            // 
            // cbxStandingClosePunch
            // 
            this.cbxStandingClosePunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStandingClosePunch.FormattingEnabled = true;
            this.cbxStandingClosePunch.Location = new System.Drawing.Point(546, 81);
            this.cbxStandingClosePunch.Name = "cbxStandingClosePunch";
            this.cbxStandingClosePunch.Size = new System.Drawing.Size(278, 40);
            this.cbxStandingClosePunch.TabIndex = 38;
            // 
            // cbxCrouchingNotApplicable
            // 
            this.cbxCrouchingNotApplicable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCrouchingNotApplicable.FormattingEnabled = true;
            this.cbxCrouchingNotApplicable.Location = new System.Drawing.Point(954, 341);
            this.cbxCrouchingNotApplicable.Name = "cbxCrouchingNotApplicable";
            this.cbxCrouchingNotApplicable.Size = new System.Drawing.Size(278, 40);
            this.cbxCrouchingNotApplicable.TabIndex = 49;
            // 
            // cbxCrouchKick
            // 
            this.cbxCrouchKick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCrouchKick.FormattingEnabled = true;
            this.cbxCrouchKick.Location = new System.Drawing.Point(954, 133);
            this.cbxCrouchKick.Name = "cbxCrouchKick";
            this.cbxCrouchKick.Size = new System.Drawing.Size(278, 40);
            this.cbxCrouchKick.TabIndex = 48;
            // 
            // cbxCrouchSlash
            // 
            this.cbxCrouchSlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCrouchSlash.FormattingEnabled = true;
            this.cbxCrouchSlash.Location = new System.Drawing.Point(954, 185);
            this.cbxCrouchSlash.Name = "cbxCrouchSlash";
            this.cbxCrouchSlash.Size = new System.Drawing.Size(278, 40);
            this.cbxCrouchSlash.TabIndex = 47;
            // 
            // cbxCrouchHeavySlash
            // 
            this.cbxCrouchHeavySlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCrouchHeavySlash.FormattingEnabled = true;
            this.cbxCrouchHeavySlash.Location = new System.Drawing.Point(954, 237);
            this.cbxCrouchHeavySlash.Name = "cbxCrouchHeavySlash";
            this.cbxCrouchHeavySlash.Size = new System.Drawing.Size(278, 40);
            this.cbxCrouchHeavySlash.TabIndex = 46;
            // 
            // cbxCrouchingDust
            // 
            this.cbxCrouchingDust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCrouchingDust.FormattingEnabled = true;
            this.cbxCrouchingDust.Location = new System.Drawing.Point(954, 289);
            this.cbxCrouchingDust.Name = "cbxCrouchingDust";
            this.cbxCrouchingDust.Size = new System.Drawing.Size(278, 40);
            this.cbxCrouchingDust.TabIndex = 45;
            // 
            // cbxCrouchingPunch
            // 
            this.cbxCrouchingPunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCrouchingPunch.FormattingEnabled = true;
            this.cbxCrouchingPunch.Location = new System.Drawing.Point(954, 81);
            this.cbxCrouchingPunch.Name = "cbxCrouchingPunch";
            this.cbxCrouchingPunch.Size = new System.Drawing.Size(278, 40);
            this.cbxCrouchingPunch.TabIndex = 44;
            // 
            // lblStandingKick
            // 
            this.lblStandingKick.AutoSize = true;
            this.lblStandingKick.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandingKick.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandingKick.Location = new System.Drawing.Point(66, 137);
            this.lblStandingKick.Name = "lblStandingKick";
            this.lblStandingKick.Size = new System.Drawing.Size(60, 38);
            this.lblStandingKick.TabIndex = 50;
            this.lblStandingKick.Text = "5K";
            // 
            // lblStandingSlash
            // 
            this.lblStandingSlash.AutoSize = true;
            this.lblStandingSlash.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandingSlash.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandingSlash.Location = new System.Drawing.Point(70, 189);
            this.lblStandingSlash.Name = "lblStandingSlash";
            this.lblStandingSlash.Size = new System.Drawing.Size(53, 38);
            this.lblStandingSlash.TabIndex = 51;
            this.lblStandingSlash.Text = "5S";
            // 
            // lblStandingHeavySlash
            // 
            this.lblStandingHeavySlash.AutoSize = true;
            this.lblStandingHeavySlash.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandingHeavySlash.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandingHeavySlash.Location = new System.Drawing.Point(47, 241);
            this.lblStandingHeavySlash.Name = "lblStandingHeavySlash";
            this.lblStandingHeavySlash.Size = new System.Drawing.Size(79, 38);
            this.lblStandingHeavySlash.TabIndex = 52;
            this.lblStandingHeavySlash.Text = "5HS";
            // 
            // lblStandingDust
            // 
            this.lblStandingDust.AutoSize = true;
            this.lblStandingDust.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandingDust.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandingDust.Location = new System.Drawing.Point(67, 293);
            this.lblStandingDust.Name = "lblStandingDust";
            this.lblStandingDust.Size = new System.Drawing.Size(59, 38);
            this.lblStandingDust.TabIndex = 53;
            this.lblStandingDust.Text = "5D";
            // 
            // lblStandingNA
            // 
            this.lblStandingNA.AutoSize = true;
            this.lblStandingNA.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandingNA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStandingNA.Location = new System.Drawing.Point(38, 345);
            this.lblStandingNA.Name = "lblStandingNA";
            this.lblStandingNA.Size = new System.Drawing.Size(92, 38);
            this.lblStandingNA.TabIndex = 54;
            this.lblStandingNA.Text = "5 NA";
            // 
            // lblCloseStandingPunch
            // 
            this.lblCloseStandingPunch.AutoSize = true;
            this.lblCloseStandingPunch.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseStandingPunch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCloseStandingPunch.Location = new System.Drawing.Point(452, 85);
            this.lblCloseStandingPunch.Name = "lblCloseStandingPunch";
            this.lblCloseStandingPunch.Size = new System.Drawing.Size(88, 38);
            this.lblCloseStandingPunch.TabIndex = 55;
            this.lblCloseStandingPunch.Text = "cl 5P";
            // 
            // lblCloseStandingKick
            // 
            this.lblCloseStandingKick.AutoSize = true;
            this.lblCloseStandingKick.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseStandingKick.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCloseStandingKick.Location = new System.Drawing.Point(447, 137);
            this.lblCloseStandingKick.Name = "lblCloseStandingKick";
            this.lblCloseStandingKick.Size = new System.Drawing.Size(93, 38);
            this.lblCloseStandingKick.TabIndex = 56;
            this.lblCloseStandingKick.Text = "cl 5K";
            // 
            // lblCloseStandingSlash
            // 
            this.lblCloseStandingSlash.AutoSize = true;
            this.lblCloseStandingSlash.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseStandingSlash.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCloseStandingSlash.Location = new System.Drawing.Point(454, 189);
            this.lblCloseStandingSlash.Name = "lblCloseStandingSlash";
            this.lblCloseStandingSlash.Size = new System.Drawing.Size(86, 38);
            this.lblCloseStandingSlash.TabIndex = 57;
            this.lblCloseStandingSlash.Text = "cl 5S";
            // 
            // lblCloseStandingHardSlash
            // 
            this.lblCloseStandingHardSlash.AutoSize = true;
            this.lblCloseStandingHardSlash.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseStandingHardSlash.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCloseStandingHardSlash.Location = new System.Drawing.Point(428, 241);
            this.lblCloseStandingHardSlash.Name = "lblCloseStandingHardSlash";
            this.lblCloseStandingHardSlash.Size = new System.Drawing.Size(112, 38);
            this.lblCloseStandingHardSlash.TabIndex = 58;
            this.lblCloseStandingHardSlash.Text = "cl 5HS";
            // 
            // lblCloseStandingDust
            // 
            this.lblCloseStandingDust.AutoSize = true;
            this.lblCloseStandingDust.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseStandingDust.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCloseStandingDust.Location = new System.Drawing.Point(452, 293);
            this.lblCloseStandingDust.Name = "lblCloseStandingDust";
            this.lblCloseStandingDust.Size = new System.Drawing.Size(92, 38);
            this.lblCloseStandingDust.TabIndex = 59;
            this.lblCloseStandingDust.Text = "cl 5D";
            // 
            // lblClosePunch
            // 
            this.lblClosePunch.AutoSize = true;
            this.lblClosePunch.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosePunch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblClosePunch.Location = new System.Drawing.Point(441, 340);
            this.lblClosePunch.Name = "lblClosePunch";
            this.lblClosePunch.Size = new System.Drawing.Size(99, 38);
            this.lblClosePunch.TabIndex = 60;
            this.lblClosePunch.Text = "cl NA";
            // 
            // lblCrouchPunch
            // 
            this.lblCrouchPunch.AutoSize = true;
            this.lblCrouchPunch.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrouchPunch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCrouchPunch.Location = new System.Drawing.Point(893, 85);
            this.lblCrouchPunch.Name = "lblCrouchPunch";
            this.lblCrouchPunch.Size = new System.Drawing.Size(55, 38);
            this.lblCrouchPunch.TabIndex = 61;
            this.lblCrouchPunch.Text = "2P";
            // 
            // lblCrouchKick
            // 
            this.lblCrouchKick.AutoSize = true;
            this.lblCrouchKick.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrouchKick.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCrouchKick.Location = new System.Drawing.Point(888, 137);
            this.lblCrouchKick.Name = "lblCrouchKick";
            this.lblCrouchKick.Size = new System.Drawing.Size(60, 38);
            this.lblCrouchKick.TabIndex = 62;
            this.lblCrouchKick.Text = "2K";
            // 
            // lblCrouchSlash
            // 
            this.lblCrouchSlash.AutoSize = true;
            this.lblCrouchSlash.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrouchSlash.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCrouchSlash.Location = new System.Drawing.Point(895, 189);
            this.lblCrouchSlash.Name = "lblCrouchSlash";
            this.lblCrouchSlash.Size = new System.Drawing.Size(53, 38);
            this.lblCrouchSlash.TabIndex = 63;
            this.lblCrouchSlash.Text = "2S";
            // 
            // lblCrouchHeavySlash
            // 
            this.lblCrouchHeavySlash.AutoSize = true;
            this.lblCrouchHeavySlash.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrouchHeavySlash.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCrouchHeavySlash.Location = new System.Drawing.Point(869, 241);
            this.lblCrouchHeavySlash.Name = "lblCrouchHeavySlash";
            this.lblCrouchHeavySlash.Size = new System.Drawing.Size(79, 38);
            this.lblCrouchHeavySlash.TabIndex = 64;
            this.lblCrouchHeavySlash.Text = "2HS";
            // 
            // lblCrouchDust
            // 
            this.lblCrouchDust.AutoSize = true;
            this.lblCrouchDust.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrouchDust.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCrouchDust.Location = new System.Drawing.Point(889, 293);
            this.lblCrouchDust.Name = "lblCrouchDust";
            this.lblCrouchDust.Size = new System.Drawing.Size(59, 38);
            this.lblCrouchDust.TabIndex = 65;
            this.lblCrouchDust.Text = "2D";
            // 
            // lblCrouchNA
            // 
            this.lblCrouchNA.AutoSize = true;
            this.lblCrouchNA.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrouchNA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCrouchNA.Location = new System.Drawing.Point(856, 345);
            this.lblCrouchNA.Name = "lblCrouchNA";
            this.lblCrouchNA.Size = new System.Drawing.Size(92, 38);
            this.lblCrouchNA.TabIndex = 66;
            this.lblCrouchNA.Text = "2 NA";
            // 
            // txtImportExportFileLocation
            // 
            this.txtImportExportFileLocation.BackColor = System.Drawing.Color.Gray;
            this.txtImportExportFileLocation.Location = new System.Drawing.Point(850, 495);
            this.txtImportExportFileLocation.Name = "txtImportExportFileLocation";
            this.txtImportExportFileLocation.ReadOnly = true;
            this.txtImportExportFileLocation.Size = new System.Drawing.Size(439, 90);
            this.txtImportExportFileLocation.TabIndex = 68;
            this.txtImportExportFileLocation.Text = "";
            this.txtImportExportFileLocation.WordWrap = false;
            this.txtImportExportFileLocation.TextChanged += new System.EventHandler(this.txtImportExportFileLocation_TextChanged);
            // 
            // lblFileLocation
            // 
            this.lblFileLocation.AutoSize = true;
            this.lblFileLocation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFileLocation.Location = new System.Drawing.Point(844, 450);
            this.lblFileLocation.Name = "lblFileLocation";
            this.lblFileLocation.Size = new System.Drawing.Size(389, 32);
            this.lblFileLocation.TabIndex = 69;
            this.lblFileLocation.Text = "Export/Import Folder Location";
            // 
            // btnFolderBrowse
            // 
            this.btnFolderBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolderBrowse.Location = new System.Drawing.Point(1230, 445);
            this.btnFolderBrowse.Name = "btnFolderBrowse";
            this.btnFolderBrowse.Size = new System.Drawing.Size(62, 44);
            this.btnFolderBrowse.TabIndex = 70;
            this.btnFolderBrowse.Text = "...";
            this.btnFolderBrowse.UseVisualStyleBackColor = true;
            this.btnFolderBrowse.Click += new System.EventHandler(this.btnFolderBrowse_Click);
            // 
            // btnOpenExternalNotesForm
            // 
            this.btnOpenExternalNotesForm.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenExternalNotesForm.Location = new System.Drawing.Point(326, 477);
            this.btnOpenExternalNotesForm.Name = "btnOpenExternalNotesForm";
            this.btnOpenExternalNotesForm.Size = new System.Drawing.Size(440, 46);
            this.btnOpenExternalNotesForm.TabIndex = 74;
            this.btnOpenExternalNotesForm.Text = "Open External Additional Notes Form";
            this.btnOpenExternalNotesForm.UseVisualStyleBackColor = true;
            // 
            // FrameDataUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.btnOpenExternalNotesForm);
            this.Controls.Add(this.btnFolderBrowse);
            this.Controls.Add(this.lblFileLocation);
            this.Controls.Add(this.txtImportExportFileLocation);
            this.Controls.Add(this.lblCrouchNA);
            this.Controls.Add(this.lblCrouchDust);
            this.Controls.Add(this.lblCrouchHeavySlash);
            this.Controls.Add(this.lblCrouchSlash);
            this.Controls.Add(this.lblCrouchKick);
            this.Controls.Add(this.lblCrouchPunch);
            this.Controls.Add(this.lblClosePunch);
            this.Controls.Add(this.lblCloseStandingDust);
            this.Controls.Add(this.lblCloseStandingHardSlash);
            this.Controls.Add(this.lblCloseStandingSlash);
            this.Controls.Add(this.lblCloseStandingKick);
            this.Controls.Add(this.lblCloseStandingPunch);
            this.Controls.Add(this.lblStandingNA);
            this.Controls.Add(this.lblStandingDust);
            this.Controls.Add(this.lblStandingHeavySlash);
            this.Controls.Add(this.lblStandingSlash);
            this.Controls.Add(this.lblStandingKick);
            this.Controls.Add(this.cbxCrouchingNotApplicable);
            this.Controls.Add(this.cbxCrouchKick);
            this.Controls.Add(this.cbxCrouchSlash);
            this.Controls.Add(this.cbxCrouchHeavySlash);
            this.Controls.Add(this.cbxCrouchingDust);
            this.Controls.Add(this.cbxCrouchingPunch);
            this.Controls.Add(this.cbxStandingCloseNotApplicable);
            this.Controls.Add(this.cbxStandingCloseKick);
            this.Controls.Add(this.cbxStandingCloseSlash);
            this.Controls.Add(this.cbxStandingCloseHeavySlash);
            this.Controls.Add(this.cbxStandingCloseDust);
            this.Controls.Add(this.cbxStandingClosePunch);
            this.Controls.Add(this.cbxStandingNA);
            this.Controls.Add(this.cbxStandingKick);
            this.Controls.Add(this.cbxStandingSlash);
            this.Controls.Add(this.cbxHeavySlash);
            this.Controls.Add(this.cbxStandingDust);
            this.Controls.Add(this.cbxStandingPunch);
            this.Controls.Add(this.btnUnderline);
            this.Controls.Add(this.btnItalic);
            this.Controls.Add(this.btnBold);
            this.Controls.Add(this.lblStandingPunch);
            this.Controls.Add(this.txtAdditionalNotes);
            this.Controls.Add(this.lblAdditionalNotes);
            this.Controls.Add(this.lblCrouchMovesHeader);
            this.Controls.Add(this.lblStandFarHeader);
            this.Controls.Add(this.lblStandCloseHeader);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Name = "FrameDataUserControl";
            this.Size = new System.Drawing.Size(1295, 723);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblStandCloseHeader;
        private System.Windows.Forms.Label lblStandFarHeader;
        private System.Windows.Forms.Label lblCrouchMovesHeader;
        private System.Windows.Forms.Label lblAdditionalNotes;
        private System.Windows.Forms.RichTextBox txtAdditionalNotes;
        private System.Windows.Forms.Label lblStandingPunch;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnUnderline;
        private System.Windows.Forms.ComboBox cbxStandingPunch;
        private System.Windows.Forms.ComboBox cbxStandingDust;
        private System.Windows.Forms.ComboBox cbxHeavySlash;
        private System.Windows.Forms.ComboBox cbxStandingSlash;
        private System.Windows.Forms.ComboBox cbxStandingKick;
        private System.Windows.Forms.ComboBox cbxStandingNA;
        private System.Windows.Forms.ComboBox cbxStandingCloseNotApplicable;
        private System.Windows.Forms.ComboBox cbxStandingCloseKick;
        private System.Windows.Forms.ComboBox cbxStandingCloseSlash;
        private System.Windows.Forms.ComboBox cbxStandingCloseHeavySlash;
        private System.Windows.Forms.ComboBox cbxStandingCloseDust;
        private System.Windows.Forms.ComboBox cbxStandingClosePunch;
        private System.Windows.Forms.ComboBox cbxCrouchingNotApplicable;
        private System.Windows.Forms.ComboBox cbxCrouchKick;
        private System.Windows.Forms.ComboBox cbxCrouchSlash;
        private System.Windows.Forms.ComboBox cbxCrouchHeavySlash;
        private System.Windows.Forms.ComboBox cbxCrouchingDust;
        private System.Windows.Forms.ComboBox cbxCrouchingPunch;
        private System.Windows.Forms.Label lblStandingKick;
        private System.Windows.Forms.Label lblStandingSlash;
        private System.Windows.Forms.Label lblStandingHeavySlash;
        private System.Windows.Forms.Label lblStandingDust;
        private System.Windows.Forms.Label lblStandingNA;
        private System.Windows.Forms.Label lblCloseStandingPunch;
        private System.Windows.Forms.Label lblCloseStandingKick;
        private System.Windows.Forms.Label lblCloseStandingSlash;
        private System.Windows.Forms.Label lblCloseStandingHardSlash;
        private System.Windows.Forms.Label lblCloseStandingDust;
        private System.Windows.Forms.Label lblClosePunch;
        private System.Windows.Forms.Label lblCrouchPunch;
        private System.Windows.Forms.Label lblCrouchKick;
        private System.Windows.Forms.Label lblCrouchSlash;
        private System.Windows.Forms.Label lblCrouchHeavySlash;
        private System.Windows.Forms.Label lblCrouchDust;
        private System.Windows.Forms.Label lblCrouchNA;
        private System.Windows.Forms.FolderBrowserDialog fldrBrowserDialog;
        private System.Windows.Forms.RichTextBox txtImportExportFileLocation;
        private System.Windows.Forms.Label lblFileLocation;
        private System.Windows.Forms.Button btnFolderBrowse;
        private System.Windows.Forms.Button btnOpenExternalNotesForm;
    }
}
