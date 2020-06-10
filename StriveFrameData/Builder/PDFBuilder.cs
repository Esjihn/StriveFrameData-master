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
                Chunk kyHeaderChunk = new Chunk();
                Chunk kyFrameDataChunk = new Chunk();
                MainFrameDataPO kyPo = list.Find(l => l.TabPageName == StriveXMLConstants.tabKyPage);

                if (kyPo != null)
                {
                    kyHeaderChunk = new Chunk("Ky Page", FontFactory.GetFont("Arial Bold", 22));

                    string kyFrameData
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

                    kyFrameDataChunk = new Chunk(kyFrameData, FontFactory.GetFont("Arial", 11));
                }

                // May
                Chunk mayHeaderChunk = new Chunk();
                Chunk mayFrameDataChunk = new Chunk();
                MainFrameDataPO mayPo = list.Find(l => l.TabPageName == StriveXMLConstants.tabMayPage);

                if (mayPo != null)
                {
                    mayHeaderChunk = new Chunk("May Page", FontFactory.GetFont("Arial Bold", 22));

                    string mayFrameData
                        // Standing Far Moves
                        = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                            + StriveXMLConstants.StandingFarPunch + ": " + mayPo.StandingFarPunch + Environment.NewLine
                            + StriveXMLConstants.StandingFarKick + ": " + mayPo.StandingFarKick + Environment.NewLine
                            + StriveXMLConstants.StandingFarSlash + ": " + mayPo.StandingFarSlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarHeavySlash + ": " + mayPo.StandingFarHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarDust + ": " + mayPo.StandingFarDust + Environment.NewLine
                            + StriveXMLConstants.StandingFarNotApplicable + ": " + mayPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                            // Standing Close Moves
                            + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                            + StriveXMLConstants.StandingClosePunch + ": " + mayPo.StandingClosePunch + Environment.NewLine
                            + StriveXMLConstants.StandingCloseKick + ": " + mayPo.StandingCloseKick + Environment.NewLine
                            + StriveXMLConstants.StandingCloseSlash + ": " + mayPo.StandingCloseSlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseHeavySlash + ": " + mayPo.StandingCloseHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseDust + ": " + mayPo.StandingCloseDust + Environment.NewLine
                            + StriveXMLConstants.StandingCloseNotApplicable + ": " + mayPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                            // Crouching Moves
                            + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                            + StriveXMLConstants.CrouchingPunch + ": " + mayPo.CrouchingPunch + Environment.NewLine
                            + StriveXMLConstants.CrouchingKick + ": " + mayPo.CrouchingKick + Environment.NewLine
                            + StriveXMLConstants.CrouchingSlash + ": " + mayPo.CrouchingSlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingHeavySlash + ": " + mayPo.CrouchingHeavySlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingDust + ": " + mayPo.CrouchingDust + Environment.NewLine
                            + StriveXMLConstants.CrouchingNotApplicable + ": " + mayPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                            // Additional Notes
                            + StriveXMLConstants.AdditionalNotes + Environment.NewLine
                            + StriveXMLConstants.AdditionalNote + ": " + mayPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

                    mayFrameDataChunk = new Chunk(mayFrameData, FontFactory.GetFont("Arial", 11));
                }

                // Chipp
                Chunk chippHeaderChunk = new Chunk();
                Chunk chippFrameDataChunk = new Chunk();
                MainFrameDataPO chippPo = list.Find(l => l.TabPageName == StriveXMLConstants.tabChippPage);

                if (chippPo != null)
                {
                    chippHeaderChunk = new Chunk("Chipp Page", FontFactory.GetFont("Arial Bold", 22));

                    string chippFrameData
                        // Standing Far Moves
                        = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                            + StriveXMLConstants.StandingFarPunch + ": " + chippPo.StandingFarPunch + Environment.NewLine
                            + StriveXMLConstants.StandingFarKick + ": " + chippPo.StandingFarKick + Environment.NewLine
                            + StriveXMLConstants.StandingFarSlash + ": " + chippPo.StandingFarSlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarHeavySlash + ": " + chippPo.StandingFarHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarDust + ": " + chippPo.StandingFarDust + Environment.NewLine
                            + StriveXMLConstants.StandingFarNotApplicable + ": " + chippPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                            // Standing Close Moves
                            + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                            + StriveXMLConstants.StandingClosePunch + ": " + chippPo.StandingClosePunch + Environment.NewLine
                            + StriveXMLConstants.StandingCloseKick + ": " + chippPo.StandingCloseKick + Environment.NewLine
                            + StriveXMLConstants.StandingCloseSlash + ": " + chippPo.StandingCloseSlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseHeavySlash + ": " + chippPo.StandingCloseHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseDust + ": " + chippPo.StandingCloseDust + Environment.NewLine
                            + StriveXMLConstants.StandingCloseNotApplicable + ": " + chippPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                            // Crouching Moves
                            + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                            + StriveXMLConstants.CrouchingPunch + ": " + chippPo.CrouchingPunch + Environment.NewLine
                            + StriveXMLConstants.CrouchingKick + ": " + chippPo.CrouchingKick + Environment.NewLine
                            + StriveXMLConstants.CrouchingSlash + ": " + chippPo.CrouchingSlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingHeavySlash + ": " + chippPo.CrouchingHeavySlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingDust + ": " + chippPo.CrouchingDust + Environment.NewLine
                            + StriveXMLConstants.CrouchingNotApplicable + ": " + chippPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                            // Additional Notes
                            + StriveXMLConstants.AdditionalNotes + Environment.NewLine
                            + StriveXMLConstants.AdditionalNote + ": " + chippPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

                    chippFrameDataChunk = new Chunk(chippFrameData, FontFactory.GetFont("Arial", 11));
                }

                // Potemkin
                Chunk potHeaderChunk = new Chunk();
                Chunk potFrameDataChunk = new Chunk();
                MainFrameDataPO potPo = list.Find(l => l.TabPageName == StriveXMLConstants.tabPotemkinPage);

                if (potPo != null)
                {
                    potHeaderChunk = new Chunk("Potemkin Page", FontFactory.GetFont("Arial Bold", 22));

                    string potFrameData
                        // Standing Far Moves
                        = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                            + StriveXMLConstants.StandingFarPunch + ": " + potPo.StandingFarPunch + Environment.NewLine
                            + StriveXMLConstants.StandingFarKick + ": " + potPo.StandingFarKick + Environment.NewLine
                            + StriveXMLConstants.StandingFarSlash + ": " + potPo.StandingFarSlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarHeavySlash + ": " + potPo.StandingFarHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarDust + ": " + potPo.StandingFarDust + Environment.NewLine
                            + StriveXMLConstants.StandingFarNotApplicable + ": " + potPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                            // Standing Close Moves
                            + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                            + StriveXMLConstants.StandingClosePunch + ": " + potPo.StandingClosePunch + Environment.NewLine
                            + StriveXMLConstants.StandingCloseKick + ": " + potPo.StandingCloseKick + Environment.NewLine
                            + StriveXMLConstants.StandingCloseSlash + ": " + potPo.StandingCloseSlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseHeavySlash + ": " + potPo.StandingCloseHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseDust + ": " + potPo.StandingCloseDust + Environment.NewLine
                            + StriveXMLConstants.StandingCloseNotApplicable + ": " + potPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                            // Crouching Moves
                            + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                            + StriveXMLConstants.CrouchingPunch + ": " + potPo.CrouchingPunch + Environment.NewLine
                            + StriveXMLConstants.CrouchingKick + ": " + potPo.CrouchingKick + Environment.NewLine
                            + StriveXMLConstants.CrouchingSlash + ": " + potPo.CrouchingSlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingHeavySlash + ": " + potPo.CrouchingHeavySlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingDust + ": " + potPo.CrouchingDust + Environment.NewLine
                            + StriveXMLConstants.CrouchingNotApplicable + ": " + potPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                            // Additional Notes
                            + StriveXMLConstants.AdditionalNotes + Environment.NewLine
                            + StriveXMLConstants.AdditionalNote + ": " + potPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

                    potFrameDataChunk = new Chunk(potFrameData, FontFactory.GetFont("Arial", 11));
                }

                // Axl
                Chunk axlHeaderChunk = new Chunk();
                Chunk axlFrameDataChunk = new Chunk();
                MainFrameDataPO axlPo = list.Find(l => l.TabPageName == StriveXMLConstants.tabAxlPage);

                if (axlPo != null)
                {
                    axlHeaderChunk = new Chunk("Axl Page", FontFactory.GetFont("Arial Bold", 22));

                    string axlFrameData
                        // Standing Far Moves
                        = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                            + StriveXMLConstants.StandingFarPunch + ": " + axlPo.StandingFarPunch + Environment.NewLine
                            + StriveXMLConstants.StandingFarKick + ": " + axlPo.StandingFarKick + Environment.NewLine
                            + StriveXMLConstants.StandingFarSlash + ": " + axlPo.StandingFarSlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarHeavySlash + ": " + axlPo.StandingFarHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarDust + ": " + axlPo.StandingFarDust + Environment.NewLine
                            + StriveXMLConstants.StandingFarNotApplicable + ": " + axlPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                            // Standing Close Moves
                            + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                            + StriveXMLConstants.StandingClosePunch + ": " + axlPo.StandingClosePunch + Environment.NewLine
                            + StriveXMLConstants.StandingCloseKick + ": " + axlPo.StandingCloseKick + Environment.NewLine
                            + StriveXMLConstants.StandingCloseSlash + ": " + axlPo.StandingCloseSlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseHeavySlash + ": " + axlPo.StandingCloseHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseDust + ": " + axlPo.StandingCloseDust + Environment.NewLine
                            + StriveXMLConstants.StandingCloseNotApplicable + ": " + axlPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                            // Crouching Moves
                            + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                            + StriveXMLConstants.CrouchingPunch + ": " + axlPo.CrouchingPunch + Environment.NewLine
                            + StriveXMLConstants.CrouchingKick + ": " + axlPo.CrouchingKick + Environment.NewLine
                            + StriveXMLConstants.CrouchingSlash + ": " + axlPo.CrouchingSlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingHeavySlash + ": " + axlPo.CrouchingHeavySlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingDust + ": " + axlPo.CrouchingDust + Environment.NewLine
                            + StriveXMLConstants.CrouchingNotApplicable + ": " + axlPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                            // Additional Notes
                            + StriveXMLConstants.AdditionalNotes + Environment.NewLine
                            + StriveXMLConstants.AdditionalNote + ": " + axlPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

                    axlFrameDataChunk = new Chunk(axlFrameData, FontFactory.GetFont("Arial", 11));
                }

                // Faust
                Chunk faustHeaderChunk = new Chunk();
                Chunk faustFrameDataChunk = new Chunk();
                MainFrameDataPO faustPo = list.Find(l => l.TabPageName == StriveXMLConstants.tabFaustPage);

                if (faustPo != null)
                {
                    faustHeaderChunk = new Chunk("Faust Page", FontFactory.GetFont("Arial Bold", 22));

                    string faustFrameData
                        // Standing Far Moves
                        = StriveXMLConstants.StandingFarMoves + Environment.NewLine
                            + StriveXMLConstants.StandingFarPunch + ": " + faustPo.StandingFarPunch + Environment.NewLine
                            + StriveXMLConstants.StandingFarKick + ": " + faustPo.StandingFarKick + Environment.NewLine
                            + StriveXMLConstants.StandingFarSlash + ": " + faustPo.StandingFarSlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarHeavySlash + ": " + faustPo.StandingFarHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingFarDust + ": " + faustPo.StandingFarDust + Environment.NewLine
                            + StriveXMLConstants.StandingFarNotApplicable + ": " + faustPo.StandingFarNotApplicable + Environment.NewLine + Environment.NewLine
                            // Standing Close Moves
                            + StriveXMLConstants.StandingCloseMoves + Environment.NewLine
                            + StriveXMLConstants.StandingClosePunch + ": " + faustPo.StandingClosePunch + Environment.NewLine
                            + StriveXMLConstants.StandingCloseKick + ": " + faustPo.StandingCloseKick + Environment.NewLine
                            + StriveXMLConstants.StandingCloseSlash + ": " + faustPo.StandingCloseSlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseHeavySlash + ": " + faustPo.StandingCloseHeavySlash + Environment.NewLine
                            + StriveXMLConstants.StandingCloseDust + ": " + faustPo.StandingCloseDust + Environment.NewLine
                            + StriveXMLConstants.StandingCloseNotApplicable + ": " + faustPo.StandingCloseNotApplicable + Environment.NewLine + Environment.NewLine
                            // Crouching Moves
                            + StriveXMLConstants.CrouchingMoves + Environment.NewLine
                            + StriveXMLConstants.CrouchingPunch + ": " + faustPo.CrouchingPunch + Environment.NewLine
                            + StriveXMLConstants.CrouchingKick + ": " + faustPo.CrouchingKick + Environment.NewLine
                            + StriveXMLConstants.CrouchingSlash + ": " + faustPo.CrouchingSlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingHeavySlash + ": " + faustPo.CrouchingHeavySlash + Environment.NewLine
                            + StriveXMLConstants.CrouchingDust + ": " + faustPo.CrouchingDust + Environment.NewLine
                            + StriveXMLConstants.CrouchingNotApplicable + ": " + faustPo.CrouchingNotApplicable + Environment.NewLine + Environment.NewLine
                            // Additional Notes
                            + StriveXMLConstants.AdditionalNotes + Environment.NewLine
                            + StriveXMLConstants.AdditionalNote + ": " + faustPo.AdditionalNotesTextBoxText + Environment.NewLine + Environment.NewLine;

                    faustFrameDataChunk = new Chunk(faustFrameData, FontFactory.GetFont("Arial", 11));
                }

                DateTime date = DateTime.Now;
                Chunk creatorChunk = new Chunk($"Developer: Matthew Miller, Email: sysnom@gmail.com, Export Date: {date}",
                    FontFactory.GetFont("Arial", 11));

                Paragraph headerParagraph = new Paragraph {Alignment = Element.ALIGN_CENTER};

                // Character paragraphs
                Paragraph solHeaderParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph solFrameDataParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph kyHeaderParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph kyFrameDataParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph mayHeaderParagraph = new Paragraph{ Alignment = Element.ALIGN_LEFT };
                Paragraph mayFrameDataParagraph = new Paragraph{ Alignment = Element.ALIGN_LEFT };
                Paragraph chippHeaderParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph chippFrameDataParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph potHeaderParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph potFrameDataParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph axlHeaderParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph axlFrameDataParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph faustHeaderParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
                Paragraph faustFrameDataParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };

                Paragraph creatorParagraph = new Paragraph {Alignment = Element.ALIGN_RIGHT};

                Paragraph lineParagraph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                Paragraph singleSpaceParagraph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                Paragraph doubleSpaceParagraph = new Paragraph{Alignment = Element.ALIGN_CENTER};
                
                // Header
                headerParagraph.Add(headerChunk);

                // Sol
                solHeaderParagraph.Add(solHeaderChunk);
                solFrameDataParagraph.Add(solFrameDataChunk);
                
                // Ky
                kyHeaderParagraph.Add(kyHeaderChunk);
                kyFrameDataParagraph.Add(kyFrameDataChunk);

                // May
                mayHeaderParagraph.Add(mayHeaderChunk);
                mayFrameDataParagraph.Add(mayFrameDataChunk);

                // Chipp
                chippHeaderParagraph.Add(chippHeaderChunk);
                chippFrameDataParagraph.Add(chippFrameDataChunk);

                // Potemkin
                potHeaderParagraph.Add(potHeaderChunk);
                potFrameDataParagraph.Add(potFrameDataChunk);

                // Axl
                axlHeaderParagraph.Add(axlHeaderChunk);
                axlFrameDataParagraph.Add(axlFrameDataChunk);

                // Faust
                faustHeaderParagraph.Add(faustHeaderChunk);
                faustFrameDataParagraph.Add(faustFrameDataChunk);

                // Dev 
                creatorParagraph.Add(creatorChunk);
                
                // Formatting
                singleSpaceParagraph.Add(singleSpaceChunk);
                doubleSpaceParagraph.Add(doubleSpaceChunk);
                lineParagraph.Add(linkChunk);

                // Header doc
                doc.Add(headerParagraph);
                doc.Add(lineParagraph);
                doc.Add(singleSpaceParagraph);
                
                // Sol doc
                doc.Add(solHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(solFrameDataParagraph);
                doc.Add(singleSpaceParagraph);

                // Ky doc
                doc.Add(kyHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(kyFrameDataParagraph);
                doc.Add(singleSpaceParagraph);

                // May doc
                doc.Add(mayHeaderChunk);
                doc.Add(singleSpaceParagraph);
                doc.Add(mayFrameDataParagraph);
                doc.Add(singleSpaceParagraph);

                // Chipp doc
                doc.Add(chippHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(chippFrameDataParagraph);
                doc.Add(singleSpaceParagraph);

                // Potemkin doc
                doc.Add(potHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(potFrameDataParagraph);
                doc.Add(singleSpaceParagraph);

                // Axl doc
                doc.Add(axlHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(axlFrameDataParagraph);
                doc.Add(singleSpaceParagraph);

                // Faust doc
                doc.Add(faustHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(faustFrameDataParagraph);
                doc.Add(singleSpaceParagraph);

                // Footer doc
                doc.Add(lineParagraph);
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
