﻿namespace GUI_REV_3
{
    partial class Form1
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
            this.SerialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SensorsPanel = new System.Windows.Forms.Panel();
            this.plotClear = new System.Windows.Forms.Button();
            this.GHTemperatureValue = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.SerialSearch = new System.Windows.Forms.Button();
            this.SerialPortSelect = new System.Windows.Forms.ComboBox();
            this.SerialConnect = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SerialDisconnect = new System.Windows.Forms.Button();
            this.SlaveFrequencyValue = new System.Windows.Forms.Label();
            this.WeightValue = new System.Windows.Forms.Label();
            this.SlaveFrequencyLabel = new System.Windows.Forms.Label();
            this.TemperatureValue = new System.Windows.Forms.Label();
            this.PressureValue = new System.Windows.Forms.Label();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.TemperatureLabel = new System.Windows.Forms.Label();
            this.PressureLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pumpIdle = new System.Windows.Forms.Button();
            this.PumpIndicator = new System.Windows.Forms.Label();
            this.pumpSpeedBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PumpSpeedInput = new System.Windows.Forms.NumericUpDown();
            this.pumpPressBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.PumpPressureInput = new System.Windows.Forms.NumericUpDown();
            this.pumpOffBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PIDReset = new System.Windows.Forms.Button();
            this.ZeroScale = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.stayHot = new System.Windows.Forms.CheckBox();
            this.HeaterIndicator = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TempOffButton = new System.Windows.Forms.Button();
            this.TempOnButton = new System.Windows.Forms.Button();
            this.tempInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.valveExtract = new System.Windows.Forms.Button();
            this.valveIdle = new System.Windows.Forms.Button();
            this.ghClose = new System.Windows.Forms.Button();
            this.ghOpen = new System.Windows.Forms.Button();
            this.loopClose = new System.Windows.Forms.Button();
            this.loopOpen = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GHValveIndicator = new System.Windows.Forms.Label();
            this.LoopValveIndicator = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.AS_PF_SPEED = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.AS_TIMER_DISPLAY = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.AS_RD_PRESSURE = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.AS_PF_PRESSURE = new System.Windows.Forms.NumericUpDown();
            this.AS_PB_Duration = new System.Windows.Forms.NumericUpDown();
            this.AS_INDICATOR = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.AS_BREW_PRESSURE = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.AS_PF_DURATION = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AS_STOP = new System.Windows.Forms.Button();
            this.AS_START = new System.Windows.Forms.Button();
            this.AS_Timer = new System.Windows.Forms.Timer(this.components);
            this.SensorsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PumpSpeedInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PumpPressureInput)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempInput)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AS_PF_SPEED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_RD_PRESSURE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_PF_PRESSURE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_PB_Duration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_BREW_PRESSURE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_PF_DURATION)).BeginInit();
            this.SuspendLayout();
            // 
            // SerialPort1
            // 
            this.SerialPort1.BaudRate = 115200;
            this.SerialPort1.PortName = "COM5";
            this.SerialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // SensorsPanel
            // 
            this.SensorsPanel.BackColor = System.Drawing.Color.White;
            this.SensorsPanel.Controls.Add(this.plotClear);
            this.SensorsPanel.Controls.Add(this.GHTemperatureValue);
            this.SensorsPanel.Controls.Add(this.label18);
            this.SensorsPanel.Controls.Add(this.SerialSearch);
            this.SensorsPanel.Controls.Add(this.SerialPortSelect);
            this.SensorsPanel.Controls.Add(this.SerialConnect);
            this.SensorsPanel.Controls.Add(this.label10);
            this.SensorsPanel.Controls.Add(this.SerialDisconnect);
            this.SensorsPanel.Controls.Add(this.SlaveFrequencyValue);
            this.SensorsPanel.Controls.Add(this.WeightValue);
            this.SensorsPanel.Controls.Add(this.SlaveFrequencyLabel);
            this.SensorsPanel.Controls.Add(this.TemperatureValue);
            this.SensorsPanel.Controls.Add(this.PressureValue);
            this.SensorsPanel.Controls.Add(this.WeightLabel);
            this.SensorsPanel.Controls.Add(this.TemperatureLabel);
            this.SensorsPanel.Controls.Add(this.PressureLabel);
            this.SensorsPanel.Location = new System.Drawing.Point(7, 9);
            this.SensorsPanel.Name = "SensorsPanel";
            this.SensorsPanel.Size = new System.Drawing.Size(693, 69);
            this.SensorsPanel.TabIndex = 1;
            // 
            // plotClear
            // 
            this.plotClear.Location = new System.Drawing.Point(316, 12);
            this.plotClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plotClear.Name = "plotClear";
            this.plotClear.Size = new System.Drawing.Size(53, 46);
            this.plotClear.TabIndex = 35;
            this.plotClear.Text = "RESET PLOTS";
            this.plotClear.UseVisualStyleBackColor = true;
            this.plotClear.Click += new System.EventHandler(this.plotClear_Click);
            // 
            // GHTemperatureValue
            // 
            this.GHTemperatureValue.AutoSize = true;
            this.GHTemperatureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GHTemperatureValue.Location = new System.Drawing.Point(248, 31);
            this.GHTemperatureValue.Name = "GHTemperatureValue";
            this.GHTemperatureValue.Size = new System.Drawing.Size(14, 15);
            this.GHTemperatureValue.TabIndex = 34;
            this.GHTemperatureValue.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(139, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 15);
            this.label18.TabIndex = 33;
            this.label18.Text = "GH Temperature: ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SerialSearch
            // 
            this.SerialSearch.Location = new System.Drawing.Point(609, 6);
            this.SerialSearch.Name = "SerialSearch";
            this.SerialSearch.Size = new System.Drawing.Size(67, 23);
            this.SerialSearch.TabIndex = 32;
            this.SerialSearch.Text = "SEARCH";
            this.SerialSearch.UseVisualStyleBackColor = true;
            this.SerialSearch.Click += new System.EventHandler(this.SerialSearch_Click);
            // 
            // SerialPortSelect
            // 
            this.SerialPortSelect.FormattingEnabled = true;
            this.SerialPortSelect.Location = new System.Drawing.Point(547, 9);
            this.SerialPortSelect.Name = "SerialPortSelect";
            this.SerialPortSelect.Size = new System.Drawing.Size(61, 21);
            this.SerialPortSelect.TabIndex = 31;
            this.SerialPortSelect.Text = "COM3";
            // 
            // SerialConnect
            // 
            this.SerialConnect.Location = new System.Drawing.Point(588, 31);
            this.SerialConnect.Name = "SerialConnect";
            this.SerialConnect.Size = new System.Drawing.Size(88, 23);
            this.SerialConnect.TabIndex = 29;
            this.SerialConnect.Text = "CONNECT";
            this.SerialConnect.UseVisualStyleBackColor = true;
            this.SerialConnect.Click += new System.EventHandler(this.SerialConnect_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(494, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "PORT: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SerialDisconnect
            // 
            this.SerialDisconnect.Location = new System.Drawing.Point(494, 31);
            this.SerialDisconnect.Name = "SerialDisconnect";
            this.SerialDisconnect.Size = new System.Drawing.Size(88, 23);
            this.SerialDisconnect.TabIndex = 26;
            this.SerialDisconnect.Text = "DISCONNECT";
            this.SerialDisconnect.UseVisualStyleBackColor = true;
            this.SerialDisconnect.Click += new System.EventHandler(this.SerialDisconnect_Click);
            // 
            // SlaveFrequencyValue
            // 
            this.SlaveFrequencyValue.AutoSize = true;
            this.SlaveFrequencyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlaveFrequencyValue.Location = new System.Drawing.Point(98, 48);
            this.SlaveFrequencyValue.Name = "SlaveFrequencyValue";
            this.SlaveFrequencyValue.Size = new System.Drawing.Size(14, 15);
            this.SlaveFrequencyValue.TabIndex = 15;
            this.SlaveFrequencyValue.Text = "0";
            // 
            // WeightValue
            // 
            this.WeightValue.AutoSize = true;
            this.WeightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightValue.Location = new System.Drawing.Point(98, 28);
            this.WeightValue.Name = "WeightValue";
            this.WeightValue.Size = new System.Drawing.Size(14, 15);
            this.WeightValue.TabIndex = 14;
            this.WeightValue.Text = "0";
            // 
            // SlaveFrequencyLabel
            // 
            this.SlaveFrequencyLabel.AutoSize = true;
            this.SlaveFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlaveFrequencyLabel.Location = new System.Drawing.Point(6, 47);
            this.SlaveFrequencyLabel.Name = "SlaveFrequencyLabel";
            this.SlaveFrequencyLabel.Size = new System.Drawing.Size(81, 15);
            this.SlaveFrequencyLabel.TabIndex = 9;
            this.SlaveFrequencyLabel.Text = "Sensor Rate: ";
            this.SlaveFrequencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TemperatureValue
            // 
            this.TemperatureValue.AutoSize = true;
            this.TemperatureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureValue.Location = new System.Drawing.Point(248, 14);
            this.TemperatureValue.Name = "TemperatureValue";
            this.TemperatureValue.Size = new System.Drawing.Size(14, 15);
            this.TemperatureValue.TabIndex = 13;
            this.TemperatureValue.Text = "0";
            // 
            // PressureValue
            // 
            this.PressureValue.AutoSize = true;
            this.PressureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressureValue.Location = new System.Drawing.Point(98, 9);
            this.PressureValue.Name = "PressureValue";
            this.PressureValue.Size = new System.Drawing.Size(14, 15);
            this.PressureValue.TabIndex = 12;
            this.PressureValue.Text = "0";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightLabel.Location = new System.Drawing.Point(34, 27);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(51, 15);
            this.WeightLabel.TabIndex = 8;
            this.WeightLabel.Text = "Weight: ";
            this.WeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TemperatureLabel
            // 
            this.TemperatureLabel.AutoSize = true;
            this.TemperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureLabel.Location = new System.Drawing.Point(159, 13);
            this.TemperatureLabel.Name = "TemperatureLabel";
            this.TemperatureLabel.Size = new System.Drawing.Size(84, 15);
            this.TemperatureLabel.TabIndex = 7;
            this.TemperatureLabel.Text = "Temperature: ";
            this.TemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PressureLabel
            // 
            this.PressureLabel.AutoSize = true;
            this.PressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressureLabel.Location = new System.Drawing.Point(23, 10);
            this.PressureLabel.Name = "PressureLabel";
            this.PressureLabel.Size = new System.Drawing.Size(62, 15);
            this.PressureLabel.TabIndex = 6;
            this.PressureLabel.Text = "Pressure: ";
            this.PressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(9, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 241);
            this.panel1.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pumpIdle);
            this.panel3.Controls.Add(this.PumpIndicator);
            this.panel3.Controls.Add(this.pumpSpeedBtn);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.PumpSpeedInput);
            this.panel3.Controls.Add(this.pumpPressBtn);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.PumpPressureInput);
            this.panel3.Controls.Add(this.pumpOffBtn);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(170, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(139, 215);
            this.panel3.TabIndex = 20;
            // 
            // pumpIdle
            // 
            this.pumpIdle.Location = new System.Drawing.Point(3, 187);
            this.pumpIdle.Name = "pumpIdle";
            this.pumpIdle.Size = new System.Drawing.Size(122, 23);
            this.pumpIdle.TabIndex = 34;
            this.pumpIdle.Text = "PUMP IDLE";
            this.pumpIdle.UseVisualStyleBackColor = true;
            this.pumpIdle.Click += new System.EventHandler(this.pumpIdle_Click);
            // 
            // PumpIndicator
            // 
            this.PumpIndicator.AutoSize = true;
            this.PumpIndicator.BackColor = System.Drawing.Color.Red;
            this.PumpIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PumpIndicator.ForeColor = System.Drawing.Color.White;
            this.PumpIndicator.Location = new System.Drawing.Point(33, 37);
            this.PumpIndicator.Name = "PumpIndicator";
            this.PumpIndicator.Size = new System.Drawing.Size(77, 15);
            this.PumpIndicator.TabIndex = 26;
            this.PumpIndicator.Text = "PUMP OFF";
            this.PumpIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pumpSpeedBtn
            // 
            this.pumpSpeedBtn.Location = new System.Drawing.Point(7, 64);
            this.pumpSpeedBtn.Name = "pumpSpeedBtn";
            this.pumpSpeedBtn.Size = new System.Drawing.Size(122, 23);
            this.pumpSpeedBtn.TabIndex = 33;
            this.pumpSpeedBtn.Text = "PUMP SPEED";
            this.pumpSpeedBtn.UseVisualStyleBackColor = true;
            this.pumpSpeedBtn.Click += new System.EventHandler(this.pumpSpeedBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Speed:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PumpSpeedInput
            // 
            this.PumpSpeedInput.DecimalPlaces = 1;
            this.PumpSpeedInput.Location = new System.Drawing.Point(74, 90);
            this.PumpSpeedInput.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.PumpSpeedInput.Name = "PumpSpeedInput";
            this.PumpSpeedInput.Size = new System.Drawing.Size(50, 20);
            this.PumpSpeedInput.TabIndex = 32;
            this.PumpSpeedInput.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // pumpPressBtn
            // 
            this.pumpPressBtn.Location = new System.Drawing.Point(7, 108);
            this.pumpPressBtn.Name = "pumpPressBtn";
            this.pumpPressBtn.Size = new System.Drawing.Size(122, 23);
            this.pumpPressBtn.TabIndex = 30;
            this.pumpPressBtn.Text = "PRESSURE SET";
            this.pumpPressBtn.UseVisualStyleBackColor = true;
            this.pumpPressBtn.Click += new System.EventHandler(this.pumpPressBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Pressure:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PumpPressureInput
            // 
            this.PumpPressureInput.DecimalPlaces = 1;
            this.PumpPressureInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.PumpPressureInput.Location = new System.Drawing.Point(74, 134);
            this.PumpPressureInput.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.PumpPressureInput.Name = "PumpPressureInput";
            this.PumpPressureInput.Size = new System.Drawing.Size(50, 20);
            this.PumpPressureInput.TabIndex = 29;
            this.PumpPressureInput.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // pumpOffBtn
            // 
            this.pumpOffBtn.Location = new System.Drawing.Point(3, 159);
            this.pumpOffBtn.Name = "pumpOffBtn";
            this.pumpOffBtn.Size = new System.Drawing.Size(122, 23);
            this.pumpOffBtn.TabIndex = 23;
            this.pumpOffBtn.Text = "PUMP OFF";
            this.pumpOffBtn.UseVisualStyleBackColor = true;
            this.pumpOffBtn.Click += new System.EventHandler(this.pumpOffBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Pump Control";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.PIDReset);
            this.panel5.Controls.Add(this.ZeroScale);
            this.panel5.Location = new System.Drawing.Point(15, 159);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(139, 70);
            this.panel5.TabIndex = 19;
            // 
            // PIDReset
            // 
            this.PIDReset.Location = new System.Drawing.Point(19, 36);
            this.PIDReset.Name = "PIDReset";
            this.PIDReset.Size = new System.Drawing.Size(105, 23);
            this.PIDReset.TabIndex = 37;
            this.PIDReset.Text = "RESET PID";
            this.PIDReset.UseVisualStyleBackColor = true;
            this.PIDReset.Click += new System.EventHandler(this.PIDReset_Click);
            // 
            // ZeroScale
            // 
            this.ZeroScale.Location = new System.Drawing.Point(18, 7);
            this.ZeroScale.Name = "ZeroScale";
            this.ZeroScale.Size = new System.Drawing.Size(105, 23);
            this.ZeroScale.TabIndex = 36;
            this.ZeroScale.Text = "ZERO SCALE";
            this.ZeroScale.UseVisualStyleBackColor = true;
            this.ZeroScale.Click += new System.EventHandler(this.ZeroScale_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.stayHot);
            this.panel2.Controls.Add(this.HeaterIndicator);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TempOffButton);
            this.panel2.Controls.Add(this.TempOnButton);
            this.panel2.Controls.Add(this.tempInput);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(15, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 132);
            this.panel2.TabIndex = 19;
            // 
            // stayHot
            // 
            this.stayHot.AutoSize = true;
            this.stayHot.Checked = true;
            this.stayHot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stayHot.Location = new System.Drawing.Point(24, 76);
            this.stayHot.Name = "stayHot";
            this.stayHot.Size = new System.Drawing.Size(67, 17);
            this.stayHot.TabIndex = 26;
            this.stayHot.Text = "Stay Hot";
            this.stayHot.UseVisualStyleBackColor = true;
            // 
            // HeaterIndicator
            // 
            this.HeaterIndicator.AutoSize = true;
            this.HeaterIndicator.BackColor = System.Drawing.Color.Red;
            this.HeaterIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaterIndicator.ForeColor = System.Drawing.Color.White;
            this.HeaterIndicator.Location = new System.Drawing.Point(21, 31);
            this.HeaterIndicator.Name = "HeaterIndicator";
            this.HeaterIndicator.Size = new System.Drawing.Size(91, 15);
            this.HeaterIndicator.TabIndex = 23;
            this.HeaterIndicator.Text = "HEATER OFF";
            this.HeaterIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Set Point:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TempOffButton
            // 
            this.TempOffButton.Location = new System.Drawing.Point(71, 99);
            this.TempOffButton.Name = "TempOffButton";
            this.TempOffButton.Size = new System.Drawing.Size(54, 23);
            this.TempOffButton.TabIndex = 24;
            this.TempOffButton.Text = "OFF";
            this.TempOffButton.UseVisualStyleBackColor = true;
            this.TempOffButton.Click += new System.EventHandler(this.TempOffButton_Click);
            // 
            // TempOnButton
            // 
            this.TempOnButton.Location = new System.Drawing.Point(11, 99);
            this.TempOnButton.Name = "TempOnButton";
            this.TempOnButton.Size = new System.Drawing.Size(54, 23);
            this.TempOnButton.TabIndex = 23;
            this.TempOnButton.Text = "ON";
            this.TempOnButton.UseVisualStyleBackColor = true;
            this.TempOnButton.Click += new System.EventHandler(this.TempOnButton_Click);
            // 
            // tempInput
            // 
            this.tempInput.DecimalPlaces = 1;
            this.tempInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tempInput.Location = new System.Drawing.Point(74, 52);
            this.tempInput.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.tempInput.Minimum = new decimal(new int[] {
            85,
            0,
            0,
            0});
            this.tempInput.Name = "tempInput";
            this.tempInput.Size = new System.Drawing.Size(50, 20);
            this.tempInput.TabIndex = 25;
            this.tempInput.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Temp Control";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.valveExtract);
            this.panel4.Controls.Add(this.valveIdle);
            this.panel4.Controls.Add(this.ghClose);
            this.panel4.Controls.Add(this.ghOpen);
            this.panel4.Controls.Add(this.loopClose);
            this.panel4.Controls.Add(this.loopOpen);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.GHValveIndicator);
            this.panel4.Controls.Add(this.LoopValveIndicator);
            this.panel4.Location = new System.Drawing.Point(314, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(139, 215);
            this.panel4.TabIndex = 21;
            // 
            // valveExtract
            // 
            this.valveExtract.Location = new System.Drawing.Point(11, 160);
            this.valveExtract.Name = "valveExtract";
            this.valveExtract.Size = new System.Drawing.Size(122, 23);
            this.valveExtract.TabIndex = 36;
            this.valveExtract.Text = "VALVE EXTRACT";
            this.valveExtract.UseVisualStyleBackColor = true;
            this.valveExtract.Click += new System.EventHandler(this.valveExtract_Click);
            // 
            // valveIdle
            // 
            this.valveIdle.Location = new System.Drawing.Point(11, 183);
            this.valveIdle.Name = "valveIdle";
            this.valveIdle.Size = new System.Drawing.Size(122, 23);
            this.valveIdle.TabIndex = 35;
            this.valveIdle.Text = "VALVE IDLE";
            this.valveIdle.UseVisualStyleBackColor = true;
            this.valveIdle.Click += new System.EventHandler(this.valveIdle_Click);
            // 
            // ghClose
            // 
            this.ghClose.Location = new System.Drawing.Point(71, 62);
            this.ghClose.Name = "ghClose";
            this.ghClose.Size = new System.Drawing.Size(54, 23);
            this.ghClose.TabIndex = 22;
            this.ghClose.Text = "CLOSE";
            this.ghClose.UseVisualStyleBackColor = true;
            this.ghClose.Click += new System.EventHandler(this.ghClose_Click);
            // 
            // ghOpen
            // 
            this.ghOpen.Location = new System.Drawing.Point(11, 62);
            this.ghOpen.Name = "ghOpen";
            this.ghOpen.Size = new System.Drawing.Size(54, 23);
            this.ghOpen.TabIndex = 21;
            this.ghOpen.Text = "OPEN";
            this.ghOpen.UseVisualStyleBackColor = true;
            this.ghOpen.Click += new System.EventHandler(this.ghOpen_Click);
            // 
            // loopClose
            // 
            this.loopClose.Location = new System.Drawing.Point(73, 127);
            this.loopClose.Name = "loopClose";
            this.loopClose.Size = new System.Drawing.Size(54, 23);
            this.loopClose.TabIndex = 20;
            this.loopClose.Text = "CLOSE";
            this.loopClose.UseVisualStyleBackColor = true;
            this.loopClose.Click += new System.EventHandler(this.loopClose_Click);
            // 
            // loopOpen
            // 
            this.loopOpen.Location = new System.Drawing.Point(13, 127);
            this.loopOpen.Name = "loopOpen";
            this.loopOpen.Size = new System.Drawing.Size(54, 23);
            this.loopOpen.TabIndex = 19;
            this.loopOpen.Text = "OPEN";
            this.loopOpen.UseVisualStyleBackColor = true;
            this.loopOpen.Click += new System.EventHandler(this.loopOpen_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Valve Control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Loop:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Group Head:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GHValveIndicator
            // 
            this.GHValveIndicator.AutoSize = true;
            this.GHValveIndicator.BackColor = System.Drawing.Color.Red;
            this.GHValveIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GHValveIndicator.ForeColor = System.Drawing.Color.White;
            this.GHValveIndicator.Location = new System.Drawing.Point(48, 44);
            this.GHValveIndicator.Name = "GHValveIndicator";
            this.GHValveIndicator.Size = new System.Drawing.Size(62, 15);
            this.GHValveIndicator.TabIndex = 17;
            this.GHValveIndicator.Text = "CLOSED";
            this.GHValveIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoopValveIndicator
            // 
            this.LoopValveIndicator.AutoSize = true;
            this.LoopValveIndicator.BackColor = System.Drawing.Color.Green;
            this.LoopValveIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoopValveIndicator.ForeColor = System.Drawing.Color.White;
            this.LoopValveIndicator.Location = new System.Drawing.Point(54, 108);
            this.LoopValveIndicator.Name = "LoopValveIndicator";
            this.LoopValveIndicator.Size = new System.Drawing.Size(45, 15);
            this.LoopValveIndicator.TabIndex = 18;
            this.LoopValveIndicator.Text = "OPEN";
            this.LoopValveIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.label19);
            this.panel6.Controls.Add(this.AS_PF_SPEED);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.AS_TIMER_DISPLAY);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.AS_RD_PRESSURE);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.AS_PF_PRESSURE);
            this.panel6.Controls.Add(this.AS_PB_Duration);
            this.panel6.Controls.Add(this.AS_INDICATOR);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.AS_BREW_PRESSURE);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.AS_PF_DURATION);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.AS_STOP);
            this.panel6.Controls.Add(this.AS_START);
            this.panel6.Location = new System.Drawing.Point(481, 85);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(218, 241);
            this.panel6.TabIndex = 38;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(9, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 15);
            this.label19.TabIndex = 51;
            this.label19.Text = "Preinfusion Pressure: ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AS_PF_SPEED
            // 
            this.AS_PF_SPEED.DecimalPlaces = 1;
            this.AS_PF_SPEED.Location = new System.Drawing.Point(138, 28);
            this.AS_PF_SPEED.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.AS_PF_SPEED.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AS_PF_SPEED.Name = "AS_PF_SPEED";
            this.AS_PF_SPEED.Size = new System.Drawing.Size(50, 20);
            this.AS_PF_SPEED.TabIndex = 52;
            this.AS_PF_SPEED.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(35, 178);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 15);
            this.label17.TabIndex = 50;
            this.label17.Text = "Brew Time:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AS_TIMER_DISPLAY
            // 
            this.AS_TIMER_DISPLAY.AutoSize = true;
            this.AS_TIMER_DISPLAY.Location = new System.Drawing.Point(115, 178);
            this.AS_TIMER_DISPLAY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AS_TIMER_DISPLAY.Name = "AS_TIMER_DISPLAY";
            this.AS_TIMER_DISPLAY.Size = new System.Drawing.Size(13, 13);
            this.AS_TIMER_DISPLAY.TabIndex = 49;
            this.AS_TIMER_DISPLAY.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(10, 134);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 15);
            this.label16.TabIndex = 47;
            this.label16.Text = "Rampdown Pressure:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AS_RD_PRESSURE
            // 
            this.AS_RD_PRESSURE.DecimalPlaces = 1;
            this.AS_RD_PRESSURE.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AS_RD_PRESSURE.Location = new System.Drawing.Point(138, 134);
            this.AS_RD_PRESSURE.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.AS_RD_PRESSURE.Name = "AS_RD_PRESSURE";
            this.AS_RD_PRESSURE.Size = new System.Drawing.Size(50, 20);
            this.AS_RD_PRESSURE.TabIndex = 48;
            this.AS_RD_PRESSURE.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(44, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 15);
            this.label15.TabIndex = 45;
            this.label15.Text = "Peak Duration: ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AS_PF_PRESSURE
            // 
            this.AS_PF_PRESSURE.DecimalPlaces = 1;
            this.AS_PF_PRESSURE.Location = new System.Drawing.Point(138, 70);
            this.AS_PF_PRESSURE.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.AS_PF_PRESSURE.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AS_PF_PRESSURE.Name = "AS_PF_PRESSURE";
            this.AS_PF_PRESSURE.Size = new System.Drawing.Size(50, 20);
            this.AS_PF_PRESSURE.TabIndex = 40;
            this.AS_PF_PRESSURE.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // AS_PB_Duration
            // 
            this.AS_PB_Duration.DecimalPlaces = 1;
            this.AS_PB_Duration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AS_PB_Duration.Location = new System.Drawing.Point(138, 113);
            this.AS_PB_Duration.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.AS_PB_Duration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AS_PB_Duration.Name = "AS_PB_Duration";
            this.AS_PB_Duration.Size = new System.Drawing.Size(50, 20);
            this.AS_PB_Duration.TabIndex = 46;
            this.AS_PB_Duration.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // AS_INDICATOR
            // 
            this.AS_INDICATOR.AutoSize = true;
            this.AS_INDICATOR.BackColor = System.Drawing.Color.Red;
            this.AS_INDICATOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AS_INDICATOR.ForeColor = System.Drawing.Color.White;
            this.AS_INDICATOR.Location = new System.Drawing.Point(32, 159);
            this.AS_INDICATOR.Name = "AS_INDICATOR";
            this.AS_INDICATOR.Size = new System.Drawing.Size(152, 15);
            this.AS_INDICATOR.TabIndex = 26;
            this.AS_INDICATOR.Text = "AUTO SEQUENCE OFF";
            this.AS_INDICATOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(44, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 15);
            this.label14.TabIndex = 43;
            this.label14.Text = "Brew Pressure:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AS_BREW_PRESSURE
            // 
            this.AS_BREW_PRESSURE.DecimalPlaces = 1;
            this.AS_BREW_PRESSURE.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AS_BREW_PRESSURE.Location = new System.Drawing.Point(138, 91);
            this.AS_BREW_PRESSURE.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.AS_BREW_PRESSURE.Name = "AS_BREW_PRESSURE";
            this.AS_BREW_PRESSURE.Size = new System.Drawing.Size(50, 20);
            this.AS_BREW_PRESSURE.TabIndex = 44;
            this.AS_BREW_PRESSURE.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 15);
            this.label13.TabIndex = 41;
            this.label13.Text = "Preinfusion Timeout: ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AS_PF_DURATION
            // 
            this.AS_PF_DURATION.DecimalPlaces = 1;
            this.AS_PF_DURATION.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AS_PF_DURATION.Location = new System.Drawing.Point(138, 49);
            this.AS_PF_DURATION.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.AS_PF_DURATION.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AS_PF_DURATION.Name = "AS_PF_DURATION";
            this.AS_PF_DURATION.Size = new System.Drawing.Size(50, 20);
            this.AS_PF_DURATION.TabIndex = 42;
            this.AS_PF_DURATION.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 15);
            this.label12.TabIndex = 39;
            this.label12.Text = "Preinfusion Speed:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Auto Sequence";
            // 
            // AS_STOP
            // 
            this.AS_STOP.Location = new System.Drawing.Point(111, 197);
            this.AS_STOP.Name = "AS_STOP";
            this.AS_STOP.Size = new System.Drawing.Size(88, 36);
            this.AS_STOP.TabIndex = 37;
            this.AS_STOP.Text = "STOP";
            this.AS_STOP.UseVisualStyleBackColor = true;
            this.AS_STOP.Click += new System.EventHandler(this.AS_STOP_Click);
            // 
            // AS_START
            // 
            this.AS_START.Location = new System.Drawing.Point(16, 197);
            this.AS_START.Name = "AS_START";
            this.AS_START.Size = new System.Drawing.Size(88, 36);
            this.AS_START.TabIndex = 36;
            this.AS_START.Text = "START";
            this.AS_START.UseVisualStyleBackColor = true;
            this.AS_START.Click += new System.EventHandler(this.AS_START_Click);
            // 
            // AS_Timer
            // 
            this.AS_Timer.Interval = 50;
            this.AS_Timer.Tick += new System.EventHandler(this.AS_Timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 336);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.SensorsPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Espresso Yourself";
            this.SensorsPanel.ResumeLayout(false);
            this.SensorsPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PumpSpeedInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PumpPressureInput)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempInput)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AS_PF_SPEED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_RD_PRESSURE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_PF_PRESSURE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_PB_Duration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_BREW_PRESSURE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS_PF_DURATION)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPort1;
        private System.Windows.Forms.Panel SensorsPanel;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.Label TemperatureLabel;
        private System.Windows.Forms.Label PressureLabel;
        private System.Windows.Forms.Label WeightValue;
        private System.Windows.Forms.Label TemperatureValue;
        private System.Windows.Forms.Label PressureValue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label SlaveFrequencyLabel;
        private System.Windows.Forms.Label SlaveFrequencyValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LoopValveIndicator;
        private System.Windows.Forms.Label GHValveIndicator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ghClose;
        private System.Windows.Forms.Button ghOpen;
        private System.Windows.Forms.Button loopClose;
        private System.Windows.Forms.Button loopOpen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button TempOffButton;
        private System.Windows.Forms.Button TempOnButton;
        private System.Windows.Forms.NumericUpDown tempInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PumpIndicator;
        private System.Windows.Forms.Button pumpSpeedBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown PumpSpeedInput;
        private System.Windows.Forms.Button pumpPressBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown PumpPressureInput;
        private System.Windows.Forms.Button pumpOffBtn;
        private System.Windows.Forms.Label HeaterIndicator;
        private System.Windows.Forms.ComboBox SerialPortSelect;
        private System.Windows.Forms.Button SerialConnect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SerialDisconnect;
        private System.Windows.Forms.Button SerialSearch;
        private System.Windows.Forms.Button pumpIdle;
        private System.Windows.Forms.Button valveIdle;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button PIDReset;
        private System.Windows.Forms.Button ZeroScale;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label AS_INDICATOR;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown AS_BREW_PRESSURE;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown AS_PF_DURATION;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown AS_PF_PRESSURE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button AS_STOP;
        private System.Windows.Forms.Button AS_START;
        private System.Windows.Forms.Timer AS_Timer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown AS_RD_PRESSURE;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown AS_PB_Duration;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label AS_TIMER_DISPLAY;
        private System.Windows.Forms.Button valveExtract;
        private System.Windows.Forms.Label GHTemperatureValue;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown AS_PF_SPEED;
        private System.Windows.Forms.Button plotClear;
        private System.Windows.Forms.CheckBox stayHot;
    }
}

