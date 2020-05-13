using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using StriveFrameData.PresentationObjects;

namespace StriveFrameData.Builder
{
    public class PDFBuilder
    {
        /// <summary>
        /// Creates export PDF file.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public void CreatePDFFromMainFrameDataPOList(List<MainFrameDataPO> list, string path)
        {
            if (list == null || !list.Any() || string.IsNullOrEmpty(path)) return;

            bool workComplete = false;
            // Hierarchy 
            // 1. MainFrameData (Simple parent tag name) 
            //   A. UI Tab Page Name i.e. tabMayPage and tabSolPage
            //      i. Type of move i.e. StandingClose, StandingFar, Crouching groups.
            //          B. All of the UI elements that represent those types
            //             i.e. StandingClosePunch and CrouchingKick

            try
            {
                Document Doc = new Document();

                PdfWriter.GetInstance(Doc, new FileStream(path, FileMode.Create));
                Doc.Open();
                Chunk chunk1 = new Chunk
                ("By Matthew Miller, sysnom@gmail.com \n",
                    FontFactory.GetFont("Arial", 11));
                Paragraph p1 = new Paragraph {Alignment = Element.ALIGN_RIGHT};
                p1.Add(chunk1);
                Doc.Add(p1);

                XmlTextReader xmlReader = xmlReader = new XmlTextReader(new StringReader(list[0].StandingFarPunch));

                HtmlParser.Parse(Doc, xmlReader);
                Doc.Close();

                workComplete = true;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Reason: {e.Message}", @"Could not Export PDF",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (workComplete)
            {
                MessageBox.Show($@"Location: {path}", @"PDF Export Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
