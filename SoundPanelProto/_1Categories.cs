using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundPanelProto
{
    public partial class _1Categories : Form
    {
        private Panel[] panel;
        public _1Categories()
        {
            InitializeComponent();
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect(pictureBox3);
            ApplyPopUpEffect(pictureBox6);
            ApplyPopUpEffect(pictureBox4);
            ApplyPopUpEffect(pictureBox7);
            ApplyPopUpEffect(pictureBox5);

        }
        private void BackButton_MouseEnter_1(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width += 5;
                pictureBox.Height += 5;
            }
        }

        private void BackButton_MouseLeave_1(object sender, EventArgs e)
        {
            // Adjust the size when the mouse leaves
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width -= 5;
                pictureBox.Height -= 5;
            }
        }

        private void ApplyPopUpEffect(PictureBox pictureBox)
        {
            // Add the global event handlers to the specified PictureBox
            pictureBox.MouseEnter += BackButton_MouseEnter_1;
            pictureBox.MouseLeave += BackButton_MouseLeave_1;

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                panel.Width += 4;
                panel.Height += 4;
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                panel.Width -= 4;
                panel.Height -= 4;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form3 frm1 = new Form3();
            frm1.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            _1SubAnimals frm5 = new _1SubAnimals();
            this.Hide();
            frm5.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Close the entire application
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _1SubAlphabets frm1 = new _1SubAlphabets();
            frm1.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _1Numbers frm1 = new _1Numbers();
            frm1.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            _1SubVehicles frm1 = new _1SubVehicles();
            frm1.Show();
            this.Hide();
        }
    }
}
