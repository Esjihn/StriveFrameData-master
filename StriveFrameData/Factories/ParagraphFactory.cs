using iTextSharp.text;
using System;

namespace StriveFrameData.Builder
{
    public class ParagraphFactory
    {
        /// <summary>
        /// Singleton Access
        /// </summary>
        public static ParagraphFactory Factory => new ParagraphFactory();

        public void CreateParagraph(Document doc, int alignment, Chunk chunk)
        {
            Paragraph paragraph = new Paragraph(chunk);
            paragraph.Alignment = alignment;
            doc.Add(paragraph);
        }
    }
}