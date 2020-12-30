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
using StriveFrameData.Helpers;
using StriveFrameData.PresentationObjects;
using StriveFrameData.Presenters;
using StriveFrameData.UserControls.UserControl_Interfaces;
using StriveFrameData.Views;

namespace StriveFrameData.UserControls
{
    public partial class FrameDataUserControl : UserControl, IFrameDataUserControl
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
            if (fldrBrowserDialog != null)
            {
                fldrBrowserDialog.ShowNewFolderButton = true;

                if (this.fldrBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtImportExportFileLocation.Text = fldrBrowserDialog.SelectedPath;
                }
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
                        MainFrameDataPresenter.FrameDataUserControls[i].TxtImportExportFileLocation.Text = txtFileLocation.Text;
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
            
            try
            {
                // tabSolPage
                MainFrameDataPO solPo = new MainFrameDataPO();

                XElement tabSolPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.TabSolPage);

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
                solPo.StandingClosePunch = tabSolPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingClosePunch)
                    .Value;

                solPo.StandingCloseKick = tabSolPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseKick)
                    .Value;

                solPo.StandingCloseSlash = tabSolPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseSlash)
                    .Value;

                solPo.StandingCloseHeavySlash = tabSolPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseHeavySlash)
                    .Value;

                solPo.StandingCloseDust = tabSolPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseDust)
                    .Value;

                solPo.StandingCloseNotApplicable = tabSolPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseNotApplicable)
                    .Value;

                // Crouching moves
                solPo.CrouchingPunch = tabSolPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingPunch)
                    .Value;

                solPo.CrouchingKick = tabSolPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingKick)
                    .Value;

                solPo.CrouchingSlash = tabSolPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingSlash)
                    .Value;

                solPo.CrouchingHeavySlash = tabSolPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingHeavySlash)
                    .Value;

                solPo.CrouchingDust = tabSolPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingDust)
                    .Value;

                solPo.CrouchingNotApplicable = tabSolPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingNotApplicable)
                    .Value;

                // Additional notes
                solPo.AdditionalNotesTextBoxText = tabSolPageElement
                    .Element(StriveXMLConstants.AdditionalNotes)
                    .Element(StriveXMLConstants.AdditionalNote)
                    .Value;

                // Export location
                // Event will fire to fill the remaining pos with ImportExportLocationText in the UI.
                solPo.ImportExportLocationText = tabSolPageElement
                    .Element(StriveXMLConstants.ImportExportLocations)
                    .Element(StriveXMLConstants.ImportExportLocation)
                    .Value;

                importList.Add(solPo);

                // tabKyPage
                MainFrameDataPO kyPo = new MainFrameDataPO();

                XElement tabKyPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.TabKyPage);

                // Standing far Moves
                kyPo.StandingFarPunch = tabKyPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarPunch)
                    .Value;

                kyPo.StandingFarKick = tabKyPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarKick)
                    .Value;

                kyPo.StandingFarSlash = tabKyPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarSlash)
                    .Value;

                kyPo.StandingFarHeavySlash = tabKyPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarHeavySlash)
                    .Value;

                kyPo.StandingFarDust = tabKyPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarDust)
                    .Value;

                kyPo.StandingFarNotApplicable = tabKyPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarNotApplicable)
                    .Value;

                // Standing close moves
                kyPo.StandingClosePunch = tabKyPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingClosePunch)
                    .Value;

                kyPo.StandingCloseKick = tabKyPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseKick)
                    .Value;

                kyPo.StandingCloseSlash = tabKyPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseSlash)
                    .Value;

                kyPo.StandingCloseHeavySlash = tabKyPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseHeavySlash)
                    .Value;

                kyPo.StandingCloseDust = tabKyPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseDust)
                    .Value;

                kyPo.StandingCloseNotApplicable = tabKyPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseNotApplicable)
                    .Value;

                // Crouching moves
                kyPo.CrouchingPunch = tabKyPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingPunch)
                    .Value;

                kyPo.CrouchingKick = tabKyPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingKick)
                    .Value;

                kyPo.CrouchingSlash = tabKyPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingSlash)
                    .Value;

                kyPo.CrouchingHeavySlash = tabKyPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingHeavySlash)
                    .Value;

                kyPo.CrouchingDust = tabKyPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingDust)
                    .Value;

                kyPo.CrouchingNotApplicable = tabKyPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingNotApplicable)
                    .Value;

                // Additional notes
                kyPo.AdditionalNotesTextBoxText = tabKyPageElement
                    .Element(StriveXMLConstants.AdditionalNotes)
                    .Element(StriveXMLConstants.AdditionalNote)
                    .Value;
                
                importList.Add(kyPo);

                // tabMayPage
                MainFrameDataPO mayPo = new MainFrameDataPO();

                XElement tabMayPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.TabMayPage);

                // Standing far Moves
                mayPo.StandingFarPunch = tabMayPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarPunch)
                    .Value;

                mayPo.StandingFarKick = tabMayPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarKick)
                    .Value;

                mayPo.StandingFarSlash = tabMayPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarSlash)
                    .Value;

                mayPo.StandingFarHeavySlash = tabMayPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarHeavySlash)
                    .Value;

                mayPo.StandingFarDust = tabMayPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarDust)
                    .Value;

                mayPo.StandingFarNotApplicable = tabMayPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarNotApplicable)
                    .Value;

                // Standing close moves
                mayPo.StandingClosePunch = tabMayPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingClosePunch)
                    .Value;

                mayPo.StandingCloseKick = tabMayPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseKick)
                    .Value;

                mayPo.StandingCloseSlash = tabMayPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseSlash)
                    .Value;

                mayPo.StandingCloseHeavySlash = tabMayPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseHeavySlash)
                    .Value;

                mayPo.StandingCloseDust = tabMayPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseDust)
                    .Value;

                mayPo.StandingCloseNotApplicable = tabMayPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseNotApplicable)
                    .Value;

                // Crouching moves
                mayPo.CrouchingPunch = tabMayPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingPunch)
                    .Value;

                mayPo.CrouchingKick = tabMayPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingKick)
                    .Value;

                mayPo.CrouchingSlash = tabMayPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingSlash)
                    .Value;

                mayPo.CrouchingHeavySlash = tabMayPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingHeavySlash)
                    .Value;

                mayPo.CrouchingDust = tabMayPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingDust)
                    .Value;

                mayPo.CrouchingNotApplicable = tabMayPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingNotApplicable)
                    .Value;

                // Additional notes
                mayPo.AdditionalNotesTextBoxText = tabMayPageElement
                    .Element(StriveXMLConstants.AdditionalNotes)
                    .Element(StriveXMLConstants.AdditionalNote)
                    .Value;

                importList.Add(mayPo);

                // tabChippPage
                MainFrameDataPO chippPo = new MainFrameDataPO();

                XElement tabChippPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.TabChippPage);

                // Standing far Moves
                chippPo.StandingFarPunch = tabChippPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarPunch)
                    .Value;

                chippPo.StandingFarKick = tabChippPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarKick)
                    .Value;

                chippPo.StandingFarSlash = tabChippPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarSlash)
                    .Value;

                chippPo.StandingFarHeavySlash = tabChippPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarHeavySlash)
                    .Value;

                chippPo.StandingFarDust = tabChippPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarDust)
                    .Value;

                chippPo.StandingFarNotApplicable = tabChippPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarNotApplicable)
                    .Value;

                // Standing close moves
                chippPo.StandingClosePunch = tabChippPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingClosePunch)
                    .Value;

                chippPo.StandingCloseKick = tabChippPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseKick)
                    .Value;

                chippPo.StandingCloseSlash = tabChippPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseSlash)
                    .Value;

                chippPo.StandingCloseHeavySlash = tabChippPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseHeavySlash)
                    .Value;

                chippPo.StandingCloseDust = tabChippPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseDust)
                    .Value;

                chippPo.StandingCloseNotApplicable = tabChippPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseNotApplicable)
                    .Value;

                // Crouching moves
                chippPo.CrouchingPunch = tabChippPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingPunch)
                    .Value;

                chippPo.CrouchingKick = tabChippPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingKick)
                    .Value;

                chippPo.CrouchingSlash = tabChippPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingSlash)
                    .Value;

                chippPo.CrouchingHeavySlash = tabChippPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingHeavySlash)
                    .Value;

                chippPo.CrouchingDust = tabChippPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingDust)
                    .Value;

                chippPo.CrouchingNotApplicable = tabChippPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingNotApplicable)
                    .Value;

                // Additional notes
                chippPo.AdditionalNotesTextBoxText = tabChippPageElement
                    .Element(StriveXMLConstants.AdditionalNotes)
                    .Element(StriveXMLConstants.AdditionalNote)
                    .Value;

                importList.Add(chippPo);

                // tabPotemkinPage
                MainFrameDataPO potPo = new MainFrameDataPO();

                XElement tabPotemkinPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.TabPotemkinPage);

                // Standing far Moves
                potPo.StandingFarPunch = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarPunch)
                    .Value;

                potPo.StandingFarKick = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarKick)
                    .Value;

                potPo.StandingFarSlash = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarSlash)
                    .Value;

                potPo.StandingFarHeavySlash = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarHeavySlash)
                    .Value;

                potPo.StandingFarDust = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarDust)
                    .Value;

                potPo.StandingFarNotApplicable = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarNotApplicable)
                    .Value;

                // Standing close moves
                potPo.StandingClosePunch = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingClosePunch)
                    .Value;

                potPo.StandingCloseKick = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseKick)
                    .Value;

                potPo.StandingCloseSlash = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseSlash)
                    .Value;

                potPo.StandingCloseHeavySlash = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseHeavySlash)
                    .Value;

                potPo.StandingCloseDust = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseDust)
                    .Value;

                potPo.StandingCloseNotApplicable = tabPotemkinPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseNotApplicable)
                    .Value;

                // Crouching moves
                potPo.CrouchingPunch = tabPotemkinPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingPunch)
                    .Value;

                potPo.CrouchingKick = tabPotemkinPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingKick)
                    .Value;

                potPo.CrouchingSlash = tabPotemkinPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingSlash)
                    .Value;

                potPo.CrouchingHeavySlash = tabPotemkinPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingHeavySlash)
                    .Value;

                potPo.CrouchingDust = tabPotemkinPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingDust)
                    .Value;

                potPo.CrouchingNotApplicable = tabPotemkinPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingNotApplicable)
                    .Value;

                // Additional notes
                potPo.AdditionalNotesTextBoxText = tabPotemkinPageElement
                    .Element(StriveXMLConstants.AdditionalNotes)
                    .Element(StriveXMLConstants.AdditionalNote)
                    .Value;
                
                importList.Add(potPo);

                // tabAxlPage
                MainFrameDataPO axlPo = new MainFrameDataPO();

                XElement tabAxlPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.TabAxlPage);

                // Standing far Moves
                axlPo.StandingFarPunch = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarPunch)
                    .Value;

                axlPo.StandingFarKick = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarKick)
                    .Value;

                axlPo.StandingFarSlash = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarSlash)
                    .Value;

                axlPo.StandingFarHeavySlash = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarHeavySlash)
                    .Value;

                axlPo.StandingFarDust = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarDust)
                    .Value;

                axlPo.StandingFarNotApplicable = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarNotApplicable)
                    .Value;

                // Standing close moves
                axlPo.StandingClosePunch = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingClosePunch)
                    .Value;

                axlPo.StandingCloseKick = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseKick)
                    .Value;

                axlPo.StandingCloseSlash = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseSlash)
                    .Value;

                axlPo.StandingCloseHeavySlash = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseHeavySlash)
                    .Value;

                axlPo.StandingCloseDust = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseDust)
                    .Value;

                axlPo.StandingCloseNotApplicable = tabAxlPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseNotApplicable)
                    .Value;

                // Crouching moves
                axlPo.CrouchingPunch = tabAxlPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingPunch)
                    .Value;

                axlPo.CrouchingKick = tabAxlPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingKick)
                    .Value;

                axlPo.CrouchingSlash = tabAxlPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingSlash)
                    .Value;

                axlPo.CrouchingHeavySlash = tabAxlPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingHeavySlash)
                    .Value;

                axlPo.CrouchingDust = tabAxlPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingDust)
                    .Value;

                axlPo.CrouchingNotApplicable = tabAxlPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingNotApplicable)
                    .Value;

                // Additional notes
                axlPo.AdditionalNotesTextBoxText = tabAxlPageElement
                    .Element(StriveXMLConstants.AdditionalNotes)
                    .Element(StriveXMLConstants.AdditionalNote)
                    .Value;

                importList.Add(axlPo);

                // tabFaustPage
                MainFrameDataPO faustPo = new MainFrameDataPO();

                XElement tabFaustPageElement = doc.Element(StriveXMLConstants.MainFrameData)
                    .Element(StriveXMLConstants.TabFaustPage);

                // Standing far Moves
                faustPo.StandingFarPunch = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarPunch)
                    .Value;

                faustPo.StandingFarKick = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarKick)
                    .Value;

                faustPo.StandingFarSlash = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarSlash)
                    .Value;

                faustPo.StandingFarHeavySlash = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarHeavySlash)
                    .Value;

                faustPo.StandingFarDust = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarDust)
                    .Value;

                faustPo.StandingFarNotApplicable = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingFarMoves)
                    .Element(StriveXMLConstants.StandingFarNotApplicable)
                    .Value;

                // Standing close moves
                faustPo.StandingClosePunch = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingClosePunch)
                    .Value;

                faustPo.StandingCloseKick = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseKick)
                    .Value;

                faustPo.StandingCloseSlash = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseSlash)
                    .Value;

                faustPo.StandingCloseHeavySlash = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseHeavySlash)
                    .Value;

                faustPo.StandingCloseDust = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseDust)
                    .Value;

                faustPo.StandingCloseNotApplicable = tabFaustPageElement
                    .Element(StriveXMLConstants.StandingCloseMoves)
                    .Element(StriveXMLConstants.StandingCloseNotApplicable)
                    .Value;

                // Crouching moves
                faustPo.CrouchingPunch = tabFaustPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingPunch)
                    .Value;

                faustPo.CrouchingKick = tabFaustPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingKick)
                    .Value;

                faustPo.CrouchingSlash = tabFaustPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingSlash)
                    .Value;

                faustPo.CrouchingHeavySlash = tabFaustPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingHeavySlash)
                    .Value;

                faustPo.CrouchingDust = tabFaustPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingDust)
                    .Value;

                faustPo.CrouchingNotApplicable = tabFaustPageElement
                    .Element(StriveXMLConstants.CrouchingMoves)
                    .Element(StriveXMLConstants.CrouchingNotApplicable)
                    .Value;

                // Additional notes
                faustPo.AdditionalNotesTextBoxText = tabFaustPageElement
                    .Element(StriveXMLConstants.AdditionalNotes)
                    .Element(StriveXMLConstants.AdditionalNote)
                    .Value;

                importList.Add(faustPo);
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Unable to Import file. File is either corrupt or xml tags are from a deprecated version of export." 
                                + Environment.NewLine 
                                + $@" Error: {e}", @"Import File Error");

                return new List<MainFrameDataPO>();
            }

            MessageBox.Show(@"Import Successful! Click 'OK' to update app.", @"Success");
     
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
                MainFrameDataPO mfdPO = new MainFrameDataPO {TabPageName = MainFrameDataView.TabPages[i].Name};
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

        public RichTextBox TxtImportExportFileLocation
        {
            get { return this.txtImportExportFileLocation; }
        }
    }
}
