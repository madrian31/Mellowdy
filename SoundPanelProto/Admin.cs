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
    public partial class Admin : Form
    {
        private SqlConnection connection = new SqlConnection("Server=LAPTOP-E8GN3HGP\\MSSQLSERVER01;Database=db_mellowdy;Integrated Security=True;");
        private TextBox[] soundNameTextBoxes = new TextBox[10];
        private PictureBox[] pictureBoxes = new PictureBox[10];
        private PictureBox[] playPictureBoxes = new PictureBox[10];
        private WindowsMediaPlayer soundPlayer = new WindowsMediaPlayer(); // Use a single instance

        private string[] soundDataArray = new string[10];

        public Admin()
        {
            InitializeComponent();
            InitializeControls();

         

            ApplyPopUpEffect(save1);
            ApplyPopUpEffect2(save1);
            ApplyPopUpEffect(save2);
            ApplyPopUpEffect2(save2);
            ApplyPopUpEffect(save3);
            ApplyPopUpEffect2(save3);
            ApplyPopUpEffect(save4);
            ApplyPopUpEffect2(save4);
            ApplyPopUpEffect(save5);
            ApplyPopUpEffect2(save5);
            ApplyPopUpEffect(save6);
            ApplyPopUpEffect2(save6);
            ApplyPopUpEffect(save7);
            ApplyPopUpEffect2(save7);
            ApplyPopUpEffect(save8);
            ApplyPopUpEffect2(save8);
            ApplyPopUpEffect(save9);
            ApplyPopUpEffect2(save9);
            ApplyPopUpEffect(save10);
            ApplyPopUpEffect2(save10);
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect2(pictureBox1);
            ApplyPopUpEffect(pictureBox6);
            ApplyPopUpEffect2(pictureBox6);

            ApplyPopUpEffect2(pictureBox3);
            ApplyPopUpEffect(pictureBox3);
            ApplyPopUpEffect2(pictureBox4);
            ApplyPopUpEffect(pictureBox4);

            ApplyPopUpEffect(d1);
            ApplyPopUpEffect(d2);
            ApplyPopUpEffect(d3);
            ApplyPopUpEffect(d4);
            ApplyPopUpEffect(d5);
            ApplyPopUpEffect(d6);
            ApplyPopUpEffect(d7);
            ApplyPopUpEffect(d8);
            ApplyPopUpEffect(d9);
            ApplyPopUpEffect(d10);

            ApplyPopUpEffect2(d1);
            ApplyPopUpEffect2(d2);
            ApplyPopUpEffect2(d3);
            ApplyPopUpEffect2(d4);
            ApplyPopUpEffect2(d5);
            ApplyPopUpEffect2(d6);
            ApplyPopUpEffect2(d7);
            ApplyPopUpEffect2(d8);
            ApplyPopUpEffect2(d9);
            ApplyPopUpEffect2(d10);

            ApplyPopUpEffect(play1);
            ApplyPopUpEffect(play2);
            ApplyPopUpEffect(play3);
            ApplyPopUpEffect(play4);
            ApplyPopUpEffect(play5);
            ApplyPopUpEffect(play6);
            ApplyPopUpEffect(play7);
            ApplyPopUpEffect(play8);
            ApplyPopUpEffect(play9);
            ApplyPopUpEffect(play10);

            ApplyPopUpEffect2(play1);
            ApplyPopUpEffect2(play2);
            ApplyPopUpEffect2(play3);
            ApplyPopUpEffect2(play4);
            ApplyPopUpEffect2(play5);
            ApplyPopUpEffect2(play6);
            ApplyPopUpEffect2(play7);
            ApplyPopUpEffect2(play8);
            ApplyPopUpEffect2(play9);
            ApplyPopUpEffect2(play10);
        }

        private void InitializeControls()
        {
            for (int i = 0; i < 10; i++)
            {
                soundNameTextBoxes[i] = Controls.Find($"Lname{i + 1}", true).FirstOrDefault() as TextBox;
                pictureBoxes[i] = Controls.Find($"pic{i + 1}", true).FirstOrDefault() as PictureBox;
                playPictureBoxes[i] = Controls.Find($"play{i + 1}", true).FirstOrDefault() as PictureBox;
                playPictureBoxes[i].Click += (sender, e) => PlaySoundBySoundID(i + 1);
            }
        }


        private bool IsValidImageData(byte[] imageData)
        {
            try
            {
                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image.FromStream(ms);
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void PlaySoundBySoundID(int soundID)
        {
            if (soundID >= 1 && soundID <= 10)
            {
                string soundData = soundDataArray[soundID - 1];
                if (!string.IsNullOrEmpty(soundData) && File.Exists(soundData))
                {
                    soundPlayer.URL = soundData;
                    soundPlayer.controls.play();
                }
                else
                {
                    MessageBox.Show($"Sound data for SoundID {soundID} is not available or the file does not exist.");
                }
            }
        }

        private string GetFilePathBySoundID(int soundID, string selectedTable)
        {
            string filePath = null;

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection);
                command.Parameters.AddWithValue("@SoundID", soundID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] fileData = (byte[])reader["SoundData"];
                        string tempFileName = Path.GetTempFileName();
                        File.WriteAllBytes(tempFileName, fileData);
                        filePath = tempFileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return filePath;
        }

        private void play1_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 1;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }





        //LOADABLE1
        // Declare the current editing sound ID as a class-level variable
        private int currentEditingSoundID = 1;

        // Add this method to handle the click event of Lsound1 button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.ogg"; // Add more formats if needed

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Read the selected audio file and update the UI (not the database yet)
                        string selectedFilePath = openFileDialog.FileName;
                        soundInfo1.Text = Path.GetFileName(selectedFilePath);

                        // Read and store the audio file data
                        byte[] audioData = File.ReadAllBytes(selectedFilePath);
                        soundDataArray[currentEditingSoundID - 1] = Convert.ToBase64String(audioData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        // Add this method to handle the click event of your image-related button (e.g., Limage1)

        private void Lbutton1_Click(object sender, EventArgs e)
        {

        }

        //LOADABLE2
        // Add this method to handle the click event of Lsound2 button




        // Modify the SaveButtonClick method

        private void button2_Click(object sender, EventArgs e)
        {
            // Handle button click events
        }






        // Add similar event handlers for play2, play3, ..., play10

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle ComboBox selection changes
        }

        private void comboBoxGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle ComboBox selection changes
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // Load data into the ComboBoxes when the form loads
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Handle group box events
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void CBGradeLevel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CBCategories.Enabled = true;
        }

        private void CBSubCategories_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CBCategories_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CBSubCategories.Enabled = true;
        }

        private void CBSubCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

        private void button5_Click(object sender, EventArgs e)
        {




        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Stop the soundPlayer if it's playing
                if (soundPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    soundPlayer.controls.stop();
                }

                // Open the Homescreen form
                Homescreen frm1 = new Homescreen();
                frm1.Show();

                // Hide the current form
                this.Hide();
            }
        }

        private void Lbutton1_Click_1(object sender, EventArgs e)
        {

        }

        private void soundData1_Click(object sender, EventArgs e)
        {

        }


        // Declare this at the class level
        private string soundFilePath1;

        // Declare these at the class level
        private string imageFilePath1;

        private void pic1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    openFileDialog1.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pic1.ImageLocation = openFileDialog1.FileName;
                        imageFilePath1 = openFileDialog1.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic1: {ex.Message}");
            }
        }

        private void save1_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L1.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L1.Text is black
                        if (L1.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname1.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname1.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath1) && File.Exists(soundFilePath1))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath1);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath1) && File.Exists(imageFilePath1))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath1);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            MessageBox.Show("Saved Successfully!");
                            sound1.Text = "EDIT SOUND";
                            sound1.BackColor = Color.MediumVioletRed;
                            soundInfo1.Visible = false;
                            // Change the color of L1.Text to Yellow only if L1.Text color is black
                            if (L1.ForeColor == Color.Black)
                            {
                                L1.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L1.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname1.Text) &&
                       !string.IsNullOrEmpty(soundFilePath1) &&
                       !string.IsNullOrEmpty(imageFilePath1);
            }


        }
        private void sound1_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    openFileDialog1.Filter = "Audio/Video Files|*.wav;*.mp3;*.ogg;*.flac;*.mp4|All files (*.*)|*.*";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        sound1.Text = "CHANGE";
                        sound1.BackColor = Color.DarkGreen;

                        soundInfo1.Visible = true;
                        soundInfo1.Text = openFileDialog1.SafeFileName;

                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath1 = openFileDialog1.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }


        }



        // Declare this at the class level
        private string soundFilePath2;

        // Declare these at the class level
        private string imageFilePath2;
        private void pic2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog2 = new OpenFileDialog())
                {
                    openFileDialog2.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        pic2.ImageLocation = openFileDialog2.FileName;
                        imageFilePath2 = openFileDialog2.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic2: {ex.Message}");
            }
        }

        private void play2_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 2;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }

        private void sound2_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog2 = new OpenFileDialog())
                {
                    openFileDialog2.Filter = "Audio/Video Files|*.wav;*.mp3;*.ogg;*.flac;*.mp4|All files (*.*)|*.*";

                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        soundInfo2.Visible = true;
                        soundInfo2.Text = openFileDialog2.SafeFileName;
                        sound2.Text = "CHANGE";
                        sound2.BackColor = Color.DarkGreen;
                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath2 = openFileDialog2.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }
        }

        private void save2_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L2.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L2.Text is black
                        if (L2.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname2.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname2.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath2) && File.Exists(soundFilePath2))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath2);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath2) && File.Exists(imageFilePath2))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath2);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            MessageBox.Show("Saved Successfully!");
                            sound2.Text = "EDIT SOUND";
                            sound2.BackColor = Color.MediumVioletRed;
                            soundInfo2.Visible = false;
                            // Change the color of L2.Text to Yellow only if L2.Text color is black
                            if (L2.ForeColor == Color.Black)
                            {
                                L2.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L2.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname2.Text) &&
                       !string.IsNullOrEmpty(soundFilePath2) &&
                       !string.IsNullOrEmpty(imageFilePath2);
            }

        }

        //LOADABLE3
        private string soundFilePath3;
        private string imageFilePath3;
        private void pic3_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog3 = new OpenFileDialog())
                {
                    openFileDialog3.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog3.ShowDialog() == DialogResult.OK)
                    {
                        pic3.ImageLocation = openFileDialog3.FileName;
                        imageFilePath3 = openFileDialog3.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic3: {ex.Message}");
            }
        }

        private void play3_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 3;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }

        private void sound3_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog3 = new OpenFileDialog())
                {
                    openFileDialog3.Filter = "Audio/Video Files|*.wav;*.mp3;*.ogg;*.flac;*.mp4|All files (*.*)|*.*";

                    if (openFileDialog3.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        soundInfo3.Visible = true;
                        soundInfo3.Text = openFileDialog3.SafeFileName;
                        sound3.Text = "CHANGE";
                        sound3.BackColor = Color.DarkGreen;
                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath3 = openFileDialog3.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }
        }

        private void save3_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L3.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L3.Text is black
                        if (L3.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname3.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname3.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath3) && File.Exists(soundFilePath3))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath3);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath3) && File.Exists(imageFilePath3))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath3);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            MessageBox.Show("Saved Successfully!");
                            sound3.Text = "EDIT SOUND";
                            sound3.BackColor = Color.MediumVioletRed;
                            soundInfo3.Visible = false;
                            // Change the color of L3.Text to Yellow only if L3.Text color is black
                            if (L3.ForeColor == Color.Black)
                            {
                                L3.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L3.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname3.Text) &&
                       !string.IsNullOrEmpty(soundFilePath3) &&
                       !string.IsNullOrEmpty(imageFilePath3);
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
                pictureBox.Width -= 5;
                pictureBox.Height -= 5;
            }
        }

        private void BackButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                pictureBox.Width += 5;
                pictureBox.Height += 5;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            try
            {
                // Check if Grade Level, Categories, and SubCategories are selected
                if (CBGradeLevel.SelectedItem == null || CBCategories.SelectedItem == null || CBSubCategories.SelectedItem == null)
                {
                    MessageBox.Show("Complete all the details of Grade Level, Categories, SubCategories!");
                    return;
                }

                // If all details are complete, proceed with the selectedTable calculation
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");
                soundPlayer.controls.stop();
                connection.Open();
                pictureBox4.Visible = true;
                // Enable loadable controls outside the loop
                loadable1.Enabled = true;
                loadable2.Enabled = true;
                loadable3.Enabled = true;
                loadable4.Enabled = true;
                loadable5.Enabled = true;
                loadable6.Enabled = true;
                loadable7.Enabled = true;
                loadable8.Enabled = true;
                loadable9.Enabled = true;
                loadable10.Enabled = true;

                imageFilePath1 = null;
                imageFilePath2 = null;
                imageFilePath3 = null;
                imageFilePath4 = null;
                imageFilePath5 = null;
                imageFilePath6 = null;
                imageFilePath7 = null;
                imageFilePath8 = null;
                imageFilePath9 = null;
                imageFilePath10 = null;

                soundFilePath1 = null;
                soundFilePath2 = null;
                soundFilePath3 = null;
                soundFilePath4 = null;
                soundFilePath5 = null;
                soundFilePath6 = null;
                soundFilePath7 = null;
                soundFilePath8 = null;
                soundFilePath9 = null;
                soundFilePath10 = null;

                soundInfo1.Visible = false;
                soundInfo2.Visible = false;
                soundInfo3.Visible = false;
                soundInfo4.Visible = false;
                soundInfo5.Visible = false;
                soundInfo6.Visible = false;
                soundInfo7.Visible = false;
                soundInfo8.Visible = false;
                soundInfo9.Visible = false;
                soundInfo10.Visible = false;

                sound1.Text = "EDIT SOUND";
                sound1.BackColor = Color.MediumVioletRed;
                sound2.Text = "EDIT SOUND";
                sound2.BackColor = Color.MediumVioletRed;
                sound3.Text = "EDIT SOUND";
                sound3.BackColor = Color.MediumVioletRed;
                sound4.Text = "EDIT SOUND";
                sound4.BackColor = Color.MediumVioletRed;
                sound5.Text = "EDIT SOUND";
                sound5.BackColor = Color.MediumVioletRed;
                sound6.Text = "EDIT SOUND";
                sound6.BackColor = Color.MediumVioletRed;
                sound7.Text = "EDIT SOUND";
                sound7.BackColor = Color.MediumVioletRed;
                sound8.Text = "EDIT SOUND";
                sound8.BackColor = Color.MediumVioletRed;
                sound9.Text = "EDIT SOUND";
                sound9.BackColor = Color.MediumVioletRed;
                sound10.Text = "EDIT SOUND";
                sound10.BackColor = Color.MediumVioletRed;


                for (int labelNumber = 1; labelNumber <= 10; labelNumber++)
                {
                    PictureBox pictureBox = Controls.Find($"pic{labelNumber}", true).FirstOrDefault() as PictureBox;
                    Label soundInfoLabel = Controls.Find($"L{labelNumber}", true).FirstOrDefault() as Label;

                    if (pictureBox == null || soundInfoLabel == null)
                    {
                        MessageBox.Show($"PictureBox pic{labelNumber} or Label L{labelNumber} not found.");
                        continue;
                    }

                    using (SqlCommand command = new SqlCommand($"SELECT SoundName, ImageData, SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        command.Parameters.AddWithValue("@SoundID", labelNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable tableData = new DataTable();
                            tableData.Load(reader);

                            if (tableData.Rows.Count > 0)
                            {
                                DataRow row = tableData.Rows[0];

                                if (row["ImageData"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])row["ImageData"];

                                    if (IsValidImageData(imageData))
                                    {
                                        using (MemoryStream ms = new MemoryStream(imageData))
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        pictureBox.Image = null;
                                        MessageBox.Show($"Invalid image data for SoundID {labelNumber}.");
                                    }
                                }
                                else
                                {
                                    // Load ImageData from tbl_ImageAssets where ImageID = 5 if ImageData is null
                                    using (SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection))
                                    using (SqlDataReader imageReader = selectImageCommand.ExecuteReader())
                                    {
                                        if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                                        {
                                            byte[] imageData = (byte[])imageReader["ImageData"];

                                            if (IsValidImageData(imageData))
                                            {
                                                using (MemoryStream ms = new MemoryStream(imageData))
                                                {
                                                    pictureBox.Image = Image.FromStream(ms);
                                                }
                                            }
                                            else
                                            {
                                                pictureBox.Image = null;
                                                MessageBox.Show($"Invalid image data for pic{labelNumber}.");
                                            }
                                        }
                                        else
                                        {
                                            pictureBox.Image = null;
                                        }
                                    }
                                }

                                string soundName = row["SoundName"].ToString();
                                string soundData = row["SoundData"].ToString();

                                soundNameTextBoxes[labelNumber - 1].Text = soundName;
                                soundDataArray[labelNumber - 1] = soundData;

                                // Check if ImageData, SoundData, and SoundName are all filled
                                if (!string.IsNullOrEmpty(soundName) && !string.IsNullOrEmpty(soundData) && row["ImageData"] != DBNull.Value)
                                {
                                    soundInfoLabel.ForeColor = Color.Yellow;
                                }
                                else
                                {
                                    soundInfoLabel.ForeColor = Color.Black;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No data found for SoundID {labelNumber}.");
                                pictureBox.Image = null;
                                soundNameTextBoxes[labelNumber - 1].Text = "";
                                soundDataArray[labelNumber - 1] = null;

                                // If there's no data, set the label color to red
                                soundInfoLabel.ForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop();
            try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete all?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    soundInfo1.Visible = false;
                    soundInfo2.Visible = false;
                    soundInfo3.Visible = false;
                    soundInfo4.Visible = false;
                    soundInfo5.Visible = false;
                    soundInfo6.Visible = false;
                    soundInfo7.Visible = false;
                    soundInfo8.Visible = false;
                    soundInfo9.Visible = false;
                    soundInfo10.Visible = false;

                    L1.ForeColor = Color.Black;
                    L2.ForeColor = Color.Black;
                    L3.ForeColor = Color.Black;
                    L4.ForeColor = Color.Black;
                    L5.ForeColor = Color.Black;
                    L6.ForeColor = Color.Black;
                    L7.ForeColor = Color.Black;
                    L8.ForeColor = Color.Black;
                    L9.ForeColor = Color.Black;
                    L10.ForeColor = Color.Black;

                    imageFilePath1 = null;
                    imageFilePath2 = null;
                    imageFilePath3 = null;
                    imageFilePath4 = null;
                    imageFilePath5 = null;
                    imageFilePath6 = null;
                    imageFilePath7 = null;
                    imageFilePath8 = null;
                    imageFilePath9 = null;
                    imageFilePath10 = null;

                    soundFilePath1 = null;
                    soundFilePath2 = null;
                    soundFilePath3 = null;
                    soundFilePath4 = null;
                    soundFilePath5 = null;
                    soundFilePath6 = null;
                    soundFilePath7 = null;
                    soundFilePath8 = null;
                    soundFilePath9 = null;
                    soundFilePath10 = null;

                    soundInfo1.Visible = false;
                    soundInfo2.Visible = false;
                    soundInfo3.Visible = false;
                    soundInfo4.Visible = false;
                    soundInfo5.Visible = false;
                    soundInfo6.Visible = false;
                    soundInfo7.Visible = false;
                    soundInfo8.Visible = false;
                    soundInfo9.Visible = false;
                    soundInfo10.Visible = false;

                    sound1.Text = "EDIT SOUND";
                    sound1.BackColor = Color.MediumVioletRed;
                    sound2.Text = "EDIT SOUND";
                    sound2.BackColor = Color.MediumVioletRed;
                    sound3.Text = "EDIT SOUND";
                    sound3.BackColor = Color.MediumVioletRed;
                    sound4.Text = "EDIT SOUND";
                    sound4.BackColor = Color.MediumVioletRed;
                    sound5.Text = "EDIT SOUND";
                    sound5.BackColor = Color.MediumVioletRed;
                    sound6.Text = "EDIT SOUND";
                    sound6.BackColor = Color.MediumVioletRed;
                    sound7.Text = "EDIT SOUND";
                    sound7.BackColor = Color.MediumVioletRed;
                    sound8.Text = "EDIT SOUND";
                    sound8.BackColor = Color.MediumVioletRed;
                    sound9.Text = "EDIT SOUND";
                    sound9.BackColor = Color.MediumVioletRed;
                    sound10.Text = "EDIT SOUND";
                    sound10.BackColor = Color.MediumVioletRed;
                    string connectionString = "Server=LAPTOP-E8GN3HGP\\MSSQLSERVER01;Database=db_mellowdy;Integrated Security=True;"; // Replace this with your actual connection string

                    // Retrieve image data from the database
                    for (int labelNumber = 1; labelNumber <= 10; labelNumber++)
                    {
                        byte[] imageData = RetrieveImageDataFromDatabase(connectionString, 5); // Assuming ImageID = 5

                        // Set PictureBox Image
                        PictureBox pictureBox = Controls.Find($"pic{labelNumber}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null && imageData != null)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBox.Image = Image.FromStream(ms);
                            }
                        }

                        // Clear TextBox
                        TextBox textBox = Controls.Find($"Lname{labelNumber}", true).FirstOrDefault() as TextBox;
                        if (textBox != null)
                        {
                            textBox.Text = string.Empty;
                        }
                    }

                    // Refresh the entire form
                    this.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private byte[] RetrieveImageDataFromDatabase(string connectionString, int imageID)
        {
            // Implement your database retrieval logic here
            // Example: replace this with actual database retrieval logic
            byte[] imageData = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID", connection);
                command.Parameters.AddWithValue("@ImageID", imageID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        imageData = (byte[])reader["ImageData"];
                    }
                }
            }

            return imageData;
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
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

        private void d1_Click(object sender, EventArgs e)
        {

            try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath1 = null;
                    soundFilePath1 = null;


                    L1.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L1.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
                if (soundPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    soundPlayer.controls.stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void d2_Click(object sender, EventArgs e)
        {
            try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath2 = null;
                    soundFilePath2 = null;

                    L2.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L2.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                try
                {
                    // Stop the soundPlayer only if it's playing
                    if (soundPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        soundPlayer.controls.stop();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error stopping soundPlayer: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void d3_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath3 = null;
                    soundFilePath3 = null;

                    L3.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L3.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                try
                {
                    // Stop the soundPlayer only if it's playing
                    if (soundPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        soundPlayer.controls.stop();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error stopping soundPlayer: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void d4_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath4 = null;
                    soundFilePath4 = null;

                    L4.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L4.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void d5_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath5 = null;
                    soundFilePath5 = null;

                    L5.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L5.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void d6_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath6 = null;
                    soundFilePath6 = null;

                    L6.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L6.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void d7_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath7 = null;
                    soundFilePath7 = null;

                    L7.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L7.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void d8_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath8 = null;
                    soundFilePath8 = null;

                    L8.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L8.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void d9_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath9 = null;
                    soundFilePath9 = null;

                    L9.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L9.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void d10_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Clear file paths
                    imageFilePath10 = null;
                    soundFilePath10 = null;

                    L10.ForeColor = Color.Black;
                    string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                    connection.Open();

                    // Assuming label1.Text contains the SoundID value
                    if (int.TryParse(L10.Text, out int soundID))
                    {
                        // Update the selected table where SoundID matches label1.Text
                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET SoundName = '', SoundData = null, ImageData = null WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            // Display image data from tbl_ImageAssets where ImageID = 5 in the corresponding PictureBox
                            SqlCommand selectImageCommand = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection);
                            SqlDataReader imageReader = selectImageCommand.ExecuteReader();

                            if (imageReader.Read() && imageReader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageReader["ImageData"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    try
                                    {
                                        // Assuming pic1 corresponds to the SoundID in label1
                                        PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                        if (pictureBox != null)
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"PictureBox pic{soundID} not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error loading image for pic{soundID}: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                // Assuming pic1 corresponds to the SoundID in label1
                                PictureBox pictureBox = Controls.Find($"pic{soundID}", true).FirstOrDefault() as PictureBox;

                                if (pictureBox != null)
                                {
                                    pictureBox.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show($"PictureBox pic{soundID} not found.");
                                }
                            }

                            imageReader.Close();

                            // Assuming Lname1 corresponds to the SoundID in label1
                            TextBox textBox = Controls.Find($"Lname{soundID}", true).FirstOrDefault() as TextBox;

                            if (textBox != null)
                            {
                                // Empty the corresponding textbox
                                textBox.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show($"TextBox Lname{soundID} not found.");
                            }
                        }
                        else
                        {
                            // Handle the case where the update did not succeed
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid SoundID format in label1.Text.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                try
                {
                    // Stop the soundPlayer only if it's playing
                    if (soundPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        soundPlayer.controls.stop();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error stopping soundPlayer: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //LOADABLE4
        private string soundFilePath4;
        private string imageFilePath4;
        private void pic4_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog4 = new OpenFileDialog())
                {
                    openFileDialog4.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog4.ShowDialog() == DialogResult.OK)
                    {
                        pic4.ImageLocation = openFileDialog4.FileName;
                        imageFilePath4 = openFileDialog4.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic4: {ex.Message}");
            }
        }

        private void play4_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 4;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }

        private void sound4_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog4 = new OpenFileDialog())
                {
                    openFileDialog4.Filter = "Audio/Video Files|*.wav;*.mp4;*.ogg;*.flac;*.mp4|All files (*.*)|*.*";

                    if (openFileDialog4.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        soundInfo4.Visible = true;
                        soundInfo4.Text = openFileDialog4.SafeFileName;
                        sound4.Text = "CHANGE";
                        sound4.BackColor = Color.DarkGreen;
                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath4 = openFileDialog4.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }
        }

        private void save4_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L4.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L4.Text is black
                        if (L4.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname4.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname4.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath4) && File.Exists(soundFilePath4))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath4);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath4) && File.Exists(imageFilePath4))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath4);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            MessageBox.Show("Saved Successfully!");
                            soundInfo4.Visible = false; sound4.Text = "EDIT SOUND";
                            sound4.BackColor = Color.MediumVioletRed;
                            // Change the color of L4.Text to Yellow only if L4.Text color is black
                            if (L4.ForeColor == Color.Black)
                            {
                                L4.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L4.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname4.Text) &&
                       !string.IsNullOrEmpty(soundFilePath4) &&
                       !string.IsNullOrEmpty(imageFilePath4);
            }

        }

        //LOADABLE5
        private string soundFilePath5;
        private string imageFilePath5;
        private void pic5_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog5 = new OpenFileDialog())
                {
                    openFileDialog5.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog5.ShowDialog() == DialogResult.OK)
                    {
                        pic5.ImageLocation = openFileDialog5.FileName;
                        imageFilePath5 = openFileDialog5.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic5: {ex.Message}");
            }
        }

        private void play5_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 5;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }

        private void sound5_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog5 = new OpenFileDialog())
                {
                    openFileDialog5.Filter = "Audio/Video Files|*.wav;*.mp5;*.ogg;*.flac;*.mp5|All files (*.*)|*.*";

                    if (openFileDialog5.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        soundInfo5.Visible = true;
                        soundInfo5.Text = openFileDialog5.SafeFileName;
                        sound5.Text = "CHANGE";
                        sound5.BackColor = Color.DarkGreen;
                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath5 = openFileDialog5.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }
        }

        private void save5_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L5.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L5.Text is black
                        if (L5.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname5.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname5.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath5) && File.Exists(soundFilePath5))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath5);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath5) && File.Exists(imageFilePath5))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath5);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            sound5.Text = "EDIT SOUND";
                            sound5.BackColor = Color.MediumVioletRed;
                            MessageBox.Show("Saved Successfully!");
                            soundInfo5.Visible = false;
                            // Change the color of L5.Text to Yellow only if L5.Text color is black
                            if (L5.ForeColor == Color.Black)
                            {
                                L5.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L5.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname5.Text) &&
                       !string.IsNullOrEmpty(soundFilePath5) &&
                       !string.IsNullOrEmpty(imageFilePath5);
            }

        }

        //LOADABLE6
        private string soundFilePath6;
        private string imageFilePath6;
        private void pic6_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog6 = new OpenFileDialog())
                {
                    openFileDialog6.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog6.ShowDialog() == DialogResult.OK)
                    {
                        pic6.ImageLocation = openFileDialog6.FileName;
                        imageFilePath6 = openFileDialog6.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic6: {ex.Message}");
            }
        }

        private void play6_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 6;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }

        private void sound6_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog6 = new OpenFileDialog())
                {
                    openFileDialog6.Filter = "Audio/Video Files|*.wav;*.mp6;*.ogg;*.flac;*.mp6|All files (*.*)|*.*";

                    if (openFileDialog6.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        soundInfo6.Visible = true;
                        soundInfo6.Text = openFileDialog6.SafeFileName;
                        sound6.Text = "CHANGE";
                        sound6.BackColor = Color.DarkGreen;
                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath6 = openFileDialog6.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }
        }

        private void save6_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L6.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L6.Text is black
                        if (L6.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname6.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname6.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath6) && File.Exists(soundFilePath6))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath6);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath6) && File.Exists(imageFilePath6))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath6);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            sound6.Text = "EDIT SOUND";
                            sound6.BackColor = Color.MediumVioletRed;
                            MessageBox.Show("Saved Successfully!");
                            soundInfo6.Visible = false;
                            // Change the color of L6.Text to Yellow only if L6.Text color is black
                            if (L6.ForeColor == Color.Black)
                            {
                                L6.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L6.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname6.Text) &&
                       !string.IsNullOrEmpty(soundFilePath6) &&
                       !string.IsNullOrEmpty(imageFilePath6);
            }

        }

        private string soundFilePath7;
        private string imageFilePath7;
        private void pic7_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog7 = new OpenFileDialog())
                {
                    openFileDialog7.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog7.ShowDialog() == DialogResult.OK)
                    {
                        pic7.ImageLocation = openFileDialog7.FileName;
                        imageFilePath7 = openFileDialog7.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic7: {ex.Message}");
            }
        }

        private void play7_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 7;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }

        private void sound7_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog7 = new OpenFileDialog())
                {
                    openFileDialog7.Filter = "Audio/Video Files|*.wav;*.mp7;*.ogg;*.flac;*.mp7|All files (*.*)|*.*";

                    if (openFileDialog7.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        soundInfo7.Visible = true;
                        soundInfo7.Text = openFileDialog7.SafeFileName;
                        sound7.Text = "CHANGE";
                        sound7.BackColor = Color.DarkGreen;
                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath7 = openFileDialog7.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }
        }

        private void save7_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L7.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L7.Text is black
                        if (L7.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname7.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname7.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath7) && File.Exists(soundFilePath7))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath7);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath7) && File.Exists(imageFilePath7))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath7);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            MessageBox.Show("Saved Successfully!");
                            soundInfo7.Visible = false; sound7.Text = "EDIT SOUND";
                            sound7.BackColor = Color.MediumVioletRed;
                            // Change the color of L7.Text to Yellow only if L7.Text color is black
                            if (L7.ForeColor == Color.Black)
                            {
                                L7.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L7.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname7.Text) &&
                       !string.IsNullOrEmpty(soundFilePath7) &&
                       !string.IsNullOrEmpty(imageFilePath7);
            }

        }

        private string soundFilePath8;
        private string imageFilePath8;
        private void pic8_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog8 = new OpenFileDialog())
                {
                    openFileDialog8.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog8.ShowDialog() == DialogResult.OK)
                    {
                        pic8.ImageLocation = openFileDialog8.FileName;
                        imageFilePath8 = openFileDialog8.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic8: {ex.Message}");
            }
        }

        private void play8_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 8;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }

        private void sound8_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog8 = new OpenFileDialog())
                {
                    openFileDialog8.Filter = "Audio/Video Files|*.wav;*.mp8;*.ogg;*.flac;*.mp8|All files (*.*)|*.*";

                    if (openFileDialog8.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        soundInfo8.Visible = true;
                        soundInfo8.Text = openFileDialog8.SafeFileName;
                        sound8.Text = "CHANGE";
                        sound8.BackColor = Color.DarkGreen;
                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath8 = openFileDialog8.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }
        }

        private void save8_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L8.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L8.Text is black
                        if (L8.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname8.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname8.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath8) && File.Exists(soundFilePath8))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath8);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath8) && File.Exists(imageFilePath8))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath8);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            MessageBox.Show("Saved Successfully!");
                            soundInfo8.Visible = false; sound8.Text = "EDIT SOUND";
                            sound8.BackColor = Color.MediumVioletRed;
                            // Change the color of L8.Text to Yellow only if L8.Text color is black
                            if (L8.ForeColor == Color.Black)
                            {
                                L8.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L8.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname8.Text) &&
                       !string.IsNullOrEmpty(soundFilePath8) &&
                       !string.IsNullOrEmpty(imageFilePath8);
            }

        }

        private string soundFilePath9;
        private string imageFilePath9;
        private void pic9_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog9 = new OpenFileDialog())
                {
                    openFileDialog9.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog9.ShowDialog() == DialogResult.OK)
                    {
                        pic9.ImageLocation = openFileDialog9.FileName;
                        imageFilePath9 = openFileDialog9.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic9: {ex.Message}");
            }
        }

        private void play9_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 9;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }

        private void sound9_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog9 = new OpenFileDialog())
                {
                    openFileDialog9.Filter = "Audio/Video Files|*.wav;*.mp9;*.ogg;*.flac;*.mp9|All files (*.*)|*.*";

                    if (openFileDialog9.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        soundInfo9.Visible = true;
                        soundInfo9.Text = openFileDialog9.SafeFileName;
                        sound9.Text = "CHANGE";
                        sound9.BackColor = Color.DarkGreen;
                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath9 = openFileDialog9.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }
        }

        private void save9_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L9.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L9.Text is black
                        if (L9.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname9.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname9.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath9) && File.Exists(soundFilePath9))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath9);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath9) && File.Exists(imageFilePath9))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath9);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            MessageBox.Show("Saved Successfully!");
                            soundInfo9.Visible = false; sound9.Text = "EDIT SOUND";
                            sound9.BackColor = Color.MediumVioletRed;
                            // Change the color of L9.Text to Yellow only if L9.Text color is black
                            if (L9.ForeColor == Color.Black)
                            {
                                L9.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L9.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname9.Text) &&
                       !string.IsNullOrEmpty(soundFilePath9) &&
                       !string.IsNullOrEmpty(imageFilePath9);
            }

        }

        private string soundFilePath10;
        private string imageFilePath10;
        private void pic10_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog10 = new OpenFileDialog())
                {
                    openFileDialog10.Filter = "Image Files (*.png;*.jpg;*.gif)|*.png;*.jpg*.gif;";

                    if (openFileDialog10.ShowDialog() == DialogResult.OK)
                    {
                        pic10.ImageLocation = openFileDialog10.FileName;
                        imageFilePath10 = openFileDialog10.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image file for pic10: {ex.Message}");
            }
        }

        private void play10_Click(object sender, EventArgs e)
        {
            try
            {
                int soundIDToPlay = 10;
                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                byte[] soundData;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand($"SELECT SoundData FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                {
                    command.Parameters.AddWithValue("@SoundID", soundIDToPlay);
                    soundData = command.ExecuteScalar() as byte[];
                }

                if (soundData != null && soundData.Length > 0)
                {
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, soundData);
                    soundPlayer.URL = tempFilePath;
                    soundPlayer.controls.play();
                }
                else
                {
                    // Optionally display a message if there is no sound data
                    // MessageBox.Show("No Sound Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Optionally close the connection if needed
                connection.Close();
            }
        }

        private void sound10_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop(); try
            {
                using (OpenFileDialog openFileDialog10 = new OpenFileDialog())
                {
                    openFileDialog10.Filter = "Audio/Video Files|*.wav;*.mp10;*.ogg;*.flac;*.mp10|All files (*.*)|*.*";

                    if (openFileDialog10.ShowDialog() == DialogResult.OK)
                    {
                        // Display the name of the selected audio or video file
                        soundInfo10.Visible = true;
                        soundInfo10.Text = openFileDialog10.SafeFileName;
                        sound10.Text = "CHANGE";
                        sound10.BackColor = Color.DarkGreen;
                        // Store the file path for later use (e.g., saving to the database)
                        soundFilePath10 = openFileDialog10.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting sound file: {ex.Message}");
            }
        }

        private void save10_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedTable = $"tbl_{CBGradeLevel.SelectedItem}{CBSubCategories.SelectedItem}{CBCategories.SelectedItem}".Replace(" ", "");

                connection.Open();

                if (int.TryParse(L10.Text, out int soundID))
                {
                    // Check if there is existing data for the given SoundID
                    bool existingData = false;

                    using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM {selectedTable} WHERE SoundID = @SoundID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SoundID", soundID);
                        existingData = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    // If there is existing data, update the specified fields; otherwise, insert a new record
                    if (existingData)
                    {
                        // Check if all required fields are filled when L10.Text is black
                        if (L10.ForeColor == Color.Black && (!FieldsAreFilled() || string.IsNullOrEmpty(Lname10.Text)))
                        {
                            MessageBox.Show("Kindly provide information for Image, Sound, and Name.");
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand($"UPDATE {selectedTable} SET " +
                                                                  "SoundName = COALESCE(@SoundName, SoundName), " +
                                                                  "SoundData = COALESCE(CONVERT(VARBINARY(MAX), @SoundData), SoundData), " +
                                                                  "ImageData = COALESCE(CONVERT(VARBINARY(MAX), @ImageData), ImageData) " +
                                                                  "WHERE SoundID = @SoundID", connection);
                        updateCommand.Parameters.AddWithValue("@SoundID", soundID);

                        // Update SoundName if provided
                        updateCommand.Parameters.AddWithValue("@SoundName", Lname10.Text);

                        // Update SoundData if a sound file is provided
                        if (!string.IsNullOrEmpty(soundFilePath10) && File.Exists(soundFilePath10))
                        {
                            byte[] soundData = File.ReadAllBytes(soundFilePath10);
                            updateCommand.Parameters.AddWithValue("@SoundData", soundData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@SoundData", DBNull.Value);
                        }

                        // Update ImageData if an image file is provided
                        if (!string.IsNullOrEmpty(imageFilePath10) && File.Exists(imageFilePath10))
                        {
                            byte[] imageData = File.ReadAllBytes(imageFilePath10);
                            updateCommand.Parameters.AddWithValue("@ImageData", imageData);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@ImageData", DBNull.Value);
                        }

                        int updateRows = updateCommand.ExecuteNonQuery();

                        if (updateRows > 0)
                        {
                            MessageBox.Show("Saved Successfully!");
                            soundInfo10.Visible = false; sound10.Text = "EDIT SOUND";
                            sound10.BackColor = Color.MediumVioletRed;
                            // Change the color of L10.Text to Yellow only if L10.Text color is black
                            if (L10.ForeColor == Color.Black)
                            {
                                L10.ForeColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existing data found for the specified SoundID. Please use Insert instead.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid SoundID format in L10.Text.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Helper function to check if all required fields are filled
            bool FieldsAreFilled()
            {
                return !string.IsNullOrEmpty(Lname10.Text) &&
                       !string.IsNullOrEmpty(soundFilePath10) &&
                       !string.IsNullOrEmpty(imageFilePath10);
            }

        }

        private void pic1_MouseEnter(object sender, EventArgs e)
        {
         
        }

        private void pic1_MouseLeave(object sender, EventArgs e)
        {
          
        }
   

        // Add similar methods for play4, play5, ..., play10
    }
}
