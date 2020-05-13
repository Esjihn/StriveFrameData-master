using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        public void CreatePDFFromMainFrameDataPOList(List<MainFrameDataPO> list, string path, string xmlPath)
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

                XmlTextReader xmlReader = new XmlTextReader(xmlPath);
                
                Chunk frameDataChunk = new Chunk();
                
                while (xmlReader.Read())
                {
                    frameDataChunk = new Chunk(xmlReader.Value, FontFactory.GetFont("Arial", 11));
                }

                Chunk headerChunk = new Chunk("Frame Data PDF Export", FontFactory.GetFont("Arial", 48));
                Chunk creatorChunk = new Chunk("By Matthew Miller, sysnom@gmail.com \n",
                    FontFactory.GetFont("Arial", 11));

                Paragraph headerParagraph = new Paragraph {Alignment = Element.ALIGN_CENTER};
                Paragraph frameDataParagraph = new Paragraph {Alignment = Element.ALIGN_LEFT};
                Paragraph creatorParagraph = new Paragraph {Alignment = Element.ALIGN_RIGHT};
                
                headerParagraph.Add(headerChunk);
                frameDataParagraph.Add(frameDataChunk);
                creatorParagraph.Add(creatorChunk);
                
                Doc.Add(headerParagraph);
                Doc.Add(frameDataParagraph);
                Doc.Add(creatorParagraph);

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
