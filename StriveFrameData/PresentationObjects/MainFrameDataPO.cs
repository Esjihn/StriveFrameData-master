using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StriveFrameData.PresentationObjects
{
    /// <summary>
    /// Presentation Objects (Properties) for data in UI Elements
    /// </summary>
    [XmlRoot("MainFrameDataPO")]
    public class MainFrameDataPO
    {

        #region TabPage Name
        /// <summary>
        /// Determines with tab page the xml was from
        /// </summary>
        [XmlElement]
        public string TabPageName { get; set; }
        #endregion

        #region Header
        // For use with import.
        public string MainFrameDataXmlHeader = "MainFrameDataPO";

        #endregion
        #region Standing Far Moves UI
        public string StandingFarPunch { get; set; }
        public string StandingFarKick { get; set; }
        public string StandingFarSlash { get; set; }
        public string StandingFarHeavySlash { get; set; }
        public string StandingFarDust { get; set; }
        public string StandingFarNotApplicable { get; set; }
        #endregion

        #region Standing Close Moves UI
        public string StandingClosePunch { get; set; }
        public string StandingCloseKick { get; set; }
        public string StandingCloseSlash { get; set; }
        public string StandingCloseHeavySlash { get; set; }
        public string StandingCloseDust { get; set; }
        public string StandingCloseNotApplicable { get; set; }
        #endregion

        #region Crouching Moves UI
        public string CrouchingPunch { get; set; }
        public string CrouchingKick { get; set; }
        public string CrouchingSlash { get; set; }
        public string CrouchingHeavySlash { get; set; }
        public string CrouchingDust { get; set; }
        public string CrouchingNotApplicable { get; set; }

        #endregion

        #region Additional Notes UI
        public string AdditionalNotesTextBoxText { get; set; }
        #endregion

        #region ImportExport UI
        public string ImportExportLocationText { get; set; }
        #endregion

    }
}
