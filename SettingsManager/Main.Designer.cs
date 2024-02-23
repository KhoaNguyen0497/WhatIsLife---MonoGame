using Common;
using System.Drawing;

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
            drawEnabledCheckBox = new System.Windows.Forms.CheckBox();
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
            graphTab = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            checkBox1 = new System.Windows.Forms.CheckBox();
            formsPlot1 = new ScottPlot.FormsPlot();
            renderFoodByDay = new System.Windows.Forms.CheckBox();
            foodByDayGraph = new ScottPlot.FormsPlot();
            panel1 = new System.Windows.Forms.Panel();
            renderEntitiesByDay = new System.Windows.Forms.CheckBox();
            entitiesbyDayGraph = new ScottPlot.FormsPlot();
            alwaysOnPanel = new System.Windows.Forms.Panel();
            averageSpeedGraph = new ScottPlot.FormsPlot();
            renderAvegrageSpeed = new System.Windows.Forms.CheckBox();
            panel4 = new System.Windows.Forms.Panel();
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
            graphTab.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            alwaysOnPanel.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // restartButton
            // 
            restartButton.Location = new Point(24, 5);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(75, 23);
            restartButton.TabIndex = 4;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // cursorCoordinate
            // 
            cursorCoordinate.AutoSize = true;
            cursorCoordinate.Location = new Point(24, 50);
            cursorCoordinate.Name = "cursorCoordinate";
            cursorCoordinate.Size = new Size(45, 15);
            cursorCoordinate.TabIndex = 9;
            cursorCoordinate.Text = "Cursor:";
            // 
            // nearestEntityLabel
            // 
            nearestEntityLabel.AutoSize = true;
            nearestEntityLabel.Location = new Point(24, 69);
            nearestEntityLabel.Name = "nearestEntityLabel";
            nearestEntityLabel.Size = new Size(83, 15);
            nearestEntityLabel.TabIndex = 15;
            nearestEntityLabel.Text = "Nearest Entity:";
            // 
            // nearestEntityTextBox
            // 
            nearestEntityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            nearestEntityTextBox.Location = new Point(26, 86);
            nearestEntityTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            nearestEntityTextBox.Name = "nearestEntityTextBox";
            nearestEntityTextBox.ReadOnly = true;
            nearestEntityTextBox.Size = new Size(141, 141);
            nearestEntityTextBox.TabIndex = 16;
            nearestEntityTextBox.Text = "";
            // 
            // upsLabel
            // 
            upsLabel.AutoSize = true;
            upsLabel.Location = new Point(113, 20);
            upsLabel.Name = "upsLabel";
            upsLabel.Size = new Size(31, 15);
            upsLabel.TabIndex = 1;
            upsLabel.Text = "UPS:";
            // 
            // fpsLabel
            // 
            fpsLabel.AutoSize = true;
            fpsLabel.Location = new Point(113, 5);
            fpsLabel.Name = "fpsLabel";
            fpsLabel.Size = new Size(29, 15);
            fpsLabel.TabIndex = 0;
            fpsLabel.Text = "FPS:";
            // 
            // worldSettingsPage
            // 
            worldSettingsPage.Controls.Add(label1);
            worldSettingsPage.Controls.Add(worldDimensionBox);
            worldSettingsPage.Location = new Point(4, 24);
            worldSettingsPage.Name = "worldSettingsPage";
            worldSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            worldSettingsPage.Size = new Size(382, 537);
            worldSettingsPage.TabIndex = 1;
            worldSettingsPage.Text = "World Settings";
            worldSettingsPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 8);
            label1.Name = "label1";
            label1.Size = new Size(199, 15);
            label1.TabIndex = 2;
            label1.Text = "These settings require a game restart";
            // 
            // worldDimensionBox
            // 
            worldDimensionBox.Controls.Add(worldHeightInput);
            worldDimensionBox.Controls.Add(heightLabel);
            worldDimensionBox.Controls.Add(widthLabel);
            worldDimensionBox.Controls.Add(worldWidthInput);
            worldDimensionBox.Location = new Point(6, 74);
            worldDimensionBox.Name = "worldDimensionBox";
            worldDimensionBox.Size = new Size(270, 117);
            worldDimensionBox.TabIndex = 6;
            worldDimensionBox.TabStop = false;
            worldDimensionBox.Text = "World Dimension";
            // 
            // worldHeightInput
            // 
            worldHeightInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            worldHeightInput.Location = new Point(67, 69);
            worldHeightInput.Maximum = new decimal(new int[] { 15000, 0, 0, 0 });
            worldHeightInput.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            worldHeightInput.Name = "worldHeightInput";
            worldHeightInput.Size = new Size(120, 23);
            worldHeightInput.TabIndex = 5;
            worldHeightInput.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            worldHeightInput.ValueChanged += worldHeightInput_ValueChanged;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Location = new Point(15, 71);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(46, 15);
            heightLabel.TabIndex = 7;
            heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Location = new Point(15, 33);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new Size(42, 15);
            widthLabel.TabIndex = 6;
            widthLabel.Text = "Width:";
            // 
            // worldWidthInput
            // 
            worldWidthInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            worldWidthInput.Location = new Point(67, 31);
            worldWidthInput.Maximum = new decimal(new int[] { 15000, 0, 0, 0 });
            worldWidthInput.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            worldWidthInput.Name = "worldWidthInput";
            worldWidthInput.Size = new Size(120, 23);
            worldWidthInput.TabIndex = 5;
            worldWidthInput.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            worldWidthInput.ValueChanged += worldWidthInput_ValueChanged;
            // 
            // commandPage
            // 
            commandPage.Controls.Add(updateSpeedBox);
            commandPage.Location = new Point(4, 24);
            commandPage.Name = "commandPage";
            commandPage.Padding = new System.Windows.Forms.Padding(3);
            commandPage.Size = new Size(382, 537);
            commandPage.TabIndex = 2;
            commandPage.Text = "Commands";
            commandPage.UseVisualStyleBackColor = true;
            // 
            // updateSpeedBox
            // 
            updateSpeedBox.Controls.Add(updateSpeedBar);
            updateSpeedBox.Location = new Point(6, 6);
            updateSpeedBox.Name = "updateSpeedBox";
            updateSpeedBox.Size = new Size(200, 72);
            updateSpeedBox.TabIndex = 3;
            updateSpeedBox.TabStop = false;
            updateSpeedBox.Text = "Update Speed";
            // 
            // updateSpeedBar
            // 
            updateSpeedBar.Location = new Point(6, 22);
            updateSpeedBar.Maximum = 1000;
            updateSpeedBar.Name = "updateSpeedBar";
            updateSpeedBar.Size = new Size(188, 45);
            updateSpeedBar.TabIndex = 1;
            updateSpeedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            updateSpeedBar.Scroll += updateSpeedBar_Scroll;
            // 
            // debugPage
            // 
            debugPage.Controls.Add(drawEnabledCheckBox);
            debugPage.Controls.Add(trackedEntitiesBox);
            debugPage.Controls.Add(baseObjectGroupLabel);
            debugPage.Controls.Add(lastUpdatedLabel);
            debugPage.Controls.Add(currentDayLabel);
            debugPage.Controls.Add(debugCheckBox);
            debugPage.Location = new Point(4, 24);
            debugPage.Name = "debugPage";
            debugPage.Padding = new System.Windows.Forms.Padding(3);
            debugPage.Size = new Size(382, 537);
            debugPage.TabIndex = 0;
            debugPage.Text = "Debug";
            debugPage.UseVisualStyleBackColor = true;
            // 
            // drawEnabledCheckBox
            // 
            drawEnabledCheckBox.AutoSize = true;
            drawEnabledCheckBox.Location = new Point(6, 36);
            drawEnabledCheckBox.Name = "drawEnabledCheckBox";
            drawEnabledCheckBox.Size = new Size(53, 19);
            drawEnabledCheckBox.TabIndex = 11;
            drawEnabledCheckBox.Text = "Draw";
            drawEnabledCheckBox.UseVisualStyleBackColor = true;
            drawEnabledCheckBox.CheckedChanged += drawEnabledCheckBox_CheckedChanged;
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
            trackedEntitiesBox.Location = new Point(6, 195);
            trackedEntitiesBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            trackedEntitiesBox.Name = "trackedEntitiesBox";
            trackedEntitiesBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            trackedEntitiesBox.Size = new Size(282, 271);
            trackedEntitiesBox.TabIndex = 10;
            trackedEntitiesBox.TabStop = false;
            trackedEntitiesBox.Text = "Tracked Entities";
            // 
            // entityInput
            // 
            entityInput.Location = new Point(11, 21);
            entityInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            entityInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            entityInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            entityInput.Name = "entityInput";
            entityInput.Size = new Size(56, 23);
            entityInput.TabIndex = 11;
            entityInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // trackedEntityTextBox
            // 
            trackedEntityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            trackedEntityTextBox.Location = new Point(11, 82);
            trackedEntityTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            trackedEntityTextBox.Name = "trackedEntityTextBox";
            trackedEntityTextBox.ReadOnly = true;
            trackedEntityTextBox.Size = new Size(266, 178);
            trackedEntityTextBox.TabIndex = 11;
            trackedEntityTextBox.Text = "";
            // 
            // nextTrackedEntityButton
            // 
            nextTrackedEntityButton.Enabled = false;
            nextTrackedEntityButton.Location = new Point(205, 45);
            nextTrackedEntityButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            nextTrackedEntityButton.Name = "nextTrackedEntityButton";
            nextTrackedEntityButton.Size = new Size(30, 22);
            nextTrackedEntityButton.TabIndex = 14;
            nextTrackedEntityButton.Text = ">";
            nextTrackedEntityButton.UseVisualStyleBackColor = true;
            nextTrackedEntityButton.Click += nextTrackedEntityButton_Click;
            // 
            // previousTrackedEntityButton
            // 
            previousTrackedEntityButton.Enabled = false;
            previousTrackedEntityButton.Location = new Point(170, 45);
            previousTrackedEntityButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            previousTrackedEntityButton.Name = "previousTrackedEntityButton";
            previousTrackedEntityButton.Size = new Size(30, 22);
            previousTrackedEntityButton.TabIndex = 13;
            previousTrackedEntityButton.Text = "<";
            previousTrackedEntityButton.UseVisualStyleBackColor = true;
            previousTrackedEntityButton.Click += previousTrackedEntityButton_Click;
            // 
            // trackedEntitiesComboBox
            // 
            trackedEntitiesComboBox.FormattingEnabled = true;
            trackedEntitiesComboBox.Location = new Point(11, 46);
            trackedEntitiesComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            trackedEntitiesComboBox.Name = "trackedEntitiesComboBox";
            trackedEntitiesComboBox.Size = new Size(57, 23);
            trackedEntitiesComboBox.TabIndex = 12;
            // 
            // removeEntityButton
            // 
            removeEntityButton.Location = new Point(82, 46);
            removeEntityButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            removeEntityButton.Name = "removeEntityButton";
            removeEntityButton.Size = new Size(82, 22);
            removeEntityButton.TabIndex = 11;
            removeEntityButton.Text = "Remove";
            removeEntityButton.UseVisualStyleBackColor = true;
            removeEntityButton.Click += removeEntityButton_Click;
            // 
            // addEntityButton
            // 
            addEntityButton.Location = new Point(82, 20);
            addEntityButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            addEntityButton.Name = "addEntityButton";
            addEntityButton.Size = new Size(82, 22);
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
            baseObjectGroupLabel.Location = new Point(6, 107);
            baseObjectGroupLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            baseObjectGroupLabel.Name = "baseObjectGroupLabel";
            baseObjectGroupLabel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            baseObjectGroupLabel.Size = new Size(282, 83);
            baseObjectGroupLabel.TabIndex = 6;
            baseObjectGroupLabel.TabStop = false;
            baseObjectGroupLabel.Text = "BaseObjects - active/recycled/total";
            // 
            // foodStatTextBox
            // 
            foodStatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            foodStatTextBox.Location = new Point(63, 55);
            foodStatTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            foodStatTextBox.Name = "foodStatTextBox";
            foodStatTextBox.ReadOnly = true;
            foodStatTextBox.Size = new Size(137, 15);
            foodStatTextBox.TabIndex = 5;
            foodStatTextBox.Text = "";
            // 
            // entityStatLabel
            // 
            entityStatLabel.AutoSize = true;
            entityStatLabel.Location = new Point(5, 29);
            entityStatLabel.Name = "entityStatLabel";
            entityStatLabel.Size = new Size(48, 15);
            entityStatLabel.TabIndex = 3;
            entityStatLabel.Text = "Entities:";
            // 
            // foodStatLabel
            // 
            foodStatLabel.AutoSize = true;
            foodStatLabel.Location = new Point(5, 55);
            foodStatLabel.Name = "foodStatLabel";
            foodStatLabel.Size = new Size(37, 15);
            foodStatLabel.TabIndex = 4;
            foodStatLabel.Text = "Food:";
            // 
            // entityStatTextBox
            // 
            entityStatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            entityStatTextBox.Location = new Point(63, 29);
            entityStatTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            entityStatTextBox.Name = "entityStatTextBox";
            entityStatTextBox.ReadOnly = true;
            entityStatTextBox.Size = new Size(137, 15);
            entityStatTextBox.TabIndex = 5;
            entityStatTextBox.Text = "";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new Point(118, 12);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new Size(79, 15);
            lastUpdatedLabel.TabIndex = 2;
            lastUpdatedLabel.Text = "Last Updated:";
            // 
            // currentDayLabel
            // 
            currentDayLabel.AutoSize = true;
            currentDayLabel.Location = new Point(10, 84);
            currentDayLabel.Name = "currentDayLabel";
            currentDayLabel.Size = new Size(72, 15);
            currentDayLabel.TabIndex = 1;
            currentDayLabel.Text = "Current day:";
            // 
            // debugCheckBox
            // 
            debugCheckBox.AutoSize = true;
            debugCheckBox.Location = new Point(6, 11);
            debugCheckBox.Name = "debugCheckBox";
            debugCheckBox.Size = new Size(95, 19);
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
            tabControl1.Controls.Add(graphTab);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(407, 565);
            tabControl1.TabIndex = 8;
            // 
            // graphTab
            // 
            graphTab.AutoScroll = true;
            graphTab.Controls.Add(panel4);
            graphTab.Controls.Add(panel2);
            graphTab.Controls.Add(panel1);
            graphTab.Location = new Point(4, 24);
            graphTab.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            graphTab.Name = "graphTab";
            graphTab.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            graphTab.Size = new Size(399, 537);
            graphTab.TabIndex = 3;
            graphTab.Text = "Graphs";
            graphTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(renderFoodByDay);
            panel2.Controls.Add(foodByDayGraph);
            panel2.Location = new Point(0, 196);
            panel2.Name = "panel2";
            panel2.Size = new Size(382, 190);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(checkBox1);
            panel3.Controls.Add(formsPlot1);
            panel3.Location = new Point(0, 196);
            panel3.Name = "panel3";
            panel3.Size = new Size(376, 190);
            panel3.TabIndex = 4;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(55, 6);
            checkBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(63, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Render";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(0, 14);
            formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(382, 176);
            formsPlot1.TabIndex = 0;
            // 
            // renderFoodByDay
            // 
            renderFoodByDay.AutoSize = true;
            renderFoodByDay.Location = new Point(55, 6);
            renderFoodByDay.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            renderFoodByDay.Name = "renderFoodByDay";
            renderFoodByDay.Size = new Size(63, 19);
            renderFoodByDay.TabIndex = 1;
            renderFoodByDay.Text = "Render";
            renderFoodByDay.UseVisualStyleBackColor = true;
            // 
            // foodByDayGraph
            // 
            foodByDayGraph.Location = new Point(4, 18);
            foodByDayGraph.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            foodByDayGraph.Name = "foodByDayGraph";
            foodByDayGraph.Size = new Size(374, 169);
            foodByDayGraph.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(renderEntitiesByDay);
            panel1.Controls.Add(entitiesbyDayGraph);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 190);
            panel1.TabIndex = 2;
            // 
            // renderEntitiesByDay
            // 
            renderEntitiesByDay.AutoSize = true;
            renderEntitiesByDay.Location = new Point(55, 6);
            renderEntitiesByDay.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            renderEntitiesByDay.Name = "renderEntitiesByDay";
            renderEntitiesByDay.Size = new Size(63, 19);
            renderEntitiesByDay.TabIndex = 1;
            renderEntitiesByDay.Text = "Render";
            renderEntitiesByDay.UseVisualStyleBackColor = true;
            // 
            // entitiesbyDayGraph
            // 
            entitiesbyDayGraph.Location = new Point(4, 14);
            entitiesbyDayGraph.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entitiesbyDayGraph.Name = "entitiesbyDayGraph";
            entitiesbyDayGraph.Size = new Size(374, 173);
            entitiesbyDayGraph.TabIndex = 0;
            // 
            // alwaysOnPanel
            // 
            alwaysOnPanel.Controls.Add(upsLabel);
            alwaysOnPanel.Controls.Add(restartButton);
            alwaysOnPanel.Controls.Add(fpsLabel);
            alwaysOnPanel.Controls.Add(cursorCoordinate);
            alwaysOnPanel.Controls.Add(nearestEntityTextBox);
            alwaysOnPanel.Controls.Add(nearestEntityLabel);
            alwaysOnPanel.Location = new Point(457, 34);
            alwaysOnPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            alwaysOnPanel.Name = "alwaysOnPanel";
            alwaysOnPanel.Size = new Size(207, 254);
            alwaysOnPanel.TabIndex = 11;
            // 
            // averageSpeedGraph
            // 
            averageSpeedGraph.Location = new Point(4, 14);
            averageSpeedGraph.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            averageSpeedGraph.Name = "averageSpeedGraph";
            averageSpeedGraph.Size = new Size(374, 173);
            averageSpeedGraph.TabIndex = 0;
            // 
            // renderAvegrageSpeed
            // 
            renderAvegrageSpeed.AutoSize = true;
            renderAvegrageSpeed.Location = new Point(55, 6);
            renderAvegrageSpeed.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            renderAvegrageSpeed.Name = "renderAvegrageSpeed";
            renderAvegrageSpeed.Size = new Size(63, 19);
            renderAvegrageSpeed.TabIndex = 1;
            renderAvegrageSpeed.Text = "Render";
            renderAvegrageSpeed.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(renderAvegrageSpeed);
            panel4.Controls.Add(averageSpeedGraph);
            panel4.Location = new Point(0, 392);
            panel4.Name = "panel4";
            panel4.Size = new Size(382, 190);
            panel4.TabIndex = 3;
            // 
            // SettingsManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new Size(692, 589);
            Controls.Add(alwaysOnPanel);
            Controls.Add(tabControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
            graphTab.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            alwaysOnPanel.ResumeLayout(false);
            alwaysOnPanel.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private System.Windows.Forms.TabPage graphTab;
        private ScottPlot.FormsPlot entitiesbyDayGraph;
        private System.Windows.Forms.CheckBox renderEntitiesByDay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ScottPlot.FormsPlot foodByDayGraph;
        private System.Windows.Forms.CheckBox renderFoodByDay;
        private System.Windows.Forms.CheckBox drawEnabledCheckBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox1;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox renderAvegrageSpeed;
        private ScottPlot.FormsPlot averageSpeedGraph;
    }
}
