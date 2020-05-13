using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StriveFrameData.Presenters;
using StriveFrameData.ViewInterfaces;

namespace StriveFrameData.Views
{
    public partial class ExternalAdditionalNotesView : Form, IExternalAdditionalNotesView
    {
        public ExternalAdditionalNotesView()
        {
            InitializeComponent();
        }

        #region Events

        /// <summary>
        /// Clear button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.None;

            if (!string.IsNullOrEmpty(this.txtExternalAdditionalNotes.Text))
            {
                 result = MessageBox.Show(
                    @"Are you sure you want to clear all text from the External Notes Form?", @"Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            }

            if (result == DialogResult.Yes && !string.IsNullOrEmpty(this.txtExternalAdditionalNotes.Text))
            {
                this.txtExternalAdditionalNotes.Clear();
            }
        }

        /// <summary>
        /// Dock button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDock_Click(object sender, EventArgs e)
        {
            MainFrameDataPresenter p = new MainFrameDataPresenter(this);

        }

        /// <summary>
        /// External additional notes view load event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExternalAdditionalNotesView_Load(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
