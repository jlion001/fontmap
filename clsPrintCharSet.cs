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
    public class clsPrintCharSet
    {
        public void SendToPDF(string filename, clsFont jfont)
        {
            //New document, 8.5"x11" in landscape orientation.
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.LETTER.Rotate());

            //add metadata
            doc.AddTitle("Font preview for font " + jfont.SelectedFontName());
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

            for(int currentPage=0;currentPage<jfont.CountOfPages();currentPage++)
            {
                //convert image to a pdf image for inclusion in the doc
                System.Drawing.Image jfontimage = jfont.MakeCharList(currentPage);
                //System.Drawing.Image jfontimage = jfont.MakeCharacterSample();
                iTextSharp.text.Image convertedimage = iTextSharp.text.Image.GetInstance(jfontimage, System.Drawing.Imaging.ImageFormat.Bmp);

                //determine size to scale to. PDF is 72 dpi, so 1 point is 1/72.
                System.Drawing.Rectangle PDFImageSize = jfont.ImageSize(72);

                convertedimage.ScaleAbsolute(PDFImageSize.Width, PDFImageSize.Height);

                //Add some blank space at the top of the document
                doc.Add(new Paragraph("Font: " + jfont.SelectedFontName()));
                doc.Add(new Paragraph("Style: " + jfont.SelectedFontStyle()));
                doc.Add(new Paragraph(""));
                doc.Add(new Paragraph(""));
                doc.Add(convertedimage);

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
