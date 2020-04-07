using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE_filter
{
    public partial class FormSettings : Form
    {


        private ALE_Tester mainForm;

        private bool moveFormEnable;
        private int cursorPositionX, cursorPositionY;



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

        public FormSettings(Form callingForm)
        {
            mainForm = callingForm as ALE_Tester;
            InitializeComponent();
            this.Location = new Point(MousePosition.X,MousePosition.Y);

            textBoxFilterOrder.Text = mainForm.order.ToString();
            textBoxNu.Text = mainForm.nu.ToString();
            textBoxNumberOfSamples.Text = mainForm.nrOfSamples.ToString();
            textBoxSNR.Text = mainForm.snr.ToString();
            textBoxSamplingFreq.Text = mainForm.samplingFreq.ToString();
            textBoxPureSigFreq.Text = mainForm.signalFreq.ToString();
        }

        private void FormSettings_MouseUp(object sender, MouseEventArgs e)
        {

            /*
             * disable moving
             */
            moveFormEnable = false;
        }

        private void FormSettings_MouseDown(object sender, MouseEventArgs e)
        {
            /*
             * enable resizing and get current cursos position after clicking on top panel to move form
             */

            moveFormEnable = true;
            cursorPositionX = e.X;
            cursorPositionY = e.Y;
        }

        private void FormSettings_MouseMove(object sender, MouseEventArgs e)
        {

            /*
             *   move form when main panel is clicked
             */

            if (moveFormEnable)
            {
                this.SetDesktopLocation(MousePosition.X - cursorPositionX, MousePosition.Y - cursorPositionY);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                mainForm.order = (int)Convert.ToDouble(textBoxFilterOrder.Text);
                mainForm.nu = Convert.ToDouble(textBoxNu.Text);
                mainForm.nrOfSamples = (int)Convert.ToDouble(textBoxNumberOfSamples.Text);
                mainForm.snr = (int)Convert.ToDouble(textBoxSNR.Text);
                mainForm.samplingFreq = Convert.ToDouble(textBoxSamplingFreq.Text);
                mainForm.signalFreq = Convert.ToDouble(textBoxPureSigFreq.Text);
                this.Close();
            }
            catch
            {
                labelError.Enabled = true;
                labelError.Visible = true;
            }
        }
    }
}
