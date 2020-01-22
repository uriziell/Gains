namespace Gains
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.NumberOfGains = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SizeX = new System.Windows.Forms.TextBox();
            this.SizeY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GenerateSpace = new System.Windows.Forms.Button();
            this.AddGains = new System.Windows.Forms.Button();
            this.NumberOfInclusions = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AddInclusions = new System.Windows.Forms.Button();
            this.InclusionType = new System.Windows.Forms.ComboBox();
            this.InclusionSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AddInclusionsAfterSimulation = new System.Windows.Forms.Button();
            this.NeighberhoodType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Probability = new System.Windows.Forms.TextBox();
            this.CleanUp = new System.Windows.Forms.Button();
            this.SetBou = new System.Windows.Forms.Button();
            this.CleanUpWitoutBoundaries = new System.Windows.Forms.Button();
            this.MicrostructureType = new System.Windows.Forms.ComboBox();
            this.isGrainBoudariesModeActive = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ExportTxt = new System.Windows.Forms.Button();
            this.ImportTxt = new System.Windows.Forms.Button();
            this.ExportJPG = new System.Windows.Forms.Button();
            this.ImportJpg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 249);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NumberOfGains
            // 
            this.NumberOfGains.Location = new System.Drawing.Point(429, 116);
            this.NumberOfGains.Name = "NumberOfGains";
            this.NumberOfGains.Size = new System.Drawing.Size(56, 20);
            this.NumberOfGains.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Number of Gains";
            // 
            // SizeX
            // 
            this.SizeX.Location = new System.Drawing.Point(429, 143);
            this.SizeX.Name = "SizeX";
            this.SizeX.Size = new System.Drawing.Size(56, 20);
            this.SizeX.TabIndex = 7;
            // 
            // SizeY
            // 
            this.SizeY.Location = new System.Drawing.Point(429, 170);
            this.SizeY.Name = "SizeY";
            this.SizeY.Size = new System.Drawing.Size(56, 20);
            this.SizeY.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "SizeX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "SizeY";
            // 
            // GenerateSpace
            // 
            this.GenerateSpace.Location = new System.Drawing.Point(429, 197);
            this.GenerateSpace.Name = "GenerateSpace";
            this.GenerateSpace.Size = new System.Drawing.Size(112, 23);
            this.GenerateSpace.TabIndex = 11;
            this.GenerateSpace.Text = "Generate Space";
            this.GenerateSpace.UseVisualStyleBackColor = true;
            this.GenerateSpace.Click += new System.EventHandler(this.GenerateSpace_Click);
            // 
            // AddGains
            // 
            this.AddGains.Location = new System.Drawing.Point(429, 227);
            this.AddGains.Name = "AddGains";
            this.AddGains.Size = new System.Drawing.Size(76, 27);
            this.AddGains.TabIndex = 12;
            this.AddGains.Text = "Add Gains";
            this.AddGains.UseVisualStyleBackColor = true;
            this.AddGains.Click += new System.EventHandler(this.AddGains_Click);
            // 
            // NumberOfInclusions
            // 
            this.NumberOfInclusions.Location = new System.Drawing.Point(429, 261);
            this.NumberOfInclusions.Name = "NumberOfInclusions";
            this.NumberOfInclusions.Size = new System.Drawing.Size(56, 20);
            this.NumberOfInclusions.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(491, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "NumberOfInclusions";
            // 
            // AddInclusions
            // 
            this.AddInclusions.Location = new System.Drawing.Point(429, 339);
            this.AddInclusions.Name = "AddInclusions";
            this.AddInclusions.Size = new System.Drawing.Size(86, 23);
            this.AddInclusions.TabIndex = 15;
            this.AddInclusions.Text = "AddInclusions";
            this.AddInclusions.UseVisualStyleBackColor = true;
            this.AddInclusions.Click += new System.EventHandler(this.AddInclusions_Click);
            // 
            // InclusionType
            // 
            this.InclusionType.FormattingEnabled = true;
            this.InclusionType.Location = new System.Drawing.Point(429, 312);
            this.InclusionType.Name = "InclusionType";
            this.InclusionType.Size = new System.Drawing.Size(121, 21);
            this.InclusionType.TabIndex = 16;
            // 
            // InclusionSize
            // 
            this.InclusionSize.Location = new System.Drawing.Point(429, 288);
            this.InclusionSize.Name = "InclusionSize";
            this.InclusionSize.Size = new System.Drawing.Size(56, 20);
            this.InclusionSize.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(492, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Inclusion Size";
            // 
            // AddInclusionsAfterSimulation
            // 
            this.AddInclusionsAfterSimulation.Location = new System.Drawing.Point(521, 339);
            this.AddInclusionsAfterSimulation.Name = "AddInclusionsAfterSimulation";
            this.AddInclusionsAfterSimulation.Size = new System.Drawing.Size(173, 23);
            this.AddInclusionsAfterSimulation.TabIndex = 20;
            this.AddInclusionsAfterSimulation.Text = "Add Inclusions After Simulation";
            this.AddInclusionsAfterSimulation.UseVisualStyleBackColor = true;
            this.AddInclusionsAfterSimulation.Click += new System.EventHandler(this.AddInclusionsAfterSimulation_Click);
            // 
            // NeighberhoodType
            // 
            this.NeighberhoodType.FormattingEnabled = true;
            this.NeighberhoodType.Location = new System.Drawing.Point(429, 89);
            this.NeighberhoodType.Name = "NeighberhoodType";
            this.NeighberhoodType.Size = new System.Drawing.Size(121, 21);
            this.NeighberhoodType.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(556, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Neiberhood Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(700, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Probability";
            // 
            // Probability
            // 
            this.Probability.Location = new System.Drawing.Point(626, 116);
            this.Probability.Name = "Probability";
            this.Probability.Size = new System.Drawing.Size(67, 20);
            this.Probability.TabIndex = 26;
            // 
            // CleanUp
            // 
            this.CleanUp.Location = new System.Drawing.Point(12, 396);
            this.CleanUp.Name = "CleanUp";
            this.CleanUp.Size = new System.Drawing.Size(75, 23);
            this.CleanUp.TabIndex = 27;
            this.CleanUp.Text = "Clean up";
            this.CleanUp.UseVisualStyleBackColor = true;
            this.CleanUp.Click += new System.EventHandler(this.CleanUp_Click);
            // 
            // SetBou
            // 
            this.SetBou.Location = new System.Drawing.Point(429, 368);
            this.SetBou.Name = "SetBou";
            this.SetBou.Size = new System.Drawing.Size(97, 23);
            this.SetBou.TabIndex = 28;
            this.SetBou.Text = "Set Boundaries";
            this.SetBou.UseVisualStyleBackColor = true;
            this.SetBou.Click += new System.EventHandler(this.SetBou_Click);
            // 
            // CleanUpWitoutBoundaries
            // 
            this.CleanUpWitoutBoundaries.Location = new System.Drawing.Point(94, 396);
            this.CleanUpWitoutBoundaries.Name = "CleanUpWitoutBoundaries";
            this.CleanUpWitoutBoundaries.Size = new System.Drawing.Size(144, 23);
            this.CleanUpWitoutBoundaries.TabIndex = 29;
            this.CleanUpWitoutBoundaries.Text = "CleanUpWitoutBoundaries";
            this.CleanUpWitoutBoundaries.UseVisualStyleBackColor = true;
            this.CleanUpWitoutBoundaries.Click += new System.EventHandler(this.CleanUpWithoutBoundaries_Click);
            // 
            // MicrostructureType
            // 
            this.MicrostructureType.FormattingEnabled = true;
            this.MicrostructureType.Location = new System.Drawing.Point(626, 149);
            this.MicrostructureType.Name = "MicrostructureType";
            this.MicrostructureType.Size = new System.Drawing.Size(68, 21);
            this.MicrostructureType.TabIndex = 31;
            // 
            // isGrainBoudariesModeActive
            // 
            this.isGrainBoudariesModeActive.AutoSize = true;
            this.isGrainBoudariesModeActive.Location = new System.Drawing.Point(626, 197);
            this.isGrainBoudariesModeActive.Name = "isGrainBoudariesModeActive";
            this.isGrainBoudariesModeActive.Size = new System.Drawing.Size(135, 17);
            this.isGrainBoudariesModeActive.TabIndex = 32;
            this.isGrainBoudariesModeActive.Text = "Grain boundaries mode";
            this.isGrainBoudariesModeActive.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(700, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Microstructure type";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // ExportTxt
            // 
            this.ExportTxt.Location = new System.Drawing.Point(13, 13);
            this.ExportTxt.Name = "ExportTxt";
            this.ExportTxt.Size = new System.Drawing.Size(75, 23);
            this.ExportTxt.TabIndex = 35;
            this.ExportTxt.Text = "Export Txt";
            this.ExportTxt.UseVisualStyleBackColor = true;
            this.ExportTxt.Click += new System.EventHandler(this.ExportTxt_Click);
            // 
            // ImportTxt
            // 
            this.ImportTxt.Location = new System.Drawing.Point(13, 39);
            this.ImportTxt.Name = "ImportTxt";
            this.ImportTxt.Size = new System.Drawing.Size(75, 23);
            this.ImportTxt.TabIndex = 36;
            this.ImportTxt.Text = "Import Txt";
            this.ImportTxt.UseVisualStyleBackColor = true;
            this.ImportTxt.Click += new System.EventHandler(this.ImportTxt_Click);
            // 
            // ExportJPG
            // 
            this.ExportJPG.Location = new System.Drawing.Point(114, 12);
            this.ExportJPG.Name = "ExportJPG";
            this.ExportJPG.Size = new System.Drawing.Size(75, 23);
            this.ExportJPG.TabIndex = 37;
            this.ExportJPG.Text = "Export Jpg";
            this.ExportJPG.UseVisualStyleBackColor = true;
            this.ExportJPG.Click += new System.EventHandler(this.button2_Click);
            // 
            // ImportJpg
            // 
            this.ImportJpg.Location = new System.Drawing.Point(114, 39);
            this.ImportJpg.Name = "ImportJpg";
            this.ImportJpg.Size = new System.Drawing.Size(75, 23);
            this.ImportJpg.TabIndex = 38;
            this.ImportJpg.Text = "Import Jpg";
            this.ImportJpg.UseVisualStyleBackColor = true;
            this.ImportJpg.Click += new System.EventHandler(this.ImportJpg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImportJpg);
            this.Controls.Add(this.ExportJPG);
            this.Controls.Add(this.ImportTxt);
            this.Controls.Add(this.ExportTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.isGrainBoudariesModeActive);
            this.Controls.Add(this.MicrostructureType);
            this.Controls.Add(this.CleanUpWitoutBoundaries);
            this.Controls.Add(this.SetBou);
            this.Controls.Add(this.CleanUp);
            this.Controls.Add(this.Probability);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NeighberhoodType);
            this.Controls.Add(this.AddInclusionsAfterSimulation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.InclusionSize);
            this.Controls.Add(this.InclusionType);
            this.Controls.Add(this.AddInclusions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumberOfInclusions);
            this.Controls.Add(this.AddGains);
            this.Controls.Add(this.GenerateSpace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SizeY);
            this.Controls.Add(this.SizeX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumberOfGains);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NumberOfGains;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SizeX;
        private System.Windows.Forms.TextBox SizeY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button GenerateSpace;
        private System.Windows.Forms.Button AddGains;
        private System.Windows.Forms.TextBox NumberOfInclusions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddInclusions;
        private System.Windows.Forms.ComboBox InclusionType;
        private System.Windows.Forms.TextBox InclusionSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddInclusionsAfterSimulation;
        private System.Windows.Forms.ComboBox NeighberhoodType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Probability;
        private System.Windows.Forms.Button CleanUp;
        private System.Windows.Forms.Button SetBou;
        private System.Windows.Forms.Button CleanUpWitoutBoundaries;
        private System.Windows.Forms.ComboBox MicrostructureType;
        private System.Windows.Forms.CheckBox isGrainBoudariesModeActive;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ExportTxt;
        private System.Windows.Forms.Button ImportTxt;
        private System.Windows.Forms.Button ExportJPG;
        private System.Windows.Forms.Button ImportJpg;
    }
}

