
namespace GUIREV2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.ConnectionPanel = new System.Windows.Forms.Panel();
            this.ButtonDisconnect = new System.Windows.Forms.Button();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ComboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.LabelBaudRate = new System.Windows.Forms.Label();
            this.ComboBoxPort = new System.Windows.Forms.ComboBox();
            this.ButtonScanPort = new System.Windows.Forms.Button();
            this.ConnectionTitle = new System.Windows.Forms.Label();
            this.PressurePanel = new System.Windows.Forms.Panel();
            this.LabelPressure = new System.Windows.Forms.Label();
            this.TemperaturePanel = new System.Windows.Forms.Panel();
            this.PressureValue = new System.Windows.Forms.Label();
            this.TemperatureLabel = new System.Windows.Forms.Label();
            this.TemperatureValue = new System.Windows.Forms.Label();
            this.WeightPanel = new System.Windows.Forms.Panel();
            this.WeightValue = new System.Windows.Forms.Label();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ConnectionPanel.SuspendLayout();
            this.PressurePanel.SuspendLayout();
            this.TemperaturePanel.SuspendLayout();
            this.WeightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionPanel
            // 
            this.ConnectionPanel.BackColor = System.Drawing.Color.White;
            this.ConnectionPanel.Controls.Add(this.ButtonDisconnect);
            this.ConnectionPanel.Controls.Add(this.ButtonConnect);
            this.ConnectionPanel.Controls.Add(this.ComboBoxBaudRate);
            this.ConnectionPanel.Controls.Add(this.LabelBaudRate);
            this.ConnectionPanel.Controls.Add(this.ComboBoxPort);
            this.ConnectionPanel.Controls.Add(this.ButtonScanPort);
            this.ConnectionPanel.Controls.Add(this.ConnectionTitle);
            this.ConnectionPanel.Location = new System.Drawing.Point(12, 12);
            this.ConnectionPanel.Name = "ConnectionPanel";
            this.ConnectionPanel.Size = new System.Drawing.Size(421, 313);
            this.ConnectionPanel.TabIndex = 0;
            // 
            // ButtonDisconnect
            // 
            this.ButtonDisconnect.BackColor = System.Drawing.Color.Salmon;
            this.ButtonDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDisconnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonDisconnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonDisconnect.Location = new System.Drawing.Point(203, 228);
            this.ButtonDisconnect.Name = "ButtonDisconnect";
            this.ButtonDisconnect.Size = new System.Drawing.Size(131, 40);
            this.ButtonDisconnect.TabIndex = 6;
            this.ButtonDisconnect.Text = "Disconnect";
            this.ButtonDisconnect.UseVisualStyleBackColor = false;
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.BackColor = System.Drawing.Color.Lime;
            this.ButtonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonConnect.Location = new System.Drawing.Point(37, 228);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(131, 40);
            this.ButtonConnect.TabIndex = 5;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = false;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // ComboBoxBaudRate
            // 
            this.ComboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxBaudRate.FormattingEnabled = true;
            this.ComboBoxBaudRate.Items.AddRange(new object[] {
            "9600",
            "",
            "14400",
            "",
            "19200",
            "",
            "38400",
            "",
            "57600",
            "",
            "115200"});
            this.ComboBoxBaudRate.Location = new System.Drawing.Point(180, 135);
            this.ComboBoxBaudRate.Name = "ComboBoxBaudRate";
            this.ComboBoxBaudRate.Size = new System.Drawing.Size(212, 38);
            this.ComboBoxBaudRate.TabIndex = 4;
            // 
            // LabelBaudRate
            // 
            this.LabelBaudRate.AutoSize = true;
            this.LabelBaudRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelBaudRate.Location = new System.Drawing.Point(49, 136);
            this.LabelBaudRate.Name = "LabelBaudRate";
            this.LabelBaudRate.Size = new System.Drawing.Size(113, 30);
            this.LabelBaudRate.TabIndex = 3;
            this.LabelBaudRate.Text = "Baud Rate";
            // 
            // ComboBoxPort
            // 
            this.ComboBoxPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxPort.FormattingEnabled = true;
            this.ComboBoxPort.Location = new System.Drawing.Point(180, 79);
            this.ComboBoxPort.Name = "ComboBoxPort";
            this.ComboBoxPort.Size = new System.Drawing.Size(212, 38);
            this.ComboBoxPort.TabIndex = 2;
            // 
            // ButtonScanPort
            // 
            this.ButtonScanPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonScanPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonScanPort.Location = new System.Drawing.Point(37, 77);
            this.ButtonScanPort.Name = "ButtonScanPort";
            this.ButtonScanPort.Size = new System.Drawing.Size(131, 40);
            this.ButtonScanPort.TabIndex = 1;
            this.ButtonScanPort.Text = "Scan Port";
            this.ButtonScanPort.UseVisualStyleBackColor = true;
            // 
            // ConnectionTitle
            // 
            this.ConnectionTitle.AutoSize = true;
            this.ConnectionTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConnectionTitle.Location = new System.Drawing.Point(70, 14);
            this.ConnectionTitle.Name = "ConnectionTitle";
            this.ConnectionTitle.Size = new System.Drawing.Size(245, 38);
            this.ConnectionTitle.TabIndex = 0;
            this.ConnectionTitle.Text = "Connection Panel";
            // 
            // PressurePanel
            // 
            this.PressurePanel.BackColor = System.Drawing.Color.White;
            this.PressurePanel.Controls.Add(this.PressureValue);
            this.PressurePanel.Controls.Add(this.LabelPressure);
            this.PressurePanel.Location = new System.Drawing.Point(452, 12);
            this.PressurePanel.Name = "PressurePanel";
            this.PressurePanel.Size = new System.Drawing.Size(271, 313);
            this.PressurePanel.TabIndex = 1;
            // 
            // LabelPressure
            // 
            this.LabelPressure.AutoSize = true;
            this.LabelPressure.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelPressure.Location = new System.Drawing.Point(73, 26);
            this.LabelPressure.Name = "LabelPressure";
            this.LabelPressure.Size = new System.Drawing.Size(127, 38);
            this.LabelPressure.TabIndex = 0;
            this.LabelPressure.Text = "Pressure";
            // 
            // TemperaturePanel
            // 
            this.TemperaturePanel.BackColor = System.Drawing.Color.White;
            this.TemperaturePanel.Controls.Add(this.TemperatureValue);
            this.TemperaturePanel.Controls.Add(this.TemperatureLabel);
            this.TemperaturePanel.Location = new System.Drawing.Point(746, 12);
            this.TemperaturePanel.Name = "TemperaturePanel";
            this.TemperaturePanel.Size = new System.Drawing.Size(271, 313);
            this.TemperaturePanel.TabIndex = 2;
            // 
            // PressureValue
            // 
            this.PressureValue.AutoSize = true;
            this.PressureValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PressureValue.Location = new System.Drawing.Point(101, 135);
            this.PressureValue.Name = "PressureValue";
            this.PressureValue.Size = new System.Drawing.Size(54, 62);
            this.PressureValue.TabIndex = 7;
            this.PressureValue.Text = "0";
            // 
            // TemperatureLabel
            // 
            this.TemperatureLabel.AutoSize = true;
            this.TemperatureLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TemperatureLabel.Location = new System.Drawing.Point(53, 22);
            this.TemperatureLabel.Name = "TemperatureLabel";
            this.TemperatureLabel.Size = new System.Drawing.Size(183, 38);
            this.TemperatureLabel.TabIndex = 8;
            this.TemperatureLabel.Text = "Temperature";
            // 
            // TemperatureValue
            // 
            this.TemperatureValue.AutoSize = true;
            this.TemperatureValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TemperatureValue.Location = new System.Drawing.Point(112, 135);
            this.TemperatureValue.Name = "TemperatureValue";
            this.TemperatureValue.Size = new System.Drawing.Size(54, 62);
            this.TemperatureValue.TabIndex = 8;
            this.TemperatureValue.Text = "0";
            // 
            // WeightPanel
            // 
            this.WeightPanel.BackColor = System.Drawing.Color.White;
            this.WeightPanel.Controls.Add(this.WeightValue);
            this.WeightPanel.Controls.Add(this.WeightLabel);
            this.WeightPanel.Location = new System.Drawing.Point(1041, 12);
            this.WeightPanel.Name = "WeightPanel";
            this.WeightPanel.Size = new System.Drawing.Size(271, 313);
            this.WeightPanel.TabIndex = 9;
            // 
            // WeightValue
            // 
            this.WeightValue.AutoSize = true;
            this.WeightValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WeightValue.Location = new System.Drawing.Point(112, 136);
            this.WeightValue.Name = "WeightValue";
            this.WeightValue.Size = new System.Drawing.Size(54, 62);
            this.WeightValue.TabIndex = 8;
            this.WeightValue.Text = "0";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WeightLabel.Location = new System.Drawing.Point(87, 26);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(112, 38);
            this.WeightLabel.TabIndex = 8;
            this.WeightLabel.Text = "Weight";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(21, 349);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(212, 30);
            this.LabelStatus.TabIndex = 10;
            this.LabelStatus.Text = "Status: Disconnected ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(230, 353);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 29);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 400);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.WeightPanel);
            this.Controls.Add(this.TemperaturePanel);
            this.Controls.Add(this.PressurePanel);
            this.Controls.Add(this.ConnectionPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ConnectionPanel.ResumeLayout(false);
            this.ConnectionPanel.PerformLayout();
            this.PressurePanel.ResumeLayout(false);
            this.PressurePanel.PerformLayout();
            this.TemperaturePanel.ResumeLayout(false);
            this.TemperaturePanel.PerformLayout();
            this.WeightPanel.ResumeLayout(false);
            this.WeightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel ConnectionPanel;
        private Button ButtonDisconnect;
        private Button ButtonConnect;
        private ComboBox ComboBoxBaudRate;
        private Label LabelBaudRate;
        private ComboBox ComboBoxPort;
        private Button ButtonScanPort;
        private Label ConnectionTitle;
        private Panel PressurePanel;
        private Label LabelPressure;
        private Panel TemperaturePanel;
        private Label PressureValue;
        private Label TemperatureLabel;
        private Label TemperatureValue;
        private Panel WeightPanel;
        private Label WeightValue;
        private Label WeightLabel;
        private Label LabelStatus;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
    private System.IO.Ports.SerialPort serialPort1;
}