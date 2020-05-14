using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StriveFrameData.Helper;
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

        #region Event Handlers

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

            RichTextBox txtFileLocation = sender as RichTextBox;

            if(txtFileLocation != null)
            {
                if(txtFileLocation.Text.Length > 0)
                {
                    // Maintain same folder selection across all tab pages.
                    for(int i = 0; i < MainFrameDataPresenter.FrameDataUserControls.Count; i++)
                    {
                        MainFrameDataPresenter.FrameDataUserControls[i].txtImportExportFileLocation.Text = txtFileLocation.Text;
                    }
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
            // todo open dialog to allow user to select file for import
            // todo check if selected xml is valid by looking for <MainFrameData> tag. 
            FileImportHelper fih = new FileImportHelper();
            if (fih.DetermineIfSelectedXmlIsValid())
            {
                MainFrameDataPresenter p = new MainFrameDataPresenter(this.Parent.Parent as MainFrameDataView);
                p.ExtractMainFrameDataListFromXMLImport(XMLImportList());
                p.ImportData();
            }
            else
            {
                // todo show MessageBox.Dialog error if not a valid file.
            }
        }

        /// <summary>
        /// Export button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            MainFrameDataPresenter p = new MainFrameDataPresenter(this.Parent.Parent as MainFrameDataView);

            p.CollectMainFrameDataViewList(MainFrameDataPOList());
            p.ExportData();
        }

        /// <summary>
        /// Open External Notes button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenExternalNotesForm_Click(object sender, EventArgs e)
        {
            ExternalAdditionalNotesView externalView = new ExternalAdditionalNotesView(this.txtAdditionalNotes.Text);
            externalView.Show();
            externalView.VisibleChanged += FormVisibleChanged;
        }

        /// <summary>
        /// Visible changed event for ExternalView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVisibleChanged(object sender, EventArgs e)
        {
            if (sender is ExternalAdditionalNotesView externalView && !externalView.Visible)
            {
                this.txtAdditionalNotes.Text = externalView.ReturnAdditionalNotesText;
                externalView.Dispose();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create MainFrameDataPO list from XML Import file. 
        /// </summary>
        /// <returns></returns>
        private List<MainFrameDataPO> XMLImportList()
        {
            // todo do work. 
            return null;
        }

        /// <summary>
        /// Create MainFrameDataPO list from relevant UI elements.
        /// </summary>
        /// <returns></returns>
        private List<MainFrameDataPO> MainFrameDataPOList()
        {
            List<MainFrameDataPO> list = new List<MainFrameDataPO>();

            // Tab pages
            for (int i = 0; i < MainFrameDataView.TabPages.Count; i++)
            {
                MainFrameDataPO mfdPO = new MainFrameDataPO();
                mfdPO.TabPageName = MainFrameDataView.TabPages[i].Name;
                // User controls inside tab page
                for (int j = 0; j < MainFrameDataView.TabPages[i].Controls.Count; j++)
                {
                    // User control controlCollection
                    for (int k = 0; k < MainFrameDataView.TabPages[i].Controls[j].Controls.Count; k++)
                    {
                        // Fill all combo boxes
                        if (MainFrameDataView.TabPages[i].Controls[j].Controls[k] is ComboBox)
                        {
                            ComboBox comboBoxControl = MainFrameDataView.TabPages[i].Controls[j].Controls[k] as ComboBox;

                            if (comboBoxControl != null)
                            {
                                switch (comboBoxControl.Name)
                                {
                                    // Standing far
                                    case "cbxStandingPunch":
                                        mfdPO.StandingFarPunch = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingKick":
                                        mfdPO.StandingFarKick = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingSlash":
                                        mfdPO.StandingFarSlash = comboBoxControl.Text;
                                        break;
                                    case "cbxHeavySlash":
                                        mfdPO.StandingFarHeavySlash = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingDust":
                                        mfdPO.StandingFarDust = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingNA":
                                        mfdPO.StandingFarNotApplicable = comboBoxControl.Text;
                                        break;
                                    // Standing close
                                    case "cbxStandingClosePunch":
                                        mfdPO.StandingClosePunch = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingCloseKick":
                                        mfdPO.StandingCloseKick = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingCloseSlash":
                                        mfdPO.StandingCloseSlash = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingCloseHeavySlash":
                                        mfdPO.StandingCloseHeavySlash = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingCloseDust":
                                        mfdPO.StandingCloseDust = comboBoxControl.Text;
                                        break;
                                    case "cbxStandingCloseNotApplicable":
                                        mfdPO.StandingCloseNotApplicable = comboBoxControl.Text;
                                        break;
                                    // Crouching
                                    case "cbxCrouchingPunch":
                                        mfdPO.CrouchingPunch = comboBoxControl.Text;
                                        break;
                                    case "cbxCrouchKick":
                                        mfdPO.CrouchingKick = comboBoxControl.Text;
                                        break;
                                    case "cbxCrouchSlash":
                                        mfdPO.CrouchingSlash = comboBoxControl.Text;
                                        break;
                                    case "cbxCrouchHeavySlash":
                                        mfdPO.CrouchingHeavySlash = comboBoxControl.Text;
                                        break;
                                    case "cbxCrouchingDust":
                                        mfdPO.CrouchingDust = comboBoxControl.Text;
                                        break;
                                    case "cbxCrouchingNotApplicable":
                                        mfdPO.CrouchingNotApplicable = comboBoxControl.Text;
                                        break;
                                }
                            }
                        }

                        if (MainFrameDataView.TabPages[i].Controls[j].Controls[k] is RichTextBox)
                        {
                            RichTextBox richTextBoxControl = MainFrameDataView.TabPages[i].Controls[j].Controls[k] as RichTextBox;

                            if (richTextBoxControl != null) 
                            {
                                if (richTextBoxControl.Name == "txtAdditionalNotes")
                                {
                                    mfdPO.AdditionalNotesTextBoxText = richTextBoxControl.Text;
                                }

                                if (richTextBoxControl.Name == "txtImportExportFileLocation")
                                {
                                    mfdPO.ImportExportLocationText = richTextBoxControl.Text;
                                }
                            }
                        }
                    }
                }
                list.Add(mfdPO);
            }
            return list;
        }
        #endregion
    }
}
