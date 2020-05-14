﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StriveFrameData.Builder;
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
        public void ImportData()
        {
            // todo leverage framedatausercontrol import event and import data back into view.
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
            
            string fileAppendDateFormat = $"{date.Year}{date.Day}{date.Month}{date.Hour}{date.Minute}";
            string codedPathXml = @"\" + fileAppendDateFormat + "_FrameData.xml";
            string codedPathPdf = @"\" + fileAppendDateFormat + "_FrameData.pdf";

            if (path != null && string.IsNullOrEmpty(path.ImportExportLocationText))
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

            // 2. Build Export PDF for easy viewing (leverage PDFBuilder)
            PDFBuilder pdfBuilder = new PDFBuilder();
            if (path != null && string.IsNullOrEmpty(path.ImportExportLocationText))
            {
                pdfBuilder.CreatePDFFromMainFrameDataPOList(
                    CompleteFrameDataList, 
                    path.ImportExportLocationText + codedPathPdf, 
                    path.ImportExportLocationText + codedPathXml);
            }
            else
            {
                // Place into my documents folder if user hasn't set an actual folder
                string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string myPath = myDocuments + @"\" + fileAppendDateFormat + "_FrameData.pdf";
                pdfBuilder.CreatePDFFromMainFrameDataPOList(CompleteFrameDataList, myPath, myDocuments + codedPathXml);
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

        /// <summary>
        /// Extracts all MainFrameDataPO from XML and stores in a list. 
        /// </summary>
        /// <param name="xmlImportList"></param>
        internal void ExtractMainFrameDataListFromXMLImport(List<MainFrameDataPO> xmlImportList)
        {
            // todo do work 
        }
    }
}
