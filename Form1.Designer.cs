namespace p99_gina_creator
{
    partial class formMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.textBoxSpells = new System.Windows.Forms.TextBox();
            this.buttonScrape = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDelay = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxColors = new System.Windows.Forms.ComboBox();
            this.pictureBoxIcons = new System.Windows.Forms.PictureBox();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.progressBarSpellList = new System.Windows.Forms.ProgressBar();
            this.checkBoxUseTextToSpeech = new System.Windows.Forms.CheckBox();
            this.buttonFixColorsInXmlFile = new System.Windows.Forms.Button();
            this.pictureBoxAllIcons = new System.Windows.Forms.PictureBox();
            this.linkLabelProgressBar = new System.Windows.Forms.LinkLabel();
            this.radioButtonUseThemeColors = new System.Windows.Forms.RadioButton();
            this.radioButtonUseGinaDefaultColors = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllIcons)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSpells
            // 
            this.textBoxSpells.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSpells.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxSpells.Location = new System.Drawing.Point(219, 9);
            this.textBoxSpells.Multiline = true;
            this.textBoxSpells.Name = "textBoxSpells";
            this.textBoxSpells.Size = new System.Drawing.Size(254, 168);
            this.textBoxSpells.TabIndex = 0;
            this.textBoxSpells.Text = "Delete all text and input your\r\n(case sensitive) spell list, as\r\nillustrated belo" +
    "w.\r\n----------\r\nArch Shielding\r\nDivine Aura\r\nPillar of Frost\r\nStun\r\nMesmerize\r\nA" +
    "egolism\r\nFeign Death\r\nBane of Nife";
            this.textBoxSpells.TextChanged += new System.EventHandler(this.textBoxSpells_TextChanged);
            // 
            // buttonScrape
            // 
            this.buttonScrape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonScrape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScrape.Location = new System.Drawing.Point(25, 382);
            this.buttonScrape.Name = "buttonScrape";
            this.buttonScrape.Size = new System.Drawing.Size(138, 47);
            this.buttonScrape.TabIndex = 1;
            this.buttonScrape.Text = "Create Gina Trigger Import Files";
            this.buttonScrape.UseVisualStyleBackColor = true;
            this.buttonScrape.Click += new System.EventHandler(this.buttonScrape_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Help;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 72);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input spell list (case \r\nsensitive) for which \r\nyou wish to create GINA \r\ntrigger" +
    " .gtp import files.";
            this.toolTip1.SetToolTip(this.label1, "Add as many desired spells or NPC effects.\r\nSeperate each with a new line. Spell " +
        "names are\r\ncase sensitive as shown on the p99 wiki site.");
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(219, 219);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(66, 21);
            this.comboBoxLevel.TabIndex = 5;
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Help;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Delay (milliseconds)";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Help;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Character level";
            this.toolTip1.SetToolTip(this.label2, "Some spell durations are impacted by character level.");
            // 
            // comboBoxDelay
            // 
            this.comboBoxDelay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxDelay.FormattingEnabled = true;
            this.comboBoxDelay.Location = new System.Drawing.Point(219, 250);
            this.comboBoxDelay.Name = "comboBoxDelay";
            this.comboBoxDelay.Size = new System.Drawing.Size(66, 21);
            this.comboBoxDelay.TabIndex = 7;
            this.comboBoxDelay.SelectedIndexChanged += new System.EventHandler(this.comboBoxDelay_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Help;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 36);
            this.label4.TabIndex = 11;
            this.label4.Text = "Color themes based \r\non icons";
            this.toolTip1.SetToolTip(this.label4, "Casting bar colors and text colors displayed.\r\n");
            // 
            // comboBoxColors
            // 
            this.comboBoxColors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxColors.FormattingEnabled = true;
            this.comboBoxColors.Location = new System.Drawing.Point(219, 305);
            this.comboBoxColors.Name = "comboBoxColors";
            this.comboBoxColors.Size = new System.Drawing.Size(53, 21);
            this.comboBoxColors.TabIndex = 8;
            this.comboBoxColors.SelectedIndexChanged += new System.EventHandler(this.comboBoxColors_SelectedIndexChanged);
            // 
            // pictureBoxIcons
            // 
            this.pictureBoxIcons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxIcons.Location = new System.Drawing.Point(278, 305);
            this.pictureBoxIcons.Name = "pictureBoxIcons";
            this.pictureBoxIcons.Size = new System.Drawing.Size(43, 42);
            this.pictureBoxIcons.TabIndex = 9;
            this.pictureBoxIcons.TabStop = false;
            this.pictureBoxIcons.Click += new System.EventHandler(this.pictureBoxIcons_Click_1);
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxColor.Location = new System.Drawing.Point(327, 305);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(43, 42);
            this.pictureBoxColor.TabIndex = 10;
            this.pictureBoxColor.TabStop = false;
            this.pictureBoxColor.Click += new System.EventHandler(this.pictureBoxColor_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // progressBarSpellList
            // 
            this.progressBarSpellList.Location = new System.Drawing.Point(24, 613);
            this.progressBarSpellList.Name = "progressBarSpellList";
            this.progressBarSpellList.Size = new System.Drawing.Size(328, 23);
            this.progressBarSpellList.TabIndex = 12;
            this.progressBarSpellList.Click += new System.EventHandler(this.progressBarSpellList_Click);
            // 
            // checkBoxUseTextToSpeech
            // 
            this.checkBoxUseTextToSpeech.AutoSize = true;
            this.checkBoxUseTextToSpeech.Checked = true;
            this.checkBoxUseTextToSpeech.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseTextToSpeech.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxUseTextToSpeech.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUseTextToSpeech.Location = new System.Drawing.Point(219, 277);
            this.checkBoxUseTextToSpeech.Name = "checkBoxUseTextToSpeech";
            this.checkBoxUseTextToSpeech.Size = new System.Drawing.Size(254, 22);
            this.checkBoxUseTextToSpeech.TabIndex = 14;
            this.checkBoxUseTextToSpeech.Text = "Text To Speech enabled in triggers";
            this.checkBoxUseTextToSpeech.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxUseTextToSpeech.UseVisualStyleBackColor = true;
            this.checkBoxUseTextToSpeech.CheckedChanged += new System.EventHandler(this.checkBoxUseTextToSpeech_CheckedChanged);
            // 
            // buttonFixColorsInXmlFile
            // 
            this.buttonFixColorsInXmlFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFixColorsInXmlFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFixColorsInXmlFile.Location = new System.Drawing.Point(24, 703);
            this.buttonFixColorsInXmlFile.Name = "buttonFixColorsInXmlFile";
            this.buttonFixColorsInXmlFile.Size = new System.Drawing.Size(139, 47);
            this.buttonFixColorsInXmlFile.TabIndex = 15;
            this.buttonFixColorsInXmlFile.Text = "Update GINA \r\nCategory Colors";
            this.buttonFixColorsInXmlFile.UseVisualStyleBackColor = true;
            this.buttonFixColorsInXmlFile.Click += new System.EventHandler(this.buttonFixColorsInXmlFile_Click_1);
            // 
            // pictureBoxAllIcons
            // 
            this.pictureBoxAllIcons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAllIcons.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxAllIcons.InitialImage")));
            this.pictureBoxAllIcons.Location = new System.Drawing.Point(384, 190);
            this.pictureBoxAllIcons.Name = "pictureBoxAllIcons";
            this.pictureBoxAllIcons.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxAllIcons.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxAllIcons.TabIndex = 16;
            this.pictureBoxAllIcons.TabStop = false;
            this.pictureBoxAllIcons.Visible = false;
            this.pictureBoxAllIcons.Click += new System.EventHandler(this.pictureBoxAllIcons_Click_1);
            // 
            // linkLabelProgressBar
            // 
            this.linkLabelProgressBar.AutoSize = true;
            this.linkLabelProgressBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelProgressBar.Location = new System.Drawing.Point(21, 578);
            this.linkLabelProgressBar.Name = "linkLabelProgressBar";
            this.linkLabelProgressBar.Size = new System.Drawing.Size(63, 16);
            this.linkLabelProgressBar.TabIndex = 17;
            this.linkLabelProgressBar.TabStop = true;
            this.linkLabelProgressBar.Text = "Progress";
            this.linkLabelProgressBar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelProgressBar_LinkClicked_1);
            // 
            // radioButtonUseThemeColors
            // 
            this.radioButtonUseThemeColors.AutoSize = true;
            this.radioButtonUseThemeColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonUseThemeColors.Location = new System.Drawing.Point(174, 691);
            this.radioButtonUseThemeColors.Name = "radioButtonUseThemeColors";
            this.radioButtonUseThemeColors.Size = new System.Drawing.Size(302, 40);
            this.radioButtonUseThemeColors.TabIndex = 18;
            this.radioButtonUseThemeColors.TabStop = true;
            this.radioButtonUseThemeColors.Text = "Use theme colors generated by this\r\napplication which are based on spell icons";
            this.radioButtonUseThemeColors.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseGinaDefaultColors
            // 
            this.radioButtonUseGinaDefaultColors.AutoSize = true;
            this.radioButtonUseGinaDefaultColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonUseGinaDefaultColors.Location = new System.Drawing.Point(174, 733);
            this.radioButtonUseGinaDefaultColors.Name = "radioButtonUseGinaDefaultColors";
            this.radioButtonUseGinaDefaultColors.Size = new System.Drawing.Size(223, 40);
            this.radioButtonUseGinaDefaultColors.TabIndex = 19;
            this.radioButtonUseGinaDefaultColors.TabStop = true;
            this.radioButtonUseGinaDefaultColors.Text = "Use GINAs default colors\r\n(yellow / maroon for all spells)";
            this.radioButtonUseGinaDefaultColors.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(0, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "1.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(1, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "2.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Update desired settings below";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(1, 359);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "3.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "Click to create trigger files";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(392, 54);
            this.label10.TabIndex = 26;
            this.label10.Text = "Open GINA. Create 4 new TIMER Overlays if they dont\r\nalready exist. Name them exa" +
    "ctly as below (all uppercase).\r\nCASTING   SELF   OTHER   and   OTHERDETRIMENTAL\r" +
    "\n";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(1, 432);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 18);
            this.label11.TabIndex = 25;
            this.label11.Text = "4.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(22, 495);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(461, 72);
            this.label12.TabIndex = 28;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(1, 497);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 18);
            this.label13.TabIndex = 27;
            this.label13.Text = "5.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(0, 645);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 18);
            this.label14.TabIndex = 29;
            this.label14.Text = "6.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Cursor = System.Windows.Forms.Cursors.Default;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(22, 645);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(449, 36);
            this.label15.TabIndex = 30;
            this.label15.Text = "Close GINA. Click below to resolve GINA Category colors with this \r\napp\'s theme c" +
    "olors, or to set to default GINA colors.";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 791);
            this.Controls.Add(this.pictureBoxAllIcons);
            this.Controls.Add(this.pictureBoxIcons);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxSpells);
            this.Controls.Add(this.radioButtonUseGinaDefaultColors);
            this.Controls.Add(this.radioButtonUseThemeColors);
            this.Controls.Add(this.linkLabelProgressBar);
            this.Controls.Add(this.buttonFixColorsInXmlFile);
            this.Controls.Add(this.checkBoxUseTextToSpeech);
            this.Controls.Add(this.progressBarSpellList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBoxColor);
            this.Controls.Add(this.comboBoxColors);
            this.Controls.Add(this.comboBoxDelay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonScrape);
            this.Controls.Add(this.label5);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "p99 GINA Trigger Creator";
            this.toolTip1.SetToolTip(this, "Some spells duration scales based on character level.");
            this.Load += new System.EventHandler(this.formMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllIcons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSpells;
        private System.Windows.Forms.Button buttonScrape;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDelay;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBoxColors;
        private System.Windows.Forms.PictureBox pictureBoxIcons;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ProgressBar progressBarSpellList;
        private System.Windows.Forms.CheckBox checkBoxUseTextToSpeech;
        private System.Windows.Forms.Button buttonFixColorsInXmlFile;
        private System.Windows.Forms.PictureBox pictureBoxAllIcons;
        private System.Windows.Forms.LinkLabel linkLabelProgressBar;
        private System.Windows.Forms.RadioButton radioButtonUseThemeColors;
        private System.Windows.Forms.RadioButton radioButtonUseGinaDefaultColors;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}

