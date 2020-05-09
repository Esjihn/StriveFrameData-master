using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /// <summary>
        /// List of tabbed frame data user controls as Singleton
        /// </summary>
        public static List<FrameDataUserControl> FrameDataUserControls { get; set; }

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
        /// Message data list to prepare for import or export
        /// </summary>
        /// <param name="list"></param>
        internal List<MainFrameDataPO> CollectMainFrameDataList(List<MainFrameDataPO> list)
        {
            if (list == null || list.Count == 0) return new List<MainFrameDataPO>();

            // Todo finish logic
            return null;
        }
    }
}
