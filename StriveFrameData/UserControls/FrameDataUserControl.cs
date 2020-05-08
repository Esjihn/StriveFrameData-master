using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StriveFrameData.PresentationObjects;

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
                this.txtAdditionalNotes.Font = new Font(this.Font, FontStyle.Bold);
            }

            if (IsItalic)
            {
                this.txtAdditionalNotes.Font = new Font(this.Font, FontStyle.Italic);
            }

            if (IsUnderline)
            {
                this.txtAdditionalNotes.Font = new Font(this.Font, FontStyle.Underline);
            }

            if (!IsBold && !IsItalic && !IsUnderline)
            {
                this.txtAdditionalNotes.Font = new Font(this.Font, FontStyle.Regular);
            }
        }

        /// <summary>
        /// Bold button click event.     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBold_Click(object sender, EventArgs e)
        {
            ShowButtonAsPressedWhenSelectionActive(this.btnBold.Font.Style);

            IsBold = !IsBold;
        }


        /// <summary>
        /// Italic button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItalic_Click(object sender, EventArgs e)
        {
            ShowButtonAsPressedWhenSelectionActive(this.btnItalic.Font.Style);

            IsItalic = !IsItalic;
        }

        /// <summary>
        /// Underline button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnderline_Click(object sender, EventArgs e)
        {
            ShowButtonAsPressedWhenSelectionActive(this.btnUnderline.Font.Style);

            IsUnderline = !IsUnderline;
        }

        /// <summary>
        /// Import button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Export button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Emulates button pressed animation when font active.
        /// </summary>
        /// <param name="fontStyle">Style font of active button</param>
        private void ShowButtonAsPressedWhenSelectionActive(FontStyle fontStyle)
        {
            Color btnOriginalColor = new Color();

            switch (fontStyle)
            {
                case FontStyle.Bold:
                case FontStyle.Italic:
                case FontStyle.Underline:
                    this.btnBold.FlatStyle = FlatStyle.Flat;
                    btnOriginalColor = this.btnBold.FlatAppearance.BorderColor;
                    this.btnBold.FlatAppearance.BorderColor = Color.Black;
                    this.btnBold.FlatAppearance.BorderSize = 1;
                    break;
                default:
                    this.btnBold.FlatStyle = FlatStyle.Standard;
                    this.btnBold.FlatAppearance.BorderColor = btnOriginalColor;
                    break;
            }
        }
        #endregion
    }
}
