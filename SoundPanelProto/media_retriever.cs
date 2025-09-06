using System;
using System.Data.SqlClient;
using System.IO;
using System.Media;
using WMPLib;
using System.Windows.Forms;

namespace SoundPanelProto
{
    public class media_retriever
    {

        SqlConnection connection;
        string connectionString = "Data Source=DESKTOP-VIJ33BO\\SQLEXPRESS; Initial Catalog=Mellowdy; Integrated Security=True";
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();

        public media_retriever()
        {
            connection = new SqlConnection(connectionString);
        }

        public void PlaySound(int soundIDToPlay)
        {
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

        public string GetFileNameBySoundID(int soundID)
        {
            string fileName = null;

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT SoundTitle FROM Sounds WHERE SoundID = @SoundID", connection);
            cmd.Parameters.AddWithValue("@SoundID", soundID);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    fileName = reader["SoundTitle"].ToString();
                }
            }

            connection.Close();

            return fileName;
        }

        public string GetFilePathBySoundID(int soundID)
        {
            string filePath = null;

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT SoundData FROM Sounds WHERE SoundID = @SoundID", connection);
            cmd.Parameters.AddWithValue("@SoundID", soundID);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    byte[] fileData = (byte[])reader["SoundData"];
                    string tempFileName = Path.GetTempFileName();
                    string mp3TempFileName = Path.ChangeExtension(tempFileName, ".mp3");
                    File.WriteAllBytes(mp3TempFileName, fileData);
                    filePath = mp3TempFileName;
                }
            }

            connection.Close();

            return filePath;
        }

        public void AvatarRetriever(string SoundTitle, PictureBox pictureBox)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT ImageData FROM Sounds WHERE SoundTitle = @SoundTitle";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SoundTitle", SoundTitle);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] imageBytes = (byte[])reader["ImageData"];

                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    Image image = Image.FromStream(ms);
                                    pictureBox.Image = image;

                                    Image resizedImage = new Bitmap(image, pictureBox.Width, pictureBox.Height);

                                    pictureBox.Image = resizedImage;

                                }
                            }
                            else
                            {
                                pictureBox.Image = null;
                                MessageBox.Show("There are no images associated with SoundTitle: " + SoundTitle);
                            }
                        }
                        else
                        {
                            pictureBox.Image = null;
                            MessageBox.Show("Cannot find sound with SoundTitle: " + SoundTitle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    }
}
