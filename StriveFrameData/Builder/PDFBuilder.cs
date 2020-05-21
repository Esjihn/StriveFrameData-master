﻿using System;
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
                Chunk solHeaderChunk = new Chunk();
                Chunk solFrameDataChunk = new Chunk();
                MainFrameDataPO solPo = list.Find(l => l.TabPageName == StriveXMLConstants.tabSolPage);
                
                if (solPo != null)
                {
                    solHeaderChunk = new Chunk("Sol Page", FontFactory.GetFont("Arial Bold", 22));

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
                            + StriveXMLConstants.AdditionalNotes + Environment.NewLine
                            + StriveXMLConstants.AdditionalNote + ": " + solPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

                    solFrameDataChunk = new Chunk(solFrameData, FontFactory.GetFont("Arial", 11));
                }

                // Ky
                // TODO 
                Chunk kyHeaderChunk = new Chunk();
                Chunk kyFrameDataChunk = new Chunk();
                MainFrameDataPO kyPo = list.Find(l => l.TabPageName == StriveXMLConstants.tabKyPage);

                if (kyPo != null)
                {
                    kyHeaderChunk = new Chunk("Ky Page", FontFactory.GetFont("Arial Bold", 22));

                    string solFrameData
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
                            + StriveXMLConstants.AdditionalNotes + Environment.NewLine
                            + StriveXMLConstants.AdditionalNote + ": " + kyPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

                    kyFrameDataChunk = new Chunk(solFrameData, FontFactory.GetFont("Arial", 11));
                }

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
                Paragraph kyHeaderParagraph = new Paragraph {Alignment = Element.ALIGN_LEFT};
                Paragraph kyFrameDataParagraph = new Paragraph {Alignment = Element.ALIGN_LEFT};
                Paragraph creatorParagraph = new Paragraph {Alignment = Element.ALIGN_RIGHT};
                Paragraph lineParagaph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                Paragraph singleSpaceParagraph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                Paragraph doubleSpaceParagraph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                
                headerParagraph.Add(headerChunk);
                solHeaderParagraph.Add(solHeaderChunk);
                solFrameDataParagraph.Add(solFrameDataChunk);
                kyHeaderParagraph.Add(kyHeaderChunk);
                kyFrameDataParagraph.Add(kyFrameDataChunk);
                creatorParagraph.Add(creatorChunk);
                lineParagaph.Add(linkChunk);
                singleSpaceParagraph.Add(singleSpaceChunk);
                doubleSpaceParagraph.Add(doubleSpaceChunk);
                
                // Header
                doc.Add(headerParagraph);
                doc.Add(lineParagaph);
                doc.Add(singleSpaceParagraph);
                
                // Sol
                doc.Add(solHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(solFrameDataParagraph);
                doc.Add(singleSpaceParagraph);

                // Ky
                doc.Add(kyHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(kyFrameDataParagraph);
                doc.Add(singleSpaceParagraph);

                // Footer
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
