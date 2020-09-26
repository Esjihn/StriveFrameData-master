using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using StriveFrameData.Constants;
using StriveFrameData.PresentationObjects;

namespace StriveFrameData.Builder
{
    public class XMLBuilder
    {
        /// <summary>
        /// Creates XML Export file.
        /// </summary>
        /// <param name="list">UI MainFrameDataPO list</param>
        /// <param name="path">file path</param>
        public void CreateXMLFromMainFrameDataPOList(List<MainFrameDataPO> list, string path)
        {
            if (list == null || !list.Any() || string.IsNullOrEmpty(path)) return;

            bool workComplete = false;
            try
            {
                // Hierarchy 
                // 1. MainFrameData (Simple parent tag name) 
                //   A. UI Tab Page Name i.e. tabMayPage and tabSolPage
                //      i. Type of move i.e. StandingClose, StandingFar, Crouching groups.
                //          B. All of the UI elements that represent those types
                //             i.e. StandingClosePunch and CrouchingKick
                //                 C. Import/Export location

                XElement element =
                    new XElement(StriveXMLConstants.MainFrameData,
                        from po in list
                        select new XElement(po.TabPageName,
                            new XElement(StriveXMLConstants.StandingFarMoves,
                                new XElement(StriveXMLConstants.StandingFarPunch, po.StandingFarPunch),
                                new XElement(StriveXMLConstants.StandingFarKick, po.StandingFarKick),
                                new XElement(StriveXMLConstants.StandingFarSlash, po.StandingFarSlash),
                                new XElement(StriveXMLConstants.StandingFarHeavySlash, po.StandingFarHeavySlash),
                                new XElement(StriveXMLConstants.StandingFarDust, po.StandingFarDust),
                                new XElement(StriveXMLConstants.StandingFarNotApplicable, po.StandingFarNotApplicable)),
                            new XElement(StriveXMLConstants.StandingCloseMoves,
                                new XElement(StriveXMLConstants.StandingClosePunch, po.StandingClosePunch),
                                new XElement(StriveXMLConstants.StandingCloseKick, po.StandingCloseKick),
                                new XElement(StriveXMLConstants.StandingCloseSlash, po.StandingCloseSlash),
                                new XElement(StriveXMLConstants.StandingCloseHeavySlash, po.StandingCloseHeavySlash),
                                new XElement(StriveXMLConstants.StandingCloseDust, po.StandingCloseDust),
                                new XElement(StriveXMLConstants.StandingCloseNotApplicable, po.StandingCloseNotApplicable)),
                            new XElement(StriveXMLConstants.CrouchingMoves,
                                new XElement(StriveXMLConstants.CrouchingPunch, po.CrouchingPunch),
                                new XElement(StriveXMLConstants.CrouchingKick, po.CrouchingKick),
                                new XElement(StriveXMLConstants.CrouchingSlash, po.CrouchingSlash),
                                new XElement(StriveXMLConstants.CrouchingHeavySlash, po.CrouchingHeavySlash),
                                new XElement(StriveXMLConstants.CrouchingDust, po.CrouchingDust),
                                new XElement(StriveXMLConstants.CrouchingNotApplicable, po.CrouchingNotApplicable)),
                            new XElement(StriveXMLConstants.AdditionalNotes,
                                new XElement(StriveXMLConstants.AdditionalNote, po.AdditionalNotesTextBoxText)),
                            new XElement(StriveXMLConstants.ImportExportLocations,
                                new XElement(StriveXMLConstants.ImportExportLocation, po.ImportExportLocationText))));

                // Write complete XML element as XML page to file.
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(element);
                }
                   
                workComplete = true;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Reason: {e.Message}", @"Could not Export XML",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (workComplete)
            {
                MessageBox.Show($@"Location: {path}", @"XML Export Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
