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
        /// Create XML from generic list.
        /// </summary>
        /// <param name="list"></param>
        public void CreateXMLFromGeneric(IEnumerable<object> list)
        {

        }

        /// <summary>
        /// Creates XML Export file for 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path">file path</param>
        public void CreateXMLFromMainFrameDataPOList(List<MainFrameDataPO> list, string path)
        {
            if (list == null || !list.Any() || string.IsNullOrEmpty(path)) return;

            // todo create xml
            XElement element = 
                new XElement("MainFrameDataPO", 
                    from po in list
                     select new XElement("StandingCloseMoves",
                         new XElement("StandingClosePunch", po.StandingClosePunch),
                         new XElement("StandingCloseKick", po.StandingCloseKick)));

            using (StreamWriter sw = new StreamWriter(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments) + @"\test.txt"))
            {
                sw.WriteLine(element);
            }

        }
    }
}
