using Common;

namespace SettingsManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.debug = new System.Windows.Forms.CheckBox();
			this.updateSpeed = new System.Windows.Forms.TrackBar();
			this.updateSpeedBox = new System.Windows.Forms.GroupBox();
			this.restartButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.updateSpeed)).BeginInit();
			this.updateSpeedBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// debug
			// 
			this.debug.AutoSize = true;
			this.debug.Location = new System.Drawing.Point(14, 16);
			this.debug.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.debug.Name = "debug";
			this.debug.Size = new System.Drawing.Size(119, 24);
			this.debug.TabIndex = 0;
			this.debug.Text = "Debug Mode";
			this.debug.UseVisualStyleBackColor = true;
			this.debug.CheckedChanged += new System.EventHandler(this.debug_CheckedChanged);
			// 
			// updateSpeed
			// 
			this.updateSpeed.Location = new System.Drawing.Point(7, 29);
			this.updateSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.updateSpeed.Maximum = 500;
			this.updateSpeed.Name = "updateSpeed";
			this.updateSpeed.Size = new System.Drawing.Size(215, 56);
			this.updateSpeed.TabIndex = 1;
			this.updateSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
			this.updateSpeed.Scroll += new System.EventHandler(this.updateSpeed_Scroll);
			// 
			// updateSpeedBox
			// 
			this.updateSpeedBox.Controls.Add(this.updateSpeed);
			this.updateSpeedBox.Location = new System.Drawing.Point(14, 63);
			this.updateSpeedBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.updateSpeedBox.Name = "updateSpeedBox";
			this.updateSpeedBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.updateSpeedBox.Size = new System.Drawing.Size(229, 96);
			this.updateSpeedBox.TabIndex = 3;
			this.updateSpeedBox.TabStop = false;
			this.updateSpeedBox.Text = "Update Speed";
			// 
			// restartButton
			// 
			this.restartButton.Location = new System.Drawing.Point(391, 16);
			this.restartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.restartButton.Name = "restartButton";
			this.restartButton.Size = new System.Drawing.Size(86, 31);
			this.restartButton.TabIndex = 4;
			this.restartButton.Text = "Restart";
			this.restartButton.UseVisualStyleBackColor = true;
			this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(490, 661);
			this.Controls.Add(this.restartButton);
			this.Controls.Add(this.updateSpeedBox);
			this.Controls.Add(this.debug);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.Text = "Settings";
			((System.ComponentModel.ISupportInitialize)(this.updateSpeed)).EndInit();
			this.updateSpeedBox.ResumeLayout(false);
			this.updateSpeedBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox debug;
        private System.Windows.Forms.TrackBar updateSpeed;
        private System.Windows.Forms.GroupBox updateSpeedBox;
        private System.Windows.Forms.Button restartButton;
    }
}
