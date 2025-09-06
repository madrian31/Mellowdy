using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Media;

namespace SoundPanelProto
{
    public partial class Homescreen : Form
    {
        public static string connectionString = "Data Source=LAPTOP-E8GN3HGP\\MSSQLSERVER01; Initial Catalog=db_mellowdy; Integrated Security=True";
        private SoundPlayer backgroundMusicPlayer;
        public Homescreen()
        {
            InitializeComponent();

            backgroundMusicPlayer = new SoundPlayer();

            // Handle the Form's Load event


            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect(pictureBox2);
            ApplyPopUpEffect(pictureBox3);
            ApplyPopUpEffect(pictureBox4);
            ApplyPopUpEffect(pictureBox5);
            ApplyPopUpEffect(pictureBox6);
            ApplyPopUpEffect(pictureBox7);
            ApplyPopUpEffect(pictureBox9);
        }

        private void ApplyPopUpEffect(PictureBox pictureBox)
        {
            // Add the global event handlers to the specified PictureBox
            pictureBox.MouseEnter += pictureBox5_MouseEnter;
            pictureBox.MouseLeave += pictureBox5_MouseLeave;

        }


        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width += 5;
                pictureBox.Height += 5;
            }
        }


        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            // Adjust the size when the mouse leaves
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width -= 5;
                pictureBox.Height -= 5;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel2.BringToFront();
            pictureBox8.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            button2.SendToBack();  // Send the hide button to back
            button1.BringToFront();
            // Bring the unhide button to front
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            button1.SendToBack();  // Send the hide button to back
            button2.BringToFront();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // If it is, move the focus to textBox2
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // If it is, perform the button1 click
                pictureBox3_Click(sender, e);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM Admins WHERE Username=@Username AND Password=@Password";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.Parameters.AddWithValue("@Password", textBox2.Text);

                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 1)
                {
                    Admin frm6 = new Admin();
                    this.Hide();
                    frm6.Show();
                }
                else
                {
                    MessageBox.Show("wrong password");
                }
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            panel2.SendToBack();
            panel2.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";

            panel1.Visible = true;
            panel1.BringToFront();
            pictureBox8.BringToFront();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                // Connect to your database
                using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-E8GN3HGP\\MSSQLSERVER01; Initial Catalog=db_mellowdy; Integrated Security=True"))
                {
                    connection.Open();

                    // Specify the table and ID
                    string tableName = "tbl_SoundAssets";
                    int soundID = 2;

                    // Retrieve SoundData from the database
                    string query = $"SELECT SoundData FROM {tableName} WHERE SoundID = @SoundID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SoundID", soundID);
                        byte[] soundData = (byte[])command.ExecuteScalar();

                        // Play the background music in a loop
                        PlaySoundFromByteArray(soundData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PlaySoundFromByteArray(byte[] soundData)
        {
            try
            {
                // Check if soundData is not null
                if (soundData != null && soundData.Length > 0)
                {
                    // Create a MemoryStream from the byte array
                    using (MemoryStream memoryStream = new MemoryStream(soundData))
                    {
                        // Load the SoundPlayer with the MemoryStream
                        backgroundMusicPlayer.Stream = memoryStream;

                        // Play the background music in a loop
                        backgroundMusicPlayer.PlayLooping();
                    }
                }
                else
                {
                    MessageBox.Show("SoundData is null or empty.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound: " + ex.Message);
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel5.BringToFront();
            pictureBox8.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }
    }
}

