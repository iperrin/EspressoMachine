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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title9 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.label8 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button7 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button8 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HeaterIndicator = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TempOffButton = new System.Windows.Forms.Button();
            this.TempOnButton = new System.Windows.Forms.Button();
            this.tempInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GHValveIndicator = new System.Windows.Forms.Label();
            this.LoopValveIndicator = new System.Windows.Forms.Label();
            this.TemperatureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SensorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempInput)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart)).BeginInit();
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
            chartArea7.Name = "ChartArea1";
            this.WeightChart.ChartAreas.Add(chartArea7);
            legend7.Enabled = false;
            legend7.Name = "Legend1";
            this.WeightChart.Legends.Add(legend7);
            this.WeightChart.Location = new System.Drawing.Point(22, 1150);
            this.WeightChart.Margin = new System.Windows.Forms.Padding(6);
            this.WeightChart.Name = "WeightChart";
            this.WeightChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "Weight";
            this.WeightChart.Series.Add(series7);
            this.WeightChart.Size = new System.Drawing.Size(1358, 325);
            this.WeightChart.TabIndex = 2;
            this.WeightChart.Text = "WeightChart";
            title7.Name = "Title1";
            title7.Text = "Weight";
            this.WeightChart.Titles.Add(title7);
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
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.numericUpDown2);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(312, 24);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 395);
            this.panel3.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Red;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(46, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "PUMP OFF";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(13, 120);
            this.button9.Margin = new System.Windows.Forms.Padding(6);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(224, 42);
            this.button9.TabIndex = 33;
            this.button9.Text = "PUMP SPEED";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 166);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Speed:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(136, 162);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(92, 29);
            this.numericUpDown1.TabIndex = 32;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(13, 231);
            this.button7.Margin = new System.Windows.Forms.Padding(6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(224, 42);
            this.button7.TabIndex = 30;
            this.button7.Text = "PRESSURE SET";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 277);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Pressure:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 1;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown2.Location = new System.Drawing.Point(136, 273);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(92, 29);
            this.numericUpDown2.TabIndex = 29;
            this.numericUpDown2.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(15, 336);
            this.button8.Margin = new System.Windows.Forms.Padding(6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(224, 42);
            this.button8.TabIndex = 23;
            this.button8.Text = "PUMP OFF";
            this.button8.UseVisualStyleBackColor = true;
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
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(130, 177);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 42);
            this.button3.TabIndex = 22;
            this.button3.Text = "CLOSE";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(20, 177);
            this.button4.Margin = new System.Windows.Forms.Padding(6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 42);
            this.button4.TabIndex = 21;
            this.button4.Text = "OPEN";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 336);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 42);
            this.button2.TabIndex = 20;
            this.button2.Text = "CLOSE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 336);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 42);
            this.button1.TabIndex = 19;
            this.button1.Text = "OPEN";
            this.button1.UseVisualStyleBackColor = true;
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
            this.label2.Location = new System.Drawing.Point(97, 260);
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
            this.label1.Location = new System.Drawing.Point(57, 98);
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
            this.GHValveIndicator.Location = new System.Drawing.Point(68, 135);
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
            this.LoopValveIndicator.Location = new System.Drawing.Point(88, 294);
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
            chartArea8.Name = "ChartArea1";
            this.TemperatureChart.ChartAreas.Add(chartArea8);
            legend8.Enabled = false;
            legend8.Name = "Legend1";
            this.TemperatureChart.Legends.Add(legend8);
            this.TemperatureChart.Location = new System.Drawing.Point(22, 814);
            this.TemperatureChart.Margin = new System.Windows.Forms.Padding(6);
            this.TemperatureChart.Name = "TemperatureChart";
            this.TemperatureChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "Temperature";
            this.TemperatureChart.Series.Add(series8);
            this.TemperatureChart.Size = new System.Drawing.Size(1358, 325);
            this.TemperatureChart.TabIndex = 17;
            this.TemperatureChart.Text = "chart1";
            title8.Name = "Title1";
            title8.Text = "Temperature";
            this.TemperatureChart.Titles.Add(title8);
            // 
            // PressureChart
            // 
            this.PressureChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea9.Name = "ChartArea1";
            this.PressureChart.ChartAreas.Add(chartArea9);
            legend9.Enabled = false;
            legend9.Name = "Legend1";
            this.PressureChart.Legends.Add(legend9);
            this.PressureChart.Location = new System.Drawing.Point(22, 478);
            this.PressureChart.Margin = new System.Windows.Forms.Padding(6);
            this.PressureChart.Name = "PressureChart";
            this.PressureChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "Pressure";
            this.PressureChart.Series.Add(series9);
            this.PressureChart.Size = new System.Drawing.Size(1358, 325);
            this.PressureChart.TabIndex = 18;
            this.PressureChart.Text = "PressureChart";
            title9.Name = "Title1";
            title9.Text = "Pressure";
            this.PressureChart.Titles.Add(title9);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 1421);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempInput)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart)).EndInit();
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button TempOffButton;
        private System.Windows.Forms.Button TempOnButton;
        private System.Windows.Forms.NumericUpDown tempInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label HeaterIndicator;
        private System.Windows.Forms.DataVisualization.Charting.Chart TemperatureChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart;
        private System.Windows.Forms.ComboBox SerialPortSelect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button SerialConnect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SerialDisconnect;
        private System.Windows.Forms.Button SerialSearch;
    }
}

