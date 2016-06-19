using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Agilent.CommandExpert.ScpiNet.Ag3446x_2_08;

namespace TpsControl
{
    public partial class FetchDigForm : Form
    {
        delegate void SetTextCallback(string text);

        Ag3446x dmm;
        bool isMeas = true;
        double result;
        double[] results;
        Thread meas;
        public FetchDigForm()
        {
            InitializeComponent();
            //while (!isClosed)
             //   ;
        }

        public FetchDigForm(double min, double max, Ag3446x dmm) {
            InitializeComponent();
            //去除最大化，最小化，关闭按钮
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            
            minBox.Text = min.ToString();
            maxBox.Text = max.ToString();
            this.dmm = dmm;

        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.measBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.measBox.Text = text;
            }
        }



        private void measThread() { 
            
            while (isMeas)
            {   if(results != null){
                    results.Initialize();
                }               
                dmm.SCPI.R.QueryAsciiReal(200, out results);
                int count = results.Count();
                for (int i = 0; i < count && isMeas; i++) {
                    if(results[i]>1e25)
                        this.SetText(results[i].ToString("f2"));
                    else
                        this.SetText(((decimal)results[i]).ToString("f2"));
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            isMeas = false;
            if (meas == null) {
                //第一次进入函数
                dmm.SCPI.FORMat.BORDer.Command("SWAPped");
                dmm.SCPI.FORMat.DATA.Command("REAL", null);
                dmm.SCPI.TRIGger.SOURce.Command("IMMediate");
                dmm.SCPI.SAMPle.COUNt.Command(200);
                dmm.SCPI.INITiate.IMMediate.Command();
            }
            if (meas != null) {
                ThreadState state = ThreadState.Aborted | ThreadState.Stopped;
                while ((meas.ThreadState | state) == 0)
                    ;
            }
            isMeas = true;
            meas = new Thread(measThread);
            meas.Start();
            return;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            isMeas = false;
            if (meas != null)
            {
                ThreadState state = ThreadState.Aborted | ThreadState.Stopped;
                while ((meas.ThreadState | state) == 0)
                    ;
                dmm.SCPI.ABORt.Command();
                meas = null;
            }
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (isMeas == true)
                MessageBox.Show("请停止测试再退出！");
            else {
                string str = measBox.Text;
                if (str == null)
                    MessageBox.Show("开始测试然后退出");
                else
                {
                    result = Convert.ToDouble(str);
                    this.Visible = false;
                }
            }
        }
        public double fetchVal() {
            return result;
        }

    }
}
