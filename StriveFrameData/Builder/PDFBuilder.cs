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
        /// <param name="list">MainFrameDataPO list</param>
        /// <param name="path">Path and file name for pdf file to be created</param>
        /// <param name="xmlPath">path to xml file</param>
        public void CreatePDFFromMainFrameDataPOList(List<MainFrameDataPO> list, string path, string xmlPath)
        {
            if (list == null || !list.Any() || string.IsNullOrEmpty(path)) return;

            bool workComplete = false;

            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                XmlReader reader = XmlReader.Create(xmlPath);
                
                StringBuilder sb = new StringBuilder();
                MainFrameDataPO po = new MainFrameDataPO();

                while (reader.Read())
                {
                    // todo further formatting is needed for readability.

                    sb.Append(reader.Name);
                    sb.Append(reader.Value);
                }

                DateTime date = DateTime.Now; 

                // todo further formatting
                // todo remove frameDataChunk Implementation
                Chunk frameDataChunk = new Chunk(sb.ToString(), FontFactory.GetFont("Arial", 11));
                // todo Dynamically create a list of chunks that parse out the entire string builder object based on a string value and edit its formatting.
                // todo create a single paragraph to store all of those chunks
                // todo add the modified paragraph to doc. 


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
