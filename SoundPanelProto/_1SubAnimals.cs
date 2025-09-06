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
    public partial class _1SubAnimals : Form
    {
        public _1SubAnimals()
        {
            InitializeComponent();
            ApplyPopUpEffect(pictureBox5);
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect(pictureBox2);
            ApplyPopUpEffect(pictureBox7);
            ApplyPopUpEffect(pictureBox3);


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
        private void ApplyPopUpEffect(PictureBox pictureBox)
        {
            // Add the global event handlers to the specified PictureBox
            pictureBox.MouseEnter += BackButton_MouseEnter;
            pictureBox.MouseLeave += BackButton_MouseLeave;

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            _1WaterAnimals form = new _1WaterAnimals();
            form.Show();
            this.Hide();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _1Categories frm1 = new _1Categories();
            frm1.Show();
            this.Hide();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _1LandAnimals frm1 = new _1LandAnimals();
            frm1.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            _1LandAnimals frm1 = new _1LandAnimals();
            frm1.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            _1WaterAnimals form = new _1WaterAnimals();
            form.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
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
            _1AerialAnimal frm1 = new _1AerialAnimal();
            frm1.Show();
            this.Hide();
        }
    }
}
