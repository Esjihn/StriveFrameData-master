using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StriveFrameData.Constants;
using StriveFrameData.PresentationObjects;

namespace StriveFrameData.Repositories
{
    public class CharacterRepository
    {
        /// <summary>
        /// Singleton access to Repository
        /// </summary>
        public static CharacterRepository Retrieve = new CharacterRepository();

        public string SolFrameData(List<MainFrameDataPO> list)
        {
            MainFrameDataPO solPo = list.Find(l => l.TabPageName == StriveXMLConstants.TabSolPage);

            string solFrameData
                       // Standing Far Moves
                       = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                           + StriveXMLConstants.StandingFarPunch + ": " + solPo.StandingFarPunch + Environment.NewLine
                           + StriveXMLConstants.StandingFarKick + ": " + solPo.StandingFarKick + Environment.NewLine
                           + StriveXMLConstants.StandingFarSlash + ": " + solPo.StandingFarSlash + Environment.NewLine
                           + StriveXMLConstants.StandingFarHeavySlash + ": " + solPo.StandingFarHeavySlash + Environment.NewLine
                           + StriveXMLConstants.StandingFarDust + ": " + solPo.StandingFarDust + Environment.NewLine
                           + StriveXMLConstants.StandingFarNotApplicable + ": " + solPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                           // Standing Close Moves
                           + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                           + StriveXMLConstants.StandingClosePunch + ": " + solPo.StandingClosePunch + Environment.NewLine
                           + StriveXMLConstants.StandingCloseKick + ": " + solPo.StandingCloseKick + Environment.NewLine
                           + StriveXMLConstants.StandingCloseSlash + ": " + solPo.StandingCloseSlash + Environment.NewLine
                           + StriveXMLConstants.StandingCloseHeavySlash + ": " + solPo.StandingCloseHeavySlash + Environment.NewLine
                           + StriveXMLConstants.StandingCloseDust + ": " + solPo.StandingCloseDust + Environment.NewLine
                           + StriveXMLConstants.StandingCloseNotApplicable + ": " + solPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                           // Crouching Moves
                           + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                           + StriveXMLConstants.CrouchingPunch + ": " + solPo.CrouchingPunch + Environment.NewLine
                           + StriveXMLConstants.CrouchingKick + ": " + solPo.CrouchingKick + Environment.NewLine
                           + StriveXMLConstants.CrouchingSlash + ": " + solPo.CrouchingSlash + Environment.NewLine
                           + StriveXMLConstants.CrouchingHeavySlash + ": " + solPo.CrouchingHeavySlash + Environment.NewLine
                           + StriveXMLConstants.CrouchingDust + ": " + solPo.CrouchingDust + Environment.NewLine
                           + StriveXMLConstants.CrouchingNotApplicable + ": " + solPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                           // Additional Notes
                           + StriveXMLConstants.AdditionalNotes + ": " + solPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

            return solFrameData;
        }

        public string KyFrameData(List<MainFrameDataPO> list)
        {
            MainFrameDataPO kyPo = list.Find(l => l.TabPageName == StriveXMLConstants.TabKyPage);

            string kyFrameData
                        // Standing Far Moves
                        = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                            + StriveXMLConstants.StandingFarPunch + ": " + kyPo.StandingFarPunch + Environment.NewLine
                            + StriveXMLConstants.StandingFarKick + ": " + kyPo.StandingFarKick + Environment.NewLine
                            + StriveXMLConstants.StandingFarSlash + ": " + kyPo.StandingFarSlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarHeavySlash + ": " + kyPo.StandingFarHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarDust + ": " + kyPo.StandingFarDust + Environment.NewLine
                            + StriveXMLConstants.StandingFarNotApplicable + ": " + kyPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                            // Standing Close Moves
                            + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                            + StriveXMLConstants.StandingClosePunch + ": " + kyPo.StandingClosePunch + Environment.NewLine
                            + StriveXMLConstants.StandingCloseKick + ": " + kyPo.StandingCloseKick + Environment.NewLine
                            + StriveXMLConstants.StandingCloseSlash + ": " + kyPo.StandingCloseSlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseHeavySlash + ": " + kyPo.StandingCloseHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseDust + ": " + kyPo.StandingCloseDust + Environment.NewLine
                            + StriveXMLConstants.StandingCloseNotApplicable + ": " + kyPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                            // Crouching Moves
                            + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                            + StriveXMLConstants.CrouchingPunch + ": " + kyPo.CrouchingPunch + Environment.NewLine
                            + StriveXMLConstants.CrouchingKick + ": " + kyPo.CrouchingKick + Environment.NewLine
                            + StriveXMLConstants.CrouchingSlash + ": " + kyPo.CrouchingSlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingHeavySlash + ": " + kyPo.CrouchingHeavySlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingDust + ": " + kyPo.CrouchingDust + Environment.NewLine
                            + StriveXMLConstants.CrouchingNotApplicable + ": " + kyPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                            // Additional Notes
                            + StriveXMLConstants.AdditionalNotes + ": " + kyPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

            return kyFrameData;
        }

