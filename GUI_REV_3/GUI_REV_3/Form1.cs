using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;



namespace GUI_REV_3
{

    public partial class Form1 : Form
    {
        public float Pressure;
        public float Temperature;
        public float Weight;
        public float slaveFrequency;
        
        public int groupValveState = 0;
        public int lineValveState = 0;
        public float tempSet;
        public float pumpSet;

        public delegate void d1(string indata);

        public Form1()
        {
            InitializeComponent();
            SerialPortListRefresh();

        }

        private void SerialPortListRefresh()
        {
            SerialPortSelect.Items.Clear();
            String[] myPorts = SerialPort.GetPortNames();
            for (int i = 0; i < myPorts.Length; i++)
            {
                SerialPortSelect.Items.Add(myPorts[i]);
            }
        }

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string indata = SerialPort1.ReadLine();
            d1 writeit = new d1(Write2Form);
            Invoke(writeit, indata);

        }

        public void Write2Form(String indata)
        {
            if(indata.Length != 34 || indata[0] != 'S')
            {
                return;
            }
            
            Pressure = (Convert.ToSingle(indata.Substring(1,8))/100)-1000;
            PressureValue.Text = Convert.ToString(Pressure) + " Bars";

            Temperature = (Convert.ToSingle(indata.Substring(9, 8)) / 100) - 1000;
            TemperatureValue.Text = Convert.ToString(Temperature) + " C";

            Weight = (Convert.ToSingle(indata.Substring(17, 8)) / 100) - 1000;
            WeightValue.Text = Convert.ToString(Weight) + " g";

            slaveFrequency = (Convert.ToSingle(indata.Substring(25, 8)) / 100) - 1000;
            SlaveFrequencyValue.Text = Convert.ToString(slaveFrequency) + " Hz";

        }

        public void updateWindow()
        {
            int numberOfPlotPoints = 600;

            if (SerialPort1.IsOpen)
            {
                TemperatureChart.Series[0].Points.AddY(Temperature);
                if (TemperatureChart.Series[0].Points.Count > numberOfPlotPoints)
                {
                    TemperatureChart.Series[0].Points.RemoveAt(0);
                }
                TemperatureChart.ResetAutoValues();
                TemperatureChart.ChartAreas[0].AxisY.Minimum = ((int)TemperatureChart.Series[0].Points.FindMinByValue("Y1", 0).YValues[0]) - 1;
                TemperatureChart.ChartAreas[0].AxisY.Maximum = ((int)TemperatureChart.Series[0].Points.FindMaxByValue("Y1", 0).YValues[0]) + 1;

                PressureChart.Series[0].Points.AddY(Pressure);
                if (PressureChart.Series[0].Points.Count > numberOfPlotPoints)
                {
                    PressureChart.Series[0].Points.RemoveAt(0);
                }
                PressureChart.ResetAutoValues();

                WeightChart.Series[0].Points.AddY(Weight);
                if (WeightChart.Series[0].Points.Count > numberOfPlotPoints)
                {
                    WeightChart.Series[0].Points.RemoveAt(0);
                }
                WeightChart.ResetAutoValues();

            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            updateWindow();
            updateSlave();

        }

        public void updateSlave()
        {
            if (SerialPort1.IsOpen)
            {
                SerialPort1.WriteLine("V" + (10 * lineValveState + groupValveState).ToString());
                SerialPort1.WriteLine("T" + tempSet.ToString());
                SerialPort1.WriteLine("P" + pumpSet.ToString());
            }
        }
     

        private void SerialConnect_Click(object sender, EventArgs e)
        {
            if (!SerialPort1.IsOpen)
            {
                SerialPort1.PortName = SerialPortSelect.Text;
                SerialPort1.Open();
            }
        }

        private void SerialDisconnect_Click(object sender, EventArgs e)
        {
            if (SerialPort1.IsOpen)
            {
                SerialPort1.Close();
            }
        }

        private void SerialSearch_Click(object sender, EventArgs e)
        {
            SerialPortListRefresh();
        }

        private void TempOnButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("T"+(Math.Round(tempInput.Value*10)).ToString());
        }

    }
}
