using System.Drawing;

namespace SpotifySeeker
{
    partial class SpotifySeekerOverlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpotifySeekerOverlay));
            this.CurrentProgressLabel = new System.Windows.Forms.Label();
            this.FutureProgressLabel = new System.Windows.Forms.Label();
            this.ProgressModifierLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // CurrentProgressLabel
            // 
            this.CurrentProgressLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentProgressLabel.Location = new System.Drawing.Point(12, 9);
            this.CurrentProgressLabel.Name = "CurrentProgressLabel";
            this.CurrentProgressLabel.Size = new System.Drawing.Size(100, 23);
            this.CurrentProgressLabel.TabIndex = 0;
            this.CurrentProgressLabel.Text = "CurrentProgressLabel";
            this.CurrentProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FutureProgressLabel
            // 
            this.FutureProgressLabel.ForeColor = System.Drawing.Color.White;
            this.FutureProgressLabel.Location = new System.Drawing.Point(224, 9);
            this.FutureProgressLabel.Name = "FutureProgressLabel";
            this.FutureProgressLabel.Size = new System.Drawing.Size(100, 23);
            this.FutureProgressLabel.TabIndex = 1;
            this.FutureProgressLabel.Text = "FutureProgressLabel";
            this.FutureProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProgressModifierLabel
            // 
            this.ProgressModifierLabel.ForeColor = System.Drawing.Color.White;
            this.ProgressModifierLabel.Location = new System.Drawing.Point(118, 9);
            this.ProgressModifierLabel.Name = "ProgressModifierLabel";
            this.ProgressModifierLabel.Size = new System.Drawing.Size(100, 23);
            this.ProgressModifierLabel.TabIndex = 2;
            this.ProgressModifierLabel.Text = "ProgressModifierLabel";
            this.ProgressModifierLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Spotify Seeker";
            this.notifyIcon.Visible = true;
            // 
            // SpotifySeekerOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(330, 30);
            this.Controls.Add(this.ProgressModifierLabel);
            this.Controls.Add(this.FutureProgressLabel);
            this.Controls.Add(this.CurrentProgressLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpotifySeekerOverlay";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CurrentProgressLabel;
        private System.Windows.Forms.Label FutureProgressLabel;
        private System.Windows.Forms.Label ProgressModifierLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

