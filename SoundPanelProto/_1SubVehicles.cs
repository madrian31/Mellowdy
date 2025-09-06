using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundPanelProto
{
    public partial class _1SubVehicles : Form
    {
        public _1SubVehicles()
        {
            InitializeComponent();
            ApplyPopUpEffect(pictureBox5);
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect(pictureBox2);
            ApplyPopUpEffect(pictureBox7);
            ApplyPopUpEffect(pictureBox3);
        }
        private void ApplyPopUpEffect(PictureBox pictureBox)
        {
            // Add the global event handlers to the specified PictureBox
            pictureBox.MouseEnter += BackButton_MouseEnter;
            pictureBox.MouseLeave += BackButton_MouseLeave;

        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            _1Categories frm1 = new _1Categories();
            frm1.Show();
            this.Hide();
        }

        private void BackButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width += 5;
                pictureBox.Height += 5;
            }
        }

        private void BackButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width -= 5;
                pictureBox.Height -= 5;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Close the entire application
                Application.Exit();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            _1LandVehicles frm1 = new _1LandVehicles();
            frm1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _1WaterVehicles frm1 = new _1WaterVehicles();
            frm1.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _1AerialVehicles frm1 = new _1AerialVehicles();
            frm1.Show();
            this.Hide();
        }
    }
}
