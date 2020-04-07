using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE_filter
{
    public partial class ALE_Tester : Form
    {
        private bool moveFormEnable = false;
        private bool moveChartEnable = false;
        private bool resizeEnable = false;
        private int formSizeX;
        private int formSizeY;
        private int cursorPositionX;
        private int cursorPositionY;
        private int prevCursorPositionX;
        private int prevCursorPositionY;
        private int formPositionX;
        private int formPositionY;

        private bool fullSizeWindow = false;
        private bool panelUpShow = true;
        private bool panelRightShow = true;
        
        private int seriesNumber = 5;

        //options
        public int order { get; set; } = 64;
        public int snr { get; set; } = 10;
        public int nrOfSamples { get; set; } = 1000;
        public double nu { get; set; } = .01;
        public double signalFreq { get; set; } = 20;
        public double samplingFreq { get; set; } = 1000;

        private ALE filter;

        string[] buttonRightPanelName = new string[]
        { "System.Windows.Forms.Button, Text: Input",
         "System.Windows.Forms.Button, Text: Output",
         "System.Windows.Forms.Button, Text: Error",
        "System.Windows.Forms.Button, Text: Clean Input Signal",
        "System.Windows.Forms.Button, Text: Input Noise" };

        public ALE_Tester()
        {
            InitializeComponent();
        }
        

        protected override CreateParams CreateParams
        {

            ///enables shadow behind Main Form
            ///copied from https://stackoverflow.com/questions/16493698/drop-shadow-on-a-borderless-winform

            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
           /*
            * change color of buttonExit after focuse on it
            */


            buttonExit.BackColor = Color.FromArgb(203, 67, 53);
            buttonExit.ForeColor = Color.FromArgb(203, 67, 53);
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
           /*
            * change color of buttonExit when not focuse on it
            */

            buttonExit.BackColor = Color.FromArgb(106, 109, 111);
            buttonExit.ForeColor = Color.FromArgb(106, 109, 111);
        }

        private void ALE_Tester_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < seriesNumber; i++)
            {
                chart1.Series[i].Enabled = false;
            }
            chart1.Series[1].Enabled = true;
            panelOutputLED.BackColor = chart1.Series[1].Color;
        }

        private void panelMain_MouseDown(object sender, MouseEventArgs e)
        {
           /*
            * enable resizing and get current cursos position after clicking on top panel to move form
            */

            moveFormEnable = true;
            cursorPositionX = e.X;
            cursorPositionY = e.Y;
        }

        private void panelMain_MouseUp(object sender, MouseEventArgs e)
        { 
           /*
            * disable moving
            */
            moveFormEnable = false;
        }

        private void panelMain_MouseMove(object sender, MouseEventArgs e)
        {
           /*
            *   move form when main panel is clicked
            */

            if(moveFormEnable)
            {
                this.SetDesktopLocation(MousePosition.X - cursorPositionX, MousePosition.Y - cursorPositionY);
            }
        }

        private void panelRightForResize_MouseUp(object sender, MouseEventArgs e)
        {
            /*
             * disable resizing
             */
            resizeFormDeinit();
        }

        private void panelRightForResize_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            * enable resizing and get current cursos position after clicking on right panel to resize form
            */
            resizeFormInit(ref e);
        }

        private void panelRightForResize_MouseMove(object sender, MouseEventArgs e)
        {
          /*
           * resize
           */
            resizeForm(ref e, false, true, false, false);
        }

        private void panelTopForResize_MouseDown(object sender, MouseEventArgs e)
        {
          /*
           * enable resizing and get current cursos position after clicking on top panel to resize form
           */
            resizeFormInit(ref e);
        }

        private void panelTopForResize_MouseUp(object sender, MouseEventArgs e)
        {
          /*
           * enable resizing and get current cursos position after clicking on top panel to resize form
           */
            resizeFormDeinit();
        }

        private void panelTopForResize_MouseMove(object sender, MouseEventArgs e)
        {
          /*
           * resize
           */
            resizeForm(ref e, true, false, true, false);
        }

        private void panelBottomForResize_MouseDown(object sender, MouseEventArgs e)
        {
          /*
           * enable resizing and get current cursos position after clicking on top panel to resize form
           */
            resizeFormInit(ref e);
        }

        private void panelBottomForResize_MouseUp(object sender, MouseEventArgs e)
        {
          /*
           * enable resizing and get current cursos position after clicking on top panel to resize form
           */
            resizeFormDeinit();
        }

        private void panelBottomForResize_MouseMove(object sender, MouseEventArgs e)
        {
         /*
          * resize
          */
            resizeForm(ref e, true, false, false, false);
        }

        private void panelLeftForResize_MouseDown(object sender, MouseEventArgs e)
        {
           /*
            * enable resizing and get current cursos position after clicking on left panel to resize form
            */
            resizeFormInit(ref e);
        }

        private void panelLeftForResize_MouseUp(object sender, MouseEventArgs e)
        {
          /*
           * enable resizing and get current cursos position after clicking on left panel to resize form
           */
            resizeFormDeinit();
        }

        private void panelLeftForResize_MouseMove(object sender, MouseEventArgs e)
        {
         /*
          * resize
          */
            resizeForm(ref e, false, true, false, true);

        }

        private void panelRightDownCorner_MouseMove(object sender, MouseEventArgs e)
        {
            resizeForm(ref e, true, true, false, false);
        }

        private void panelRightDownCorner_MouseUp(object sender, MouseEventArgs e)
        {
            resizeFormDeinit();
        }

        private void panelRightDownCorner_MouseDown(object sender, MouseEventArgs e)
        {
            resizeFormInit(ref e);
        }

        private void panelLeftDownCorner_MouseDown(object sender, MouseEventArgs e)
        {
            resizeFormInit(ref e);
        }

        private void panelLeftDownCorner_MouseMove(object sender, MouseEventArgs e)
        {
            resizeForm(ref e, true, true, false, true);
        }

        private void panelLeftDownCorner_MouseUp(object sender, MouseEventArgs e)
        {
            resizeFormDeinit();
        }

        private void panelLeftTopCorner_MouseMove(object sender, MouseEventArgs e)
        {
            resizeForm(ref e, true, true, true, true);
        }

        private void panelLeftTopCorner_MouseUp(object sender, MouseEventArgs e)
        {
            resizeFormDeinit();
        }

        private void panelLeftTopCorner_MouseDown(object sender, MouseEventArgs e)
        {
            resizeFormInit(ref e);
        }

        private void resizeFormInit(ref MouseEventArgs e)
        {
            resizeEnable = true;
            cursorPositionX = e.X;
            cursorPositionY = e.Y;
            prevCursorPositionY = cursorPositionY;
            prevCursorPositionX = cursorPositionX;
            formSizeX = this.Size.Width;
            formSizeY = this.Size.Height;
            formPositionX = this.Left;
            formPositionY = this.Top;
        }
        
        private void resizeFormDeinit()
        {
            resizeEnable = false;
        }

        private void resizeForm(ref MouseEventArgs e, bool moveHorizontal, bool moveVertical, bool resizeFromTop, bool ResizeFromLeft)
        {
            if (resizeEnable)
            {
                if (moveVertical)
                {
                    cursorPositionX -= e.X;

                    if (ResizeFromLeft)
                    {
                        int dCursorPositionX = MousePosition.X - prevCursorPositionX; //delta for cursor position
                        prevCursorPositionX = MousePosition.X;

                        this.Size = new Size(this.Size.Width - dCursorPositionX, this.Size.Height);
                            if (this.Size.Width > this.MinimumSize.Width)
                                this.SetDesktopLocation(MousePosition.X, this.Top);
                    }
                    else
                    {
                        this.Size = new Size(formSizeX - cursorPositionX, this.Size.Height);
                    }
                }
                if (moveHorizontal)
                {
                    cursorPositionY -= e.Y;

                    if (resizeFromTop)
                    {
                        int dCursorPositionY = MousePosition.Y - prevCursorPositionY; //delta for cursor position
                        prevCursorPositionY = MousePosition.Y;

                        this.Size = new Size(this.Size.Width, this.Size.Height - dCursorPositionY);
                        if (this.Size.Height > this.MinimumSize.Height)
                            this.SetDesktopLocation(this.Left, MousePosition.Y);
                    }
                    else
                    {
                        this.Size = new Size(this.Size.Width, formSizeY - cursorPositionY);
                    }
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exit Error");
            }
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            fullSizeWindow ^= true;

            if (fullSizeWindow)
            {
                formSizeX = this.Size.Width;
                formSizeY = this.Size.Height;
                formPositionX = this.Left;
                formPositionY = this.Top;

                this.buttonResize.Image = global::ALE_filter.Properties.Resources.minimize;
                this.Location = new Point(0, 0);
                this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            }
            else
            {
                this.buttonResize.Image = global::ALE_filter.Properties.Resources.rectangle;
                this.Location = new Point(formPositionX, formPositionY);
                this.Size = new Size(formSizeX, formSizeY);
            }
        }

        private void buttonMinimalize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelUpControl_Click(object sender, EventArgs e)
        {
            panelUpShow ^= true;

            sidePanelsControls(sender, panelUp, panelUpShow, true);
        }

        private void panelRightControl_Click(object sender, EventArgs e)
        {
            panelRightShow ^= true;

            sidePanelsControls(sender, panelRight, panelRightShow, false);
        }

        private void sidePanelsControls(object controlPanel, object targetPanel ,bool currentState, bool verticalControl)
        {
            Panel cPanel = (Panel)controlPanel;
            Panel tPanel = (Panel)targetPanel;

            if (currentState)
            {
                if (verticalControl)
                {
                    tPanel.Size = new Size(tPanel.Size.Width, Math.Min(tPanel.Size.Width / 5, 100));
                    cPanel.BackgroundImage = global::ALE_filter.Properties.Resources.up_arrow;
                }
                else
                {
                    tPanel.Size = new Size(200, tPanel.Size.Height);
                    cPanel.BackgroundImage = global::ALE_filter.Properties.Resources.right_arrow;
                    panel1.Size = new Size(panel1.Size.Width + (int)((double)tPanel.Size.Width / 1.5), panel1.Size.Height); //this panel is on form by accident, ignore
                }
            }
            else
            {
                if (verticalControl)
                {
                    tPanel.Size = new Size(tPanel.Size.Width, cPanel.Size.Height);
                    cPanel.BackgroundImage = global::ALE_filter.Properties.Resources.down_arrow1;
                }
                else
                {
                    panel1.Size = new Size(panel1.Size.Width - (int)((double)tPanel.Size.Width/1.5), panel1.Size.Height); //this panel is on form by accident, ignore
                    tPanel.Size = new Size(cPanel.Size.Width, tPanel.Size.Height);
                    cPanel.BackgroundImage = global::ALE_filter.Properties.Resources.left_arrow;
                }
            }
        }

        private void RightPanelButton_Enter(object sender, EventArgs e)
        {
            string buttonName = sender.ToString();
            Button button = (Button)sender;

            for (int i = 0; i < buttonRightPanelName.Length; i++)
                if (buttonName == buttonRightPanelName[i])
                {
                    button.BackColor = chart1.Series[i].Color;
                    button.ForeColor = chart1.Series[i].Color;
                    break;
                }
        }

        private void RightPanelButton_Leave(object sender, EventArgs e)
        {
            string buttonName = sender.ToString();
            Button button = (Button)sender;

            button.BackColor = Color.FromArgb(37, 40, 42);
            button.ForeColor = Color.FromArgb(174, 182, 191);
        }

        private void RightPanelButton_Click(object sender, EventArgs e)
        {
            string buttonName = sender.ToString();
            Button button = (Button)sender;

            Panel[] pannelsLED = new Panel[]
            {
            panelInputLED,
            panelOutputLED,
            panelErrorLED,
            panelCleanInputSingalLED,
            panelInputNoiseLED
            };

            for (int i = 0; i < buttonRightPanelName.Length; i++)
            {
                if (buttonName == buttonRightPanelName[i])
                {
                    if (pannelsLED[i].BackColor != chart1.Series[i].Color)
                    {
                        pannelsLED[i].BackColor = chart1.Series[i].Color;
                        chart1.Series[i].Enabled = true;
                    }
                    else
                    {
                        pannelsLED[i].BackColor = button.BackColor = Color.FromArgb(22, 22, 22);
                        chart1.Series[i].Enabled = false;
                    }
                    break;
                }
            }
            chart1.ResetAutoValues();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            chart1.Enabled = true;

            filter = new ALE(order, snr, nrOfSamples, nu, signalFreq, samplingFreq);
            filter.startFilter();
            
            for (int i = 0; i < seriesNumber; i++)
                chart1.Series[i].Points.Clear();

            for (int i = 0; i < nrOfSamples; i++)
            {
                chart1.Series[0].Points.AddXY(filter.timeBuffer[i], filter.inputBuffer[i]);
                chart1.Series[1].Points.AddXY(filter.timeBuffer[i], filter.outputBuffer[i]);
                chart1.Series[2].Points.AddXY(filter.timeBuffer[i], filter.errorBuffer[i]);
                chart1.Series[3].Points.AddXY(filter.timeBuffer[i], filter.cleanInputBuffer[i]);
                chart1.Series[4].Points.AddXY(filter.timeBuffer[i], filter.noiseBuffer[i]);
            }
            this.Enabled = true;
            this.Cursor = Cursors.Default;
            buttonSave.Enabled = true;
        }

        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            double delta = (double)e.Delta / 2400.0;

            double newMinX = Math.Max(chart1.ChartAreas[0].AxisX.Minimum + delta, 0.0);
            newMinX = Math.Min(newMinX, chart1.ChartAreas[0].AxisX.Maximum);
            double newMaxX = Math.Min(chart1.ChartAreas[0].AxisX.Maximum - delta, filter.maximumTime);
            newMaxX = Math.Max(newMaxX, 0);

            
            if (newMaxX - newMinX > 1 / filter.samplingFreq)
            {
                chart1.ChartAreas[0].AxisX.Minimum = newMinX;
                chart1.ChartAreas[0].AxisX.Maximum = newMaxX;
            }
            chart1.ChartAreas[0].AxisX.RoundAxisValues();
            /*
            double newMinY = Math.Max(chart1.ChartAreas[0].AxisY.Minimum + delta, 0.0);
            newMinY = Math.Min(newMinY, 1);
            double newMaxY = Math.Min(chart1.ChartAreas[0].AxisY.Maximum - delta, 1.0);
            newMaxY = Math.Max(newMaxY, 0);

            if (newMaxY - newMinY > 1.0 / 1000.0)
            {
                chart1.ChartAreas[0].AxisY.Minimum = newMinY;
                chart1.ChartAreas[0].AxisY.Maximum = newMaxY;
            }*/
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            moveChartEnable = false;
            chart1.Cursor = Cursors.Cross;
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            moveChartEnable = true;
            chart1.Cursor = Cursors.Hand;
            cursorPositionX = e.X;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveChartEnable)
            {
                double delta = (double)(int)(((double)(cursorPositionX - e.X) / 10000.0) * (chart1.ChartAreas[0].AxisX.Maximum - chart1.ChartAreas[0].AxisX.Minimum) * 100000.0) / 10000.0;

                double newMinX = Math.Max(chart1.ChartAreas[0].AxisX.Minimum + delta, 0.0);
                newMinX = Math.Min(newMinX, chart1.ChartAreas[0].AxisX.Maximum);
                double newMaxX = Math.Min(chart1.ChartAreas[0].AxisX.Maximum + delta, filter.maximumTime);
                newMaxX = Math.Max(newMaxX, 0);

                if (newMaxX - newMinX > 1.0 / filter.samplingFreq)
                {
                    chart1.ChartAreas[0].AxisX.Minimum = newMinX;
                    chart1.ChartAreas[0].AxisX.Maximum = newMaxX;
                }
                chart1.ChartAreas[0].AxisX.RoundAxisValues();
                cursorPositionX = e.X;
            }
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            Form formOptions = new FormSettings(this);
            formOptions.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                Stream fileStream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine("time;input;output;error;clean_input;noise;filter_order;nu");

                // System.Globalization.CultureInfo.InvariantCulture - changes separator to dot.
                string format = "0.000000000";

                streamWriter.Write(filter.timeBuffer[0].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                streamWriter.Write(filter.inputBuffer[0].ToString(format,System.Globalization.CultureInfo.InvariantCulture) + ";");
                streamWriter.Write(filter.outputBuffer[0].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                streamWriter.Write(filter.errorBuffer[0].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                streamWriter.Write(filter.cleanInputBuffer[0].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                streamWriter.Write(filter.noiseBuffer[0].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                streamWriter.Write(order.ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                streamWriter.WriteLine(nu.ToString(format, System.Globalization.CultureInfo.InvariantCulture));

                for (int i = 1; i < nrOfSamples; i++)
                {
                    streamWriter.Write(filter.timeBuffer[i].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                    streamWriter.Write(filter.inputBuffer[i].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                    streamWriter.Write(filter.outputBuffer[i].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                    streamWriter.Write(filter.errorBuffer[i].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                    streamWriter.Write(filter.cleanInputBuffer[i].ToString(format, System.Globalization.CultureInfo.InvariantCulture) + ";");
                    streamWriter.WriteLine(filter.noiseBuffer[i].ToString(format, System.Globalization.CultureInfo.InvariantCulture));
                }

                streamWriter.Close();
                fileStream.Close();
            }
            buttonSave.Enabled = true;
            this.Cursor = Cursors.Default;
        }
    }
}

