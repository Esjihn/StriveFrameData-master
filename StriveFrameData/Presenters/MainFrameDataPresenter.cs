using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StriveFrameData.Builder;
using StriveFrameData.Helper;
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

        public MainFrameDataPresenter(IMainFrameDataView view)
        {
            _view = view;
        }

        // Setup ImportData()
        public void ImportData()
        {

        }

        // Setup ExportData()
        public void ExportData()
        {
            // 1. Build Export XML for import (leverage XMLBuilder)
            XMLBuilder xmlBuilder = new XMLBuilder();
            MainFrameDataPO path = CompleteFrameDataList.First(m => m.ImportExportLocationText != string.Empty);
            
            if (path != null)
            {
                xmlBuilder.CreateXMLFromMainFrameDataPOList(CompleteFrameDataList, path.ImportExportLocationText);
            }
            else
            {
                // Place into my documents folder if user hasn't set an actual folder
                string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                xmlBuilder.CreateXMLFromMainFrameDataPOList(CompleteFrameDataList, myDocuments);
            }

            // 2. Build Export PDF for easy viewing (leverage PDFBuilder)
            PDFBuilder pdfBuilder = new PDFBuilder();

            // 3. Export file to folder (leverage FileImport)
            FileExportHelper exportHelper = new FileExportHelper();
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
