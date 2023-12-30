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
            restartButton = new System.Windows.Forms.Button();
            cursorCoordinate = new System.Windows.Forms.Label();
            nearestEntityLabel = new System.Windows.Forms.Label();
            nearestEntityTextBox = new System.Windows.Forms.RichTextBox();
            upsLabel = new System.Windows.Forms.Label();
            fpsLabel = new System.Windows.Forms.Label();
            worldSettingsPage = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            worldDimensionBox = new System.Windows.Forms.GroupBox();
            worldHeightInput = new System.Windows.Forms.NumericUpDown();
            heightLabel = new System.Windows.Forms.Label();
            widthLabel = new System.Windows.Forms.Label();
            worldWidthInput = new System.Windows.Forms.NumericUpDown();
            commandPage = new System.Windows.Forms.TabPage();
            updateSpeedBox = new System.Windows.Forms.GroupBox();
            updateSpeedBar = new System.Windows.Forms.TrackBar();
            debugPage = new System.Windows.Forms.TabPage();
            trackedEntitiesBox = new System.Windows.Forms.GroupBox();
            entityInput = new System.Windows.Forms.NumericUpDown();
            trackedEntityTextBox = new System.Windows.Forms.RichTextBox();
            nextTrackedEntityButton = new System.Windows.Forms.Button();
            previousTrackedEntityButton = new System.Windows.Forms.Button();
            trackedEntitiesComboBox = new System.Windows.Forms.ComboBox();
            removeEntityButton = new System.Windows.Forms.Button();
            addEntityButton = new System.Windows.Forms.Button();
            baseObjectGroupLabel = new System.Windows.Forms.GroupBox();
            foodStatTextBox = new System.Windows.Forms.RichTextBox();
            entityStatLabel = new System.Windows.Forms.Label();
            foodStatLabel = new System.Windows.Forms.Label();
            entityStatTextBox = new System.Windows.Forms.RichTextBox();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            currentDayLabel = new System.Windows.Forms.Label();
            debugCheckBox = new System.Windows.Forms.CheckBox();
            tabControl1 = new System.Windows.Forms.TabControl();
            alwaysOnPanel = new System.Windows.Forms.Panel();
            worldSettingsPage.SuspendLayout();
            worldDimensionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)worldHeightInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)worldWidthInput).BeginInit();
            commandPage.SuspendLayout();
            updateSpeedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)updateSpeedBar).BeginInit();
            debugPage.SuspendLayout();
            trackedEntitiesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)entityInput).BeginInit();
            baseObjectGroupLabel.SuspendLayout();
            tabControl1.SuspendLayout();
            alwaysOnPanel.SuspendLayout();
            SuspendLayout();
            // 
            // restartButton
            // 
            restartButton.Location = new System.Drawing.Point(44, 10);
            restartButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            restartButton.Name = "restartButton";
            restartButton.Size = new System.Drawing.Size(140, 50);
            restartButton.TabIndex = 4;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // cursorCoordinate
            // 
            cursorCoordinate.AutoSize = true;
            cursorCoordinate.Location = new System.Drawing.Point(44, 106);
            cursorCoordinate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            cursorCoordinate.Name = "cursorCoordinate";
            cursorCoordinate.Size = new System.Drawing.Size(88, 32);
            cursorCoordinate.TabIndex = 9;
            cursorCoordinate.Text = "Cursor:";
            // 
            // nearestEntityLabel
            // 
            nearestEntityLabel.AutoSize = true;
            nearestEntityLabel.Location = new System.Drawing.Point(44, 147);
            nearestEntityLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            nearestEntityLabel.Name = "nearestEntityLabel";
            nearestEntityLabel.Size = new System.Drawing.Size(168, 32);
            nearestEntityLabel.TabIndex = 15;
            nearestEntityLabel.Text = "Nearest Entity:";
            // 
            // nearestEntityTextBox
            // 
            nearestEntityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            nearestEntityTextBox.Location = new System.Drawing.Point(48, 184);
            nearestEntityTextBox.Margin = new System.Windows.Forms.Padding(5);
            nearestEntityTextBox.Name = "nearestEntityTextBox";
            nearestEntityTextBox.ReadOnly = true;
            nearestEntityTextBox.Size = new System.Drawing.Size(262, 301);
            nearestEntityTextBox.TabIndex = 16;
            nearestEntityTextBox.Text = "";
            // 
            // upsLabel
            // 
            upsLabel.AutoSize = true;
            upsLabel.Location = new System.Drawing.Point(210, 42);
            upsLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            upsLabel.Name = "upsLabel";
            upsLabel.Size = new System.Drawing.Size(61, 32);
            upsLabel.TabIndex = 1;
            upsLabel.Text = "UPS:";
            // 
            // fpsLabel
            // 
            fpsLabel.AutoSize = true;
            fpsLabel.Location = new System.Drawing.Point(210, 10);
            fpsLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            fpsLabel.Name = "fpsLabel";
            fpsLabel.Size = new System.Drawing.Size(57, 32);
            fpsLabel.TabIndex = 0;
            fpsLabel.Text = "FPS:";
            // 
            // worldSettingsPage
            // 
            worldSettingsPage.Controls.Add(label1);
            worldSettingsPage.Controls.Add(worldDimensionBox);
            worldSettingsPage.Location = new System.Drawing.Point(8, 46);
            worldSettingsPage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            worldSettingsPage.Name = "worldSettingsPage";
            worldSettingsPage.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            worldSettingsPage.Size = new System.Drawing.Size(543, 1151);
            worldSettingsPage.TabIndex = 1;
            worldSettingsPage.Text = "World Settings";
            worldSettingsPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 18);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(410, 32);
            label1.TabIndex = 2;
            label1.Text = "These settings require a game restart";
            // 
            // worldDimensionBox
            // 
            worldDimensionBox.Controls.Add(worldHeightInput);
            worldDimensionBox.Controls.Add(heightLabel);
            worldDimensionBox.Controls.Add(widthLabel);
            worldDimensionBox.Controls.Add(worldWidthInput);
            worldDimensionBox.Location = new System.Drawing.Point(11, 158);
            worldDimensionBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            worldDimensionBox.Name = "worldDimensionBox";
            worldDimensionBox.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            worldDimensionBox.Size = new System.Drawing.Size(502, 250);
            worldDimensionBox.TabIndex = 6;
            worldDimensionBox.TabStop = false;
            worldDimensionBox.Text = "World Dimension";
            // 
            // worldHeightInput
            // 
            worldHeightInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            worldHeightInput.Location = new System.Drawing.Point(125, 147);
            worldHeightInput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            worldHeightInput.Maximum = new decimal(new int[] { 15000, 0, 0, 0 });
            worldHeightInput.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            worldHeightInput.Name = "worldHeightInput";
            worldHeightInput.Size = new System.Drawing.Size(223, 39);
            worldHeightInput.TabIndex = 5;
            worldHeightInput.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            worldHeightInput.ValueChanged += worldHeightInput_ValueChanged;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Location = new System.Drawing.Point(28, 152);
            heightLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new System.Drawing.Size(91, 32);
            heightLabel.TabIndex = 7;
            heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Location = new System.Drawing.Point(28, 70);
            widthLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new System.Drawing.Size(83, 32);
            widthLabel.TabIndex = 6;
            widthLabel.Text = "Width:";
            // 
            // worldWidthInput
            // 
            worldWidthInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            worldWidthInput.Location = new System.Drawing.Point(125, 66);
            worldWidthInput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            worldWidthInput.Maximum = new decimal(new int[] { 15000, 0, 0, 0 });
            worldWidthInput.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            worldWidthInput.Name = "worldWidthInput";
            worldWidthInput.Size = new System.Drawing.Size(223, 39);
            worldWidthInput.TabIndex = 5;
            worldWidthInput.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            worldWidthInput.ValueChanged += worldWidthInput_ValueChanged;
            // 
            // commandPage
            // 
            commandPage.Controls.Add(updateSpeedBox);
            commandPage.Location = new System.Drawing.Point(8, 46);
            commandPage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            commandPage.Name = "commandPage";
            commandPage.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            commandPage.Size = new System.Drawing.Size(543, 1151);
            commandPage.TabIndex = 2;
            commandPage.Text = "Commands";
            commandPage.UseVisualStyleBackColor = true;
            // 
            // updateSpeedBox
            // 
            updateSpeedBox.Controls.Add(updateSpeedBar);
            updateSpeedBox.Location = new System.Drawing.Point(11, 13);
            updateSpeedBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            updateSpeedBox.Name = "updateSpeedBox";
            updateSpeedBox.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            updateSpeedBox.Size = new System.Drawing.Size(372, 154);
            updateSpeedBox.TabIndex = 3;
            updateSpeedBox.TabStop = false;
            updateSpeedBox.Text = "Update Speed";
            // 
            // updateSpeedBar
            // 
            updateSpeedBar.Location = new System.Drawing.Point(11, 46);
            updateSpeedBar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            updateSpeedBar.Maximum = 500;
            updateSpeedBar.Name = "updateSpeedBar";
            updateSpeedBar.Size = new System.Drawing.Size(349, 90);
            updateSpeedBar.TabIndex = 1;
            updateSpeedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            updateSpeedBar.Scroll += updateSpeedBar_Scroll;
            // 
            // debugPage
            // 
            debugPage.Controls.Add(trackedEntitiesBox);
            debugPage.Controls.Add(baseObjectGroupLabel);
            debugPage.Controls.Add(lastUpdatedLabel);
            debugPage.Controls.Add(currentDayLabel);
            debugPage.Controls.Add(debugCheckBox);
            debugPage.Location = new System.Drawing.Point(8, 46);
            debugPage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            debugPage.Name = "debugPage";
            debugPage.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            debugPage.Size = new System.Drawing.Size(543, 1151);
            debugPage.TabIndex = 0;
            debugPage.Text = "Debug";
            debugPage.UseVisualStyleBackColor = true;
            // 
            // trackedEntitiesBox
            // 
            trackedEntitiesBox.Controls.Add(entityInput);
            trackedEntitiesBox.Controls.Add(trackedEntityTextBox);
            trackedEntitiesBox.Controls.Add(nextTrackedEntityButton);
            trackedEntitiesBox.Controls.Add(previousTrackedEntityButton);
            trackedEntitiesBox.Controls.Add(trackedEntitiesComboBox);
            trackedEntitiesBox.Controls.Add(removeEntityButton);
            trackedEntitiesBox.Controls.Add(addEntityButton);
            trackedEntitiesBox.Location = new System.Drawing.Point(11, 328);
            trackedEntitiesBox.Margin = new System.Windows.Forms.Padding(5);
            trackedEntitiesBox.Name = "trackedEntitiesBox";
            trackedEntitiesBox.Padding = new System.Windows.Forms.Padding(5);
            trackedEntitiesBox.Size = new System.Drawing.Size(523, 579);
            trackedEntitiesBox.TabIndex = 10;
            trackedEntitiesBox.TabStop = false;
            trackedEntitiesBox.Text = "Tracked Entities";
            // 
            // entityInput
            // 
            entityInput.Location = new System.Drawing.Point(20, 45);
            entityInput.Margin = new System.Windows.Forms.Padding(5);
            entityInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            entityInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            entityInput.Name = "entityInput";
            entityInput.Size = new System.Drawing.Size(104, 39);
            entityInput.TabIndex = 11;
            entityInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // trackedEntityTextBox
            // 
            trackedEntityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            trackedEntityTextBox.Location = new System.Drawing.Point(20, 174);
            trackedEntityTextBox.Margin = new System.Windows.Forms.Padding(5);
            trackedEntityTextBox.Name = "trackedEntityTextBox";
            trackedEntityTextBox.ReadOnly = true;
            trackedEntityTextBox.Size = new System.Drawing.Size(494, 379);
            trackedEntityTextBox.TabIndex = 11;
            trackedEntityTextBox.Text = "";
            // 
            // nextTrackedEntityButton
            // 
            nextTrackedEntityButton.Enabled = false;
            nextTrackedEntityButton.Location = new System.Drawing.Point(380, 96);
            nextTrackedEntityButton.Margin = new System.Windows.Forms.Padding(5);
            nextTrackedEntityButton.Name = "nextTrackedEntityButton";
            nextTrackedEntityButton.Size = new System.Drawing.Size(55, 46);
            nextTrackedEntityButton.TabIndex = 14;
            nextTrackedEntityButton.Text = ">";
            nextTrackedEntityButton.UseVisualStyleBackColor = true;
            nextTrackedEntityButton.Click += nextTrackedEntityButton_Click;
            // 
            // previousTrackedEntityButton
            // 
            previousTrackedEntityButton.Enabled = false;
            previousTrackedEntityButton.Location = new System.Drawing.Point(315, 96);
            previousTrackedEntityButton.Margin = new System.Windows.Forms.Padding(5);
            previousTrackedEntityButton.Name = "previousTrackedEntityButton";
            previousTrackedEntityButton.Size = new System.Drawing.Size(55, 46);
            previousTrackedEntityButton.TabIndex = 13;
            previousTrackedEntityButton.Text = "<";
            previousTrackedEntityButton.UseVisualStyleBackColor = true;
            previousTrackedEntityButton.Click += previousTrackedEntityButton_Click;
            // 
            // trackedEntitiesComboBox
            // 
            trackedEntitiesComboBox.FormattingEnabled = true;
            trackedEntitiesComboBox.Location = new System.Drawing.Point(20, 98);
            trackedEntitiesComboBox.Margin = new System.Windows.Forms.Padding(5);
            trackedEntitiesComboBox.Name = "trackedEntitiesComboBox";
            trackedEntitiesComboBox.Size = new System.Drawing.Size(102, 40);
            trackedEntitiesComboBox.TabIndex = 12;
            // 
            // removeEntityButton
            // 
            removeEntityButton.Location = new System.Drawing.Point(153, 98);
            removeEntityButton.Margin = new System.Windows.Forms.Padding(5);
            removeEntityButton.Name = "removeEntityButton";
            removeEntityButton.Size = new System.Drawing.Size(153, 46);
            removeEntityButton.TabIndex = 11;
            removeEntityButton.Text = "Remove";
            removeEntityButton.UseVisualStyleBackColor = true;
            removeEntityButton.Click += removeEntityButton_Click;
            // 
            // addEntityButton
            // 
            addEntityButton.Location = new System.Drawing.Point(153, 43);
            addEntityButton.Margin = new System.Windows.Forms.Padding(5);
            addEntityButton.Name = "addEntityButton";
            addEntityButton.Size = new System.Drawing.Size(153, 46);
            addEntityButton.TabIndex = 10;
            addEntityButton.Text = "Add";
            addEntityButton.UseVisualStyleBackColor = true;
            addEntityButton.Click += addEntityButton_Click;
            // 
            // baseObjectGroupLabel
            // 
            baseObjectGroupLabel.Controls.Add(foodStatTextBox);
            baseObjectGroupLabel.Controls.Add(entityStatLabel);
            baseObjectGroupLabel.Controls.Add(foodStatLabel);
            baseObjectGroupLabel.Controls.Add(entityStatTextBox);
            baseObjectGroupLabel.Location = new System.Drawing.Point(11, 141);
            baseObjectGroupLabel.Margin = new System.Windows.Forms.Padding(5);
            baseObjectGroupLabel.Name = "baseObjectGroupLabel";
            baseObjectGroupLabel.Padding = new System.Windows.Forms.Padding(5);
            baseObjectGroupLabel.Size = new System.Drawing.Size(523, 178);
            baseObjectGroupLabel.TabIndex = 6;
            baseObjectGroupLabel.TabStop = false;
            baseObjectGroupLabel.Text = "BaseObjects - active/recycled/total";
            // 
            // foodStatTextBox
            // 
            foodStatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            foodStatTextBox.Location = new System.Drawing.Point(117, 117);
            foodStatTextBox.Margin = new System.Windows.Forms.Padding(5);
            foodStatTextBox.Name = "foodStatTextBox";
            foodStatTextBox.ReadOnly = true;
            foodStatTextBox.Size = new System.Drawing.Size(254, 32);
            foodStatTextBox.TabIndex = 5;
            foodStatTextBox.Text = "";
            // 
            // entityStatLabel
            // 
            entityStatLabel.AutoSize = true;
            entityStatLabel.Location = new System.Drawing.Point(10, 61);
            entityStatLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            entityStatLabel.Name = "entityStatLabel";
            entityStatLabel.Size = new System.Drawing.Size(96, 32);
            entityStatLabel.TabIndex = 3;
            entityStatLabel.Text = "Entities:";
            // 
            // foodStatLabel
            // 
            foodStatLabel.AutoSize = true;
            foodStatLabel.Location = new System.Drawing.Point(10, 117);
            foodStatLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            foodStatLabel.Name = "foodStatLabel";
            foodStatLabel.Size = new System.Drawing.Size(73, 32);
            foodStatLabel.TabIndex = 4;
            foodStatLabel.Text = "Food:";
            // 
            // entityStatTextBox
            // 
            entityStatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            entityStatTextBox.Location = new System.Drawing.Point(117, 61);
            entityStatTextBox.Margin = new System.Windows.Forms.Padding(5);
            entityStatTextBox.Name = "entityStatTextBox";
            entityStatTextBox.ReadOnly = true;
            entityStatTextBox.Size = new System.Drawing.Size(254, 32);
            entityStatTextBox.TabIndex = 5;
            entityStatTextBox.Text = "";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(219, 26);
            lastUpdatedLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(158, 32);
            lastUpdatedLabel.TabIndex = 2;
            lastUpdatedLabel.Text = "Last Updated:";
            // 
            // currentDayLabel
            // 
            currentDayLabel.AutoSize = true;
            currentDayLabel.Location = new System.Drawing.Point(21, 90);
            currentDayLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            currentDayLabel.Name = "currentDayLabel";
            currentDayLabel.Size = new System.Drawing.Size(144, 32);
            currentDayLabel.TabIndex = 1;
            currentDayLabel.Text = "Current day:";
            // 
            // debugCheckBox
            // 
            debugCheckBox.AutoSize = true;
            debugCheckBox.Location = new System.Drawing.Point(11, 24);
            debugCheckBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            debugCheckBox.Name = "debugCheckBox";
            debugCheckBox.Size = new System.Drawing.Size(188, 36);
            debugCheckBox.TabIndex = 0;
            debugCheckBox.Text = "Debug Mode";
            debugCheckBox.UseVisualStyleBackColor = true;
            debugCheckBox.CheckedChanged += debugCheckBox_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(debugPage);
            tabControl1.Controls.Add(commandPage);
            tabControl1.Controls.Add(worldSettingsPage);
            tabControl1.Location = new System.Drawing.Point(23, 26);
            tabControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(559, 1205);
            tabControl1.TabIndex = 8;
            // 
            // alwaysOnPanel
            // 
            alwaysOnPanel.Controls.Add(upsLabel);
            alwaysOnPanel.Controls.Add(restartButton);
            alwaysOnPanel.Controls.Add(fpsLabel);
            alwaysOnPanel.Controls.Add(cursorCoordinate);
            alwaysOnPanel.Controls.Add(nearestEntityTextBox);
            alwaysOnPanel.Controls.Add(nearestEntityLabel);
            alwaysOnPanel.Location = new System.Drawing.Point(592, 72);
            alwaysOnPanel.Margin = new System.Windows.Forms.Padding(5);
            alwaysOnPanel.Name = "alwaysOnPanel";
            alwaysOnPanel.Size = new System.Drawing.Size(384, 542);
            alwaysOnPanel.TabIndex = 11;
            // 
            // SettingsManagerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(990, 1256);
            Controls.Add(alwaysOnPanel);
            Controls.Add(tabControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "SettingsManagerForm";
            Text = "Settings";
            worldSettingsPage.ResumeLayout(false);
            worldSettingsPage.PerformLayout();
            worldDimensionBox.ResumeLayout(false);
            worldDimensionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)worldHeightInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)worldWidthInput).EndInit();
            commandPage.ResumeLayout(false);
            updateSpeedBox.ResumeLayout(false);
            updateSpeedBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)updateSpeedBar).EndInit();
            debugPage.ResumeLayout(false);
            debugPage.PerformLayout();
            trackedEntitiesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)entityInput).EndInit();
            baseObjectGroupLabel.ResumeLayout(false);
            baseObjectGroupLabel.PerformLayout();
            tabControl1.ResumeLayout(false);
            alwaysOnPanel.ResumeLayout(false);
            alwaysOnPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label cursorCoordinate;
        private System.Windows.Forms.Label nearestEntityLabel;
        private System.Windows.Forms.RichTextBox nearestEntityTextBox;
        private System.Windows.Forms.TabPage worldSettingsPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox worldDimensionBox;
        private System.Windows.Forms.NumericUpDown worldHeightInput;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.NumericUpDown worldWidthInput;
        private System.Windows.Forms.TabPage commandPage;
        private System.Windows.Forms.GroupBox updateSpeedBox;
        private System.Windows.Forms.TrackBar updateSpeedBar;
        private System.Windows.Forms.TabPage debugPage;
        private System.Windows.Forms.GroupBox trackedEntitiesBox;
        private System.Windows.Forms.NumericUpDown entityInput;
        private System.Windows.Forms.RichTextBox trackedEntityTextBox;
        private System.Windows.Forms.Button nextTrackedEntityButton;
        private System.Windows.Forms.Button previousTrackedEntityButton;
        private System.Windows.Forms.ComboBox trackedEntitiesComboBox;
        private System.Windows.Forms.Button removeEntityButton;
        private System.Windows.Forms.Button addEntityButton;
        private System.Windows.Forms.GroupBox baseObjectGroupLabel;
        private System.Windows.Forms.RichTextBox foodStatTextBox;
        private System.Windows.Forms.Label entityStatLabel;
        private System.Windows.Forms.Label foodStatLabel;
        private System.Windows.Forms.RichTextBox entityStatTextBox;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.Label currentDayLabel;
        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel alwaysOnPanel;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.Label upsLabel;
    }
}
