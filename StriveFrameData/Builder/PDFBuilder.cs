using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
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
        /// <param name="xmlPath"></param>
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
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                XmlReader reader = XmlReader.Create(xmlPath);
                
                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                {
                    sb.Append(reader.Name);
                    sb.Append(reader.Value);
                }
                DateTime date = DateTime.Now;

                Chunk frameDataChunk = new Chunk(sb.ToString(), FontFactory.GetFont("Arial", 11));
                Chunk headerChunk = new Chunk("Frame Data PDF Export", FontFactory.GetFont("Arial", 48));
                Chunk creatorChunk = new Chunk($"Developer: Matthew Miller, Email: sysnom@gmail.com, Export Date: {date}",
                    FontFactory.GetFont("Arial", 11));
                Chunk spaceChunk = new Chunk("--------------------------------------------------------------------------" +
                                             "--------------------------------------------------------------------", 
                    FontFactory.GetFont("Arial", 11));

                Paragraph headerParagraph = new Paragraph {Alignment = Element.ALIGN_CENTER};
                Paragraph frameDataParagraph = new Paragraph {Alignment = Element.ALIGN_LEFT};
                Paragraph creatorParagraph = new Paragraph {Alignment = Element.ALIGN_RIGHT};
                Paragraph spaceParagraph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                
                headerParagraph.Add(headerChunk);
                frameDataParagraph.Add(frameDataChunk);
                creatorParagraph.Add(creatorChunk);
                spaceParagraph.Add(spaceChunk);
                
                doc.Add(headerParagraph);
                doc.Add(spaceParagraph);
                doc.Add(frameDataParagraph);
                doc.Add(spaceParagraph);
                doc.Add(creatorParagraph);

                doc.Close();

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
