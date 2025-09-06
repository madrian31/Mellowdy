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
    public partial class VOWELSalphabets : Form
    {
        public static string connectionString = "Data Source=LAPTOP-E8GN3HGP\\MSSQLSERVER01; Initial Catalog=db_mellowdy; Integrated Security=True";

        // SqlConnection declared at the class level
        private SqlConnection connection = new SqlConnection(connectionString);
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer wmp;
        public VOWELSalphabets()
        {
            InitializeComponent();
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect2(pictureBox1);
            ApplyPopUpEffect(pictureBox5);
            ApplyPopUpEffect2(pictureBox5);
            ApplyPopUpEffect(pictureBox9);
            ApplyPopUpEffect2(pictureBox9);
            ApplyPopUpEffect(pictureBox15);
            ApplyPopUpEffect2(pictureBox15);
            ApplyPopUpEffect(pictureBox21);
            ApplyPopUpEffect2(pictureBox21);
            ApplyPopUpEffect(pictureBox30);
            ApplyPopUpEffect2(pictureBox30);
            ApplyPopUpEffect(pictureBox29);
            ApplyPopUpEffect2(pictureBox29);


        }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox1.Image;
            int soundIDToPlay = 27; // I-update ito base sa SoundID na nais mong i-play

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

        private void BackButton_Click(object sender, EventArgs e)
        {
            _1SubAlphabets frm1 = new _1SubAlphabets();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox5.Image;
            int soundIDToPlay = 28; // I-update ito base sa SoundID na nais mong i-play

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
            int soundIDToPlay = 29; // I-update ito base sa SoundID na nais mong i-play

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
            int soundIDToPlay = 30; // I-update ito base sa SoundID na nais mong i-play

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
            int soundIDToPlay = 31; // I-update ito base sa SoundID na nais mong i-play

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
    }
}
