namespace ALE_filter
{
    partial class FormSettings
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSamplingFreq = new System.Windows.Forms.TextBox();
            this.textBoxPureSigFreq = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfSamples = new System.Windows.Forms.TextBox();
            this.textBoxSNR = new System.Windows.Forms.TextBox();
            this.textBoxNu = new System.Windows.Forms.TextBox();
            this.textBoxFilterOrder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(109)))), ((int)(((byte)(111)))));
            this.buttonCancel.Location = new System.Drawing.Point(12, 386);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.buttonAccept.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(109)))), ((int)(((byte)(111)))));
            this.buttonAccept.Location = new System.Drawing.Point(159, 386);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(120, 50);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Enabled = false;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.DarkRed;
            this.labelError.Location = new System.Drawing.Point(23, 303);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(145, 80);
            this.labelError.TabIndex = 37;
            this.labelError.Text = "Error!\r\nProvide correct values.\r\nCheck separators.\r\n\r\n\r\n";
            this.labelError.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(242, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "[Hz]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "[Hz]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(242, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "[-]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(242, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "[-]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(242, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "[-]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "[dB]";
            // 
            // textBoxSamplingFreq
            // 
            this.textBoxSamplingFreq.Location = new System.Drawing.Point(138, 268);
            this.textBoxSamplingFreq.Name = "textBoxSamplingFreq";
            this.textBoxSamplingFreq.Size = new System.Drawing.Size(100, 20);
            this.textBoxSamplingFreq.TabIndex = 30;
            this.textBoxSamplingFreq.Text = "1000";
            this.textBoxSamplingFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPureSigFreq
            // 
            this.textBoxPureSigFreq.Location = new System.Drawing.Point(138, 228);
            this.textBoxPureSigFreq.Name = "textBoxPureSigFreq";
            this.textBoxPureSigFreq.Size = new System.Drawing.Size(100, 20);
            this.textBoxPureSigFreq.TabIndex = 29;
            this.textBoxPureSigFreq.Text = "50";
            this.textBoxPureSigFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxNumberOfSamples
            // 
            this.textBoxNumberOfSamples.Location = new System.Drawing.Point(138, 188);
            this.textBoxNumberOfSamples.Name = "textBoxNumberOfSamples";
            this.textBoxNumberOfSamples.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumberOfSamples.TabIndex = 28;
            this.textBoxNumberOfSamples.Text = "1000";
            this.textBoxNumberOfSamples.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSNR
            // 
            this.textBoxSNR.Location = new System.Drawing.Point(138, 148);
            this.textBoxSNR.Name = "textBoxSNR";
            this.textBoxSNR.Size = new System.Drawing.Size(100, 20);
            this.textBoxSNR.TabIndex = 27;
            this.textBoxSNR.Text = "10";
            this.textBoxSNR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxNu
            // 
            this.textBoxNu.Location = new System.Drawing.Point(138, 108);
            this.textBoxNu.Name = "textBoxNu";
            this.textBoxNu.Size = new System.Drawing.Size(100, 20);
            this.textBoxNu.TabIndex = 26;
            this.textBoxNu.Text = "0,05";
            this.textBoxNu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxFilterOrder
            // 
            this.textBoxFilterOrder.Location = new System.Drawing.Point(138, 68);
            this.textBoxFilterOrder.Name = "textBoxFilterOrder";
            this.textBoxFilterOrder.Size = new System.Drawing.Size(100, 20);
            this.textBoxFilterOrder.TabIndex = 25;
            this.textBoxFilterOrder.Text = "64";
            this.textBoxFilterOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Sampling freq.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Pure signal freq.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "μ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "# of samples:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "SNR:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filter order:";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(109)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(291, 448);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSamplingFreq);
            this.Controls.Add(this.textBoxPureSigFreq);
            this.Controls.Add(this.textBoxNumberOfSamples);
            this.Controls.Add(this.textBoxSNR);
            this.Controls.Add(this.textBoxNu);
            this.Controls.Add(this.textBoxFilterOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSettings";
            this.Text = "Options";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSamplingFreq;
        private System.Windows.Forms.TextBox textBoxPureSigFreq;
        private System.Windows.Forms.TextBox textBoxNumberOfSamples;
        private System.Windows.Forms.TextBox textBoxSNR;
        private System.Windows.Forms.TextBox textBoxNu;
        private System.Windows.Forms.TextBox textBoxFilterOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}