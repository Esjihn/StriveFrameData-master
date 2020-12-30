using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StriveFrameData.PresentationObjects;
using StriveFrameData.Repositories;

namespace StriveFrameData.Factories
{
    public class PDFFactory
    {
        /// <summary>
        /// Singleton PDF Factory
        /// </summary>
        public static PDFFactory Factory => new PDFFactory();

        /// <summary>
        /// Creates export PDF file.
        /// </summary>
        /// <param name="list">MainFrameDataPO list</param>
        /// <param name="path">Path and file name for pdf file to be created</param>
        public void CreatePdfFromMainFrameDataPoList(List<MainFrameDataPO> list, string path)
        {
            bool workComplete = false;

            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                Chunk headerChunk = new Chunk("Frame Data PDF Export", FontFactory.GetFont("Arial", 48));
                Chunk lineChunk = new Chunk("--------------------------------------------------------------------------" +
                                            "--------------------------------------------------------------------",
                                            FontFactory.GetFont("Arial", 11));
                Chunk singleSpaceChunk = new Chunk(Environment.NewLine);
                Chunk doubleSpaceChunk = new Chunk(Environment.NewLine + Environment.NewLine);

                // Sol
                Chunk solHeaderChunk = solHeaderChunk = new Chunk("Sol Page", FontFactory.GetFont("Arial Bold", 22));
                Chunk solFrameDataChunk = new Chunk(CharacterRepository.Retrieve.SolFrameData(list), FontFactory.GetFont("Arial", 11));

                // Ky
                Chunk kyHeaderChunk = new Chunk("Ky Page", FontFactory.GetFont("Arial Bold", 22)); ;
                Chunk kyFrameDataChunk = new Chunk(CharacterRepository.Retrieve.KyFrameData(list), FontFactory.GetFont("Arial", 11));

                // May
                Chunk mayHeaderChunk = new Chunk("May Page", FontFactory.GetFont("Arial Bold", 22));
                Chunk mayFrameDataChunk = new Chunk(CharacterRepository.Retrieve.MayFrameData(list), FontFactory.GetFont("Arial", 11));

                // Chipp
                Chunk chippHeaderChunk = new Chunk("Chipp Page", FontFactory.GetFont("Arial Bold", 22));
                Chunk chippFrameDataChunk = new Chunk(CharacterRepository.Retrieve.ChippFrameData(list), FontFactory.GetFont("Arial", 11));

                // Potemkin
                Chunk potHeaderChunk = new Chunk("Potemkin Page", FontFactory.GetFont("Arial Bold", 22));
                Chunk potFrameDataChunk = new Chunk(CharacterRepository.Retrieve.PotemkinFrameData(list), FontFactory.GetFont("Arial", 11));

                // Axl
                Chunk axlHeaderChunk = new Chunk("Axl Page", FontFactory.GetFont("Arial Bold", 22));
                Chunk axlFrameDataChunk = new Chunk(CharacterRepository.Retrieve.AxlFrameData(list), FontFactory.GetFont("Arial", 11));

                // Faust
                Chunk faustHeaderChunk = new Chunk("Faust Page", FontFactory.GetFont("Arial Bold", 22));
                Chunk faustFrameDataChunk = new Chunk(CharacterRepository.Retrieve.AxlFrameData(list), FontFactory.GetFont("Arial", 11));

                // Date
                DateTime date = DateTime.Now;
                Chunk creatorChunk = new Chunk($"Developer: Matthew Miller, Email: sysnom@gmail.com, Export Date: {date}",
                    FontFactory.GetFont("Arial", 11));

                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_CENTER, headerChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_CENTER, singleSpaceChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, solHeaderChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, solFrameDataChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, kyHeaderChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, kyFrameDataChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, mayHeaderChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, mayFrameDataChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, chippHeaderChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, chippFrameDataChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, potHeaderChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, potFrameDataChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, axlHeaderChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, axlFrameDataChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, faustHeaderChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_LEFT, faustFrameDataChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_RIGHT, creatorChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_CENTER, lineChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_CENTER, singleSpaceChunk);
                ParagraphFactory.Factory.CreateParagraph(doc, Element.ALIGN_CENTER, doubleSpaceChunk);

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