        public string MayFrameData(List<MainFrameDataPO> list)
        {
            MainFrameDataPO mayPo = list.Find(l => l.TabPageName == StriveXMLConstants.TabMayPage);

            string mayFrameData
                       // Standing Far Moves
                       = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                           + StriveXMLConstants.StandingFarPunch + ": " + mayPo.StandingFarPunch + Environment.NewLine
                           + StriveXMLConstants.StandingFarKick + ": " + mayPo.StandingFarKick + Environment.NewLine
                           + StriveXMLConstants.StandingFarSlash + ": " + mayPo.StandingFarSlash + Environment.NewLine
                           + StriveXMLConstants.StandingFarHeavySlash + ": " + mayPo.StandingFarHeavySlash + Environment.NewLine
                           + StriveXMLConstants.StandingFarDust + ": " + mayPo.StandingFarDust + Environment.NewLine
                           + StriveXMLConstants.StandingFarNotApplicable + ": " + mayPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                           // Standing Close Moves
                           + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                           + StriveXMLConstants.StandingClosePunch + ": " + mayPo.StandingClosePunch + Environment.NewLine
                           + StriveXMLConstants.StandingCloseKick + ": " + mayPo.StandingCloseKick + Environment.NewLine
                           + StriveXMLConstants.StandingCloseSlash + ": " + mayPo.StandingCloseSlash + Environment.NewLine
                           + StriveXMLConstants.StandingCloseHeavySlash + ": " + mayPo.StandingCloseHeavySlash + Environment.NewLine
                           + StriveXMLConstants.StandingCloseDust + ": " + mayPo.StandingCloseDust + Environment.NewLine
                           + StriveXMLConstants.StandingCloseNotApplicable + ": " + mayPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                           // Crouching Moves
                           + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                           + StriveXMLConstants.CrouchingPunch + ": " + mayPo.CrouchingPunch + Environment.NewLine
                           + StriveXMLConstants.CrouchingKick + ": " + mayPo.CrouchingKick + Environment.NewLine
                           + StriveXMLConstants.CrouchingSlash + ": " + mayPo.CrouchingSlash + Environment.NewLine
                           + StriveXMLConstants.CrouchingHeavySlash + ": " + mayPo.CrouchingHeavySlash + Environment.NewLine
                           + StriveXMLConstants.CrouchingDust + ": " + mayPo.CrouchingDust + Environment.NewLine
                           + StriveXMLConstants.CrouchingNotApplicable + ": " + mayPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                           // Additional Notes
                           + StriveXMLConstants.AdditionalNotes + ": " + mayPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

            return mayFrameData;
        }

