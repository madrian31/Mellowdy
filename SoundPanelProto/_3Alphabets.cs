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
    public partial class _3Alphabets : Form
    {
        public _3Alphabets()
        {
            InitializeComponent();
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect2(pictureBox1);
            ApplyPopUpEffect(pictureBox2);
            ApplyPopUpEffect2(pictureBox2);
            ApplyPopUpEffect(pictureBox3);
            ApplyPopUpEffect2(pictureBox3);
            ApplyPopUpEffect(pictureBox7);
            ApplyPopUpEffect2(pictureBox7);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _3Categories frm5 = new _3Categories();
            this.Hide();
            frm5.Show();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ABCAlphabets frm1 = new ABCAlphabets();
            frm1.UpdateLabelText("Prep");
            frm1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _3Phonics frm1 = new _3Phonics();
            frm1.Show();
            this.Hide();
        }

        //END
    }
}
