﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriveFrameData.PresentationObjects
{
    /// <summary>
    /// Presentation Objects (Properties) for data in UI Elements
    /// </summary>
    public class MainFrameDataPO
    {
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
    }
}
