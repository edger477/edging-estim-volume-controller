namespace VolumeController
{
    partial class VolumeController
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
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.btn_ResetSensor = new System.Windows.Forms.Button();
            this.selectSensorBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this._availableSensors = new System.Windows.Forms.ComboBox();
            this.lbOutDevice = new System.Windows.Forms.Label();
            this.cbOutputDevice = new System.Windows.Forms.ComboBox();
            this.groupBox_volumeSettings = new System.Windows.Forms.GroupBox();
            this.numChgStepUp = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numChgStepDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numChangeFreq = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numMinVol = new System.Windows.Forms.NumericUpDown();
            this.numMaxVol = new System.Windows.Forms.NumericUpDown();
            this.lbBaseFreq = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numHRAverageWindow = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numHRDesired = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numHRMin = new System.Windows.Forms.NumericUpDown();
            this.numHRMax = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_currentVolume = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_heartRateAverage = new System.Windows.Forms.Label();
            this.label_heartRate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxSettings.SuspendLayout();
            this.groupBox_volumeSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgStepUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChgStepDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxVol)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHRAverageWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHRDesired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHRMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHRMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.btn_ResetSensor);
            this.groupBoxSettings.Controls.Add(this.selectSensorBtn);
            this.groupBoxSettings.Controls.Add(this.label10);
            this.groupBoxSettings.Controls.Add(this._availableSensors);
            this.groupBoxSettings.Controls.Add(this.lbOutDevice);
            this.groupBoxSettings.Controls.Add(this.cbOutputDevice);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(716, 56);
            this.groupBoxSettings.TabIndex = 1;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // btn_ResetSensor
            // 
            this.btn_ResetSensor.Location = new System.Drawing.Point(655, 17);
            this.btn_ResetSensor.Name = "btn_ResetSensor";
            this.btn_ResetSensor.Size = new System.Drawing.Size(55, 23);
            this.btn_ResetSensor.TabIndex = 5;
            this.btn_ResetSensor.Text = "Reset";
            this.btn_ResetSensor.UseVisualStyleBackColor = true;
            this.btn_ResetSensor.Visible = false;
            this.btn_ResetSensor.Click += new System.EventHandler(this.btn_ResetSensor_Click);
            // 
            // selectSensorBtn
            // 
            this.selectSensorBtn.Location = new System.Drawing.Point(654, 17);
            this.selectSensorBtn.Name = "selectSensorBtn";
            this.selectSensorBtn.Size = new System.Drawing.Size(55, 23);
            this.selectSensorBtn.TabIndex = 4;
            this.selectSensorBtn.Text = "Select";
            this.selectSensorBtn.UseVisualStyleBackColor = true;
            this.selectSensorBtn.Click += new System.EventHandler(this.selectSensor);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(386, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Sensor";
            // 
            // _availableSensors
            // 
            this._availableSensors.FormattingEnabled = true;
            this._availableSensors.Location = new System.Drawing.Point(432, 19);
            this._availableSensors.Name = "_availableSensors";
            this._availableSensors.Size = new System.Drawing.Size(216, 21);
            this._availableSensors.TabIndex = 2;
            this._availableSensors.MouseClick += new System.Windows.Forms.MouseEventHandler(this._availableSensors_MouseClick);
            // 
            // lbOutDevice
            // 
            this.lbOutDevice.AutoSize = true;
            this.lbOutDevice.Location = new System.Drawing.Point(6, 22);
            this.lbOutDevice.Name = "lbOutDevice";
            this.lbOutDevice.Size = new System.Drawing.Size(76, 13);
            this.lbOutDevice.TabIndex = 1;
            this.lbOutDevice.Text = "Output Device";
            // 
            // cbOutputDevice
            // 
            this.cbOutputDevice.FormattingEnabled = true;
            this.cbOutputDevice.Location = new System.Drawing.Point(88, 19);
            this.cbOutputDevice.Name = "cbOutputDevice";
            this.cbOutputDevice.Size = new System.Drawing.Size(266, 21);
            this.cbOutputDevice.TabIndex = 0;
            this.cbOutputDevice.SelectedIndexChanged += new System.EventHandler(this.cbOutputDevice_SelectedIndexChanged);
            // 
            // groupBox_volumeSettings
            // 
            this.groupBox_volumeSettings.Controls.Add(this.label11);
            this.groupBox_volumeSettings.Controls.Add(this.numChgStepUp);
            this.groupBox_volumeSettings.Controls.Add(this.label4);
            this.groupBox_volumeSettings.Controls.Add(this.numChgStepDown);
            this.groupBox_volumeSettings.Controls.Add(this.label3);
            this.groupBox_volumeSettings.Controls.Add(this.numChangeFreq);
            this.groupBox_volumeSettings.Controls.Add(this.label2);
            this.groupBox_volumeSettings.Controls.Add(this.label1);
            this.groupBox_volumeSettings.Controls.Add(this.numMinVol);
            this.groupBox_volumeSettings.Controls.Add(this.numMaxVol);
            this.groupBox_volumeSettings.Controls.Add(this.lbBaseFreq);
            this.groupBox_volumeSettings.Location = new System.Drawing.Point(13, 74);
            this.groupBox_volumeSettings.Name = "groupBox_volumeSettings";
            this.groupBox_volumeSettings.Size = new System.Drawing.Size(359, 165);
            this.groupBox_volumeSettings.TabIndex = 2;
            this.groupBox_volumeSettings.TabStop = false;
            this.groupBox_volumeSettings.Text = "Volume settings";
            // 
            // numChgStepUp
            // 
            this.numChgStepUp.DecimalPlaces = 1;
            this.numChgStepUp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numChgStepUp.Location = new System.Drawing.Point(123, 123);
            this.numChgStepUp.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numChgStepUp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numChgStepUp.Name = "numChgStepUp";
            this.numChgStepUp.Size = new System.Drawing.Size(96, 20);
            this.numChgStepUp.TabIndex = 7;
            this.numChgStepUp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Change Step (up)";
            // 
            // numChgStepDown
            // 
            this.numChgStepDown.DecimalPlaces = 1;
            this.numChgStepDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numChgStepDown.Location = new System.Drawing.Point(123, 97);
            this.numChgStepDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numChgStepDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numChgStepDown.Name = "numChgStepDown";
            this.numChgStepDown.Size = new System.Drawing.Size(96, 20);
            this.numChgStepDown.TabIndex = 4;
            this.numChgStepDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Change Step (down)";
            // 
            // numChangeFreq
            // 
            this.numChangeFreq.Enabled = false;
            this.numChangeFreq.Location = new System.Drawing.Point(123, 71);
            this.numChangeFreq.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numChangeFreq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChangeFreq.Name = "numChangeFreq";
            this.numChangeFreq.Size = new System.Drawing.Size(96, 20);
            this.numChangeFreq.TabIndex = 3;
            this.numChangeFreq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stop regulating after";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Min";
            // 
            // numMinVol
            // 
            this.numMinVol.Location = new System.Drawing.Point(123, 45);
            this.numMinVol.Name = "numMinVol";
            this.numMinVol.Size = new System.Drawing.Size(96, 20);
            this.numMinVol.TabIndex = 2;
            this.numMinVol.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numMaxVol
            // 
            this.numMaxVol.Location = new System.Drawing.Point(123, 18);
            this.numMaxVol.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMaxVol.Name = "numMaxVol";
            this.numMaxVol.Size = new System.Drawing.Size(96, 20);
            this.numMaxVol.TabIndex = 1;
            this.numMaxVol.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxVol.ValueChanged += new System.EventHandler(this.numMaxVol_ValueChanged);
            // 
            // lbBaseFreq
            // 
            this.lbBaseFreq.AutoSize = true;
            this.lbBaseFreq.Location = new System.Drawing.Point(9, 20);
            this.lbBaseFreq.Name = "lbBaseFreq";
            this.lbBaseFreq.Size = new System.Drawing.Size(27, 13);
            this.lbBaseFreq.TabIndex = 0;
            this.lbBaseFreq.Text = "Max";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numHRAverageWindow);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numHRDesired);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numHRMin);
            this.groupBox2.Controls.Add(this.numHRMax);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(392, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 164);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Heart Rate Settings";
            // 
            // numHRAverageWindow
            // 
            this.numHRAverageWindow.Location = new System.Drawing.Point(120, 97);
            this.numHRAverageWindow.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numHRAverageWindow.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numHRAverageWindow.Name = "numHRAverageWindow";
            this.numHRAverageWindow.Size = new System.Drawing.Size(96, 20);
            this.numHRAverageWindow.TabIndex = 14;
            this.numHRAverageWindow.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Average Window";
            // 
            // numHRDesired
            // 
            this.numHRDesired.Location = new System.Drawing.Point(120, 71);
            this.numHRDesired.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numHRDesired.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numHRDesired.Name = "numHRDesired";
            this.numHRDesired.Size = new System.Drawing.Size(96, 20);
            this.numHRDesired.TabIndex = 12;
            this.numHRDesired.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Desired";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Min";
            // 
            // numHRMin
            // 
            this.numHRMin.Location = new System.Drawing.Point(120, 45);
            this.numHRMin.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numHRMin.Name = "numHRMin";
            this.numHRMin.Size = new System.Drawing.Size(96, 20);
            this.numHRMin.TabIndex = 11;
            this.numHRMin.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numHRMax
            // 
            this.numHRMax.Location = new System.Drawing.Point(120, 18);
            this.numHRMax.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.numHRMax.Minimum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numHRMax.Name = "numHRMax";
            this.numHRMax.Size = new System.Drawing.Size(96, 20);
            this.numHRMax.TabIndex = 10;
            this.numHRMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Max";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_currentVolume);
            this.groupBox1.Location = new System.Drawing.Point(13, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 193);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volume Info";
            // 
            // label_currentVolume
            // 
            this.label_currentVolume.AutoSize = true;
            this.label_currentVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentVolume.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_currentVolume.Location = new System.Drawing.Point(12, 34);
            this.label_currentVolume.Name = "label_currentVolume";
            this.label_currentVolume.Size = new System.Drawing.Size(69, 76);
            this.label_currentVolume.TabIndex = 1;
            this.label_currentVolume.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_heartRateAverage);
            this.groupBox3.Controls.Add(this.label_heartRate);
            this.groupBox3.Location = new System.Drawing.Point(392, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 193);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HR Info";
            // 
            // label_heartRateAverage
            // 
            this.label_heartRateAverage.AutoSize = true;
            this.label_heartRateAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_heartRateAverage.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_heartRateAverage.Location = new System.Drawing.Point(169, 34);
            this.label_heartRateAverage.Name = "label_heartRateAverage";
            this.label_heartRateAverage.Size = new System.Drawing.Size(69, 76);
            this.label_heartRateAverage.TabIndex = 1;
            this.label_heartRateAverage.Text = "0";
            // 
            // label_heartRate
            // 
            this.label_heartRate.AutoSize = true;
            this.label_heartRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_heartRate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_heartRate.Location = new System.Drawing.Point(20, 34);
            this.label_heartRate.Name = "label_heartRate";
            this.label_heartRate.Size = new System.Drawing.Size(69, 76);
            this.label_heartRate.TabIndex = 0;
            this.label_heartRate.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(225, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "minutes";
            // 
            // VolumeController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_volumeSettings);
            this.Controls.Add(this.groupBoxSettings);
            this.Name = "VolumeController";
            this.Text = "Volume Controller";
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.groupBox_volumeSettings.ResumeLayout(false);
            this.groupBox_volumeSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgStepUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChgStepDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxVol)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHRAverageWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHRDesired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHRMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHRMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label lbOutDevice;
        private System.Windows.Forms.ComboBox cbOutputDevice;
        private System.Windows.Forms.GroupBox groupBox_volumeSettings;
        private System.Windows.Forms.NumericUpDown numChangeFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMinVol;
        private System.Windows.Forms.NumericUpDown numMaxVol;
        private System.Windows.Forms.Label lbBaseFreq;
        private System.Windows.Forms.NumericUpDown numChgStepDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numChgStepUp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numHRAverageWindow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numHRDesired;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numHRMin;
        private System.Windows.Forms.NumericUpDown numHRMax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button selectSensorBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox _availableSensors;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_heartRate;
        private System.Windows.Forms.Label label_currentVolume;
        private System.Windows.Forms.Button btn_ResetSensor;
        private System.Windows.Forms.Label label_heartRateAverage;
        private System.Windows.Forms.Label label11;
    }
}

