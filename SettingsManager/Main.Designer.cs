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
            this.trackedEntitiesBox = new System.Windows.Forms.GroupBox();
            this.entityInput = new System.Windows.Forms.NumericUpDown();
            this.trackedEntityTextBox = new System.Windows.Forms.RichTextBox();
            this.nextTrackedEntityButton = new System.Windows.Forms.Button();
            this.previousTrackedEntityButton = new System.Windows.Forms.Button();
            this.trackedEntitiesComboBox = new System.Windows.Forms.ComboBox();
            this.removeEntityButton = new System.Windows.Forms.Button();
            this.addEntityButton = new System.Windows.Forms.Button();
            this.baseObjectGroupLabel = new System.Windows.Forms.GroupBox();
            this.foodStatTextBox = new System.Windows.Forms.RichTextBox();
            this.entityStatLabel = new System.Windows.Forms.Label();
            this.foodStatLabel = new System.Windows.Forms.Label();
            this.entityStatTextBox = new System.Windows.Forms.RichTextBox();
            this.lastUpdatedLabel = new System.Windows.Forms.Label();
            this.currentDayLabel = new System.Windows.Forms.Label();
            this.commandPage = new System.Windows.Forms.TabPage();
            this.worldSettingsPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cursorCoordinate = new System.Windows.Forms.Label();
            this.nearestEntityLabel = new System.Windows.Forms.Label();
            this.nearestEntityTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.updateSpeedBar)).BeginInit();
            this.updateSpeedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldWidthInput)).BeginInit();
            this.worldDimensionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldHeightInput)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.debugPage.SuspendLayout();
            this.trackedEntitiesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityInput)).BeginInit();
            this.baseObjectGroupLabel.SuspendLayout();
            this.commandPage.SuspendLayout();
            this.worldSettingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Location = new System.Drawing.Point(7, 15);
            this.debugCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(119, 24);
            this.debugCheckBox.TabIndex = 0;
            this.debugCheckBox.Text = "Debug Mode";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            this.debugCheckBox.CheckedChanged += new System.EventHandler(this.debugCheckBox_CheckedChanged);
            // 
            // updateSpeedBar
            // 
            this.updateSpeedBar.Location = new System.Drawing.Point(7, 29);
            this.updateSpeedBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateSpeedBar.Maximum = 500;
            this.updateSpeedBar.Name = "updateSpeedBar";
            this.updateSpeedBar.Size = new System.Drawing.Size(215, 56);
            this.updateSpeedBar.TabIndex = 1;
            this.updateSpeedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.updateSpeedBar.Scroll += new System.EventHandler(this.updateSpeedBar_Scroll);
            // 
            // updateSpeedBox
            // 
            this.updateSpeedBox.Controls.Add(this.updateSpeedBar);
            this.updateSpeedBox.Location = new System.Drawing.Point(7, 8);
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
            this.restartButton.Location = new System.Drawing.Point(413, 45);
            this.restartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(86, 31);
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
            this.worldWidthInput.Location = new System.Drawing.Point(77, 41);
            this.worldWidthInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.worldWidthInput.Size = new System.Drawing.Size(137, 27);
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
            this.worldDimensionBox.Location = new System.Drawing.Point(7, 99);
            this.worldDimensionBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.worldDimensionBox.Name = "worldDimensionBox";
            this.worldDimensionBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.worldDimensionBox.Size = new System.Drawing.Size(309, 156);
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
            this.worldHeightInput.Location = new System.Drawing.Point(77, 92);
            this.worldHeightInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.worldHeightInput.Size = new System.Drawing.Size(137, 27);
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
            this.heightLabel.Location = new System.Drawing.Point(17, 95);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(57, 20);
            this.heightLabel.TabIndex = 7;
            this.heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(17, 44);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(52, 20);
            this.widthLabel.TabIndex = 6;
            this.widthLabel.Text = "Width:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.debugPage);
            this.tabControl1.Controls.Add(this.commandPage);
            this.tabControl1.Controls.Add(this.worldSettingsPage);
            this.tabControl1.Location = new System.Drawing.Point(14, 16);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(343, 753);
            this.tabControl1.TabIndex = 8;
            // 
            // debugPage
            // 
            this.debugPage.Controls.Add(this.trackedEntitiesBox);
            this.debugPage.Controls.Add(this.baseObjectGroupLabel);
            this.debugPage.Controls.Add(this.lastUpdatedLabel);
            this.debugPage.Controls.Add(this.currentDayLabel);
            this.debugPage.Controls.Add(this.debugCheckBox);
            this.debugPage.Location = new System.Drawing.Point(4, 29);
            this.debugPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.debugPage.Name = "debugPage";
            this.debugPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.debugPage.Size = new System.Drawing.Size(335, 720);
            this.debugPage.TabIndex = 0;
            this.debugPage.Text = "Debug";
            this.debugPage.UseVisualStyleBackColor = true;
            // 
            // trackedEntitiesBox
            // 
            this.trackedEntitiesBox.Controls.Add(this.entityInput);
            this.trackedEntitiesBox.Controls.Add(this.trackedEntityTextBox);
            this.trackedEntitiesBox.Controls.Add(this.nextTrackedEntityButton);
            this.trackedEntitiesBox.Controls.Add(this.previousTrackedEntityButton);
            this.trackedEntitiesBox.Controls.Add(this.trackedEntitiesComboBox);
            this.trackedEntitiesBox.Controls.Add(this.removeEntityButton);
            this.trackedEntitiesBox.Controls.Add(this.addEntityButton);
            this.trackedEntitiesBox.Location = new System.Drawing.Point(7, 205);
            this.trackedEntitiesBox.Name = "trackedEntitiesBox";
            this.trackedEntitiesBox.Size = new System.Drawing.Size(322, 362);
            this.trackedEntitiesBox.TabIndex = 10;
            this.trackedEntitiesBox.TabStop = false;
            this.trackedEntitiesBox.Text = "Tracked Entities";
            // 
            // entityInput
            // 
            this.entityInput.Location = new System.Drawing.Point(12, 28);
            this.entityInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.entityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.entityInput.Name = "entityInput";
            this.entityInput.Size = new System.Drawing.Size(64, 27);
            this.entityInput.TabIndex = 11;
            this.entityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // trackedEntityTextBox
            // 
            this.trackedEntityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trackedEntityTextBox.Location = new System.Drawing.Point(12, 109);
            this.trackedEntityTextBox.Name = "trackedEntityTextBox";
            this.trackedEntityTextBox.ReadOnly = true;
            this.trackedEntityTextBox.Size = new System.Drawing.Size(304, 237);
            this.trackedEntityTextBox.TabIndex = 11;
            this.trackedEntityTextBox.Text = "";
            // 
            // nextTrackedEntityButton
            // 
            this.nextTrackedEntityButton.Enabled = false;
            this.nextTrackedEntityButton.Location = new System.Drawing.Point(234, 60);
            this.nextTrackedEntityButton.Name = "nextTrackedEntityButton";
            this.nextTrackedEntityButton.Size = new System.Drawing.Size(34, 29);
            this.nextTrackedEntityButton.TabIndex = 14;
            this.nextTrackedEntityButton.Text = ">";
            this.nextTrackedEntityButton.UseVisualStyleBackColor = true;
            this.nextTrackedEntityButton.Click += new System.EventHandler(this.nextTrackedEntityButton_Click);
            // 
            // previousTrackedEntityButton
            // 
            this.previousTrackedEntityButton.Enabled = false;
            this.previousTrackedEntityButton.Location = new System.Drawing.Point(194, 60);
            this.previousTrackedEntityButton.Name = "previousTrackedEntityButton";
            this.previousTrackedEntityButton.Size = new System.Drawing.Size(34, 29);
            this.previousTrackedEntityButton.TabIndex = 13;
            this.previousTrackedEntityButton.Text = "<";
            this.previousTrackedEntityButton.UseVisualStyleBackColor = true;
            this.previousTrackedEntityButton.Click += new System.EventHandler(this.previousTrackedEntityButton_Click);
            // 
            // trackedEntitiesComboBox
            // 
            this.trackedEntitiesComboBox.FormattingEnabled = true;
            this.trackedEntitiesComboBox.Location = new System.Drawing.Point(12, 61);
            this.trackedEntitiesComboBox.Name = "trackedEntitiesComboBox";
            this.trackedEntitiesComboBox.Size = new System.Drawing.Size(64, 28);
            this.trackedEntitiesComboBox.TabIndex = 12;
            // 
            // removeEntityButton
            // 
            this.removeEntityButton.Location = new System.Drawing.Point(94, 61);
            this.removeEntityButton.Name = "removeEntityButton";
            this.removeEntityButton.Size = new System.Drawing.Size(94, 29);
            this.removeEntityButton.TabIndex = 11;
            this.removeEntityButton.Text = "Remove";
            this.removeEntityButton.UseVisualStyleBackColor = true;
            this.removeEntityButton.Click += new System.EventHandler(this.removeEntityButton_Click);
            // 
            // addEntityButton
            // 
            this.addEntityButton.Location = new System.Drawing.Point(94, 27);
            this.addEntityButton.Name = "addEntityButton";
            this.addEntityButton.Size = new System.Drawing.Size(94, 29);
            this.addEntityButton.TabIndex = 10;
            this.addEntityButton.Text = "Add";
            this.addEntityButton.UseVisualStyleBackColor = true;
            this.addEntityButton.Click += new System.EventHandler(this.addEntityButton_Click);
            // 
            // baseObjectGroupLabel
            // 
            this.baseObjectGroupLabel.Controls.Add(this.foodStatTextBox);
            this.baseObjectGroupLabel.Controls.Add(this.entityStatLabel);
            this.baseObjectGroupLabel.Controls.Add(this.foodStatLabel);
            this.baseObjectGroupLabel.Controls.Add(this.entityStatTextBox);
            this.baseObjectGroupLabel.Location = new System.Drawing.Point(7, 88);
            this.baseObjectGroupLabel.Name = "baseObjectGroupLabel";
            this.baseObjectGroupLabel.Size = new System.Drawing.Size(322, 111);
            this.baseObjectGroupLabel.TabIndex = 6;
            this.baseObjectGroupLabel.TabStop = false;
            this.baseObjectGroupLabel.Text = "BaseObjects - active/recycled/total";
            // 
            // foodStatTextBox
            // 
            this.foodStatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.foodStatTextBox.Location = new System.Drawing.Point(72, 73);
            this.foodStatTextBox.Name = "foodStatTextBox";
            this.foodStatTextBox.ReadOnly = true;
            this.foodStatTextBox.Size = new System.Drawing.Size(156, 20);
            this.foodStatTextBox.TabIndex = 5;
            this.foodStatTextBox.Text = "";
            // 
            // entityStatLabel
            // 
            this.entityStatLabel.AutoSize = true;
            this.entityStatLabel.Location = new System.Drawing.Point(6, 38);
            this.entityStatLabel.Name = "entityStatLabel";
            this.entityStatLabel.Size = new System.Drawing.Size(60, 20);
            this.entityStatLabel.TabIndex = 3;
            this.entityStatLabel.Text = "Entities:";
            // 
            // foodStatLabel
            // 
            this.foodStatLabel.AutoSize = true;
            this.foodStatLabel.Location = new System.Drawing.Point(6, 73);
            this.foodStatLabel.Name = "foodStatLabel";
            this.foodStatLabel.Size = new System.Drawing.Size(46, 20);
            this.foodStatLabel.TabIndex = 4;
            this.foodStatLabel.Text = "Food:";
            // 
            // entityStatTextBox
            // 
            this.entityStatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.entityStatTextBox.Location = new System.Drawing.Point(72, 38);
            this.entityStatTextBox.Name = "entityStatTextBox";
            this.entityStatTextBox.ReadOnly = true;
            this.entityStatTextBox.Size = new System.Drawing.Size(156, 20);
            this.entityStatTextBox.TabIndex = 5;
            this.entityStatTextBox.Text = "";
            // 
            // lastUpdatedLabel
            // 
            this.lastUpdatedLabel.AutoSize = true;
            this.lastUpdatedLabel.Location = new System.Drawing.Point(135, 16);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Size = new System.Drawing.Size(100, 20);
            this.lastUpdatedLabel.TabIndex = 2;
            this.lastUpdatedLabel.Text = "Last Updated:";
            // 
            // currentDayLabel
            // 
            this.currentDayLabel.AutoSize = true;
            this.currentDayLabel.Location = new System.Drawing.Point(13, 56);
            this.currentDayLabel.Name = "currentDayLabel";
            this.currentDayLabel.Size = new System.Drawing.Size(88, 20);
            this.currentDayLabel.TabIndex = 1;
            this.currentDayLabel.Text = "Current day:";
            // 
            // commandPage
            // 
            this.commandPage.Controls.Add(this.updateSpeedBox);
            this.commandPage.Location = new System.Drawing.Point(4, 29);
            this.commandPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.commandPage.Name = "commandPage";
            this.commandPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.commandPage.Size = new System.Drawing.Size(335, 720);
            this.commandPage.TabIndex = 2;
            this.commandPage.Text = "Commands";
            this.commandPage.UseVisualStyleBackColor = true;
            // 
            // worldSettingsPage
            // 
            this.worldSettingsPage.Controls.Add(this.label1);
            this.worldSettingsPage.Controls.Add(this.worldDimensionBox);
            this.worldSettingsPage.Location = new System.Drawing.Point(4, 29);
            this.worldSettingsPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.worldSettingsPage.Name = "worldSettingsPage";
            this.worldSettingsPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.worldSettingsPage.Size = new System.Drawing.Size(335, 720);
            this.worldSettingsPage.TabIndex = 1;
            this.worldSettingsPage.Text = "World Settings";
            this.worldSettingsPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "These settings require a game restart";
            // 
            // cursorCoordinate
            // 
            this.cursorCoordinate.AutoSize = true;
            this.cursorCoordinate.Location = new System.Drawing.Point(363, 101);
            this.cursorCoordinate.Name = "cursorCoordinate";
            this.cursorCoordinate.Size = new System.Drawing.Size(54, 20);
            this.cursorCoordinate.TabIndex = 9;
            this.cursorCoordinate.Text = "Cursor:";
            // 
            // nearestEntityLabel
            // 
            this.nearestEntityLabel.AutoSize = true;
            this.nearestEntityLabel.Location = new System.Drawing.Point(363, 133);
            this.nearestEntityLabel.Name = "nearestEntityLabel";
            this.nearestEntityLabel.Size = new System.Drawing.Size(104, 20);
            this.nearestEntityLabel.TabIndex = 15;
            this.nearestEntityLabel.Text = "Nearest Entity:";
            // 
            // nearestEntityTextBox
            // 
            this.nearestEntityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nearestEntityTextBox.Location = new System.Drawing.Point(363, 171);
            this.nearestEntityTextBox.Name = "nearestEntityTextBox";
            this.nearestEntityTextBox.ReadOnly = true;
            this.nearestEntityTextBox.Size = new System.Drawing.Size(161, 188);
            this.nearestEntityTextBox.TabIndex = 16;
            this.nearestEntityTextBox.Text = "";
            // 
            // SettingsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 785);
            this.Controls.Add(this.nearestEntityTextBox);
            this.Controls.Add(this.nearestEntityLabel);
            this.Controls.Add(this.cursorCoordinate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.restartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.trackedEntitiesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entityInput)).EndInit();
            this.baseObjectGroupLabel.ResumeLayout(false);
            this.baseObjectGroupLabel.PerformLayout();
            this.commandPage.ResumeLayout(false);
            this.worldSettingsPage.ResumeLayout(false);
            this.worldSettingsPage.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage debugPage;
        private System.Windows.Forms.TabPage worldSettingsPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage commandPage;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.Label currentDayLabel;
        private System.Windows.Forms.Label entityStatLabel;
        private System.Windows.Forms.Label foodStatLabel;
        private System.Windows.Forms.RichTextBox entityStatTextBox;
        private System.Windows.Forms.RichTextBox foodStatTextBox;
        private System.Windows.Forms.GroupBox baseObjectGroupLabel;
        private System.Windows.Forms.Label cursorCoordinate;
        private System.Windows.Forms.GroupBox trackedEntitiesBox;
        private System.Windows.Forms.ComboBox trackedEntitiesComboBox;
        private System.Windows.Forms.Button removeEntityButton;
        private System.Windows.Forms.Button addEntityButton;
        private System.Windows.Forms.RichTextBox trackedEntityTextBox;
        private System.Windows.Forms.Button nextTrackedEntityButton;
        private System.Windows.Forms.Button previousTrackedEntityButton;
        private System.Windows.Forms.NumericUpDown entityInput;
        private System.Windows.Forms.Label nearestEntityLabel;
        private System.Windows.Forms.RichTextBox nearestEntityTextBox;
    }
}
