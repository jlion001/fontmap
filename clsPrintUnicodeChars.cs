using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace jFont2
{
    public class clsPrintUnicodeChars
    {
        private const int LINES_PER_PAGE = 23;

        private UnicodeCharList _unicodeCharList = null;

        public clsPrintUnicodeChars()
        {
            _unicodeCharList=new UnicodeCharList();
        }

        public void SendToPDF(string filename, clsFont jfont)
        {
            int countOfPages = _unicodeCharList.CharCodes.Count() / LINES_PER_PAGE; //fifty lines per page.

            //New document, 8.5"x11" in landscape orientation.
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.LETTER);

            //add metadata
            doc.AddTitle("Unicode Character Set for font " + jfont.SelectedFontName());
            doc.AddSubject("font family " + jfont.SelectedFontName());
            doc.AddAuthor("JLION.COM jFONT font preview utility");
            doc.AddCreationDate();

            //create a pdfwriter
            iTextSharp.text.pdf.PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));

            //trap events
            PDFPageEvent pdfevent = new PDFPageEvent();
            writer.PageEvent = pdfevent;

            //create the doc
            doc.Open();
            doc.SetMargins(.75f*72,.75f*72,0,0);

            //Create our base font
            string FontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
            BaseFont baseFont = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font x = FontFactory.GetFont(jfont.SelectedFontName());

            for (int currentPage=0;currentPage< countOfPages; currentPage++)
            {
                PdfPTable table = new PdfPTable(5);
                table.AddCell("Char");
                table.AddCell("Dec");
                table.AddCell("Hex");
                table.AddCell("Desc");
                table.AddCell("AltDesc");

                //convert image to a pdf image for inclusion in the doc
                for (int curChar=currentPage*LINES_PER_PAGE; curChar < (currentPage*LINES_PER_PAGE+LINES_PER_PAGE); curChar++)
                {
                    UnicodeCharList.CharEntry oneEntry = _unicodeCharList.CharCodes[curChar];
                    string charString = char.ConvertFromUtf32(Convert.ToInt32(oneEntry.CodeDec)).ToString();

                    Phrase codedChar=new Phrase(charString, x);
                    table.AddCell(codedChar);
                    table.AddCell(oneEntry.CodeDec);
                    table.AddCell(oneEntry.CodeHex);
                    table.AddCell(oneEntry.Desc);
                    table.AddCell(oneEntry.AltDesc);
                }

                doc.Add(table);

                doc.NewPage();
            }

            doc.Close();
        }

        public class PDFPageEvent: IPdfPageEvent
        {
            private PdfTemplate m_template;
            private PdfContentByte m_cb;
            private BaseFont m_bf;

            public PDFPageEvent():base()
            {
              
            }

            void IPdfPageEvent.OnOpenDocument(PdfWriter writer, Document document)
            {
                try
                {
                    m_bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    m_cb = writer.DirectContent;
                    m_template = m_cb.CreateTemplate(50, 50);
                }
                catch (DocumentException) { }
                catch (IOException) { }
            }

            void IPdfPageEvent.OnStartPage(PdfWriter writer, Document document)
            {

            }

            void IPdfPageEvent.OnEndPage(PdfWriter writer, Document document)
            {
                setHeader(writer, document);
                setFooter(writer, document);
            }

            void IPdfPageEvent.OnCloseDocument(PdfWriter writer, Document document)
            {
                m_template.BeginText();
                m_template.SetFontAndSize(m_bf, 8);
                m_template.ShowText((writer.PageNumber - 1).ToString());
                m_template.EndText();
            }

            void IPdfPageEvent.OnParagraph(PdfWriter writer, Document document, float paragraphPosition)
            {
            }

            void IPdfPageEvent.OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition)
            {

            }

            void IPdfPageEvent.OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title)
            {

            }

            void IPdfPageEvent.OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition)
            {

            }

            void IPdfPageEvent.OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title)
            {

            }

            void IPdfPageEvent.OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition)
            {

            }

            void IPdfPageEvent.OnGenericTag(PdfWriter writer, Document document, iTextSharp.text.Rectangle rect, string text)
            {

            }

            private void setHeader(PdfWriter writer, iTextSharp.text.Document doc)
            {

            }

            private void setFooter(PdfWriter writer, iTextSharp.text.Document doc)
            {
                //three columns at bottom of page
                string text;
                Single flen;

                //column 1 - disclaimer
                text = "Created by jFont";
                flen = m_bf.GetWidthPoint(text, 8);

                m_cb.BeginText();
                m_cb.SetFontAndSize(m_bf, 8);
                m_cb.SetTextMatrix(30, 20);
                m_cb.ShowText(text);
                m_cb.EndText();

                //column 2 - date/time
                text = DateTime.Now.ToString();
                flen = m_bf.GetWidthPoint(text, 8);

                m_cb.BeginText();
                m_cb.SetFontAndSize(m_bf, 8);
                m_cb.SetTextMatrix(doc.PageSize.Width/2-flen/2,20);
                m_cb.ShowText(text);
                m_cb.EndText();

                //column 3 - URL
                text = "http://jFont.jlion.com";
                flen = m_bf.GetWidthPoint(text, 8);

                m_cb.BeginText();
                m_cb.SetFontAndSize(m_bf, 8);
                m_cb.SetTextMatrix(doc.PageSize.Width - 230, 20);
                m_cb.ShowText(text);
                m_cb.EndText();
            }
        }
    }
}
