namespace GUI_REV_3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.SerialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SensorsPanel = new System.Windows.Forms.Panel();
            this.SerialSearch = new System.Windows.Forms.Button();
            this.SerialPortSelect = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.SensorsTitle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.WeightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PumpIndicator = new System.Windows.Forms.Label();
            this.pumpSpeedBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PumpSpeedInput = new System.Windows.Forms.NumericUpDown();
            this.pumpPressBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.PumpPressureInput = new System.Windows.Forms.NumericUpDown();
            this.pumpOffBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HeaterIndicator = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TempOffButton = new System.Windows.Forms.Button();
            this.TempOnButton = new System.Windows.Forms.Button();
            this.tempInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ghClose = new System.Windows.Forms.Button();
            this.ghOpen = new System.Windows.Forms.Button();
            this.loopClose = new System.Windows.Forms.Button();
            this.loopOpen = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GHValveIndicator = new System.Windows.Forms.Label();
            this.LoopValveIndicator = new System.Windows.Forms.Label();
            this.TemperatureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pumpIdle = new System.Windows.Forms.Button();
            this.valveIdle = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PIDReset = new System.Windows.Forms.Button();
            this.ZeroScale = new System.Windows.Forms.Button();
            this.SensorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PumpSpeedInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PumpPressureInput)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempInput)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // SerialPort1
            // 
            this.SerialPort1.BaudRate = 115200;
            this.SerialPort1.PortName = "COM5";
            this.SerialPort1.ReceivedBytesThreshold = 6;
            this.SerialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // SensorsPanel
            // 
            this.SensorsPanel.BackColor = System.Drawing.Color.White;
            this.SensorsPanel.Controls.Add(this.SerialSearch);
            this.SensorsPanel.Controls.Add(this.SerialPortSelect);
            this.SensorsPanel.Controls.Add(this.label11);
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
            this.SensorsPanel.Controls.Add(this.SensorsTitle);
            this.SensorsPanel.Location = new System.Drawing.Point(22, 22);
            this.SensorsPanel.Margin = new System.Windows.Forms.Padding(6);
            this.SensorsPanel.Name = "SensorsPanel";
            this.SensorsPanel.Size = new System.Drawing.Size(444, 445);
            this.SensorsPanel.TabIndex = 1;
            // 
            // SerialSearch
            // 
            this.SerialSearch.Location = new System.Drawing.Point(257, 308);
            this.SerialSearch.Margin = new System.Windows.Forms.Padding(6);
            this.SerialSearch.Name = "SerialSearch";
            this.SerialSearch.Size = new System.Drawing.Size(122, 42);
            this.SerialSearch.TabIndex = 32;
            this.SerialSearch.Text = "SEARCH";
            this.SerialSearch.UseVisualStyleBackColor = true;
            this.SerialSearch.Click += new System.EventHandler(this.SerialSearch_Click);
            // 
            // SerialPortSelect
            // 
            this.SerialPortSelect.FormattingEnabled = true;
            this.SerialPortSelect.Location = new System.Drawing.Point(141, 312);
            this.SerialPortSelect.Margin = new System.Windows.Forms.Padding(6);
            this.SerialPortSelect.Name = "SerialPortSelect";
            this.SerialPortSelect.Size = new System.Drawing.Size(108, 32);
            this.SerialPortSelect.TabIndex = 31;
            this.SerialPortSelect.Text = "COM5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(73, 264);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "Serial Connection";
            // 
            // SerialConnect
            // 
            this.SerialConnect.Location = new System.Drawing.Point(220, 362);
            this.SerialConnect.Margin = new System.Windows.Forms.Padding(6);
            this.SerialConnect.Name = "SerialConnect";
            this.SerialConnect.Size = new System.Drawing.Size(161, 42);
            this.SerialConnect.TabIndex = 29;
            this.SerialConnect.Text = "CONNECT";
            this.SerialConnect.UseVisualStyleBackColor = true;
            this.SerialConnect.Click += new System.EventHandler(this.SerialConnect_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(48, 319);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "PORT: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SerialDisconnect
            // 
            this.SerialDisconnect.Location = new System.Drawing.Point(48, 362);
            this.SerialDisconnect.Margin = new System.Windows.Forms.Padding(6);
            this.SerialDisconnect.Name = "SerialDisconnect";
            this.SerialDisconnect.Size = new System.Drawing.Size(161, 42);
            this.SerialDisconnect.TabIndex = 26;
            this.SerialDisconnect.Text = "DISCONNECT";
            this.SerialDisconnect.UseVisualStyleBackColor = true;
            this.SerialDisconnect.Click += new System.EventHandler(this.SerialDisconnect_Click);
            // 
            // SlaveFrequencyValue
            // 
            this.SlaveFrequencyValue.AutoSize = true;
            this.SlaveFrequencyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlaveFrequencyValue.Location = new System.Drawing.Point(277, 183);
            this.SlaveFrequencyValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SlaveFrequencyValue.Name = "SlaveFrequencyValue";
            this.SlaveFrequencyValue.Size = new System.Drawing.Size(14, 15);
            this.SlaveFrequencyValue.TabIndex = 15;
            this.SlaveFrequencyValue.Text = "0";
            // 
            // WeightValue
            // 
            this.WeightValue.AutoSize = true;
            this.WeightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightValue.Location = new System.Drawing.Point(277, 148);
            this.WeightValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.WeightValue.Name = "WeightValue";
            this.WeightValue.Size = new System.Drawing.Size(14, 15);
            this.WeightValue.TabIndex = 14;
            this.WeightValue.Text = "0";
            // 
            // SlaveFrequencyLabel
            // 
            this.SlaveFrequencyLabel.AutoSize = true;
            this.SlaveFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlaveFrequencyLabel.Location = new System.Drawing.Point(48, 181);
            this.SlaveFrequencyLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SlaveFrequencyLabel.Name = "SlaveFrequencyLabel";
            this.SlaveFrequencyLabel.Size = new System.Drawing.Size(112, 15);
            this.SlaveFrequencyLabel.TabIndex = 9;
            this.SlaveFrequencyLabel.Text = "Sensor Frequency: ";
            this.SlaveFrequencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TemperatureValue
            // 
            this.TemperatureValue.AutoSize = true;
            this.TemperatureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureValue.Location = new System.Drawing.Point(277, 113);
            this.TemperatureValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TemperatureValue.Name = "TemperatureValue";
            this.TemperatureValue.Size = new System.Drawing.Size(14, 15);
            this.TemperatureValue.TabIndex = 13;
            this.TemperatureValue.Text = "0";
            // 
            // PressureValue
            // 
            this.PressureValue.AutoSize = true;
            this.PressureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressureValue.Location = new System.Drawing.Point(277, 76);
            this.PressureValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PressureValue.Name = "PressureValue";
            this.PressureValue.Size = new System.Drawing.Size(14, 15);
            this.PressureValue.TabIndex = 12;
            this.PressureValue.Text = "0";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightLabel.Location = new System.Drawing.Point(160, 146);
            this.WeightLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
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
            this.TemperatureLabel.Location = new System.Drawing.Point(99, 111);
            this.TemperatureLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
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
            this.PressureLabel.Location = new System.Drawing.Point(139, 78);
            this.PressureLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PressureLabel.Name = "PressureLabel";
            this.PressureLabel.Size = new System.Drawing.Size(62, 15);
            this.PressureLabel.TabIndex = 6;
            this.PressureLabel.Text = "Pressure: ";
            this.PressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SensorsTitle
            // 
            this.SensorsTitle.AutoSize = true;
            this.SensorsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensorsTitle.Location = new System.Drawing.Point(150, 26);
            this.SensorsTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SensorsTitle.Name = "SensorsTitle";
            this.SensorsTitle.Size = new System.Drawing.Size(75, 20);
            this.SensorsTitle.TabIndex = 4;
            this.SensorsTitle.Text = "Sensors";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WeightChart
            // 
            this.WeightChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea4.Name = "ChartArea1";
            this.WeightChart.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.WeightChart.Legends.Add(legend4);
            this.WeightChart.Location = new System.Drawing.Point(22, 1118);
            this.WeightChart.Margin = new System.Windows.Forms.Padding(6);
            this.WeightChart.Name = "WeightChart";
            this.WeightChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "Weight";
            this.WeightChart.Series.Add(series4);
            this.WeightChart.Size = new System.Drawing.Size(1358, 279);
            this.WeightChart.TabIndex = 2;
            this.WeightChart.Text = "WeightChart";
            title4.Name = "Title1";
            title4.Text = "Weight";
            this.WeightChart.Titles.Add(title4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(495, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 445);
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
            this.panel3.Location = new System.Drawing.Point(312, 24);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 395);
            this.panel3.TabIndex = 20;
            // 
            // PumpIndicator
            // 
            this.PumpIndicator.AutoSize = true;
            this.PumpIndicator.BackColor = System.Drawing.Color.Red;
            this.PumpIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PumpIndicator.ForeColor = System.Drawing.Color.White;
            this.PumpIndicator.Location = new System.Drawing.Point(46, 56);
            this.PumpIndicator.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PumpIndicator.Name = "PumpIndicator";
            this.PumpIndicator.Size = new System.Drawing.Size(77, 15);
            this.PumpIndicator.TabIndex = 26;
            this.PumpIndicator.Text = "PUMP OFF";
            this.PumpIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pumpSpeedBtn
            // 
            this.pumpSpeedBtn.Location = new System.Drawing.Point(13, 119);
            this.pumpSpeedBtn.Margin = new System.Windows.Forms.Padding(6);
            this.pumpSpeedBtn.Name = "pumpSpeedBtn";
            this.pumpSpeedBtn.Size = new System.Drawing.Size(224, 42);
            this.pumpSpeedBtn.TabIndex = 33;
            this.pumpSpeedBtn.Text = "PUMP SPEED";
            this.pumpSpeedBtn.UseVisualStyleBackColor = true;
            this.pumpSpeedBtn.Click += new System.EventHandler(this.pumpSpeedBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 173);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Speed:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PumpSpeedInput
            // 
            this.PumpSpeedInput.DecimalPlaces = 1;
            this.PumpSpeedInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PumpSpeedInput.Location = new System.Drawing.Point(136, 166);
            this.PumpSpeedInput.Margin = new System.Windows.Forms.Padding(6);
            this.PumpSpeedInput.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.PumpSpeedInput.Name = "PumpSpeedInput";
            this.PumpSpeedInput.Size = new System.Drawing.Size(92, 29);
            this.PumpSpeedInput.TabIndex = 32;
            this.PumpSpeedInput.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // pumpPressBtn
            // 
            this.pumpPressBtn.Location = new System.Drawing.Point(13, 199);
            this.pumpPressBtn.Margin = new System.Windows.Forms.Padding(6);
            this.pumpPressBtn.Name = "pumpPressBtn";
            this.pumpPressBtn.Size = new System.Drawing.Size(224, 42);
            this.pumpPressBtn.TabIndex = 30;
            this.pumpPressBtn.Text = "PRESSURE SET";
            this.pumpPressBtn.UseVisualStyleBackColor = true;
            this.pumpPressBtn.Click += new System.EventHandler(this.pumpPressBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 255);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
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
            this.PumpPressureInput.Location = new System.Drawing.Point(136, 248);
            this.PumpPressureInput.Margin = new System.Windows.Forms.Padding(6);
            this.PumpPressureInput.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.PumpPressureInput.Name = "PumpPressureInput";
            this.PumpPressureInput.Size = new System.Drawing.Size(92, 29);
            this.PumpPressureInput.TabIndex = 29;
            this.PumpPressureInput.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // pumpOffBtn
            // 
            this.pumpOffBtn.Location = new System.Drawing.Point(6, 294);
            this.pumpOffBtn.Margin = new System.Windows.Forms.Padding(6);
            this.pumpOffBtn.Name = "pumpOffBtn";
            this.pumpOffBtn.Size = new System.Drawing.Size(224, 42);
            this.pumpOffBtn.TabIndex = 23;
            this.pumpOffBtn.Text = "PUMP OFF";
            this.pumpOffBtn.UseVisualStyleBackColor = true;
            this.pumpOffBtn.Click += new System.EventHandler(this.pumpOffBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Pump Control";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.HeaterIndicator);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TempOffButton);
            this.panel2.Controls.Add(this.TempOnButton);
            this.panel2.Controls.Add(this.tempInput);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(28, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 395);
            this.panel2.TabIndex = 19;
            // 
            // HeaterIndicator
            // 
            this.HeaterIndicator.AutoSize = true;
            this.HeaterIndicator.BackColor = System.Drawing.Color.Red;
            this.HeaterIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaterIndicator.ForeColor = System.Drawing.Color.White;
            this.HeaterIndicator.Location = new System.Drawing.Point(42, 157);
            this.HeaterIndicator.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
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
            this.label5.Location = new System.Drawing.Point(20, 286);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Set Point:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TempOffButton
            // 
            this.TempOffButton.Location = new System.Drawing.Point(132, 336);
            this.TempOffButton.Margin = new System.Windows.Forms.Padding(6);
            this.TempOffButton.Name = "TempOffButton";
            this.TempOffButton.Size = new System.Drawing.Size(99, 42);
            this.TempOffButton.TabIndex = 24;
            this.TempOffButton.Text = "OFF";
            this.TempOffButton.UseVisualStyleBackColor = true;
            this.TempOffButton.Click += new System.EventHandler(this.TempOffButton_Click);
            // 
            // TempOnButton
            // 
            this.TempOnButton.Location = new System.Drawing.Point(22, 336);
            this.TempOnButton.Margin = new System.Windows.Forms.Padding(6);
            this.TempOnButton.Name = "TempOnButton";
            this.TempOnButton.Size = new System.Drawing.Size(99, 42);
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
            this.tempInput.Location = new System.Drawing.Point(139, 282);
            this.tempInput.Margin = new System.Windows.Forms.Padding(6);
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
            this.tempInput.Size = new System.Drawing.Size(92, 29);
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
            this.label4.Location = new System.Drawing.Point(18, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Temp Control";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel4.Location = new System.Drawing.Point(594, 24);
            this.panel4.Margin = new System.Windows.Forms.Padding(6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(253, 395);
            this.panel4.TabIndex = 21;
            // 
            // ghClose
            // 
            this.ghClose.Location = new System.Drawing.Point(130, 127);
            this.ghClose.Margin = new System.Windows.Forms.Padding(6);
            this.ghClose.Name = "ghClose";
            this.ghClose.Size = new System.Drawing.Size(99, 42);
            this.ghClose.TabIndex = 22;
            this.ghClose.Text = "CLOSE";
            this.ghClose.UseVisualStyleBackColor = true;
            this.ghClose.Click += new System.EventHandler(this.ghClose_Click);
            // 
            // ghOpen
            // 
            this.ghOpen.Location = new System.Drawing.Point(20, 127);
            this.ghOpen.Margin = new System.Windows.Forms.Padding(6);
            this.ghOpen.Name = "ghOpen";
            this.ghOpen.Size = new System.Drawing.Size(99, 42);
            this.ghOpen.TabIndex = 21;
            this.ghOpen.Text = "OPEN";
            this.ghOpen.UseVisualStyleBackColor = true;
            this.ghOpen.Click += new System.EventHandler(this.ghOpen_Click);
            // 
            // loopClose
            // 
            this.loopClose.Location = new System.Drawing.Point(134, 278);
            this.loopClose.Margin = new System.Windows.Forms.Padding(6);
            this.loopClose.Name = "loopClose";
            this.loopClose.Size = new System.Drawing.Size(99, 42);
            this.loopClose.TabIndex = 20;
            this.loopClose.Text = "CLOSE";
            this.loopClose.UseVisualStyleBackColor = true;
            this.loopClose.Click += new System.EventHandler(this.loopClose_Click);
            // 
            // loopOpen
            // 
            this.loopOpen.Location = new System.Drawing.Point(24, 278);
            this.loopOpen.Margin = new System.Windows.Forms.Padding(6);
            this.loopOpen.Name = "loopOpen";
            this.loopOpen.Size = new System.Drawing.Size(99, 42);
            this.loopOpen.TabIndex = 19;
            this.loopOpen.Text = "OPEN";
            this.loopOpen.UseVisualStyleBackColor = true;
            this.loopOpen.Click += new System.EventHandler(this.loopOpen_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Valve Control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
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
            this.label1.Location = new System.Drawing.Point(83, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
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
            this.GHValveIndicator.Location = new System.Drawing.Point(88, 82);
            this.GHValveIndicator.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
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
            this.LoopValveIndicator.Location = new System.Drawing.Point(99, 234);
            this.LoopValveIndicator.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LoopValveIndicator.Name = "LoopValveIndicator";
            this.LoopValveIndicator.Size = new System.Drawing.Size(45, 15);
            this.LoopValveIndicator.TabIndex = 18;
            this.LoopValveIndicator.Text = "OPEN";
            this.LoopValveIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TemperatureChart
            // 
            this.TemperatureChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea5.Name = "ChartArea1";
            this.TemperatureChart.ChartAreas.Add(chartArea5);
            legend5.Enabled = false;
            legend5.Name = "Legend1";
            this.TemperatureChart.Legends.Add(legend5);
            this.TemperatureChart.Location = new System.Drawing.Point(22, 792);
            this.TemperatureChart.Margin = new System.Windows.Forms.Padding(6);
            this.TemperatureChart.Name = "TemperatureChart";
            this.TemperatureChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.Name = "Temperature";
            this.TemperatureChart.Series.Add(series5);
            this.TemperatureChart.Size = new System.Drawing.Size(1358, 289);
            this.TemperatureChart.TabIndex = 17;
            this.TemperatureChart.Text = "chart1";
            title5.Name = "Title1";
            title5.Text = "Temperature";
            this.TemperatureChart.Titles.Add(title5);
            // 
            // PressureChart
            // 
            this.PressureChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea6.Name = "ChartArea1";
            this.PressureChart.ChartAreas.Add(chartArea6);
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.PressureChart.Legends.Add(legend6);
            this.PressureChart.Location = new System.Drawing.Point(22, 478);
            this.PressureChart.Margin = new System.Windows.Forms.Padding(6);
            this.PressureChart.Name = "PressureChart";
            this.PressureChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "Pressure";
            this.PressureChart.Series.Add(series6);
            this.PressureChart.Size = new System.Drawing.Size(1358, 290);
            this.PressureChart.TabIndex = 18;
            this.PressureChart.Text = "PressureChart";
            title6.Name = "Title1";
            title6.Text = "Pressure";
            this.PressureChart.Titles.Add(title6);
            // 
            // pumpIdle
            // 
            this.pumpIdle.Location = new System.Drawing.Point(6, 345);
            this.pumpIdle.Margin = new System.Windows.Forms.Padding(6);
            this.pumpIdle.Name = "pumpIdle";
            this.pumpIdle.Size = new System.Drawing.Size(224, 42);
            this.pumpIdle.TabIndex = 34;
            this.pumpIdle.Text = "PUMP IDLE";
            this.pumpIdle.UseVisualStyleBackColor = true;
            this.pumpIdle.Click += new System.EventHandler(this.pumpIdle_Click);
            // 
            // valveIdle
            // 
            this.valveIdle.Location = new System.Drawing.Point(20, 337);
            this.valveIdle.Margin = new System.Windows.Forms.Padding(6);
            this.valveIdle.Name = "valveIdle";
            this.valveIdle.Size = new System.Drawing.Size(224, 42);
            this.valveIdle.TabIndex = 35;
            this.valveIdle.Text = "VALVE IDLE";
            this.valveIdle.UseVisualStyleBackColor = true;
            this.valveIdle.Click += new System.EventHandler(this.valveIdle_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.PIDReset);
            this.panel5.Controls.Add(this.ZeroScale);
            this.panel5.Location = new System.Drawing.Point(1419, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(255, 445);
            this.panel5.TabIndex = 19;
            // 
            // PIDReset
            // 
            this.PIDReset.Location = new System.Drawing.Point(36, 81);
            this.PIDReset.Margin = new System.Windows.Forms.Padding(6);
            this.PIDReset.Name = "PIDReset";
            this.PIDReset.Size = new System.Drawing.Size(192, 42);
            this.PIDReset.TabIndex = 37;
            this.PIDReset.Text = "RESET PID";
            this.PIDReset.UseVisualStyleBackColor = true;
            this.PIDReset.Click += new System.EventHandler(this.PIDReset_Click);
            // 
            // ZeroScale
            // 
            this.ZeroScale.Location = new System.Drawing.Point(36, 26);
            this.ZeroScale.Margin = new System.Windows.Forms.Padding(6);
            this.ZeroScale.Name = "ZeroScale";
            this.ZeroScale.Size = new System.Drawing.Size(192, 42);
            this.ZeroScale.TabIndex = 36;
            this.ZeroScale.Text = "ZERO SCALE";
            this.ZeroScale.UseVisualStyleBackColor = true;
            this.ZeroScale.Click += new System.EventHandler(this.ZeroScale_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2317, 1421);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.PressureChart);
            this.Controls.Add(this.TemperatureChart);
            this.Controls.Add(this.WeightChart);
            this.Controls.Add(this.SensorsPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Espresso Yourself";
            this.SensorsPanel.ResumeLayout(false);
            this.SensorsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PumpSpeedInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PumpPressureInput)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempInput)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPort1;
        private System.Windows.Forms.Panel SensorsPanel;
        private System.Windows.Forms.Label SensorsTitle;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.Label TemperatureLabel;
        private System.Windows.Forms.Label PressureLabel;
        private System.Windows.Forms.Label WeightValue;
        private System.Windows.Forms.Label TemperatureValue;
        private System.Windows.Forms.Label PressureValue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label SlaveFrequencyLabel;
        private System.Windows.Forms.Label SlaveFrequencyValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart WeightChart;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart TemperatureChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart;
        private System.Windows.Forms.ComboBox SerialPortSelect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button SerialConnect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SerialDisconnect;
        private System.Windows.Forms.Button SerialSearch;
        private System.Windows.Forms.Button pumpIdle;
        private System.Windows.Forms.Button valveIdle;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button PIDReset;
        private System.Windows.Forms.Button ZeroScale;
    }
}

