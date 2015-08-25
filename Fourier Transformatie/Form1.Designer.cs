namespace Fourier_Transformatie {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox_Origineel = new System.Windows.Forms.PictureBox();
            this.button_Inladen = new System.Windows.Forms.Button();
            this.button_Forward = new System.Windows.Forms.Button();
            this.button_Backwards = new System.Windows.Forms.Button();
            this.label_InladenInfo = new System.Windows.Forms.Label();
            this.pictureBox_grijs = new System.Windows.Forms.PictureBox();
            this.label_origineel = new System.Windows.Forms.Label();
            this.label_grijs = new System.Windows.Forms.Label();
            this.label_Fase = new System.Windows.Forms.Label();
            this.pictureBox_Fase = new System.Windows.Forms.PictureBox();
            this.label_Magnitude = new System.Windows.Forms.Label();
            this.pictureBox_Mag = new System.Windows.Forms.PictureBox();
            this.label_Reverse = new System.Windows.Forms.Label();
            this.pictureBox_Backward = new System.Windows.Forms.PictureBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_dump = new System.Windows.Forms.Button();
            this.numericUpDown_mag = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Phase = new System.Windows.Forms.NumericUpDown();
            this.checkBox_shift = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Origineel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_grijs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Fase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Backward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Phase)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Origineel
            // 
            this.pictureBox_Origineel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Origineel.Location = new System.Drawing.Point(12, 25);
            this.pictureBox_Origineel.Name = "pictureBox_Origineel";
            this.pictureBox_Origineel.Size = new System.Drawing.Size(512, 512);
            this.pictureBox_Origineel.TabIndex = 0;
            this.pictureBox_Origineel.TabStop = false;
            // 
            // button_Inladen
            // 
            this.button_Inladen.Location = new System.Drawing.Point(11, 544);
            this.button_Inladen.Name = "button_Inladen";
            this.button_Inladen.Size = new System.Drawing.Size(110, 25);
            this.button_Inladen.TabIndex = 1;
            this.button_Inladen.Text = "Afbeelding inladen";
            this.button_Inladen.UseVisualStyleBackColor = true;
            this.button_Inladen.Click += new System.EventHandler(this.button_Inladen_Click);
            // 
            // button_Forward
            // 
            this.button_Forward.Enabled = false;
            this.button_Forward.Location = new System.Drawing.Point(298, 544);
            this.button_Forward.Name = "button_Forward";
            this.button_Forward.Size = new System.Drawing.Size(110, 25);
            this.button_Forward.TabIndex = 2;
            this.button_Forward.Text = "Forward FFT";
            this.button_Forward.UseVisualStyleBackColor = true;
            this.button_Forward.Click += new System.EventHandler(this.button_Forward_Click);
            // 
            // button_Backwards
            // 
            this.button_Backwards.Enabled = false;
            this.button_Backwards.Location = new System.Drawing.Point(414, 544);
            this.button_Backwards.Name = "button_Backwards";
            this.button_Backwards.Size = new System.Drawing.Size(110, 25);
            this.button_Backwards.TabIndex = 3;
            this.button_Backwards.Text = "Backward FFT";
            this.button_Backwards.UseVisualStyleBackColor = true;
            this.button_Backwards.Click += new System.EventHandler(this.button_Backwards_Click);
            // 
            // label_InladenInfo
            // 
            this.label_InladenInfo.AutoSize = true;
            this.label_InladenInfo.Location = new System.Drawing.Point(9, 589);
            this.label_InladenInfo.Name = "label_InladenInfo";
            this.label_InladenInfo.Size = new System.Drawing.Size(420, 26);
            this.label_InladenInfo.TabIndex = 4;
            this.label_InladenInfo.Text = "Indien de afmetingen van de ingeladen afbeelding geen macht van 2 bedragen, wordt" +
    " \r\nhet grootst mogelijk bereik met afmetingen die een macht van 2 bedragen eruit" +
    " gebruikt.";
            // 
            // pictureBox_grijs
            // 
            this.pictureBox_grijs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_grijs.Location = new System.Drawing.Point(530, 25);
            this.pictureBox_grijs.Name = "pictureBox_grijs";
            this.pictureBox_grijs.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_grijs.TabIndex = 5;
            this.pictureBox_grijs.TabStop = false;
            // 
            // label_origineel
            // 
            this.label_origineel.AutoSize = true;
            this.label_origineel.Location = new System.Drawing.Point(12, 9);
            this.label_origineel.Name = "label_origineel";
            this.label_origineel.Size = new System.Drawing.Size(51, 13);
            this.label_origineel.TabIndex = 6;
            this.label_origineel.Text = "Origineel:";
            // 
            // label_grijs
            // 
            this.label_grijs.AutoSize = true;
            this.label_grijs.Location = new System.Drawing.Point(530, 9);
            this.label_grijs.Name = "label_grijs";
            this.label_grijs.Size = new System.Drawing.Size(112, 13);
            this.label_grijs.TabIndex = 7;
            this.label_grijs.Text = "Grey-scale afbeelding:";
            // 
            // label_Fase
            // 
            this.label_Fase.AutoSize = true;
            this.label_Fase.Location = new System.Drawing.Point(530, 296);
            this.label_Fase.Name = "label_Fase";
            this.label_Fase.Size = new System.Drawing.Size(68, 13);
            this.label_Fase.TabIndex = 9;
            this.label_Fase.Text = "Fourier Fase:";
            // 
            // pictureBox_Fase
            // 
            this.pictureBox_Fase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Fase.Location = new System.Drawing.Point(530, 313);
            this.pictureBox_Fase.Name = "pictureBox_Fase";
            this.pictureBox_Fase.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Fase.TabIndex = 8;
            this.pictureBox_Fase.TabStop = false;
            // 
            // label_Magnitude
            // 
            this.label_Magnitude.AutoSize = true;
            this.label_Magnitude.Location = new System.Drawing.Point(792, 9);
            this.label_Magnitude.Name = "label_Magnitude";
            this.label_Magnitude.Size = new System.Drawing.Size(91, 13);
            this.label_Magnitude.TabIndex = 11;
            this.label_Magnitude.Text = "Fourier Amplitude:";
            // 
            // pictureBox_Mag
            // 
            this.pictureBox_Mag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Mag.Location = new System.Drawing.Point(792, 25);
            this.pictureBox_Mag.Name = "pictureBox_Mag";
            this.pictureBox_Mag.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Mag.TabIndex = 10;
            this.pictureBox_Mag.TabStop = false;
            // 
            // label_Reverse
            // 
            this.label_Reverse.AutoSize = true;
            this.label_Reverse.Location = new System.Drawing.Point(792, 296);
            this.label_Reverse.Name = "label_Reverse";
            this.label_Reverse.Size = new System.Drawing.Size(80, 13);
            this.label_Reverse.TabIndex = 13;
            this.label_Reverse.Text = "Backward FFT:";
            // 
            // pictureBox_Backward
            // 
            this.pictureBox_Backward.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Backward.Location = new System.Drawing.Point(792, 312);
            this.pictureBox_Backward.Name = "pictureBox_Backward";
            this.pictureBox_Backward.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Backward.TabIndex = 12;
            this.pictureBox_Backward.TabStop = false;
            // 
            // button_Save
            // 
            this.button_Save.Enabled = false;
            this.button_Save.Location = new System.Drawing.Point(792, 574);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(256, 23);
            this.button_Save.TabIndex = 14;
            this.button_Save.Text = "Afbeeldingen opslaan";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_dump
            // 
            this.button_dump.Location = new System.Drawing.Point(530, 574);
            this.button_dump.Name = "button_dump";
            this.button_dump.Size = new System.Drawing.Size(256, 23);
            this.button_dump.TabIndex = 15;
            this.button_dump.Text = "Resultaten opslaan naar .txt bestand";
            this.button_dump.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_mag
            // 
            this.numericUpDown_mag.Enabled = false;
            this.numericUpDown_mag.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_mag.Location = new System.Drawing.Point(977, 3);
            this.numericUpDown_mag.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_mag.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_mag.Name = "numericUpDown_mag";
            this.numericUpDown_mag.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown_mag.TabIndex = 16;
            this.numericUpDown_mag.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // numericUpDown_Phase
            // 
            this.numericUpDown_Phase.Enabled = false;
            this.numericUpDown_Phase.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_Phase.Location = new System.Drawing.Point(716, 291);
            this.numericUpDown_Phase.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown_Phase.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_Phase.Name = "numericUpDown_Phase";
            this.numericUpDown_Phase.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown_Phase.TabIndex = 17;
            this.numericUpDown_Phase.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // checkBox_shift
            // 
            this.checkBox_shift.AutoSize = true;
            this.checkBox_shift.Location = new System.Drawing.Point(212, 549);
            this.checkBox_shift.Name = "checkBox_shift";
            this.checkBox_shift.Size = new System.Drawing.Size(87, 17);
            this.checkBox_shift.TabIndex = 18;
            this.checkBox_shift.Text = "Normaliseren";
            this.checkBox_shift.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 622);
            this.Controls.Add(this.checkBox_shift);
            this.Controls.Add(this.numericUpDown_Phase);
            this.Controls.Add(this.numericUpDown_mag);
            this.Controls.Add(this.button_dump);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.label_Reverse);
            this.Controls.Add(this.pictureBox_Backward);
            this.Controls.Add(this.label_Magnitude);
            this.Controls.Add(this.pictureBox_Mag);
            this.Controls.Add(this.label_Fase);
            this.Controls.Add(this.pictureBox_Fase);
            this.Controls.Add(this.label_grijs);
            this.Controls.Add(this.label_origineel);
            this.Controls.Add(this.pictureBox_grijs);
            this.Controls.Add(this.label_InladenInfo);
            this.Controls.Add(this.button_Backwards);
            this.Controls.Add(this.button_Forward);
            this.Controls.Add(this.button_Inladen);
            this.Controls.Add(this.pictureBox_Origineel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 660);
            this.MinimumSize = new System.Drawing.Size(1080, 660);
            this.Name = "Form1";
            this.Text = "Fourier Transformatie";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Origineel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_grijs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Fase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Backward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Phase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Origineel;
        private System.Windows.Forms.Button button_Inladen;
        private System.Windows.Forms.Button button_Forward;
        private System.Windows.Forms.Button button_Backwards;
        private System.Windows.Forms.Label label_InladenInfo;
        private System.Windows.Forms.PictureBox pictureBox_grijs;
        private System.Windows.Forms.Label label_origineel;
        private System.Windows.Forms.Label label_grijs;
        private System.Windows.Forms.Label label_Fase;
        private System.Windows.Forms.PictureBox pictureBox_Fase;
        private System.Windows.Forms.Label label_Magnitude;
        private System.Windows.Forms.PictureBox pictureBox_Mag;
        private System.Windows.Forms.Label label_Reverse;
        private System.Windows.Forms.PictureBox pictureBox_Backward;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_dump;
        private System.Windows.Forms.NumericUpDown numericUpDown_mag;
        private System.Windows.Forms.NumericUpDown numericUpDown_Phase;
        private System.Windows.Forms.CheckBox checkBox_shift;
    }
}