        public string ChippFrameData(List<MainFrameDataPO> list)
        {
            MainFrameDataPO chippPo = list.Find(l => l.TabPageName == StriveXMLConstants.TabChippPage);
            
            string chippFrameData
                        // Standing Far Moves
                        = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                            + StriveXMLConstants.StandingFarPunch + ": " + chippPo.StandingFarPunch + Environment.NewLine
                            + StriveXMLConstants.StandingFarKick + ": " + chippPo.StandingFarKick + Environment.NewLine
                            + StriveXMLConstants.StandingFarSlash + ": " + chippPo.StandingFarSlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarHeavySlash + ": " + chippPo.StandingFarHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarDust + ": " + chippPo.StandingFarDust + Environment.NewLine
                            + StriveXMLConstants.StandingFarNotApplicable + ": " + chippPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                            // Standing Close Moves
                            + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                            + StriveXMLConstants.StandingClosePunch + ": " + chippPo.StandingClosePunch + Environment.NewLine
                            + StriveXMLConstants.StandingCloseKick + ": " + chippPo.StandingCloseKick + Environment.NewLine
                            + StriveXMLConstants.StandingCloseSlash + ": " + chippPo.StandingCloseSlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseHeavySlash + ": " + chippPo.StandingCloseHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseDust + ": " + chippPo.StandingCloseDust + Environment.NewLine
                            + StriveXMLConstants.StandingCloseNotApplicable + ": " + chippPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                            // Crouching Moves
                            + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                            + StriveXMLConstants.CrouchingPunch + ": " + chippPo.CrouchingPunch + Environment.NewLine
                            + StriveXMLConstants.CrouchingKick + ": " + chippPo.CrouchingKick + Environment.NewLine
                            + StriveXMLConstants.CrouchingSlash + ": " + chippPo.CrouchingSlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingHeavySlash + ": " + chippPo.CrouchingHeavySlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingDust + ": " + chippPo.CrouchingDust + Environment.NewLine
                            + StriveXMLConstants.CrouchingNotApplicable + ": " + chippPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                            // Additional Notes
                            + StriveXMLConstants.AdditionalNotes + ": " + chippPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

            return chippFrameData;
        }

        public string PotemkinFrameData(List<MainFrameDataPO> list)
        {
            MainFrameDataPO potPo = list.Find(l => l.TabPageName == StriveXMLConstants.TabPotemkinPage);

            string potFrameData
                // Standing Far Moves
                = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                    + StriveXMLConstants.StandingFarPunch + ": " + potPo.StandingFarPunch + Environment.NewLine
                    + StriveXMLConstants.StandingFarKick + ": " + potPo.StandingFarKick + Environment.NewLine
                    + StriveXMLConstants.StandingFarSlash + ": " + potPo.StandingFarSlash + Environment.NewLine
                    + StriveXMLConstants.StandingFarHeavySlash + ": " + potPo.StandingFarHeavySlash + Environment.NewLine
                    + StriveXMLConstants.StandingFarDust + ": " + potPo.StandingFarDust + Environment.NewLine
                    + StriveXMLConstants.StandingFarNotApplicable + ": " + potPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                    // Standing Close Moves
                    + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                    + StriveXMLConstants.StandingClosePunch + ": " + potPo.StandingClosePunch + Environment.NewLine
                    + StriveXMLConstants.StandingCloseKick + ": " + potPo.StandingCloseKick + Environment.NewLine
                    + StriveXMLConstants.StandingCloseSlash + ": " + potPo.StandingCloseSlash + Environment.NewLine
                    + StriveXMLConstants.StandingCloseHeavySlash + ": " + potPo.StandingCloseHeavySlash + Environment.NewLine
                    + StriveXMLConstants.StandingCloseDust + ": " + potPo.StandingCloseDust + Environment.NewLine
                    + StriveXMLConstants.StandingCloseNotApplicable + ": " + potPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                    // Crouching Moves
                    + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                    + StriveXMLConstants.CrouchingPunch + ": " + potPo.CrouchingPunch + Environment.NewLine
                    + StriveXMLConstants.CrouchingKick + ": " + potPo.CrouchingKick + Environment.NewLine
                    + StriveXMLConstants.CrouchingSlash + ": " + potPo.CrouchingSlash + Environment.NewLine
                    + StriveXMLConstants.CrouchingHeavySlash + ": " + potPo.CrouchingHeavySlash + Environment.NewLine
                    + StriveXMLConstants.CrouchingDust + ": " + potPo.CrouchingDust + Environment.NewLine
                    + StriveXMLConstants.CrouchingNotApplicable + ": " + potPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                    // Additional Notes
                    + StriveXMLConstants.AdditionalNotes + ": " + potPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

            return potFrameData;
        }

