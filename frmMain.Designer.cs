namespace jFont2
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFontList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdStyleUnderline = new System.Windows.Forms.RadioButton();
            this.rdStyleStrikeout = new System.Windows.Forms.RadioButton();
            this.rdStyleRegular = new System.Windows.Forms.RadioButton();
            this.rdStyleItalic = new System.Windows.Forms.RadioButton();
            this.rdStyleBold = new System.Windows.Forms.RadioButton();
            this.panPreview = new System.Windows.Forms.Panel();
            this.pictImage = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsAbout = new System.Windows.Forms.ToolStripButton();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.llJlion = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdANSI = new System.Windows.Forms.RadioButton();
            this.rdHTML = new System.Windows.Forms.RadioButton();
            this.cmdSaveUnicode = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictImage)).BeginInit();
            this.tsToolbar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Font:";
            // 
            // cmbFontList
            // 
            this.cmbFontList.FormattingEnabled = true;
            this.cmbFontList.Location = new System.Drawing.Point(21, 63);
            this.cmbFontList.Name = "cmbFontList";
            this.cmbFontList.Size = new System.Drawing.Size(186, 21);
            this.cmbFontList.TabIndex = 3;
            this.cmbFontList.SelectedIndexChanged += new System.EventHandler(this.cmbFontList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdStyleUnderline);
            this.groupBox1.Controls.Add(this.rdStyleStrikeout);
            this.groupBox1.Controls.Add(this.rdStyleRegular);
            this.groupBox1.Controls.Add(this.rdStyleItalic);
            this.groupBox1.Controls.Add(this.rdStyleBold);
            this.groupBox1.Location = new System.Drawing.Point(15, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 147);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Style";
            // 
            // rdStyleUnderline
            // 
            this.rdStyleUnderline.AutoSize = true;
            this.rdStyleUnderline.Location = new System.Drawing.Point(31, 111);
            this.rdStyleUnderline.Name = "rdStyleUnderline";
            this.rdStyleUnderline.Size = new System.Drawing.Size(70, 17);
            this.rdStyleUnderline.TabIndex = 4;
            this.rdStyleUnderline.TabStop = true;
            this.rdStyleUnderline.Text = "Underline";
            this.rdStyleUnderline.UseVisualStyleBackColor = true;
            this.rdStyleUnderline.CheckedChanged += new System.EventHandler(this.rdStyleUnderline_CheckedChanged);
            // 
            // rdStyleStrikeout
            // 
            this.rdStyleStrikeout.AutoSize = true;
            this.rdStyleStrikeout.Location = new System.Drawing.Point(31, 88);
            this.rdStyleStrikeout.Name = "rdStyleStrikeout";
            this.rdStyleStrikeout.Size = new System.Drawing.Size(67, 17);
            this.rdStyleStrikeout.TabIndex = 3;
            this.rdStyleStrikeout.TabStop = true;
            this.rdStyleStrikeout.Text = "Strikeout";
            this.rdStyleStrikeout.UseVisualStyleBackColor = true;
            this.rdStyleStrikeout.CheckedChanged += new System.EventHandler(this.rdStyleStrikeout_CheckedChanged);
            // 
            // rdStyleRegular
            // 
            this.rdStyleRegular.AutoSize = true;
            this.rdStyleRegular.Location = new System.Drawing.Point(30, 19);
            this.rdStyleRegular.Name = "rdStyleRegular";
            this.rdStyleRegular.Size = new System.Drawing.Size(62, 17);
            this.rdStyleRegular.TabIndex = 2;
            this.rdStyleRegular.TabStop = true;
            this.rdStyleRegular.Text = "Regular";
            this.rdStyleRegular.UseVisualStyleBackColor = true;
            this.rdStyleRegular.CheckedChanged += new System.EventHandler(this.rdStyleRegular_CheckedChanged);
            // 
            // rdStyleItalic
            // 
            this.rdStyleItalic.AutoSize = true;
            this.rdStyleItalic.Location = new System.Drawing.Point(30, 65);
            this.rdStyleItalic.Name = "rdStyleItalic";
            this.rdStyleItalic.Size = new System.Drawing.Size(47, 17);
            this.rdStyleItalic.TabIndex = 1;
            this.rdStyleItalic.TabStop = true;
            this.rdStyleItalic.Text = "Italic";
            this.rdStyleItalic.UseVisualStyleBackColor = true;
            this.rdStyleItalic.CheckedChanged += new System.EventHandler(this.rdStyleItalic_CheckedChanged);
            // 
            // rdStyleBold
            // 
            this.rdStyleBold.AutoSize = true;
            this.rdStyleBold.Location = new System.Drawing.Point(30, 42);
            this.rdStyleBold.Name = "rdStyleBold";
            this.rdStyleBold.Size = new System.Drawing.Size(46, 17);
            this.rdStyleBold.TabIndex = 0;
            this.rdStyleBold.TabStop = true;
            this.rdStyleBold.Text = "Bold";
            this.rdStyleBold.UseVisualStyleBackColor = true;
            this.rdStyleBold.CheckedChanged += new System.EventHandler(this.rdStyleBold_CheckedChanged);
            // 
            // panPreview
            // 
            this.panPreview.AutoScroll = true;
            this.panPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panPreview.Controls.Add(this.pictImage);
            this.panPreview.Location = new System.Drawing.Point(278, 28);
            this.panPreview.Name = "panPreview";
            this.panPreview.Size = new System.Drawing.Size(541, 298);
            this.panPreview.TabIndex = 6;
            // 
            // pictImage
            // 
            this.pictImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictImage.Location = new System.Drawing.Point(-1, -1);
            this.pictImage.Name = "pictImage";
            this.pictImage.Size = new System.Drawing.Size(553, 5000);
            this.pictImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictImage.TabIndex = 6;
            this.pictImage.TabStop = false;
            // 
            // tsToolbar
            // 
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSave,
            this.tsAbout,
            this.tsExit});
            this.tsToolbar.Location = new System.Drawing.Point(0, 0);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsToolbar.Size = new System.Drawing.Size(843, 25);
            this.tsToolbar.TabIndex = 8;
            this.tsToolbar.Text = "toolStrip1";
            // 
            // tsSave
            // 
            this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(51, 22);
            this.tsSave.Text = "&Save";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // tsAbout
            // 
            this.tsAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsAbout.Image")));
            this.tsAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAbout.Name = "tsAbout";
            this.tsAbout.Size = new System.Drawing.Size(60, 22);
            this.tsAbout.Text = "&About";
            this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
            // 
            // tsExit
            // 
            this.tsExit.Image = ((System.Drawing.Image)(resources.GetObject("tsExit.Image")));
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(45, 22);
            this.tsExit.Text = "E&xit";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 355);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(843, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // llJlion
            // 
            this.llJlion.AutoSize = true;
            this.llJlion.Location = new System.Drawing.Point(12, 320);
            this.llJlion.Name = "llJlion";
            this.llJlion.Size = new System.Drawing.Size(75, 13);
            this.llJlion.TabIndex = 10;
            this.llJlion.TabStop = true;
            this.llJlion.Text = "www.jlion.com";
            this.llJlion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llJlion_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdANSI);
            this.groupBox2.Controls.Add(this.rdHTML);
            this.groupBox2.Location = new System.Drawing.Point(21, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 67);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Format";
            // 
            // rdANSI
            // 
            this.rdANSI.AutoSize = true;
            this.rdANSI.Checked = true;
            this.rdANSI.Location = new System.Drawing.Point(24, 19);
            this.rdANSI.Name = "rdANSI";
            this.rdANSI.Size = new System.Drawing.Size(91, 17);
            this.rdANSI.TabIndex = 4;
            this.rdANSI.TabStop = true;
            this.rdANSI.Text = "Keyboard (Alt)";
            this.rdANSI.UseVisualStyleBackColor = true;
            this.rdANSI.CheckedChanged += new System.EventHandler(this.rdANSI_CheckedChanged);
            // 
            // rdHTML
            // 
            this.rdHTML.AutoSize = true;
            this.rdHTML.Location = new System.Drawing.Point(24, 42);
            this.rdHTML.Name = "rdHTML";
            this.rdHTML.Size = new System.Drawing.Size(89, 17);
            this.rdHTML.TabIndex = 3;
            this.rdHTML.Text = "HTML (&#xxx;)";
            this.rdHTML.UseVisualStyleBackColor = true;
            this.rdHTML.CheckedChanged += new System.EventHandler(this.rdHTML_CheckedChanged);
            // 
            // cmdSaveUnicode
            // 
            this.cmdSaveUnicode.Location = new System.Drawing.Point(128, 320);
            this.cmdSaveUnicode.Name = "cmdSaveUnicode";
            this.cmdSaveUnicode.Size = new System.Drawing.Size(109, 23);
            this.cmdSaveUnicode.TabIndex = 12;
            this.cmdSaveUnicode.Text = "Unicode Char Set";
            this.cmdSaveUnicode.UseVisualStyleBackColor = true;
            this.cmdSaveUnicode.Click += new System.EventHandler(this.cmdSaveUnicode_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 377);
            this.Controls.Add(this.cmdSaveUnicode);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.llJlion);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsToolbar);
            this.Controls.Add(this.panPreview);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbFontList);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "jFont2";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panPreview.ResumeLayout(false);
            this.panPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictImage)).EndInit();
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFontList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdStyleStrikeout;
        private System.Windows.Forms.RadioButton rdStyleRegular;
        private System.Windows.Forms.RadioButton rdStyleItalic;
        private System.Windows.Forms.RadioButton rdStyleBold;
        private System.Windows.Forms.RadioButton rdStyleUnderline;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.PictureBox pictImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsAbout;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.LinkLabel llJlion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdANSI;
        private System.Windows.Forms.RadioButton rdHTML;
        private System.Windows.Forms.Button cmdSaveUnicode;
    }
}

