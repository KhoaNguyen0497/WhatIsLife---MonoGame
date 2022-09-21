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
            ((System.ComponentModel.ISupportInitialize)(this.updateSpeed)).BeginInit();
            this.updateSpeedBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(12, 12);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(95, 19);
            this.debug.TabIndex = 0;
            this.debug.Text = "Debug Mode";
            this.debug.UseVisualStyleBackColor = true;
            this.debug.CheckedChanged += new System.EventHandler(this.debug_CheckedChanged);
            // 
            // updateSpeed
            // 
            this.updateSpeed.Location = new System.Drawing.Point(6, 22);
            this.updateSpeed.Maximum = 500;
            this.updateSpeed.Name = "updateSpeed";
            this.updateSpeed.Size = new System.Drawing.Size(188, 45);
            this.updateSpeed.TabIndex = 1;
            this.updateSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.updateSpeed.Scroll += new System.EventHandler(this.updateSpeed_Scroll);
            this.updateSpeed.Value = (int)(GameConfig.SpeedMultiplier * 100);
            // 
            // updateSpeedBox
            // 
            this.updateSpeedBox.Controls.Add(this.updateSpeed);
            this.updateSpeedBox.Location = new System.Drawing.Point(12, 47);
            this.updateSpeedBox.Name = "updateSpeedBox";
            this.updateSpeedBox.Size = new System.Drawing.Size(200, 72);
            this.updateSpeedBox.TabIndex = 3;
            this.updateSpeedBox.TabStop = false;
            this.updateSpeedBox.Text = "Update Speed";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 496);
            this.Controls.Add(this.updateSpeedBox);
            this.Controls.Add(this.debug);
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
    }
}