        public string AxlFrameData(List<MainFrameDataPO> list)
        {
            MainFrameDataPO axlPo = list.Find(l => l.TabPageName == StriveXMLConstants.TabAxlPage);

            string axlFrameData
                // Standing Far Moves
                = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                    + StriveXMLConstants.StandingFarPunch + ": " + axlPo.StandingFarPunch + Environment.NewLine
                    + StriveXMLConstants.StandingFarKick + ": " + axlPo.StandingFarKick + Environment.NewLine
                    + StriveXMLConstants.StandingFarSlash + ": " + axlPo.StandingFarSlash + Environment.NewLine
                    + StriveXMLConstants.StandingFarHeavySlash + ": " + axlPo.StandingFarHeavySlash + Environment.NewLine
                    + StriveXMLConstants.StandingFarDust + ": " + axlPo.StandingFarDust + Environment.NewLine
                    + StriveXMLConstants.StandingFarNotApplicable + ": " + axlPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                    // Standing Close Moves
                    + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                    + StriveXMLConstants.StandingClosePunch + ": " + axlPo.StandingClosePunch + Environment.NewLine
                    + StriveXMLConstants.StandingCloseKick + ": " + axlPo.StandingCloseKick + Environment.NewLine
                    + StriveXMLConstants.StandingCloseSlash + ": " + axlPo.StandingCloseSlash + Environment.NewLine
                    + StriveXMLConstants.StandingCloseHeavySlash + ": " + axlPo.StandingCloseHeavySlash + Environment.NewLine
                    + StriveXMLConstants.StandingCloseDust + ": " + axlPo.StandingCloseDust + Environment.NewLine
                    + StriveXMLConstants.StandingCloseNotApplicable + ": " + axlPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                    // Crouching Moves
                    + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                    + StriveXMLConstants.CrouchingPunch + ": " + axlPo.CrouchingPunch + Environment.NewLine
                    + StriveXMLConstants.CrouchingKick + ": " + axlPo.CrouchingKick + Environment.NewLine
                    + StriveXMLConstants.CrouchingSlash + ": " + axlPo.CrouchingSlash + Environment.NewLine
                    + StriveXMLConstants.CrouchingHeavySlash + ": " + axlPo.CrouchingHeavySlash + Environment.NewLine
                    + StriveXMLConstants.CrouchingDust + ": " + axlPo.CrouchingDust + Environment.NewLine
                    + StriveXMLConstants.CrouchingNotApplicable + ": " + axlPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                    // Additional Notes
                    + StriveXMLConstants.AdditionalNotes + ": " + axlPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

            return axlFrameData;
        }

        public string FaustFrameData(List<MainFrameDataPO> list)
        {
            MainFrameDataPO faustPo = list.Find(l => l.TabPageName == StriveXMLConstants.TabFaustPage);

            string faustFrameData
                        // Standing Far Moves
                        = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                            + StriveXMLConstants.StandingFarPunch + ": " + faustPo.StandingFarPunch + Environment.NewLine
                            + StriveXMLConstants.StandingFarKick + ": " + faustPo.StandingFarKick + Environment.NewLine
                            + StriveXMLConstants.StandingFarSlash + ": " + faustPo.StandingFarSlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarHeavySlash + ": " + faustPo.StandingFarHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarDust + ": " + faustPo.StandingFarDust + Environment.NewLine
                            + StriveXMLConstants.StandingFarNotApplicable + ": " + faustPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                            // Standing Close Moves
                            + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                            + StriveXMLConstants.StandingClosePunch + ": " + faustPo.StandingClosePunch + Environment.NewLine
                            + StriveXMLConstants.StandingCloseKick + ": " + faustPo.StandingCloseKick + Environment.NewLine
                            + StriveXMLConstants.StandingCloseSlash + ": " + faustPo.StandingCloseSlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseHeavySlash + ": " + faustPo.StandingCloseHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseDust + ": " + faustPo.StandingCloseDust + Environment.NewLine
                            + StriveXMLConstants.StandingCloseNotApplicable + ": " + faustPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                            // Crouching Moves
                            + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                            + StriveXMLConstants.CrouchingPunch + ": " + faustPo.CrouchingPunch + Environment.NewLine
                            + StriveXMLConstants.CrouchingKick + ": " + faustPo.CrouchingKick + Environment.NewLine
                            + StriveXMLConstants.CrouchingSlash + ": " + faustPo.CrouchingSlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingHeavySlash + ": " + faustPo.CrouchingHeavySlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingDust + ": " + faustPo.CrouchingDust + Environment.NewLine
                            + StriveXMLConstants.CrouchingNotApplicable + ": " + faustPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                            // Additional Notes
                            + StriveXMLConstants.AdditionalNotes + ": " + faustPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

            return faustFrameData;
        }
    }
}
