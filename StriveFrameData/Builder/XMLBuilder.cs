using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using StriveFrameData.PresentationObjects;

namespace StriveFrameData.Builder
{
    public class XMLBuilder
    {
        /// <summary>
        /// Creates XML Export file for 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path">file path</param>
        public void CreateXMLFromMainFrameDataPOList(List<MainFrameDataPO> list, string path)
        {
            if (list == null || !list.Any() || string.IsNullOrEmpty(path)) return;

            // todo finish creating all XElements 
            // Hierarchy 
            // 1. MainFrameData (Simple parent tag name) 
            //   A. UI Tab Page Name i.e. tabMayPage and tabSolPage
            //      i. Type of move i.e. StandingClose, StandingFar, Crouching groups
            //          B. All of the UI elements that represent those types
            //             i.e. StandingClosePunch and CrouchingKick

            XElement element =
                new XElement("MainFrameData",
                    from po in list
                    select new XElement(po.TabPageName,
                        new XElement("StandingCloseMoves",
                        new XElement("StandingClosePunch", po.StandingClosePunch),
                        new XElement("StandingCloseKick", po.StandingCloseKick))));

            using (StreamWriter sw = new StreamWriter(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments) + @"\test.txt"))
            {
                sw.WriteLine(element);
            }

        }
    }
}
