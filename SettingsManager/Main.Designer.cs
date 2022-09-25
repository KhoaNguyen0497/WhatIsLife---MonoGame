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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.debugPage = new System.Windows.Forms.TabPage();
            this.numOfEntitiesLabel = new System.Windows.Forms.Label();
            this.lastUpdatedLabel = new System.Windows.Forms.Label();
            this.currentDayLabel = new System.Windows.Forms.Label();
            this.commandPage = new System.Windows.Forms.TabPage();
            this.worldSettingsPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.foodLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.updateSpeedBar)).BeginInit();
            this.updateSpeedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldWidthInput)).BeginInit();
            this.worldDimensionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldHeightInput)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.debugPage.SuspendLayout();
            this.commandPage.SuspendLayout();
            this.worldSettingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Location = new System.Drawing.Point(6, 11);
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
            this.updateSpeedBox.Location = new System.Drawing.Point(6, 6);
            this.updateSpeedBox.Name = "updateSpeedBox";
            this.updateSpeedBox.Size = new System.Drawing.Size(200, 72);
            this.updateSpeedBox.TabIndex = 3;
            this.updateSpeedBox.TabStop = false;
            this.updateSpeedBox.Text = "Update Speed";
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(318, 36);
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
            this.worldDimensionBox.Location = new System.Drawing.Point(6, 74);
            this.worldDimensionBox.Name = "worldDimensionBox";
            this.worldDimensionBox.Size = new System.Drawing.Size(270, 117);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.debugPage);
            this.tabControl1.Controls.Add(this.commandPage);
            this.tabControl1.Controls.Add(this.worldSettingsPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(290, 565);
            this.tabControl1.TabIndex = 8;
            // 
            // debugPage
            // 
            this.debugPage.Controls.Add(this.foodLabel);
            this.debugPage.Controls.Add(this.numOfEntitiesLabel);
            this.debugPage.Controls.Add(this.lastUpdatedLabel);
            this.debugPage.Controls.Add(this.currentDayLabel);
            this.debugPage.Controls.Add(this.debugCheckBox);
            this.debugPage.Location = new System.Drawing.Point(4, 24);
            this.debugPage.Name = "debugPage";
            this.debugPage.Padding = new System.Windows.Forms.Padding(3);
            this.debugPage.Size = new System.Drawing.Size(282, 537);
            this.debugPage.TabIndex = 0;
            this.debugPage.Text = "Debug";
            this.debugPage.UseVisualStyleBackColor = true;
            // 
            // numOfEntitiesLabel
            // 
            this.numOfEntitiesLabel.AutoSize = true;
            this.numOfEntitiesLabel.Location = new System.Drawing.Point(6, 69);
            this.numOfEntitiesLabel.Name = "numOfEntitiesLabel";
            this.numOfEntitiesLabel.Size = new System.Drawing.Size(48, 15);
            this.numOfEntitiesLabel.TabIndex = 3;
            this.numOfEntitiesLabel.Text = "Entities:";
            // 
            // lastUpdatedLabel
            // 
            this.lastUpdatedLabel.AutoSize = true;
            this.lastUpdatedLabel.Location = new System.Drawing.Point(118, 12);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Size = new System.Drawing.Size(79, 15);
            this.lastUpdatedLabel.TabIndex = 2;
            this.lastUpdatedLabel.Text = "Last Updated:";
            // 
            // currentDayLabel
            // 
            this.currentDayLabel.AutoSize = true;
            this.currentDayLabel.Location = new System.Drawing.Point(6, 43);
            this.currentDayLabel.Name = "currentDayLabel";
            this.currentDayLabel.Size = new System.Drawing.Size(72, 15);
            this.currentDayLabel.TabIndex = 1;
            this.currentDayLabel.Text = "Current day:";
            // 
            // commandPage
            // 
            this.commandPage.Controls.Add(this.updateSpeedBox);
            this.commandPage.Location = new System.Drawing.Point(4, 24);
            this.commandPage.Name = "commandPage";
            this.commandPage.Padding = new System.Windows.Forms.Padding(3);
            this.commandPage.Size = new System.Drawing.Size(282, 537);
            this.commandPage.TabIndex = 2;
            this.commandPage.Text = "Commands";
            this.commandPage.UseVisualStyleBackColor = true;
            // 
            // worldSettingsPage
            // 
            this.worldSettingsPage.Controls.Add(this.label1);
            this.worldSettingsPage.Controls.Add(this.worldDimensionBox);
            this.worldSettingsPage.Location = new System.Drawing.Point(4, 24);
            this.worldSettingsPage.Name = "worldSettingsPage";
            this.worldSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.worldSettingsPage.Size = new System.Drawing.Size(282, 537);
            this.worldSettingsPage.TabIndex = 1;
            this.worldSettingsPage.Text = "World Settings";
            this.worldSettingsPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "These settings require a game restart";
            // 
            // foodLabel
            // 
            this.foodLabel.AutoSize = true;
            this.foodLabel.Location = new System.Drawing.Point(6, 95);
            this.foodLabel.Name = "foodLabel";
            this.foodLabel.Size = new System.Drawing.Size(37, 15);
            this.foodLabel.TabIndex = 4;
            this.foodLabel.Text = "Food:";
            // 
            // SettingsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 589);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.restartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsManagerForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.updateSpeedBar)).EndInit();
            this.updateSpeedBox.ResumeLayout(false);
            this.updateSpeedBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldWidthInput)).EndInit();
            this.worldDimensionBox.ResumeLayout(false);
            this.worldDimensionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldHeightInput)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.debugPage.ResumeLayout(false);
            this.debugPage.PerformLayout();
            this.commandPage.ResumeLayout(false);
            this.worldSettingsPage.ResumeLayout(false);
            this.worldSettingsPage.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage debugPage;
        private System.Windows.Forms.TabPage worldSettingsPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage commandPage;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.Label currentDayLabel;
        private System.Windows.Forms.Label numOfEntitiesLabel;
        private System.Windows.Forms.Label foodLabel;
    }
}
