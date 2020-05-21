using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StriveFrameData.Constants
{
    /// <summary>
    /// Constants use for XML Import.
    /// </summary>
    public class StriveXMLConstants
    {
        #region Parent XML constant
        public const string MainFrameData = "MainFrameData";
        #endregion

        #region TabPages constants
        public const string tabSolPage = "tabSolPage";
        public const string tabKyPage = "tabKyPage";
        public const string tabMayPage = "tabMayPage";
        public const string tabChippPage = "tabChippPage";
        public const string tabPotemkinPage = "tabPotemkinPage";
        public const string tabAxlPage = "tabAxlPage";
        public const string tabFaustPage = "tabFaustPage";
        #endregion

        #region Moves constants
        public const string StandingFarMoves = "StandingFarMoves";
        public const string StandingFarPunch = "StandingFarPunch";
        public const string StandingFarKick = "StandingFarKick";
        public const string StandingFarSlash = "StandingFarSlash";
        public const string StandingFarHeavySlash = "StandingFarHeavySlash";
        public const string StandingFarDust = "StandingFarDust";
        public const string StandingFarNotApplicable = "StandingFarNotApplicable";

        public const string StandingCloseMoves = "StandingCloseMoves";
        public const string StandingClosePunch = "StandingClosePunch";
        public const string StandingCloseKick = "StandingCloseKick";
        public const string StandingCloseSlash = "StandingCloseSlash";
        public const string StandingCloseHeavySlash = "StandingCloseHeavySlash";
        public const string StandingCloseDust = "StandingCloseDust";
        public const string StandingCloseNotApplicable = "StandingCloseNotApplicable";

        public const string CrouchingMoves = "CrouchingMoves";
        public const string CrouchingPunch = "CrouchingPunch";
        public const string CrouchingKick = "CrouchingKick";
        public const string CrouchingSlash = "CrouchingSlash";
        public const string CrouchingHeavySlash = "CrouchingHeavySlash";
        public const string CrouchingDust = "CrouchingDust";
        public const string CrouchingNotApplicable = "CrouchingNotApplicable";

        #endregion

        #region Notes constant
        public const string AdditionalNotes = "AdditionalNotes";
        public const string AdditionalNote = "AdditionalNote";
        #endregion

        #region Import / Export constant
        public const string ImportExportLocations = "ImportExportLocations";
        public const string ImportExportLocation = "ImportExportLocation";

        #endregion
    }
}
