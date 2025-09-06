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
    public partial class _2Categories : Form
    {
        public _2Categories()
        {
            InitializeComponent();
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect2(pictureBox1);
            ApplyPopUpEffect(pictureBox6);
            ApplyPopUpEffect2(pictureBox6);
            ApplyPopUpEffect(pictureBox3);
            ApplyPopUpEffect2(pictureBox3);
            ApplyPopUpEffect(pictureBox7);
            ApplyPopUpEffect2(pictureBox7);
            ApplyPopUpEffect(pictureBox5);
            ApplyPopUpEffect2(pictureBox5);
            ApplyPopUpEffect2(pictureBox4);
            ApplyPopUpEffect(pictureBox4);
        }

        private void ApplyPopUpEffect(PictureBox pictureBox)
        {
            // Add the global event handlers to the specified PictureBox
            pictureBox.MouseEnter += BackButton_MouseEnter;
            pictureBox.MouseLeave += BackButton_MouseLeave;

        }

        private void ApplyPopUpEffect2(PictureBox pictureBox)
        {
            // Add the global event handlers to the specified PictureBox
            pictureBox.MouseDown += BackButton_MouseDown;
            pictureBox.MouseUp += BackButton_MouseUp;
        }

        private void BackButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width += 10;
                pictureBox.Height += 10;
            }
        }

        private void BackButton_MouseLeave(object sender, EventArgs e)
        {
            // Adjust the size when the mouse leaves
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width -= 10;
                pictureBox.Height -= 10;
            }
        }

        private void BackButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width -= 10;
                pictureBox.Height -= 10;
            }
        }

        private void BackButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width += 10;
                pictureBox.Height += 10;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            _2Vehicles frm5 = new _2Vehicles();
            this.Hide();
            frm5.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            _2SubAnimals frm5 = new _2SubAnimals();
            this.Hide();
            frm5.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form3 frm5 = new Form3();
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
            _2SubAlphabets frm5 = new _2SubAlphabets();
            this.Hide();
            frm5.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _2Numbers frm5 = new _2Numbers();
            this.Hide();
            frm5.Show();
        }
    }
}
