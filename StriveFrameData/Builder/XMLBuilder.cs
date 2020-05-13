using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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

                XElement element =
                    new XElement("MainFrameData",
                        from po in list
                        select new XElement(po.TabPageName,
                            new XElement("StandingFarMoves",
                                new XElement("StandingFarPunch", po.StandingFarPunch),
                                new XElement("StandingFarKick", po.StandingFarKick),
                                new XElement("StandingFarSlash", po.StandingFarSlash),
                                new XElement("StandingFarHeavySlash", po.StandingFarHeavySlash),
                                new XElement("StandingFarDust", po.StandingFarDust),
                                new XElement("StandingFarNotApplicable", po.StandingFarNotApplicable)),
                            new XElement("StandingCloseMoves",
                                new XElement("StandingClosePunch", po.StandingClosePunch),
                                new XElement("StandingCloseKick", po.StandingCloseKick),
                                new XElement("StandingCloseSlash", po.StandingCloseSlash),
                                new XElement("StandingCloseHeavySlash", po.StandingCloseHeavySlash),
                                new XElement("StandingCloseDust", po.StandingCloseDust),
                                new XElement("StandingCloseNotApplicable", po.StandingCloseNotApplicable)),
                            new XElement("CrouchingMoves",
                                new XElement("CrouchingPunch", po.CrouchingPunch),
                                new XElement("CrouchingSlash", po.CrouchingSlash),
                                new XElement("CrouchingHeavySlash", po.CrouchingHeavySlash),
                                new XElement("CrouchingDust", po.CrouchingDust),
                                new XElement("CrouchingNotApplicable", po.CrouchingNotApplicable)),
                            new XElement("AdditionalNotes",
                                new XElement("AdditionalNote", po.AdditionalNotesTextBoxText)),
                            new XElement("ImportExportLocations",
                                new XElement("ImportExportLocation", po.ImportExportLocationText))));

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
