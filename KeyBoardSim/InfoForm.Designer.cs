namespace kursaCH
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.hardRadioB = new System.Windows.Forms.RadioButton();
            this.mediumRadioB = new System.Windows.Forms.RadioButton();
            this.easyRadioB = new System.Windows.Forms.RadioButton();
            this.infoButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.complError = new System.Windows.Forms.ErrorProvider(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.complError)).BeginInit();
            this.SuspendLayout();
            // 
            // hardRadioB
            // 
            this.hardRadioB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.hardRadioB.AutoSize = true;
            this.hardRadioB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hardRadioB.ForeColor = System.Drawing.Color.Purple;
            this.hardRadioB.Location = new System.Drawing.Point(257, 123);
            this.hardRadioB.Margin = new System.Windows.Forms.Padding(2);
            this.hardRadioB.Name = "hardRadioB";
            this.hardRadioB.Size = new System.Drawing.Size(127, 33);
            this.hardRadioB.TabIndex = 5;
            this.hardRadioB.Text = "Сложно";
            this.hardRadioB.UseVisualStyleBackColor = true;
            this.hardRadioB.CheckedChanged += new System.EventHandler(this.hardRadioB_CheckedChanged);
            // 
            // mediumRadioB
            // 
            this.mediumRadioB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mediumRadioB.AutoSize = true;
            this.mediumRadioB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mediumRadioB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(1)))), ((int)(((byte)(109)))));
            this.mediumRadioB.Location = new System.Drawing.Point(156, 123);
            this.mediumRadioB.Margin = new System.Windows.Forms.Padding(2);
            this.mediumRadioB.Name = "mediumRadioB";
            this.mediumRadioB.Size = new System.Drawing.Size(97, 33);
            this.mediumRadioB.TabIndex = 6;
            this.mediumRadioB.Text = "Норм";
            this.mediumRadioB.UseVisualStyleBackColor = true;
            this.mediumRadioB.CheckedChanged += new System.EventHandler(this.mediumRadioB_CheckedChanged);
            // 
            // easyRadioB
            // 
            this.easyRadioB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.easyRadioB.AutoSize = true;
            this.easyRadioB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.easyRadioB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(145)))), ((int)(((byte)(77)))));
            this.easyRadioB.Location = new System.Drawing.Point(52, 123);
            this.easyRadioB.Margin = new System.Windows.Forms.Padding(2);
            this.easyRadioB.Name = "easyRadioB";
            this.easyRadioB.Size = new System.Drawing.Size(100, 33);
            this.easyRadioB.TabIndex = 7;
            this.easyRadioB.Text = "Легко";
            this.easyRadioB.UseVisualStyleBackColor = true;
            this.easyRadioB.CheckedChanged += new System.EventHandler(this.easyRadioB_CheckedChanged);
            // 
            // infoButton
            // 
            this.infoButton.BackColor = System.Drawing.Color.MediumPurple;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoButton.Location = new System.Drawing.Point(53, 183);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(136, 47);
            this.infoButton.TabIndex = 8;
            this.infoButton.Text = "Инфо";
            this.infoButton.UseVisualStyleBackColor = false;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.MediumPurple;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(208, 183);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(136, 47);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(67, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 41);
            this.label3.TabIndex = 10;
            this.label3.Text = "Выберете сложность";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // complError
            // 
            this.complError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.complError.ContainerControl = this;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.White;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(361, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.TabIndex = 11;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(89)))), ((int)(((byte)(148)))));
            this.ClientSize = new System.Drawing.Size(403, 283);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.hardRadioB);
            this.Controls.Add(this.mediumRadioB);
            this.Controls.Add(this.easyRadioB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfoForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InfoForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InfoForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.complError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton hardRadioB;
        private System.Windows.Forms.RadioButton mediumRadioB;
        private System.Windows.Forms.RadioButton easyRadioB;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider complError;
        private System.Windows.Forms.Button closeButton;
    }
}