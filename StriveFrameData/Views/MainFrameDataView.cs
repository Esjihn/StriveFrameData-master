using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StriveFrameData.PresentationObjects;
using StriveFrameData.Presenters;
using StriveFrameData.ViewInterfaces;

namespace StriveFrameData.Views
{
    public partial class MainFrameDataView : Form, IMainFrameDataView
    {
        public MainFrameDataView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main Frame data view load event.
        /// Loads user controls into form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrameDataView_Load(object sender, EventArgs e)
        {
            if (sender != null)
            {
                MainFrameDataPresenter p = new MainFrameDataPresenter(this);
                p.Initialize();

                CreateTabPagesList();
                LoadUserControlsIntoTabs();
                LoadFrameDataIntoAllComboBoxes();
            }
        }

        #region Private Properties

        /// <summary>
        /// Property with current list of TabPages as Singleton
        /// </summary>
        private static List<TabPage> TabPages { get; set; }

        #endregion

        #region Private Methods
        /// <summary>
        /// Loads user controls into All Tab Pages during form load event.
        /// </summary>
        private void LoadUserControlsIntoTabs()
        {
            if (TabPages != null)
            {
                // Add user controls to tab pages
                for (int i = 0; i < MainFrameDataPresenter.FrameDataUserControls.Count; i++)
                {
                    TabPages[i].Controls.Add(MainFrameDataPresenter.FrameDataUserControls[i]);
                }
            }

            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Loads Frame Data data into all combo boxes during form load event.
        /// </summary>
        private void LoadFrameDataIntoAllComboBoxes()
        {
            MainFrameDataPresenter p = new MainFrameDataPresenter(this);

            // Tab pages
            for(int i = 0; i < TabPages.Count; i++)
            {
                // User controls inside tab page
                for (int j = 0; j < TabPages[i].Controls.Count; j++)
                {
                    // User control controlCollection
                    for (int k = 0; k < TabPages[i].Controls[j].Controls.Count; k++)
                    {
                        // Fill all combo boxes
                        if (TabPages[i].Controls[j].Controls[k] is ComboBox)
                        {
                            ComboBox comboBoxControl = TabPages[i].Controls[j].Controls[k] as ComboBox;
                            if (comboBoxControl != null)
                            {
                                // Populate combobox control with frame data list constants.
                                comboBoxControl.DataSource = p.FrameDataList();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates list of all UI tab pages
        /// </summary>
        /// <returns></returns>
        private void CreateTabPagesList()
        {
            List<TabPage> tabPages = new List<TabPage>
            {
                this.tabMayPage,
                this.tabSolPage,
                this.tabKyPage,
                this.tabAxlPage,
                this.tabChippPage,
                this.tabFaustPage,
                this.tabPotemkinPage
            };
            TabPages = tabPages;
        }

        #endregion

        #region IMainFrameDataView members

        /// <summary>
        /// Create list of all MainFrameDataPO's from UI elements for use with Import/Export
        /// </summary>
        public List<MainFrameDataPO> MainFrameDataList()
        {
            List<MainFrameDataPO> list = new List<MainFrameDataPO>();

            // TODO iterate over all UI elements


            return list;
        }
        #endregion

    }
}
