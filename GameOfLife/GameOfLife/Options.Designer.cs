namespace GameOfLife
{
    partial class Options
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
            this.Milliseconds = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.Label();
            this.Height = new System.Windows.Forms.Label();
            this.MilliUpDown = new System.Windows.Forms.NumericUpDown();
            this.WidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.HeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MilliUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Milliseconds
            // 
            this.Milliseconds.AutoSize = true;
            this.Milliseconds.Location = new System.Drawing.Point(31, 35);
            this.Milliseconds.Name = "Milliseconds";
            this.Milliseconds.Size = new System.Drawing.Size(104, 13);
            this.Milliseconds.TabIndex = 0;
            this.Milliseconds.Text = "Timer in Milliseconds";
            // 
            // Width
            // 
            this.Width.AutoSize = true;
            this.Width.Location = new System.Drawing.Point(44, 74);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(91, 13);
            this.Width.TabIndex = 1;
            this.Width.Text = "Width in Universe";
            // 
            // Height
            // 
            this.Height.AutoSize = true;
            this.Height.Location = new System.Drawing.Point(41, 112);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(94, 13);
            this.Height.TabIndex = 2;
            this.Height.Text = "Height in Universe";
            // 
            // MilliUpDown
            // 
            this.MilliUpDown.Location = new System.Drawing.Point(164, 33);
            this.MilliUpDown.Name = "MilliUpDown";
            this.MilliUpDown.Size = new System.Drawing.Size(120, 20);
            this.MilliUpDown.TabIndex = 3;
            // 
            // WidthUpDown
            // 
            this.WidthUpDown.Location = new System.Drawing.Point(164, 72);
            this.WidthUpDown.Name = "WidthUpDown";
            this.WidthUpDown.Size = new System.Drawing.Size(120, 20);
            this.WidthUpDown.TabIndex = 4;
            // 
            // HeightUpDown
            // 
            this.HeightUpDown.Location = new System.Drawing.Point(164, 110);
            this.HeightUpDown.Name = "HeightUpDown";
            this.HeightUpDown.Size = new System.Drawing.Size(120, 20);
            this.HeightUpDown.TabIndex = 5;
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(60, 157);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 6;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(183, 157);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 208);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.HeightUpDown);
            this.Controls.Add(this.WidthUpDown);
            this.Controls.Add(this.MilliUpDown);
            this.Controls.Add(this.Height);
            this.Controls.Add(this.Width);
            this.Controls.Add(this.Milliseconds);
            this.Name = "Options";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.MilliUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Milliseconds;
        private new System.Windows.Forms.Label Width;
        private new System.Windows.Forms.Label Height;
        private System.Windows.Forms.NumericUpDown MilliUpDown;
        private System.Windows.Forms.NumericUpDown WidthUpDown;
        private System.Windows.Forms.NumericUpDown HeightUpDown;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}