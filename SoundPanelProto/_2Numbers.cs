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
    public partial class _2Numbers : Form
    {
        public static string connectionString = "Data Source=LAPTOP-E8GN3HGP\\MSSQLSERVER01; Initial Catalog=db_mellowdy; Integrated Security=True";

        // SqlConnection declared at the class level
        private SqlConnection connection = new SqlConnection(connectionString);
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer wmp;

        public _2Numbers()
        {
            InitializeComponent();
            //1
            

            ApplyPopUpEffect(pictureBox29);
            ApplyPopUpEffect(pictureBox30);

            //2
         

            ApplyPopUpEffect2(pictureBox29);
            ApplyPopUpEffect2(pictureBox30);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _2Categories frm1 = new _2Categories();
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
        private string GetFilePathBySoundID(int soundID)
        {
            string filePath = null;

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT SoundData FROM tbl_Numbers WHERE SoundID = @SoundID", connection);
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
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox11.Image;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox1.Image;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox2.Image;
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox3.Image;
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox4.Image;
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox8.Image;
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
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox9.Image;
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
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox10.Image;
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox7.Image;
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox6.Image;
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox5.Image;
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

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox13.Image;
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

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox14.Image;
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

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox15.Image;
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

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox16.Image;
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
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox17.Image;
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


        private void pictureBox18_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox18.Image;
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

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox19.Image;
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

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox20.Image;
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

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox21.Image;
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

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox22.Image;
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

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox23.Image;
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

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox24.Image;
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
        private void pictureBox25_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox17.Image;
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
        private void pictureBox26_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox26.Image;
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

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox27.Image;
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

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox31.Image;
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

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox32.Image;
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

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox33.Image;
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

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox34.Image;
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

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox35.Image;
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

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox36.Image;
            int soundIDToPlay = 32; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox37.Image;
            int soundIDToPlay = 33; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox38.Image;
            int soundIDToPlay = 34; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox39.Image;
            int soundIDToPlay = 35; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox40.Image;
            int soundIDToPlay = 36; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox41.Image;
            int soundIDToPlay = 37; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox42.Image;
            int soundIDToPlay = 38; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox43.Image;
            int soundIDToPlay = 39; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox44.Image;
            int soundIDToPlay = 40; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox45.Image;
            int soundIDToPlay = 41; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox46.Image;
            int soundIDToPlay = 42; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox47.Image;
            int soundIDToPlay = 43; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox48.Image;
            int soundIDToPlay = 44; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox49.Image;
            int soundIDToPlay = 45; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox50.Image;
            int soundIDToPlay = 46; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox51.Image;
            int soundIDToPlay = 47; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox52.Image;
            int soundIDToPlay = 48; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox53.Image;
            int soundIDToPlay = 49; // I-update ito base sa SoundID na nais mong i-play

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

        private void pictureBox54_Click(object sender, EventArgs e)
        {
            picDisplay.Image = pictureBox54.Image;
            int soundIDToPlay = 50; // I-update ito base sa SoundID na nais mong i-play

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








        //END
    }
}
