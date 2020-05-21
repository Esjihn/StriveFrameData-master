using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using StriveFrameData.Constants;
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
            if (fileBrowserDialog != null)
            {
                fileBrowserDialog.Filter = @"xml files (*.xml)|*.xml";

                if (this.fileBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileNameAndPath = fileBrowserDialog.FileName;

                    FileImportHelper fih = new FileImportHelper();
                    if (fih.DetermineIfSelectedXmlIsValid(fileNameAndPath))
                    {
                        MainFrameDataPresenter p = new MainFrameDataPresenter(this.Parent.Parent as MainFrameDataView);
                        p.ImportData(XMLImportList(fileNameAndPath));
                    }
                    else
                    {
                        MessageBox.Show(
                            @"The selected file is not compatible for import. *.xml files only.", @"File Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
        /// <param name="fileNameAndPath"></param>
        /// <returns></returns>
        private List<MainFrameDataPO> XMLImportList(string fileNameAndPath)
        {
            if (string.IsNullOrEmpty(fileNameAndPath)) return new List<MainFrameDataPO>();

            List<MainFrameDataPO> importList = new List<MainFrameDataPO>();

            XDocument doc = XDocument.Load(fileNameAndPath);
            
            // TODO parse Element values into list. 
            try
            {
                // tabSolPage
                MainFrameDataPO solPo = new MainFrameDataPO();

                XElement tabSolPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.tabSolPage);

                // Standing far Moves
                solPo.StandingFarPunch = tabSolPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarPunch)
                    .Value;

                solPo.StandingFarKick = tabSolPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarKick)
                    .Value;

                solPo.StandingFarSlash = tabSolPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarSlash)
                    .Value;

                solPo.StandingFarHeavySlash = tabSolPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarHeavySlash)
                    .Value;

                solPo.StandingFarDust = tabSolPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarDust)
                    .Value;

                solPo.StandingFarNotApplicable = tabSolPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarNotApplicable)
                    .Value;

                // Standing close moves

                // Crouching moves

                solPo.AdditionalNotesTextBoxText = tabSolPageElement
                    .Element(StriveXMLConstants.AdditionalNotes)
                    .Element(StriveXMLConstants.AdditionalNote)
                    .Value;

                // Event will fire to fill the remaining pos with ImportExportLocationText in the UI.
                solPo.ImportExportLocationText = tabSolPageElement
                    .Element(StriveXMLConstants.ImportExportLocations)
                    .Element(StriveXMLConstants.ImportExportLocation)
                    .Value;

                importList.Add(solPo);

                // tabKyPage
                MainFrameDataPO kyPo = new MainFrameDataPO();

                XElement tabKyPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.tabKyPage);

                

                importList.Add(kyPo);

                // tabMayPage
                MainFrameDataPO mayPo = new MainFrameDataPO();

                XElement tabMayPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.tabMayPage);

                importList.Add(mayPo);

                // tabChippPage
                MainFrameDataPO chippPo = new MainFrameDataPO();

                XElement tabChippPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.tabChippPage);

                importList.Add(chippPo);

                // tabPotemkinPage
                MainFrameDataPO potPo = new MainFrameDataPO();

                XElement tabPotemkinPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.tabPotemkinPage);

;               importList.Add(potPo);

                // tabAxlPage
                MainFrameDataPO axlPo = new MainFrameDataPO();

                XElement tabAxlPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.tabAxlPage);

                importList.Add(axlPo);

                // tabFaustPage
                MainFrameDataPO faustPo = new MainFrameDataPO();

                XElement tabFaustPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.tabFaustPage);

                importList.Add(faustPo);
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Unable to Import file. Error: {e}", @"Import File Error");

                return new List<MainFrameDataPO>();
            }

            MessageBox.Show(@"Import Successful!", @"Success");
     
            return importList;
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
