using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StriveFrameData.Builders;
using StriveFrameData.Factories;
using StriveFrameData.Models;
using StriveFrameData.PresentationObjects;
using StriveFrameData.UserControls;
using StriveFrameData.ViewInterfaces;
using StriveFrameData.Views;

namespace StriveFrameData.Presenters
{
    /// <summary>
    /// Handles Presentation logic for Main Frame Data View.
    /// </summary>
    public class MainFrameDataPresenter
    {
        private readonly IMainFrameDataView _view;
        private readonly IExternalAdditionalNotesView _externalView;

        public MainFrameDataPresenter(IMainFrameDataView view)
        {
            _view = view;
        }

        public MainFrameDataPresenter(IExternalAdditionalNotesView externalView)
        {
            _externalView = externalView;
        }

        /// <summary>
        /// Imports XML to UI.
        /// </summary>
        /// <param name="xmlImportList"></param>
        public void ImportData(List<MainFrameDataPO> xmlImportList)
        {
            if (xmlImportList == null || xmlImportList.Count == 0) return;

            // Tab pages
            for (int i = 0; i < MainFrameDataView.TabPages.Count; i++)
            {
                // Iterate over import list 1 to 1 with tabPages. 
                MainFrameDataPO mfdPO = xmlImportList[i];
                
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
                                        comboBoxControl.Text = mfdPO.StandingFarPunch;
                                        break;
                                    case "cbxStandingKick":
                                        comboBoxControl.Text = mfdPO.StandingFarKick;
                                        break;
                                    case "cbxStandingSlash":
                                         comboBoxControl.Text = mfdPO.StandingFarSlash;
                                        break;
                                    case "cbxHeavySlash":
                                         comboBoxControl.Text = mfdPO.StandingFarHeavySlash;
                                        break;
                                    case "cbxStandingDust":
                                        comboBoxControl.Text = mfdPO.StandingFarDust;
                                        break;
                                    case "cbxStandingNA":
                                        comboBoxControl.Text = mfdPO.StandingFarNotApplicable;
                                        break;
                                    // Standing close
                                    case "cbxStandingClosePunch":
                                        comboBoxControl.Text = mfdPO.StandingClosePunch;
                                        break;
                                    case "cbxStandingCloseKick":
                                        comboBoxControl.Text = mfdPO.StandingCloseKick;
                                        break;
                                    case "cbxStandingCloseSlash":
                                        comboBoxControl.Text = mfdPO.StandingCloseSlash;
                                        break;
                                    case "cbxStandingCloseHeavySlash":
                                        comboBoxControl.Text = mfdPO.StandingCloseHeavySlash;
                                        break;
                                    case "cbxStandingCloseDust":
                                        comboBoxControl.Text = mfdPO.StandingCloseDust;
                                        break;
                                    case "cbxStandingCloseNotApplicable":
                                        comboBoxControl.Text = mfdPO.StandingCloseNotApplicable;
                                        break;
                                    // Crouching
                                    case "cbxCrouchingPunch":
                                        comboBoxControl.Text = mfdPO.CrouchingPunch;
                                        break;
                                    case "cbxCrouchKick":
                                        comboBoxControl.Text = mfdPO.CrouchingKick;
                                        break;
                                    case "cbxCrouchSlash":
                                        comboBoxControl.Text = mfdPO.CrouchingSlash;
                                        break;
                                    case "cbxCrouchHeavySlash":
                                        comboBoxControl.Text = mfdPO.CrouchingHeavySlash;
                                        break;
                                    case "cbxCrouchingDust":
                                        comboBoxControl.Text = mfdPO.CrouchingDust;
                                        break;
                                    case "cbxCrouchingNotApplicable":
                                        comboBoxControl.Text = mfdPO.CrouchingNotApplicable;
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
                                    richTextBoxControl.Text = mfdPO.AdditionalNotesTextBoxText;
                                }

                                // Ensure we do not trigger export text changed event. Once we import one value into export text box
                                // the application will automatically fill out the rest via event in the view. 
                                if (richTextBoxControl.Name == "txtImportExportFileLocation" && string.IsNullOrEmpty(richTextBoxControl.Text))
                                {
                                    richTextBoxControl.Text = mfdPO.ImportExportLocationText;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Exports Data to XML and PDF file.
        /// </summary>
        public void ExportData()
        {
            // 1. Build Export XML for import (leverage XMLBuilder)
            XMLBuilder xmlBuilder = new XMLBuilder();
            MainFrameDataPO path = CompleteFrameDataList.FirstOrDefault(m => m.ImportExportLocationText != string.Empty);
            DateTime date = DateTime.Now;
            
            string fileAppendDateFormat = $"{date.Year}{date.Day}{date.Month}{date.Hour}{date.Minute}{date.Second}";
            string codedPathXml = @"\" + fileAppendDateFormat + "_FrameData.xml";
            string codedPathPdf = @"\" + fileAppendDateFormat + "_FrameData.pdf";

            if (path != null && !string.IsNullOrEmpty(path.ImportExportLocationText))
            {
                xmlBuilder.CreateXMLFromMainFrameDataPOList(CompleteFrameDataList, path.ImportExportLocationText + codedPathXml);
            }
            else
            {
                // Place into my documents folder if user hasn't set an actual folder
                string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string myPath = myDocuments + @"\" + fileAppendDateFormat + "_FrameData.xml";
                xmlBuilder.CreateXMLFromMainFrameDataPOList(CompleteFrameDataList, myPath);
            }

            // 2. Build Export PDF for easy viewing (leverage PDFFactory)
            if (path != null && !string.IsNullOrEmpty(path.ImportExportLocationText))
            {
                PDFFactory.Factory.CreatePdfFromMainFrameDataPoList(
                    CompleteFrameDataList, 
                    path.ImportExportLocationText + codedPathPdf);
            }
            else
            {
                // Place into my documents folder if user hasn't set an actual folder
                string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string myPath = myDocuments + @"\" + fileAppendDateFormat + "_FrameData.pdf";
                PDFFactory.Factory.CreatePdfFromMainFrameDataPoList(CompleteFrameDataList, myPath);
            }
        }

        /// <summary>
        /// List of tabbed frame data user controls as Singleton
        /// </summary>
        public static List<FrameDataUserControl> FrameDataUserControls { get; set; }

        /// <summary>
        /// Complete Frame Data list from UI
        /// </summary>
        private List<MainFrameDataPO> CompleteFrameDataList { get; set; }

        /// <summary>
        /// Load User Control List into p.FrameDataUserControls
        /// </summary>
        public void Initialize()
        {
            List<FrameDataUserControl> userControlList = new List<FrameDataUserControl>();
            FrameDataUserControl fdc = new FrameDataUserControl();
            FrameDataUserControl fdc2 = new FrameDataUserControl();
            FrameDataUserControl fdc3 = new FrameDataUserControl();
            FrameDataUserControl fdc4 = new FrameDataUserControl();
            FrameDataUserControl fdc5 = new FrameDataUserControl();
            FrameDataUserControl fdc6 = new FrameDataUserControl();
            FrameDataUserControl fdc7 = new FrameDataUserControl();
            userControlList.Add(fdc);
            userControlList.Add(fdc2);
            userControlList.Add(fdc3);
            userControlList.Add(fdc4);
            userControlList.Add(fdc5);
            userControlList.Add(fdc6);
            userControlList.Add(fdc7);

            FrameDataUserControls = new List<FrameDataUserControl>();
            FrameDataUserControls = userControlList;
        }

        /// <summary>
        /// Creates Frame Data List from FrameDataModel class. 
        /// </summary>
        /// <returns>String list of Frame data model constants</returns>
        public List<string> FrameDataList()
        {
            FrameDataModel fdm = new FrameDataModel();

            List<string> fdmList = new List<string>
            {
                fdm.PlaceHolderConstant,
                fdm.LargeAdvantageConst,
                fdm.SlightAdvantageConst,
                fdm.NeutralEvenConst,
                fdm.SlightDisadvantageConst,
                fdm.LargeDisadvantageConst
            };

            return fdmList;
        }
        
        /// <summary>
        /// Collect Frame Data UI data and place into property for use. 
        /// </summary>
        /// <param name="list"></param>
        /// <returns>List of Main Frame Data PO</returns>
        internal void CollectMainFrameDataViewList(List<MainFrameDataPO> list) 
        {
            if (list == null || list.Count == 0) return;

            CompleteFrameDataList = list;
        }
    }
}
