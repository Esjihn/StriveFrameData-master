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
            Paragraph paragraph = new Paragraph
            {
                alignment
            };

            paragraph.Add(chunk);
            doc.Add(paragraph);
        }
    }
}