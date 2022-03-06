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
        public float GHTemperature;
        public int AS_state;
        
        //Autosequence state variables
        public int AS_Loop_Counter = 0;
        public int AS_peak_press_counter = 0;

        //valve state: 0 = unenergized | 1 = energized (group is normally close, loop is normally open)
        public int groupValveState = 0;
        public int loopValveState = 0;

        public float tempSet;

        //pumpSetting 0 = off | 1 = motor set | 2 = pressure set
        public int pumpSetting = 0;
        public float pumpSet = 0;

        public Boolean heating = false;

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
            if(indata.Length != 42 || indata[0] != 'S')
            {
                return;
            }
            
            Pressure = (Convert.ToSingle(indata.Substring(1,8))/100)-1000;
            PressureValue.Text = Convert.ToString(Pressure) + " Bars";

            Temperature = (Convert.ToSingle(indata.Substring(9, 8)) / 100) - 1000;
            TemperatureValue.Text = Convert.ToString(Temperature) + " C";

            GHTemperature = (Convert.ToSingle(indata.Substring(17, 8)) / 100) - 1000;
            GHTemperatureValue.Text = Convert.ToString(GHTemperature) + " C";

            Weight = (Convert.ToSingle(indata.Substring(25, 8)) / 100) - 1000;
            WeightValue.Text = Convert.ToString(Weight) + " g";

            slaveFrequency = (Convert.ToSingle(indata.Substring(33, 8)) / 100) - 1000;
            SlaveFrequencyValue.Text = Convert.ToString(slaveFrequency) + " Hz";

        }

        public void updateWindow()
        {
            int numberOfPlotPoints = 300;

            if (SerialPort1.IsOpen)
            {
                TemperatureChart.Series[0].Points.AddY(Temperature);
                if (TemperatureChart.Series[0].Points.Count > numberOfPlotPoints)
                {
                    TemperatureChart.Series[0].Points.RemoveAt(0);
                }
                TemperatureChart.Series[1].Points.AddY(GHTemperature);
                if (TemperatureChart.Series[1].Points.Count > numberOfPlotPoints)
                {
                    TemperatureChart.Series[1].Points.RemoveAt(0);
                }
                TemperatureChart.ResetAutoValues();
                TemperatureChart.ChartAreas[0].AxisY.Minimum = Math.Min(((int)TemperatureChart.Series[0].Points.FindMinByValue("Y1", 0).YValues[0]),((int)TemperatureChart.Series[1].Points.FindMinByValue("Y1", 0).YValues[0]));
                TemperatureChart.ChartAreas[0].AxisY.Maximum = Math.Max(((int)TemperatureChart.Series[0].Points.FindMaxByValue("Y1", 0).YValues[0]) + 1, ((int)TemperatureChart.Series[1].Points.FindMaxByValue("Y1", 0).YValues[0]) + 1);

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
                
                //send valve state
                SerialPort1.WriteLine("V" + loopValveState.ToString() + groupValveState.ToString());
                
                

                //Send pump state (M for motor speed, P for pump speed)
                if(pumpSetting == 1)
                {
                    SerialPort1.WriteLine("M" + (Math.Round(PumpSpeedInput.Value)).ToString());
                
                }
                else if (pumpSetting == 2)
                {
                    SerialPort1.WriteLine("P" + (Math.Round(PumpPressureInput.Value*10)).ToString());
                }
                else
                {

                    SerialPort1.WriteLine("M0");
                }

                //Send heating information
                if (heating)
                {
                    SerialPort1.WriteLine("T" + (Math.Round(tempInput.Value * 10)).ToString());
                }
                else
                {
                    SerialPort1.WriteLine("T0");
                }

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
            heating = true;
            HeaterIndicator.Text = "HEATER ON";
            HeaterIndicator.BackColor = Color.Green;
        }

        private void TempOffButton_Click(object sender, EventArgs e)
        {
            heating = false;
            HeaterIndicator.Text = "HEATER OFF";
            HeaterIndicator.BackColor = Color.Red;
        }

        private void pumpSpeedBtn_Click(object sender, EventArgs e)
        {
            pumpSetting = 1;
            PumpIndicator.Text = "SPEED\nCONTROL";
            PumpIndicator.BackColor = Color.Orange;
        }

        private void pumpPressBtn_Click(object sender, EventArgs e)
        {
            pumpSetting = 2;
            PumpIndicator.Text = "PRESSURE\nCONTROL";
            PumpIndicator.BackColor = Color.Green;
        }

        private void pumpOffBtn_Click(object sender, EventArgs e)
        {
            pumpSetting = 0;
            PumpIndicator.Text = "PUMP OFF";
            PumpIndicator.BackColor = Color.Red;
        }

        private void ghOpen_Click(object sender, EventArgs e)
        {
            groupValveState = 1;
            GHValveIndicator.Text = "OPEN";
            GHValveIndicator.BackColor = Color.Green;
        }

        private void ghClose_Click(object sender, EventArgs e)
        {
            groupValveState = 0;
            GHValveIndicator.Text = "CLOSED";
            GHValveIndicator.BackColor = Color.Red;
        }

        private void loopOpen_Click(object sender, EventArgs e)
        {
            loopValveState = 0;
            LoopValveIndicator.Text = "OPEN";
            LoopValveIndicator.BackColor = Color.Green;
        }

        private void loopClose_Click(object sender, EventArgs e)
        {
            loopValveState = 1;
            LoopValveIndicator.Text = "CLOSED";
            LoopValveIndicator.BackColor = Color.Red;
        }

        private void pumpIdle_Click(object sender, EventArgs e)
        {
            PumpSpeedInput.Value = 25;
            pumpSpeedBtn_Click(sender, new EventArgs());
        }

        private void valveIdle_Click(object sender, EventArgs e)
        {
            ghClose_Click(sender, new EventArgs());
            loopOpen_Click(sender, new EventArgs());
        }

        private void ZeroScale_Click(object sender, EventArgs e)
        {
            if (SerialPort1.IsOpen)
            {
                SerialPort1.WriteLine("R2");
            }
        }

        private void PIDReset_Click(object sender, EventArgs e)
        {
            if (SerialPort1.IsOpen)
            {
                SerialPort1.WriteLine("R1");
            }
        }

        private void AS_START_Click(object sender, EventArgs e)
        {
            AS_Timer.Start();
            AS_Loop_Counter = 0;
        }

        private void AS_STOP_Click(object sender, EventArgs e)
        {
            AS_Timer.Stop();
            valveIdle_Click(sender, new EventArgs());
            pumpIdle_Click(sender, new EventArgs());
            TempOffButton_Click(sender, new EventArgs());

            AS_INDICATOR.Text = "AUTO SEQUENCE OFF";
            AS_INDICATOR.BackColor = Color.Red;

        }

        private void AS_Timer_Tick(object sender, EventArgs e)
        {

            //autosequence start
            if (AS_Loop_Counter == 0)
            {
                loopClose_Click(sender, new EventArgs());
                ghOpen_Click(sender, new EventArgs());
                TempOnButton_Click(sender, new EventArgs());
                AS_state = 1;
            }

            //update timer
            float brewTime = AS_Loop_Counter / 10;
            AS_TIMER_DISPLAY.Text = Convert.ToString(brewTime)+" s";


            //state definitions
            //AS_state == 1 ==> preinfusion
            //AS_state == 2 ==> main brew
            //AS_state == 3 ==> ramp down

            if(AS_state == 1)
            {
                //check for end of preinfusion conditions
                if (AS_Loop_Counter > 10*AS_PF_DURATION.Value || Pressure > (float)AS_PF_PRESSURE.Value)
                {
                    AS_state = 2;
                    AS_peak_press_counter = 0;
                }
            }else if (AS_state == 2)
            {
                //check for end of main brew conditions
                if (AS_peak_press_counter > 10*AS_PB_Duration.Value)
                {
                    AS_state = 3;
                }
            }


            if (AS_state == 1)
            {
                //preinfusion
                AS_INDICATOR.Text = "PREINFUSION";
                AS_INDICATOR.BackColor = Color.Green;
                PumpSpeedInput.Value = AS_PF_SPEED.Value;
            }
            else if (AS_state == 2)
            {
                //main brew
                pumpPressBtn_Click(sender, new EventArgs());
                AS_INDICATOR.Text = "PEAK PRESSURE";
                AS_INDICATOR.BackColor = Color.Green;
                PumpPressureInput.Value = AS_BREW_PRESSURE.Value;
                AS_peak_press_counter++;
            }
            else
            {
                //ramp down
                pumpPressBtn_Click(sender, new EventArgs());
                AS_INDICATOR.Text = "RAMP DOWN";
                AS_INDICATOR.BackColor = Color.Green;
                PumpPressureInput.Value = AS_RD_PRESSURE.Value;
            }

            AS_Loop_Counter++;
        }

        private void valveExtract_Click(object sender, EventArgs e)
        {
            ghOpen_Click(sender, new EventArgs());
            loopClose_Click(sender, new EventArgs());
        }
    }
}
