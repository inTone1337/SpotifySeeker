﻿using System.Drawing;

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
            this.CurrentTrackLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CurrentProgressLabel
            // 
            this.CurrentProgressLabel.AutoSize = true;
            this.CurrentProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentProgressLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentProgressLabel.Location = new System.Drawing.Point(12, 27);
            this.CurrentProgressLabel.Name = "CurrentProgressLabel";
            this.CurrentProgressLabel.Size = new System.Drawing.Size(153, 18);
            this.CurrentProgressLabel.TabIndex = 0;
            this.CurrentProgressLabel.Text = "CurrentProgressLabel";
            this.CurrentProgressLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FutureProgressLabel
            // 
            this.FutureProgressLabel.AutoSize = true;
            this.FutureProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FutureProgressLabel.ForeColor = System.Drawing.Color.White;
            this.FutureProgressLabel.Location = new System.Drawing.Point(8, 45);
            this.FutureProgressLabel.Name = "FutureProgressLabel";
            this.FutureProgressLabel.Size = new System.Drawing.Size(335, 37);
            this.FutureProgressLabel.TabIndex = 1;
            this.FutureProgressLabel.Text = "FutureProgressLabel";
            this.FutureProgressLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ProgressModifierLabel
            // 
            this.ProgressModifierLabel.AutoSize = true;
            this.ProgressModifierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressModifierLabel.ForeColor = System.Drawing.Color.White;
            this.ProgressModifierLabel.Location = new System.Drawing.Point(171, 27);
            this.ProgressModifierLabel.Name = "ProgressModifierLabel";
            this.ProgressModifierLabel.Size = new System.Drawing.Size(157, 18);
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
            // CurrentTrackLabel
            // 
            this.CurrentTrackLabel.AutoSize = true;
            this.CurrentTrackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTrackLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentTrackLabel.Location = new System.Drawing.Point(12, 9);
            this.CurrentTrackLabel.Name = "CurrentTrackLabel";
            this.CurrentTrackLabel.Size = new System.Drawing.Size(130, 18);
            this.CurrentTrackLabel.TabIndex = 3;
            this.CurrentTrackLabel.Text = "CurrentTrackLabel";
            this.CurrentTrackLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SpotifySeekerOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 100);
            this.Controls.Add(this.CurrentTrackLabel);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentProgressLabel;
        private System.Windows.Forms.Label FutureProgressLabel;
        private System.Windows.Forms.Label ProgressModifierLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label CurrentTrackLabel;
    }
}

