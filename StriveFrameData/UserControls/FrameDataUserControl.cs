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
using StriveFrameData.Views;

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
                this.txtAdditionalNotes.SelectionFont = new Font(this.Font, FontStyle.Bold);
            }

            if (IsItalic)
            {
                this.txtAdditionalNotes.SelectionFont = new Font(this.Font, FontStyle.Italic);
            }

            if (IsUnderline)
            {
                this.txtAdditionalNotes.SelectionFont = new Font(this.Font, FontStyle.Underline);
            }

            if (!IsBold && !IsItalic && !IsUnderline)
            {
                this.txtAdditionalNotes.SelectionFont = new Font(this.Font, FontStyle.Regular);
            }
        }

        /// <summary>
        /// Bold button click event.     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBold_Click(object sender, EventArgs e)
        {
            IsBold = !IsBold;

            ShowButtonAsPressedWhenSelectionActive("Bold");
        }

        /// <summary>
        /// Italic button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItalic_Click(object sender, EventArgs e)
        {
            IsItalic = !IsItalic;

            ShowButtonAsPressedWhenSelectionActive("Italic");
        }

        /// <summary>
        /// Underline button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnderline_Click(object sender, EventArgs e)
        {
            IsUnderline = !IsUnderline;

            ShowButtonAsPressedWhenSelectionActive("Underline");
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
        private void ShowButtonAsPressedWhenSelectionActive(string fontStyle)
        {
            Color btnOriginalColor = new Color();

            if (fontStyle == "Bold" && IsBold)
            {
                this.btnBold.FlatStyle = FlatStyle.Flat;
                btnOriginalColor = this.btnBold.FlatAppearance.BorderColor;
                this.btnBold.FlatAppearance.BorderColor = Color.Black;
                this.btnBold.FlatAppearance.BorderSize = 1;
            }
            else
            {
                this.btnBold.FlatStyle = FlatStyle.Standard;
                this.btnBold.FlatAppearance.BorderColor = btnOriginalColor;
            }

            if (fontStyle == "Italic" && IsItalic)
            {
                this.btnItalic.FlatStyle = FlatStyle.Flat;
                btnOriginalColor = this.btnItalic.FlatAppearance.BorderColor;
                this.btnItalic.FlatAppearance.BorderColor = Color.Black;
                this.btnItalic.FlatAppearance.BorderSize = 1;
            }
            else
            {
                this.btnItalic.FlatStyle = FlatStyle.Standard;
                this.btnItalic.FlatAppearance.BorderColor = btnOriginalColor;
            }

            if (fontStyle == "Underline" && IsUnderline)
            {
                this.btnUnderline.FlatStyle = FlatStyle.Flat;
                btnOriginalColor = this.btnUnderline.FlatAppearance.BorderColor;
                this.btnUnderline.FlatAppearance.BorderColor = Color.Black;
                this.btnUnderline.FlatAppearance.BorderSize = 1;
            }
            else
            {
                this.btnUnderline.FlatStyle = FlatStyle.Standard;
                this.btnUnderline.FlatAppearance.BorderColor = btnOriginalColor;
            }
        }
        #endregion

    }
}
