using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;

namespace StriveFrameData.Factories
{
    public class ParagraphFactory
    {
        /// <summary>
        /// Singleton Access
        /// </summary>
        public static ParagraphFactory Factory => new ParagraphFactory();

        public void CreateParagraph(Document doc, int alignment, Chunk chunk)
        {
            Paragraph paragraph = new Paragraph(chunk) {Alignment = alignment};
            doc.Add(paragraph);
        }
    }
}
