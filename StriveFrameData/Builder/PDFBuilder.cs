using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StriveFrameData.Constants;
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
        public void CreatePdfFromMainFrameDataPoList(List<MainFrameDataPO> list, string path)
        {
            if (list == null || !list.Any() || string.IsNullOrEmpty(path)) return;

            bool workComplete = false;

            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                Chunk headerChunk = new Chunk("Frame Data PDF Export", FontFactory.GetFont("Arial", 48));
                Chunk linkChunk = new Chunk("--------------------------------------------------------------------------" +
                                            "--------------------------------------------------------------------",
                    FontFactory.GetFont("Arial", 11));
                Chunk singleSpaceChunk = new Chunk(Environment.NewLine);
                Chunk doubleSpaceChunk = new Chunk(Environment.NewLine + Environment.NewLine);

                // Sol
                // TODO (finish)
                Chunk solHeaderChunk = new Chunk();
                Chunk solFrameDataChunk = new Chunk();

                MainFrameDataPO solPo = list.Find(l => l.TabPageName == StriveXMLConstants.tabSolPage);
                if (solPo != null)
                {
                    solHeaderChunk = new Chunk("Sol Page", FontFactory.GetFont("Arial Bold", 22));

                    string solFrameData
                        // Standing Far Moves
                        = StriveXMLConstants.StandingFarMoves
                          + Environment.NewLine
                          + StriveXMLConstants.StandingFarPunch + ": " + solPo.StandingFarPunch
                          + Environment.NewLine
                          + StriveXMLConstants.StandingFarKick + ": " + solPo.StandingFarKick
                          + Environment.NewLine
                          + StriveXMLConstants.StandingFarSlash + ": " + solPo.StandingFarSlash
                          + Environment.NewLine
                          + StriveXMLConstants.StandingFarHeavySlash + ": " + solPo.StandingFarHeavySlash
                          + Environment.NewLine
                          + StriveXMLConstants.StandingFarDust + ": " + solPo.StandingFarDust
                          + Environment.NewLine
                          + StriveXMLConstants.StandingFarNotApplicable + ": " + solPo.StandingFarNotApplicable
                          + Environment.NewLine
                          // Standing Close Moves
                          + StriveXMLConstants.StandingFarMoves
                          + Environment.NewLine;


                    solFrameDataChunk = new Chunk(solFrameData, FontFactory.GetFont("Arial", 11));
                }

                // Ky
                // TODO 
                // May
                // TODO
                // Chipp
                // TODO
                // Potemkin
                // TODO
                // Axl
                // TODO
                // Faust
                // TODO

                DateTime date = DateTime.Now;
                Chunk creatorChunk = new Chunk($"Developer: Matthew Miller, Email: sysnom@gmail.com, Export Date: {date}",
                    FontFactory.GetFont("Arial", 11));
                

                Paragraph headerParagraph = new Paragraph {Alignment = Element.ALIGN_CENTER};
                Paragraph solHeaderParagraph = new Paragraph {Alignment = Element.ALIGN_LEFT};
                Paragraph solFrameDataParagraph = new Paragraph {Alignment = Element.ALIGN_LEFT};
                Paragraph creatorParagraph = new Paragraph {Alignment = Element.ALIGN_RIGHT};
                Paragraph lineParagaph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                Paragraph singleSpaceParagraph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                Paragraph doubleSpaceParagraph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                
                headerParagraph.Add(headerChunk);
                solHeaderParagraph.Add(solHeaderChunk);
                solFrameDataParagraph.Add(solFrameDataChunk);
                creatorParagraph.Add(creatorChunk);
                lineParagaph.Add(linkChunk);
                singleSpaceParagraph.Add(singleSpaceChunk);
                doubleSpaceParagraph.Add(doubleSpaceChunk);
                
                doc.Add(headerParagraph);
                doc.Add(lineParagaph);
                doc.Add(singleSpaceParagraph);
                doc.Add(solHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(solFrameDataParagraph);
                doc.Add(lineParagaph);
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
