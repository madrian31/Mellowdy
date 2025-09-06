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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect(pictureBox2);
            ApplyPopUpEffect(pictureBox3);
            ApplyPopUpEffect(pictureBox4);
            ApplyPopUpEffect(pictureBox6);
        }
        private void BackButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width += 5;
                pictureBox.Height += 5;
            }
        }
        private void ApplyPopUpEffect(PictureBox pictureBox)
        {
            // Add the global event handlers to the specified PictureBox
            pictureBox.MouseEnter += BackButton_MouseEnter;
            pictureBox.MouseLeave += BackButton_MouseLeave;

        }
        private void BackButton_MouseLeave(object sender, EventArgs e)
        {
            // Adjust the size when the mouse leaves
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width -= 5;
                pictureBox.Height -= 5;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            _1Categories frm4 = new _1Categories();
            this.Hide();
            frm4.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Homescreen frm1 = new Homescreen();
            frm1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _1Categories frm4 = new _1Categories();
            this.Hide();
            frm4.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Close the entire application
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _2Categories frm4 = new _2Categories();
            this.Hide();
            frm4.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _3Categories frm4 = new _3Categories();
            this.Hide();
            frm4.Show();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Close the entire application
                Application.Exit();
            }
        }
    }
}
