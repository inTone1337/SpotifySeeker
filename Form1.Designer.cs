namespace SpotifySeeker
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
            this.CurrentProgressLabel = new System.Windows.Forms.Label();
            this.FutureProgressLabel = new System.Windows.Forms.Label();
            this.ProgressModifierLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CurrentProgressLabel
            // 
            this.CurrentProgressLabel.Location = new System.Drawing.Point(12, 9);
            this.CurrentProgressLabel.Name = "CurrentProgressLabel";
            this.CurrentProgressLabel.Size = new System.Drawing.Size(100, 23);
            this.CurrentProgressLabel.TabIndex = 0;
            this.CurrentProgressLabel.Text = "CurrentProgressLabel";
            // 
            // FutureProgressLabel
            // 
            this.FutureProgressLabel.Location = new System.Drawing.Point(224, 9);
            this.FutureProgressLabel.Name = "FutureProgressLabel";
            this.FutureProgressLabel.Size = new System.Drawing.Size(100, 23);
            this.FutureProgressLabel.TabIndex = 1;
            this.FutureProgressLabel.Text = "FutureProgressLabel";
            // 
            // ProgressModifierLabel
            // 
            this.ProgressModifierLabel.Location = new System.Drawing.Point(118, 9);
            this.ProgressModifierLabel.Name = "ProgressModifierLabel";
            this.ProgressModifierLabel.Size = new System.Drawing.Size(100, 23);
            this.ProgressModifierLabel.TabIndex = 2;
            this.ProgressModifierLabel.Text = "ProgressModifierLabel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProgressModifierLabel);
            this.Controls.Add(this.FutureProgressLabel);
            this.Controls.Add(this.CurrentProgressLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CurrentProgressLabel;
        private System.Windows.Forms.Label FutureProgressLabel;
        private System.Windows.Forms.Label ProgressModifierLabel;
    }
}

