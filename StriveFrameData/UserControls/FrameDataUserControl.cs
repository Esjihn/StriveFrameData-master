using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StriveFrameData.PresentationObjects;
using StriveFrameData.Presenters;
using StriveFrameData.Views;

namespace StriveFrameData.UserControls
{
    public partial class FrameDataUserControl : UserControl
    {
        public FrameDataUserControl()
        {
            InitializeComponent();
        }

        #region Properties
        /// <summary>
        /// Stores boolean click state for Bold button
        /// </summary>
        private bool IsBold { get; set; }  
        
        /// <summary>
        /// Stores boolean click state for Italic button 
        /// </summary>
        private bool IsItalic { get; set; }  
        
        /// <summary>
        /// Stores boolean click state for Underline button.p
        /// </summary>
        private bool IsUnderline { get; set; }
        #endregion

        #region Event Handlers

        /// <summary>
        /// Additional Notes text box text changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAdditionalNotes_TextChanged(object sender, EventArgs e)
        {
            if (IsBold)
            {
                this.txtAdditionalNotes.SelectionFont = new Font(this.Font, FontStyle.Bold);
            }

            if (IsItalic)
            {
                this.txtAdditionalNotes.SelectionFont = new Font(this.Font, FontStyle.Italic);
            }

            if (IsUnderline)
            {
                this.txtAdditionalNotes.SelectionFont = new Font(this.Font, FontStyle.Underline);
            }

            if (!IsBold && !IsItalic && !IsUnderline)
            {
                this.txtAdditionalNotes.SelectionFont = new Font(this.Font, FontStyle.Regular);
            }
        }

        /// <summary>
        /// Bold button click event.     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBold_Click(object sender, EventArgs e)
        {
            IsBold = !IsBold;

            ShowButtonAsPressedWhenSelectionActive("Bold");
        }

        /// <summary>
        /// Italic button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItalic_Click(object sender, EventArgs e)
        {
            IsItalic = !IsItalic;

            ShowButtonAsPressedWhenSelectionActive("Italic");
        }

        /// <summary>
        /// Underline button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnderline_Click(object sender, EventArgs e)
        {
            IsUnderline = !IsUnderline;

            ShowButtonAsPressedWhenSelectionActive("Underline");
        }

        /// <summary>
        /// Folder browse button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            if (fldrBrowserDialog == null)
            {
                fldrBrowserDialog.ShowNewFolderButton = true;
                fldrBrowserDialog.ShowDialog();
            }

            if (this.fldrBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtImportExportFileLocation.Text = fldrBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Import Export File Location text box text changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtImportExportFileLocation_TextChanged(object sender, EventArgs e)
        {
            if (sender == null) return;

            TextBox txtFileLocation = sender as TextBox;

            if(txtFileLocation != null)
            {
                if(txtFileLocation.Text.Length > 0)
                {
                    txtFileLocation.Select();
                    txtFileLocation.Select(txtImportExportFileLocation.Text.Length, 0);
                }
            }
        }

        /// <summary>
        /// Import button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            // todo check if a file exists to import if nothing exists then return;

            // todo leverage FileImportHelper to check for an read xml file into a list<MainFrameDataPO>
            // The presenter will call view method to process import into actual ui elements
        }

        /// <summary>
        /// Export button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            MainFrameDataPresenter p = new MainFrameDataPresenter(this.Parent.Parent as MainFrameDataView);

            // Collect all text from relevant UI elements.
            // todo
            p.CollectMainFrameDataViewList(MainFrameDataPOList());

            // todo call another presenter method that is used to create two files
            // 1. Build Export XML for import (leverage XMLBuilder)
            // 2. Build Export PDF for easy viewing (leverage PDFBuilder)
            // 3. Export file to folder (leverage FileImport)
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Emulates button pressed animation when font active.
        /// </summary>
        /// <param name="fontStyle">Style font of active button</param>
        private void ShowButtonAsPressedWhenSelectionActive(string fontStyle)
        {
            Color btnOriginalColor = new Color();

            if (fontStyle == "Bold" && IsBold)
            {
                this.btnBold.FlatStyle = FlatStyle.Flat;
                btnOriginalColor = this.btnBold.FlatAppearance.BorderColor;
                this.btnBold.FlatAppearance.BorderColor = Color.Black;
                this.btnBold.FlatAppearance.BorderSize = 1;
            }
            else
            {
                this.btnBold.FlatStyle = FlatStyle.Standard;
                this.btnBold.FlatAppearance.BorderColor = btnOriginalColor;
            }

            if (fontStyle == "Italic" && IsItalic)
            {
                this.btnItalic.FlatStyle = FlatStyle.Flat;
                btnOriginalColor = this.btnItalic.FlatAppearance.BorderColor;
                this.btnItalic.FlatAppearance.BorderColor = Color.Black;
                this.btnItalic.FlatAppearance.BorderSize = 1;
            }
            else
            {
                this.btnItalic.FlatStyle = FlatStyle.Standard;
                this.btnItalic.FlatAppearance.BorderColor = btnOriginalColor;
            }

            if (fontStyle == "Underline" && IsUnderline)
            {
                this.btnUnderline.FlatStyle = FlatStyle.Flat;
                btnOriginalColor = this.btnUnderline.FlatAppearance.BorderColor;
                this.btnUnderline.FlatAppearance.BorderColor = Color.Black;
                this.btnUnderline.FlatAppearance.BorderSize = 1;
            }
            else
            {
                this.btnUnderline.FlatStyle = FlatStyle.Standard;
                this.btnUnderline.FlatAppearance.BorderColor = btnOriginalColor;
            }
        }
        #endregion

        public List<MainFrameDataPO> MainFrameDataPOList()
        {
            List<MainFrameDataPO> list = new List<MainFrameDataPO>();

            // Tab pages
            for (int i = 0; i < MainFrameDataView.TabPages.Count; i++)
            {
                // User controls inside tab page
                for (int j = 0; j < MainFrameDataView.TabPages[i].Controls.Count; j++)
                {
                    // User control controlCollection
                    for (int k = 0; k < MainFrameDataView.TabPages[i].Controls[j].Controls.Count; k++)
                    {
                        MainFrameDataPO mfdPO = new MainFrameDataPO();
                        // Fill all combo boxes
                        if (MainFrameDataView.TabPages[i].Controls[j].Controls[k] is ComboBox)
                        {
                            ComboBox comboBoxControl = MainFrameDataView.TabPages[i].Controls[j].Controls[k] as ComboBox;

                            if (comboBoxControl != null)
                            {
                                switch (comboBoxControl.Name)
                                {
                                    case "cbxStandingPunch":
                                        mfdPO.StandingFarPunch = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingFarKick":
                                        mfdPO.StandingFarKick = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingFarSlash":
                                        mfdPO.StandingFarSlash = comboBoxControl.Text;
                                        break;
                                    default:
                                        break;

                                }
                            }
                        }
                        list.Add(mfdPO);
                    }
                }
            }
            return list;
        }
    }
}
