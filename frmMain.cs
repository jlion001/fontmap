using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace jFont2
{
    public partial class frmMain : Form
    {
        private clsFont m_font = new clsFont();
        FormWindowState _lastWindowState = FormWindowState.Minimized;

        public frmMain()
        {
            InitializeComponent();

            try
            {
                this.Text = "jFont v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            catch
            {

            }

            llJlion.Links.Add(6, 4, "www.jlion.com");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbFontList.Items.Clear();
            foreach (string name in m_font.GetAllInstalledFontNames())
                cmbFontList.Items.Add(name);
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbFontList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontname = cmbFontList.SelectedItem.ToString();
            m_font.setSelectedFont(fontname);

            rdStyleUnderline.Enabled = false;
            rdStyleStrikeout.Enabled = false;
            rdStyleItalic.Enabled = false;
            rdStyleBold.Enabled = false;
            rdStyleRegular.Enabled = false;

            if (m_font.IsAvailableUnderline())
                rdStyleUnderline.Enabled = true;

            if (m_font.IsAvailableStrikeout())
                rdStyleStrikeout.Enabled = true;

            if (m_font.IsAvailableItalic())
                rdStyleItalic.Enabled = true;

            if (m_font.IsAvailableBold())
                rdStyleBold.Enabled = true;

            if (m_font.IsAvailableRegular())
                rdStyleRegular.Enabled = true;

            if (rdStyleRegular.Enabled)
                rdStyleRegular.Select();

            else if (rdStyleBold.Enabled)
                rdStyleBold.Select();

            else if (rdStyleItalic.Enabled)
                rdStyleItalic.Select();

            else if (rdStyleUnderline.Enabled)
                rdStyleUnderline.Select();

            else if (rdStyleStrikeout.Enabled)
                rdStyleStrikeout.Select();
        }

        private void setFont()
        {
            pictImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictImage.Image = m_font.MakeCharList(0);
            //pictImage.Image = m_font.MakeCharacterSample();
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void ResizeForm()
        {
            panPreview.Top = 28;
            panPreview.Left = 276;
            panPreview.Width = this.Width - 320;
            panPreview.Height = this.Height - 110;
        }

        private void rdStyleRegular_CheckedChanged(object sender, EventArgs e)
        {
            if (rdStyleRegular.Checked)
            {
                m_font.setSelectedStyle(FontStyle.Regular);
                setFont();
            }
        }

        private void rdStyleBold_CheckedChanged(object sender, EventArgs e)
        {
            if (rdStyleBold.Checked)
            {
                m_font.setSelectedStyle(FontStyle.Bold);
                setFont();
            }
        }

        private void rdStyleItalic_CheckedChanged(object sender, EventArgs e)
        {
            if (rdStyleItalic.Checked)
            {
                m_font.setSelectedStyle(FontStyle.Italic);
                setFont();
            }
        }

        private void rdStyleStrikeout_CheckedChanged(object sender, EventArgs e)
        {
            if (rdStyleStrikeout.Checked)
            {
                m_font.setSelectedStyle(FontStyle.Strikeout);
                setFont();
            }
        }

        private void rdStyleUnderline_CheckedChanged(object sender, EventArgs e)
        {
            if (rdStyleUnderline.Checked)
            {
                m_font.setSelectedStyle(FontStyle.Underline);
                setFont();
            }
        }

        private void SaveAsPDF()
        {
            saveFileDialog1.Title = "Save Font Map";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FileName = m_font.SelectedFontName() + " character set.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                clsPrintCharSet printer = new clsPrintCharSet();
                printer.SendToPDF(saveFileDialog1.FileName, m_font);
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            }
        }

        private void ExitApplication()
        {
            Application.Exit();
        }

        private void AboutApplication()
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            SaveAsPDF();
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            SaveAsPDF();
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void tsAbout_Click(object sender, EventArgs e)
        {
            AboutApplication();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutApplication();
        }

        private void llJlion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void rdANSI_CheckedChanged(object sender, EventArgs e)
        {
            m_font.SetSelectedFormat(clsFont.FormatStyle.ANSI);
            setFont();
        }

        private void rdHTML_CheckedChanged(object sender, EventArgs e)
        {
            m_font.SetSelectedFormat(clsFont.FormatStyle.ASCII);
            setFont();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            // When window state changes
            if (WindowState != _lastWindowState)
            {
                _lastWindowState = WindowState;
                if (WindowState == FormWindowState.Maximized)
                {
                    // Maximized!
                    ResizeForm();
                }
                if (WindowState == FormWindowState.Normal)
                {
                    // Restored!
                    ResizeForm();
                }
            }
        }

        private void cmdSaveUnicode_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save Unicode Char Set";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FileName = m_font.SelectedFontName() + " unicode character set.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                clsPrintUnicodeChars printer = new clsPrintUnicodeChars();
                printer.SendToPDF(saveFileDialog1.FileName, m_font);
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            }
        }
    }
}
