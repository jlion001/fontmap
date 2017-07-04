using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace jFont2
{
    public class clsFont
    {
        const int RESOLUTION = 300;

        const decimal PAGE_WIDTH = 11.0m;
        const decimal PAGE_HEIGHT = 8.5m;

        const decimal LEFT_MARGIN = 0.5m;  //inch
        const decimal RIGHT_MARGIN = 0.5m;
        const decimal TOP_MARGIN = 1;
        const decimal BOTTOM_MARGIN = 1;

        public enum FormatStyle
        {
            undefined,
            ANSI,
            ASCII
        }

        private FontFamily m_selectedFont = null;
        private FontStyle m_selectedStyle = FontStyle.Regular;
        private FormatStyle m_selectedFormat = FormatStyle.ANSI;

        public clsFont()
        {
            
        }

        public int CountOfPages()
        {
            double pageCount = 1;   //TODO: Determine how many pages to print.
            //double pageCount=Convert.ToDouble(_unicodeCharList.CharCodes.Count / 256);
            return Convert.ToInt16(Math.Ceiling(pageCount));
        }

        public void setSelectedFont(string fontname)
        {
            m_selectedFont = new FontFamily(fontname);
        }

        public string SelectedFontName()
        {
            return m_selectedFont.Name;
        }

        public void setSelectedStyle(FontStyle s)
        {
            m_selectedStyle = s;
        }

        public string SelectedFontStyle()
        {
            return m_selectedStyle.ToString();
        }

        public void SetSelectedFormat(FormatStyle format)
        {
            m_selectedFormat = format;
        }

        public bool IsAvailableBold()
        {
            return m_selectedFont.IsStyleAvailable(FontStyle.Bold);
        }

        public bool IsAvailableItalic()
        {
            return m_selectedFont.IsStyleAvailable(FontStyle.Italic);
        }

        public bool IsAvailableRegular()
        {
            return m_selectedFont.IsStyleAvailable(FontStyle.Regular);
        }

        public bool IsAvailableStrikeout()
        {
            return m_selectedFont.IsStyleAvailable(FontStyle.Strikeout);
        }

        public bool IsAvailableUnderline()
        {
            return m_selectedFont.IsStyleAvailable(FontStyle.Underline);
        }


        public List<string> GetAllInstalledFontNames()
        {
            List<string> retVal = new List<string>();

            System.Drawing.Text.InstalledFontCollection oInstalledFontCollection = new System.Drawing.Text.InstalledFontCollection();
            foreach (System.Drawing.FontFamily oFontFamily in oInstalledFontCollection.Families)
                retVal.Add(oFontFamily.Name);

            return retVal;
        }

        #region "CharList"
        public Bitmap MakeCharList(int page)
        {
            const int COLUMN_COUNT = 8;
            const int ROW_COUNT = 32;
            const decimal MARGIN_PERCENT = 0.10m;

            //we want the image to be about half a page. 
            //a page is 8.5" x 11" so our half-page will be 8.5" by 5.5"
            //in DPI this is 8.5*72 by 5.5*72 or 612 x 396

            Rectangle pagesize = ImageSize(RESOLUTION);

            //column margin area is percent of page
            int margin = (int)(MARGIN_PERCENT * pagesize.Width) / (COLUMN_COUNT-1);
            int colwidth = (pagesize.Width - (COLUMN_COUNT - 1) * margin) / COLUMN_COUNT;
            int cellheight = pagesize.Height / ROW_COUNT;

            //working image
            Bitmap fontimage = new Bitmap(pagesize.Width, pagesize.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            try
            {
                Graphics g = Graphics.FromImage(fontimage);

                //initialize to white
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pagesize.Width, pagesize.Height));

                //frame around outside
                //g.DrawRectangle(Pens.Black, new Rectangle(1, 1, pagesize.Width - 2, pagesize.Height - 2));               
               
                //we're going to show all 255 characters of the font. that's 85 characters in each of the three columns
                int hpos = 0;
                int startingCharCode = (page * 256) + 1 ;
                int curPageCharIndex = 0;

                for (int col = 0; col < COLUMN_COUNT; col++)
                {
                    //calculate left position of column
                    hpos = hpos + (col==0?0:colwidth);

                    //add margin
                    hpos = hpos + ((col >0 && col < COLUMN_COUNT) ? margin : 0);

                    for (int row = 0; row < ROW_COUNT; row++)
                    {
                        int vpos = cellheight * row;

                        Rectangle r = new Rectangle(new Point(hpos, vpos), new Size(colwidth, cellheight));
                        g.DrawRectangle(new Pen(Color.Black), r);

                        //into each rectangle goes a character block
                        int charToDisplay = startingCharCode + curPageCharIndex;

                        if (m_selectedFormat==FormatStyle.ASCII)
                            DrawASCIICharacterBlock(ref g, r, charToDisplay, m_selectedFont.Name, m_selectedStyle);
                        else if (m_selectedFormat==FormatStyle.ANSI)
                            DrawANSICharacterBlock(ref g, r, charToDisplay, m_selectedFont.Name, m_selectedStyle);

                        curPageCharIndex++;

                        if (curPageCharIndex > 256) break;
                    }

                    if (curPageCharIndex > 256) break;
                }
            } catch (Exception ex)
            {
                throw;
            }
          
            return fontimage;
        }

        private void DrawANSICharacterBlock(ref Graphics g, Rectangle r, int charCode, string fontname,FontStyle s)
        {
            //each character block is divided into three parts:
            //1) The decimal ASCII code for the character
            //2) The ASCII character as displayed in courior
            //3) The ASCII character as displayed in the designated font.
            const int BLOCK_MARGIN = 5;
            const int FONT_MARGIN = 5;

            const int FONT_SIZE = 24;

            int width = r.Width /8;

            int p1 = r.Left;
            int p2 = (width * 4) + r.Left;
            int p3 = (width * 6) + r.Left;

            g.DrawLine(Pens.Black, new Point(p2, r.Top),new Point(p2, r.Top + r.Height));
            g.DrawLine(Pens.Black, new Point(p3, r.Top), new Point(p3, r.Top + r.Height));

            string unicodeCharString = char.ConvertFromUtf32(charCode).ToString();

            byte[] srcChar = Encoding.UTF32.GetBytes(unicodeCharString);

            Encoding enc = Encoding.GetEncoding(1252);  //ANSI encoding
            string charString = enc.GetString(srcChar);

            int maxStringLength = 3;
            if (charCode > 9999)
                maxStringLength = 5;
            else if (charCode > 999)
                maxStringLength = 4;

            if (charCode < 256)
                DrawText(
                    ref g,
                    p1 + BLOCK_MARGIN, r.Top - FONT_MARGIN,
                    "Alt+0" + new string('0', maxStringLength - charCode.ToString().Length) + charCode.ToString(),
                    "Courier New",
                    FONT_SIZE);

            DrawText(
                ref g, 
                p2 + BLOCK_MARGIN*5, r.Top - FONT_MARGIN,
                charString,
                "Courier New",
                FONT_SIZE);

            DrawText(
                ref g,
                p3 + BLOCK_MARGIN*5, r.Top - FONT_MARGIN,
                charString,
                fontname,
                FONT_SIZE,
                s);
        }

        private void DrawASCIICharacterBlock(ref Graphics g, Rectangle r, int charCode, string fontname, FontStyle s)
        {
            //each character block is divided into three parts:
            //1) The decimal ASCII code for the character
            //2) The ASCII character as displayed in courior
            //3) The ASCII character as displayed in the designated font.
            const int BLOCK_MARGIN = 5;
            const int FONT_MARGIN = 5;

            const int FONT_SIZE = 24;

            int width = r.Width / 8;

            int p1 = r.Left;
            int p2 = (width * 4) + r.Left;
            int p3 = (width * 6) + r.Left;

            g.DrawLine(Pens.Black, new Point(p2, r.Top), new Point(p2, r.Top + r.Height));
            g.DrawLine(Pens.Black, new Point(p3, r.Top), new Point(p3, r.Top + r.Height));

            string charString = char.ConvertFromUtf32(charCode).ToString();

            DrawText(
                ref g,
                p1 + BLOCK_MARGIN, r.Top - FONT_MARGIN,
                "&#" + charCode.ToString() + ";",
                "Courier New",
                FONT_SIZE);

            DrawText(
                ref g,
                p2 + BLOCK_MARGIN * 5, r.Top - FONT_MARGIN,
                charString,
                "Courier New",
                FONT_SIZE);

            DrawText(
                ref g,
                p3 + BLOCK_MARGIN * 5, r.Top - FONT_MARGIN,
                charString,
                fontname,
                FONT_SIZE,
                s);
        }
        #endregion

        #region "CharSample"
        public Bitmap MakeCharacterSample()
        {
            string sampletext = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            //we want the image to be about half a page. 
            //a page is 8.5" x 11" so our half-page will be 8.5" by 5.5"
            //in DPI this is 8.5*72 by 5.5*72 or 612 x 396

            Rectangle pagesize = ImageSize(RESOLUTION);

            //working image
            Bitmap fontimage = new Bitmap(pagesize.Width, pagesize.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            string fontname = m_selectedFont.Name;

            try
            {
                Graphics g = Graphics.FromImage(fontimage);

                //initialize to white
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pagesize.Width, pagesize.Height));

                int ypos = 0;

                int fontsize = 12;
                FontFamily ff = new FontFamily(fontname);

                while (fontsize < 128)
                {
                    Font f = new Font(fontname, fontsize, m_selectedStyle);
                    SizeF stringsize = g.MeasureString(sampletext, f);
                                
                    DrawText(
                        ref g,
                        pagesize.Left, pagesize.Top + ypos,
                        "font size: " + fontsize.ToString() + " pt",
                        "Courier New",
                        12);

                    ypos = ypos + 30;

                    g.DrawString(
                        sampletext,
                        f,
                        new SolidBrush(Color.Black),
                        pagesize.Left,
                        pagesize.Top + ypos,
                        System.Drawing.StringFormat.GenericTypographic);

                    ypos = ypos + (int)stringsize.Height;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    fontsize = fontsize + 6;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return fontimage;
        }

        #endregion

        private void DrawText(ref Graphics g, int left, int top, string text, string fontname, int fontsize, FontStyle s=FontStyle.Regular)
        {
            FontFamily ff = new FontFamily(fontname);

            Font f = new Font(fontname, fontsize, s);
            SizeF stringsize = g.MeasureString(text, f);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            g.DrawString(
                text,
                f,
                new SolidBrush(Color.Black),
                left,
                top + (int)stringsize.Height/2,
                System.Drawing.StringFormat.GenericTypographic);
        }

        public Rectangle ImageSize(int resolution)
        {
            Rectangle retVal;

            decimal width = (PAGE_WIDTH - (LEFT_MARGIN + RIGHT_MARGIN)) * resolution;
            decimal height = (PAGE_HEIGHT - (TOP_MARGIN + BOTTOM_MARGIN)) * resolution;

            retVal = new Rectangle(0, 0, (int)width, (int)height);

            return retVal;
        }

    }
}
