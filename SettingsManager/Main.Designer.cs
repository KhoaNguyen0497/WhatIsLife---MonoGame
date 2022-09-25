using Common;

namespace SettingsManager
{
    partial class SettingsManagerForm
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
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.updateSpeedBar = new System.Windows.Forms.TrackBar();
            this.updateSpeedBox = new System.Windows.Forms.GroupBox();
            this.restartButton = new System.Windows.Forms.Button();
            this.worldWidthInput = new System.Windows.Forms.NumericUpDown();
            this.worldDimensionBox = new System.Windows.Forms.GroupBox();
            this.worldHeightInput = new System.Windows.Forms.NumericUpDown();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.updateSpeedBar)).BeginInit();
            this.updateSpeedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldWidthInput)).BeginInit();
            this.worldDimensionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldHeightInput)).BeginInit();
            this.SuspendLayout();
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Location = new System.Drawing.Point(12, 12);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(95, 19);
            this.debugCheckBox.TabIndex = 0;
            this.debugCheckBox.Text = "Debug Mode";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            this.debugCheckBox.CheckedChanged += new System.EventHandler(this.debugCheckBox_CheckedChanged);
            // 
            // updateSpeedBar
            // 
            this.updateSpeedBar.Location = new System.Drawing.Point(6, 22);
            this.updateSpeedBar.Maximum = 500;
            this.updateSpeedBar.Name = "updateSpeedBar";
            this.updateSpeedBar.Size = new System.Drawing.Size(188, 45);
            this.updateSpeedBar.TabIndex = 1;
            this.updateSpeedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.updateSpeedBar.Scroll += new System.EventHandler(this.updateSpeedBar_Scroll);
            // 
            // updateSpeedBox
            // 
            this.updateSpeedBox.Controls.Add(this.updateSpeedBar);
            this.updateSpeedBox.Location = new System.Drawing.Point(12, 47);
            this.updateSpeedBox.Name = "updateSpeedBox";
            this.updateSpeedBox.Size = new System.Drawing.Size(200, 72);
            this.updateSpeedBox.TabIndex = 3;
            this.updateSpeedBox.TabStop = false;
            this.updateSpeedBox.Text = "Update Speed";
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(342, 12);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(75, 23);
            this.restartButton.TabIndex = 4;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // worldWidthInput
            // 
            this.worldWidthInput.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.worldWidthInput.Location = new System.Drawing.Point(67, 31);
            this.worldWidthInput.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.worldWidthInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.worldWidthInput.Name = "worldWidthInput";
            this.worldWidthInput.Size = new System.Drawing.Size(120, 23);
            this.worldWidthInput.TabIndex = 5;
            this.worldWidthInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.worldWidthInput.ValueChanged += new System.EventHandler(this.worldWidthInput_ValueChanged);
            // 
            // worldDimensionBox
            // 
            this.worldDimensionBox.Controls.Add(this.worldHeightInput);
            this.worldDimensionBox.Controls.Add(this.heightLabel);
            this.worldDimensionBox.Controls.Add(this.widthLabel);
            this.worldDimensionBox.Controls.Add(this.worldWidthInput);
            this.worldDimensionBox.Location = new System.Drawing.Point(12, 137);
            this.worldDimensionBox.Name = "worldDimensionBox";
            this.worldDimensionBox.Size = new System.Drawing.Size(200, 117);
            this.worldDimensionBox.TabIndex = 6;
            this.worldDimensionBox.TabStop = false;
            this.worldDimensionBox.Text = "World Dimension";
            // 
            // worldHeightInput
            // 
            this.worldHeightInput.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.worldHeightInput.Location = new System.Drawing.Point(67, 69);
            this.worldHeightInput.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.worldHeightInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.worldHeightInput.Name = "worldHeightInput";
            this.worldHeightInput.Size = new System.Drawing.Size(120, 23);
            this.worldHeightInput.TabIndex = 5;
            this.worldHeightInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.worldHeightInput.ValueChanged += new System.EventHandler(this.worldHeightInput_ValueChanged);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(15, 71);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(46, 15);
            this.heightLabel.TabIndex = 7;
            this.heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(15, 33);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(42, 15);
            this.widthLabel.TabIndex = 6;
            this.widthLabel.Text = "Width:";
            // 
            // SettingsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 589);
            this.Controls.Add(this.worldDimensionBox);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.updateSpeedBox);
            this.Controls.Add(this.debugCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsManagerForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.updateSpeedBar)).EndInit();
            this.updateSpeedBox.ResumeLayout(false);
            this.updateSpeedBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldWidthInput)).EndInit();
            this.worldDimensionBox.ResumeLayout(false);
            this.worldDimensionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldHeightInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.TrackBar updateSpeedBar;
        private System.Windows.Forms.GroupBox updateSpeedBox;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.NumericUpDown worldWidthInput;
        private System.Windows.Forms.GroupBox worldDimensionBox;
        private System.Windows.Forms.NumericUpDown worldHeightInput;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
    }
}
