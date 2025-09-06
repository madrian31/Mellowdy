using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Media;
using System.Numerics;
using System.Drawing;
using WMPLib;
using System;
using System.Diagnostics.Tracing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;
using Timer = System.Windows.Forms.Timer;
using System.Reflection.Metadata;

namespace SoundPanelProto
{
    public partial class ABCAlphabets : Form
    {
        public static string connectionString = "Data Source=LAPTOP-E8GN3HGP\\MSSQLSERVER01; Initial Catalog=db_mellowdy; Integrated Security=True";

        // SqlConnection declared at the class level
        private SqlConnection connection = new SqlConnection(connectionString);
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer wmp;

        public ABCAlphabets()
        {
            InitializeComponent();
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect(pictureBox2);
            ApplyPopUpEffect(pictureBox3);
            ApplyPopUpEffect(pictureBox4);
            ApplyPopUpEffect(pictureBox5);
            ApplyPopUpEffect(pictureBox6);
            ApplyPopUpEffect(pictureBox7);
            ApplyPopUpEffect(pictureBox8);
            ApplyPopUpEffect(pictureBox9);
            ApplyPopUpEffect(pictureBox10);

            ApplyPopUpEffect(pictureBox11);
            ApplyPopUpEffect(pictureBox12);
            ApplyPopUpEffect(pictureBox13);
            ApplyPopUpEffect(pictureBox14);
            ApplyPopUpEffect(pictureBox15);
            ApplyPopUpEffect(pictureBox16);
            ApplyPopUpEffect(pictureBox17);
            ApplyPopUpEffect(pictureBox18);
            ApplyPopUpEffect(pictureBox19);
            ApplyPopUpEffect(pictureBox20);
            ApplyPopUpEffect(pictureBox21);
            ApplyPopUpEffect(pictureBox22);
            ApplyPopUpEffect(pictureBox23);
            ApplyPopUpEffect(pictureBox24);
            ApplyPopUpEffect(pictureBox25);
            ApplyPopUpEffect(pictureBox26);

            ApplyPopUpEffect(pictureBox29);
            ApplyPopUpEffect(pictureBox30);



            ApplyPopUpEffect2(pictureBox1);
            ApplyPopUpEffect2(pictureBox2);
            ApplyPopUpEffect2(pictureBox3);
            ApplyPopUpEffect2(pictureBox4);
            ApplyPopUpEffect2(pictureBox5);
            ApplyPopUpEffect2(pictureBox6);
            ApplyPopUpEffect2(pictureBox7);
            ApplyPopUpEffect2(pictureBox8);
            ApplyPopUpEffect2(pictureBox9);
            ApplyPopUpEffect2(pictureBox10);

            ApplyPopUpEffect2(pictureBox11);
            ApplyPopUpEffect2(pictureBox12);
            ApplyPopUpEffect2(pictureBox13);
            ApplyPopUpEffect2(pictureBox14);
            ApplyPopUpEffect2(pictureBox15);
            ApplyPopUpEffect2(pictureBox16);
            ApplyPopUpEffect2(pictureBox17);
            ApplyPopUpEffect2(pictureBox18);
            ApplyPopUpEffect2(pictureBox19);
            ApplyPopUpEffect2(pictureBox20);
            ApplyPopUpEffect2(pictureBox21);
            ApplyPopUpEffect2(pictureBox22);
            ApplyPopUpEffect2(pictureBox23);
            ApplyPopUpEffect2(pictureBox24);
            ApplyPopUpEffect2(pictureBox25);
            ApplyPopUpEffect2(pictureBox26);

            ApplyPopUpEffect2(pictureBox29);
            ApplyPopUpEffect2(pictureBox30);



        }



        private void BackButton_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Nursery") {
                _1SubAlphabets frm1 = new _1SubAlphabets();
                frm1.Show();
                this.Hide();
            }
            else if (label1.Text == "Kinder") {
                _2SubAlphabets frm2 = new _2SubAlphabets();
                frm2.Show();
                this.Hide();
            }
            else if (label1.Text == "Prep")
            {
                _3Alphabets frm2 = new _3Alphabets();
                frm2.Show();
                this.Hide();
            }
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
            pictureBox.MouseEnter += BackButton_MouseEnter;
            pictureBox.MouseLeave += BackButton_MouseLeave;

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
        private void ApplyPopUpEffect2(PictureBox pictureBox)
        {
            // Add the global event handlers to the specified PictureBox
            pictureBox.MouseDown += BackButton_MouseDown;
            pictureBox.MouseUp += BackButton_MouseUp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox1.Image;
            int soundIDToPlay = 1; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox2.Image;
            int soundIDToPlay = 2; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox3.Image;
            int soundIDToPlay = 3; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox4.Image;
            int soundIDToPlay = 4; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox5.Image;
            int soundIDToPlay = 5; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox6.Image;
            int soundIDToPlay = 6; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox7.Image;
            int soundIDToPlay = 7; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox8.Image;
            int soundIDToPlay = 8; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox9.Image;
            int soundIDToPlay = 9; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox10.Image;
            int soundIDToPlay = 10; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox11.Image;
            int soundIDToPlay = 11; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox12.Image;
            int soundIDToPlay = 12; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox13.Image;
            int soundIDToPlay = 13; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox14.Image;
            int soundIDToPlay = 14; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox15.Image;
            int soundIDToPlay = 15; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox16.Image;
            int soundIDToPlay = 16; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox17.Image;
            int soundIDToPlay = 17; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox18.Image;
            int soundIDToPlay = 18; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox19.Image;
            int soundIDToPlay = 19; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox20.Image;
            int soundIDToPlay = 20; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox21.Image;
            int soundIDToPlay = 21; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox22.Image;
            int soundIDToPlay = 22; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox23.Image;
            int soundIDToPlay = 23; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox24.Image;
            int soundIDToPlay = 24; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox25.Image;
            int soundIDToPlay = 25; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox26.Image;
            int soundIDToPlay = 26; // I-update ito base sa SoundID na nais mong i-play

            string filePath = GetFilePathBySoundID(soundIDToPlay);

            if (!string.IsNullOrEmpty(filePath))
            {


                Player.URL = filePath;
                Player.controls.play();

            }

            else
            {
                MessageBox.Show("Sound file not found");
            }
        }

        //SOUNDS
        private string GetFilePathBySoundID(int soundID)
        {
            string filePath = null;

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT SoundData FROM tbl_EnglishALPHABETS WHERE SoundID = @SoundID", connection);
            cmd.Parameters.AddWithValue("@SoundID", soundID);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    byte[] fileData = (byte[])reader["SoundData"];
                    string tempFileName = Path.GetTempFileName();
                    File.WriteAllBytes(tempFileName, fileData);
                    filePath = tempFileName;
                }
            }

            connection.Close();

            return filePath;
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Close the entire application
                Application.Exit();
            }
        }

        public void UpdateLabelText(string newText)
        {
            label1.Text = newText;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //END
    }
}
