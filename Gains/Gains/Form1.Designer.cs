﻿namespace Gains
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddInclusionsAfterSimulation = new System.Windows.Forms.Button();
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(429, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "von Neuman";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(429, 92);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(56, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Moore";
            this.checkBox2.UseVisualStyleBackColor = true;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "label5";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddInclusionsAfterSimulation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
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
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddInclusionsAfterSimulation;
    }
}

