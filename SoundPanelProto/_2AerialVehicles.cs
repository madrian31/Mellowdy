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
    public partial class _2AerialVehicles : Form
    {
        public OpenFileDialog openFileDialog = new OpenFileDialog();
        public string[] stringArray = { "D1", "D2", "D3", "D4", "D5", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        private int currentIndex = 2;

        // Make the connection string static if you want it to be accessible globally across different classes
        public static string connectionString = "Data Source=LAPTOP-E8GN3HGP\\MSSQLSERVER01; Initial Catalog=db_mellowdy; Integrated Security=True";

        // SqlConnection declared at the class level
        private SqlConnection connection = new SqlConnection(connectionString);
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer wmp;

        private const int PictureBoxCount = 10;

        private PictureBox[] pictureBoxes;

        private const int ButtonCount = 10;

        private PictureBox[] buttons;

        private SoundPlayer[] soundPlayers;
        private Label[] nameLabel;

        private Panel[] overlayPanels = new Panel[10];
        public _2AerialVehicles()
        {
            InitializeComponent();
            ApplyPopUpEffect(prevButton);
            ApplyPopUpEffect2(prevButton);
            ApplyPopUpEffect(nextButton);
            ApplyPopUpEffect2(nextButton);
            ApplyPopUpEffect(pictureBox8);
            ApplyPopUpEffect2(pictureBox8);

            ApplyPopUpEffect(DefaultSoundBtn1);
            ApplyPopUpEffect2(DefaultSoundBtn1);
            ApplyPopUpEffect(DefaultSoundBtn2);
            ApplyPopUpEffect2(DefaultSoundBtn2);
            ApplyPopUpEffect(DefaultSoundBtn3);
            ApplyPopUpEffect2(DefaultSoundBtn3);
            ApplyPopUpEffect(DefaultSoundBtn4);
            ApplyPopUpEffect2(DefaultSoundBtn4);
            ApplyPopUpEffect(DefaultSoundBtn5);
            ApplyPopUpEffect2(DefaultSoundBtn5);

            ApplyPopUpEffect(lbutton1);
            ApplyPopUpEffect2(lbutton1);
            ApplyPopUpEffect(lbutton2);
            ApplyPopUpEffect2(lbutton2);
            ApplyPopUpEffect(lbutton3);
            ApplyPopUpEffect2(lbutton3);
            ApplyPopUpEffect(lbutton4);
            ApplyPopUpEffect2(lbutton4);
            ApplyPopUpEffect(lbutton5);
            ApplyPopUpEffect2(lbutton5);
            ApplyPopUpEffect(lbutton6);
            ApplyPopUpEffect2(lbutton6);
            ApplyPopUpEffect(lbutton7);
            ApplyPopUpEffect2(lbutton7);
            ApplyPopUpEffect(lbutton8);
            ApplyPopUpEffect2(lbutton8);
            ApplyPopUpEffect(lbutton9);
            ApplyPopUpEffect2(lbutton9);
            ApplyPopUpEffect(lbutton10);
            ApplyPopUpEffect2(lbutton10);


            ApplyPopUpEffect(BackButton);
            ApplyPopUpEffect2(BackButton);
            ApplyPopUpEffect(InsertBtn);
            ApplyPopUpEffect2(InsertBtn);
            ApplyPopUpEffect(pictureBox2);
            ApplyPopUpEffect2(pictureBox2);

            ApplyPopUpEffect(pictureBox7);
            ApplyPopUpEffect2(pictureBox7);
            ApplyPopUpEffect(pictureBox5);
            ApplyPopUpEffect2(pictureBox5);

            ApplyPopUpEffect(ModalPlay);
            ApplyPopUpEffect2(ModalPlay);
            ApplyPopUpEffect(pictureBox1);
            ApplyPopUpEffect2(pictureBox1);
            // Initialize connectionString in the constructor


            wmp = new WMPLib.WindowsMediaPlayer();




            //TIMER NG PANEL NA NALABAS

            pictureBoxes = new PictureBox[] { Lpicture1, Lpicture2, Lpicture3, Lpicture4, Lpicture5, Lpicture6, Lpicture7, pictureBox8, Lpicture9, Lpicture10 };
            nameLabel = new Label[] { Lname1, Lname2, Lname3, Lname4, Lname5, Lname6, Lname7, Lname8, Lname9, Lname10 };
            buttons = new PictureBox[] { lbutton1, lbutton2, lbutton3, lbutton4, lbutton5, lbutton6, lbutton7, lbutton8, lbutton9, lbutton10 };
            soundPlayers = new SoundPlayer[ButtonCount];
            // Call the data loading method when the form is loaded
            LoadData();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _2Vehicles frm1 = new _2Vehicles();
            frm1.Show();
            this.Hide();
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
        //METHODS
        public bool soundDataSaved = false;
        private byte[] imageData;
        private void LoadData()
        {
            Font dFont = new Font("Berlin Sans FB Demi", 12, FontStyle.Bold);
            Font selectedDFont = new Font("Berlin Sans FB Demi", 36, FontStyle.Bold);

            Font lFont = new Font("Berlin Sans FB Demi", 12, FontStyle.Bold);

            Lname1.Font = lFont;
            Lname2.Font = lFont;
            Lname3.Font = lFont;
            Lname4.Font = lFont;
            Lname5.Font = lFont;
            Lname6.Font = lFont;
            Lname7.Font = lFont;
            Lname8.Font = lFont;
            Lname9.Font = lFont;
            Lname10.Font = lFont;


            DefaultSoundBtn1.Size = new Size(162, 151);
            DefaultSoundBtn2.Size = new Size(162, 151);
            DefaultSoundBtn3.Size = new Size(162, 151);
            DefaultSoundBtn4.Size = new Size(162, 151);
            DefaultSoundBtn5.Size = new Size(162, 151);

            lbutton1.Size = new Size(162, 151);
            lbutton2.Size = new Size(162, 151);
            lbutton3.Size = new Size(162, 151);
            lbutton4.Size = new Size(162, 151);
            lbutton5.Size = new Size(162, 151);
            lbutton6.Size = new Size(162, 151);
            lbutton7.Size = new Size(162, 151);
            lbutton8.Size = new Size(162, 151);
            lbutton9.Size = new Size(162, 151);
            lbutton10.Size = new Size(162, 151);



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < PictureBoxCount; i++)
                {
                    int dataId = i + 1;

                    if (HasImageData(connection, dataId)) //
                    {
                        LoadAndSetPictureBoxImage(connection, dataId, pictureBoxes[i]);
                        pictureBoxes[i].Size = new Size(42, 38);

                        // SQL query to retrieve image data from tbl_assets WHERE SoundID is 3
                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Replace @ImageID with the actual parameter name and value (in this case, 3)
                            command.Parameters.AddWithValue("@ImageID", 4);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Check if the column with image data exists
                                    if (reader["ImageData"] != DBNull.Value)
                                    {
                                        // Retrieve the image data as a byte array
                                        byte[] imageData = (byte[])reader["ImageData"];

                                        // Convert the byte array to a MemoryStream
                                        using (MemoryStream stream = new MemoryStream(imageData))
                                        {
                                            // Create a Bitmap from the MemoryStream
                                            Bitmap image = new Bitmap(stream);

                                            // Set the image to the PictureBox
                                            buttons[i].Image = image;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }


            //SOUNDS
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < ButtonCount; i++)
                {
                    int soundId = GetSoundId(i + 1); // Assuming Button IDs start from 1

                    if (HasSoundData(connection, soundId))
                    {
                        LoadSoundData(connection, soundId, i);
                        buttons[i].Enabled = true; // Enable the button if sound data exists


                    }
                    else
                    {
                        buttons[i].Enabled = true; // Disable the button if no sound data
                    }
                }
            }
        }
        private bool HasSoundData(SqlConnection connection, int soundId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_KINDERAERIALVEHICLES WHERE SoundID = @SoundId AND SoundData IS NOT NULL", connection))
            {
                cmd.Parameters.AddWithValue("@SoundId", soundId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }


        private void LoadSoundData(SqlConnection connection, int soundId, int index)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT SoundName, SoundData FROM tbl_KINDERAERIALVEHICLES WHERE SoundID = @SoundId", connection))
            {
                cmd.Parameters.AddWithValue("@SoundId", soundId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        string soundFilePath = GetFilePathFromLoadableSounds(soundId); // Retrieve the file path

                        if (!string.IsNullOrEmpty(soundFilePath))
                        {
                            nameLabel[index].Text = reader["SoundName"].ToString();

                            // Attach the playback logic to a button click event
                            buttons[index].Click += (sender, e) =>
                            {
                                // Assuming you have a Windows Media Player control named "Player" on your form
                                Player.URL = soundFilePath;
                                Player.controls.play();
                            };
                        }
                        else
                        {
                            soundPlayers[index] = null; // Set SoundPlayer to null if sound file path is empty
                            nameLabel[index].Text = "No Sound";
                        }
                    }
                    else
                    {
                        soundPlayers[index] = null; // Set SoundPlayer to null if no data found
                        nameLabel[index].Text = "No Sound";
                    }
                }
            }
        }

        private int GetSoundId(int index) => index; // Adjust according to your sound ID logic


        private bool HasImageData(SqlConnection connection, int dataId)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_KINDERAERIALVEHICLES WHERE SoundID = @DataId AND ImageData IS NOT NULL", connection))
            {
                cmd.Parameters.AddWithValue("@DataId", dataId);

                // ExecuteScalar requires an open connection
                int count = (int)cmd.ExecuteScalar();

                // Return true if count is greater than 0, indicating that there is image data
                return count > 0;
            }
        }

        private void LoadAndSetPictureBoxImage(SqlConnection connection, int dataId, PictureBox pictureBox)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT ImageData FROM tbl_KINDERAERIALVEHICLES WHERE SoundID = @DataId", connection))
            {
                cmd.Parameters.AddWithValue("@DataId", dataId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                    pictureBox.Image = reader.Read() ? ConvertBytesToImage((byte[])reader["ImageData"]) : null;
            }
        }

        private Image ConvertBytesToImage(byte[] imageData) => Image.FromStream(new MemoryStream(imageData));


        private void dock()
        {
            loadables();


            Dpanel2.Dock = DockStyle.Fill;

            LoadablePnl1.Dock = DockStyle.Fill;
            LoadablePnl2.Dock = DockStyle.Fill;
            LoadablePnl3.Dock = DockStyle.Fill;
            LoadablePnl4.Dock = DockStyle.Fill;
            LoadablePnl5.Dock = DockStyle.Fill;
            LoadablePnl6.Dock = DockStyle.Fill;
            LoadablePnl7.Dock = DockStyle.Fill;
            LoadablePnl8.Dock = DockStyle.Fill;
            LoadablePnl9.Dock = DockStyle.Fill;
            LoadablePnl10.Dock = DockStyle.Fill;




        }


        private void UpdateDataInDatabase(byte[] dataBytes, int rowId, string columnName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlQuery = $"UPDATE tbl_KINDERAERIALVEHICLES SET {columnName} = @{columnName} WHERE SoundID = @ID";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", rowId);
                        command.Parameters.Add($"@{columnName}", System.Data.SqlDbType.VarBinary).Value = dataBytes;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"{columnName} data updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating {columnName} data: " + ex.Message);
            }
        }
        private void clearcontainer()
        {
            PanelContainer1.Controls.Clear();
            PanelContainer2.Controls.Clear();
            PanelContainer3.Controls.Clear();
            PanelContainer4.Controls.Clear();
            PanelContainer5.Controls.Clear();


            dock();
        }

        private void loadables() //temporary
        {
            LoadablePnl5.Visible = false;
            LoadablePnl4.Visible = false;
            LoadablePnl3.Visible = false;
            LoadablePnl2.Visible = false;
            LoadablePnl1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clearcontainer();
            PanelContainer5.Controls.Add(Dpanel5);
            PanelContainer4.Controls.Add(Dpanel4);
            PanelContainer3.Controls.Add(Dpanel3);
            PanelContainer2.Controls.Add(Dpanel2);
            PanelContainer1.Controls.Add(Dpanel1);
        }


        string selectedFilePath = string.Empty;

        private void opnfiledialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sound Files|*.mp3;*.wav;*.ogg;*.flac|All Files|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;

                textBox1.Text = Path.GetFileName(selectedFilePath);

                panel1.Visible = true;
                panel1.BringToFront();

            }
        }

        private byte[] RetrieveSoundDataFromDatabase(int soundId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Replace "YourTable" and "SoundData" with your actual table and column names
                    string sqlQuery = "SELECT SoundData FROM tbl_KINDERAERIALVEHICLES WHERE SoundID = @ID";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", soundId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (byte[])reader["SoundData"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving sound data: " + ex.Message);
            }

            return null;
        }
        private void PlaySound(byte[] soundData)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(soundData))
                {
                    SoundPlayer soundPlayer = new SoundPlayer(ms);
                    soundPlayer.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound: " + ex.Message);
            }
        }
        private string GetFilePathFromLoadableSounds(int soundID)
        {
            string filePath = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SoundData FROM tbl_KINDERAERIALVEHICLES WHERE SoundID = @SoundID", connection);
                cmd.Parameters.AddWithValue("@SoundID", soundID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && reader["SoundData"] != DBNull.Value)
                    {
                        byte[] fileData = (byte[])reader["SoundData"];
                        string tempFileName = Path.GetTempFileName();
                        File.WriteAllBytes(tempFileName, fileData);
                        filePath = tempFileName;
                    }
                }
            }

            return filePath;
        }


        // DEFAULT SOUNDS
        private string GetFilePathBySoundID(int soundID)
        {
            string filePath = null;

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT SoundData FROM tbl_defaultSounds WHERE SoundID = @SoundID", connection);
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

        private void LoadImageFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = 5", connection))
            {
                connection.Open();
                byte[] imageData = command.ExecuteScalar() as byte[];

                if (imageData != null)
                    pictureBox8.Image = Image.FromStream(new MemoryStream(imageData));
                else
                    MessageBox.Show("No image found in the database.");
            }
        }

        //BUTTONS
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

        private void prevButton_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex - 1) % stringArray.Length;

            // Update the label with the current string
            label3.Text = stringArray[currentIndex];

            if (label3.Text == "D1")
            {
                clearcontainer();

                PanelContainer1.Visible = false;
                PanelContainer2.Visible = false;

                PanelContainer3.Controls.Add(Dpanel1);


                PanelContainer4.Controls.Add(Dpanel2);
                PanelContainer5.Controls.Add(Dpanel3);


                DefaultSoundBtn1.Visible = true;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = false;
                nextButton.Visible = true;

                //TEXT CHANGE
                Dname1.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Dname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


            }
            else if (label3.Text == "D2")
            {
                clearcontainer();


                PanelContainer2.Visible = true;


                PanelContainer2.Controls.Add(Dpanel1);
                PanelContainer3.Controls.Add(Dpanel2);
                PanelContainer4.Controls.Add(Dpanel3);
                PanelContainer5.Controls.Add(Dpanel4);

                //TEXT CHANGE
                Dname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname2.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Dname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                prevButton.Visible = true;
                nextButton.Visible = true;

                DefaultSoundBtn1.Visible = false;


                DefaultSoundBtn2.Visible = true;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;


            }

            if (label3.Text == "D3")
            {
                clearcontainer();
                PanelContainer1.Visible = true;
                PanelContainer2.Visible = true;


                PanelContainer1.Controls.Add(Dpanel1);
                PanelContainer2.Controls.Add(Dpanel2);
                PanelContainer3.Controls.Add(Dpanel3);
                PanelContainer4.Controls.Add(Dpanel4);
                PanelContainer5.Controls.Add(Dpanel5);
                //TEXT CHANGE
                Dname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname3.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Dname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                prevButton.Visible = true;
                nextButton.Visible = true;



                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = true;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
            }
            else if (label3.Text == "D4")
            {
                clearcontainer();

                PanelContainer1.Visible = true;
                PanelContainer2.Visible = true;
                LoadablePnl1.Visible = true;


                PanelContainer1.Controls.Add(Dpanel2);
                PanelContainer2.Controls.Add(Dpanel3);
                PanelContainer3.Controls.Add(Dpanel4);
                PanelContainer4.Controls.Add(Dpanel5);
                PanelContainer5.Controls.Add(LoadablePnl1);

                //TEXT CHANGE
                Dname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname4.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Dname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = true;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "D5")
            {
                clearcontainer();

                LoadablePnl1.Visible = true;
                LoadablePnl2.Visible = true;


                PanelContainer1.Controls.Add(Dpanel3);
                PanelContainer2.Controls.Add(Dpanel4);
                PanelContainer3.Controls.Add(Dpanel5);
                PanelContainer4.Controls.Add(LoadablePnl1);
                PanelContainer5.Controls.Add(LoadablePnl2);
                //TEXT CHANGE
                Dname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname5.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = true;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;

            }
            else if (label3.Text == "1")
            {
                clearcontainer();

                LoadablePnl1.Visible = true;
                LoadablePnl2.Visible = true;
                LoadablePnl3.Visible = true;

                PanelContainer1.Controls.Add(Dpanel4);
                PanelContainer2.Controls.Add(Dpanel5);
                PanelContainer3.Controls.Add(LoadablePnl1);
                PanelContainer4.Controls.Add(LoadablePnl2);
                PanelContainer5.Controls.Add(LoadablePnl3);
                //TEXT CHANGE
                Dname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname1.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = true;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
                prevButton.Visible = true;
                nextButton.Visible = true;

            }
            else if (label3.Text == "2")
            {
                clearcontainer();

                LoadablePnl1.Visible = true;
                LoadablePnl2.Visible = true;
                LoadablePnl3.Visible = true;
                LoadablePnl4.Visible = true;


                PanelContainer1.Controls.Add(Dpanel5);
                PanelContainer2.Controls.Add(LoadablePnl1);
                PanelContainer3.Controls.Add(LoadablePnl2);
                PanelContainer4.Controls.Add(LoadablePnl3);
                PanelContainer5.Controls.Add(LoadablePnl4);
                //TEXT CHANGE
                Dname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname2.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = true;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
                prevButton.Visible = true;
                nextButton.Visible = true;
                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "3")
            {
                clearcontainer();

                LoadablePnl1.Visible = true;
                LoadablePnl2.Visible = true;
                LoadablePnl3.Visible = true;
                LoadablePnl4.Visible = true;
                LoadablePnl5.Visible = true;


                PanelContainer1.Controls.Add(LoadablePnl1);
                PanelContainer2.Controls.Add(LoadablePnl2);
                PanelContainer3.Controls.Add(LoadablePnl3);
                PanelContainer4.Controls.Add(LoadablePnl4);
                PanelContainer5.Controls.Add(LoadablePnl5);
                //TEXT CHANGE
                Lname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname3.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = true;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
                prevButton.Visible = true;
                nextButton.Visible = true;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "4")
            {
                clearcontainer();


                LoadablePnl2.Visible = true;
                LoadablePnl3.Visible = true;
                LoadablePnl4.Visible = true;
                LoadablePnl5.Visible = true;
                LoadablePnl6.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl2);
                PanelContainer2.Controls.Add(LoadablePnl3);
                PanelContainer3.Controls.Add(LoadablePnl4);
                PanelContainer4.Controls.Add(LoadablePnl5);
                PanelContainer5.Controls.Add(LoadablePnl6);
                //TEXT CHANGE
                Lname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname4.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname6.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = true;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
                prevButton.Visible = true;
                nextButton.Visible = true;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "5")
            {
                clearcontainer();

                LoadablePnl3.Visible = true;
                LoadablePnl4.Visible = true;
                LoadablePnl5.Visible = true;
                LoadablePnl6.Visible = true;
                LoadablePnl7.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl3);
                PanelContainer2.Controls.Add(LoadablePnl4);
                PanelContainer3.Controls.Add(LoadablePnl5);
                PanelContainer4.Controls.Add(LoadablePnl6);
                PanelContainer5.Controls.Add(LoadablePnl7);
                //TEXT CHANGE
                Lname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname5.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname6.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname7.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = true;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;



                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "6")
            {
                clearcontainer();


                LoadablePnl4.Visible = true;
                LoadablePnl5.Visible = true;
                LoadablePnl6.Visible = true;
                LoadablePnl7.Visible = true;
                LoadablePnl8.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl4);
                PanelContainer2.Controls.Add(LoadablePnl5);
                PanelContainer3.Controls.Add(LoadablePnl6);
                PanelContainer4.Controls.Add(LoadablePnl7);
                PanelContainer5.Controls.Add(LoadablePnl8);
                //TEXT CHANGE
                Lname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname6.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname7.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname8.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = true;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "7")
            {
                clearcontainer();


                LoadablePnl5.Visible = true;
                LoadablePnl6.Visible = true;
                LoadablePnl7.Visible = true;
                LoadablePnl8.Visible = true;
                LoadablePnl9.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl5);
                PanelContainer2.Controls.Add(LoadablePnl6);
                PanelContainer3.Controls.Add(LoadablePnl7);
                PanelContainer4.Controls.Add(LoadablePnl8);
                PanelContainer5.Controls.Add(LoadablePnl9);
                //TEXT CHANGE
                Lname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname6.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname7.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname8.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname9.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = true;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }

            else if (label3.Text == "8")
            {
                clearcontainer();

                LoadablePnl6.Visible = true;
                LoadablePnl7.Visible = true;
                LoadablePnl8.Visible = true;
                LoadablePnl9.Visible = true;
                LoadablePnl10.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl6);
                PanelContainer2.Controls.Add(LoadablePnl7);
                PanelContainer3.Controls.Add(LoadablePnl8);
                PanelContainer4.Controls.Add(LoadablePnl9);
                PanelContainer5.Controls.Add(LoadablePnl10);
                //TEXT CHANGE
                Lname6.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname7.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname8.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname9.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname10.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = true;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;

                PanelContainer4.Visible = true;
                PanelContainer5.Visible = true;
            }

            else if (label3.Text == "9")
            {
                clearcontainer();


                LoadablePnl7.Visible = true;
                LoadablePnl8.Visible = true;
                LoadablePnl9.Visible = true;
                LoadablePnl10.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl7);
                PanelContainer2.Controls.Add(LoadablePnl8);
                PanelContainer3.Controls.Add(LoadablePnl9);
                PanelContainer4.Controls.Add(LoadablePnl10);
                //TEXT CHANGE
                Lname7.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname8.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname9.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname10.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = true;
                lbutton10.Visible = false;

                nextButton.Visible = true;

                PanelContainer4.Visible = true;
                PanelContainer5.Visible = false;

            }
            else if (label3.Text == "10")
            {
                clearcontainer();

                LoadablePnl8.Visible = true;
                LoadablePnl9.Visible = true;
                LoadablePnl10.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl8);
                PanelContainer2.Controls.Add(LoadablePnl9);
                PanelContainer3.Controls.Add(LoadablePnl10);
                //TEXT CHANGE
                Lname8.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname9.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname10.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = true;

                PanelContainer4.Visible = false;
                PanelContainer5.Visible = false;



                nextButton.Visible = false;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % stringArray.Length;

            // Update the label with the current string
            label3.Text = stringArray[currentIndex];

            // FOR BUTTONS

            if (label3.Text == "D1")
            {
                clearcontainer();

                PanelContainer1.Visible = false;
                PanelContainer2.Visible = false;

                PanelContainer3.Controls.Add(Dpanel1);
                //TEXT CHANGE
                Dname1.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Dname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                PanelContainer4.Controls.Add(Dpanel2);
                PanelContainer5.Controls.Add(Dpanel3);

                DefaultSoundBtn1.Visible = true;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;




                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "D2")
            {
                clearcontainer();


                PanelContainer2.Visible = true;


                PanelContainer2.Controls.Add(Dpanel1);
                PanelContainer3.Controls.Add(Dpanel2);
                PanelContainer4.Controls.Add(Dpanel3);
                PanelContainer5.Controls.Add(Dpanel4);
                //TEXT CHANGE
                Dname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname2.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Dname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


                prevButton.Visible = true;
                nextButton.Visible = true;

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = true;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
            }
            if (label3.Text == "D3")
            {
                clearcontainer();
                PanelContainer1.Visible = true;
                PanelContainer2.Visible = true;


                PanelContainer1.Controls.Add(Dpanel1);
                PanelContainer2.Controls.Add(Dpanel2);
                PanelContainer3.Controls.Add(Dpanel3);
                PanelContainer4.Controls.Add(Dpanel4);
                PanelContainer5.Controls.Add(Dpanel5);
                //TEXT CHANGE
                Dname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname3.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Dname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


                prevButton.Visible = true;
                nextButton.Visible = true;

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = true;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
            }
            else if (label3.Text == "D4")
            {
                clearcontainer();

                PanelContainer1.Visible = true;
                PanelContainer2.Visible = true;

                LoadablePnl1.Visible = true;


                PanelContainer1.Controls.Add(Dpanel2);
                PanelContainer2.Controls.Add(Dpanel3);
                PanelContainer3.Controls.Add(Dpanel4);
                PanelContainer4.Controls.Add(Dpanel5);
                PanelContainer5.Controls.Add(LoadablePnl1);
                //TEXT CHANGE
                Dname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname4.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Dname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = true;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "D5")
            {
                clearcontainer();

                LoadablePnl1.Visible = true;
                LoadablePnl2.Visible = true;


                PanelContainer1.Controls.Add(Dpanel3);
                PanelContainer2.Controls.Add(Dpanel4);
                PanelContainer3.Controls.Add(Dpanel5);
                PanelContainer4.Controls.Add(LoadablePnl1);
                PanelContainer5.Controls.Add(LoadablePnl2);
                //TEXT CHANGE
                Dname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname5.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = true;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;

            }
            else if (label3.Text == "1")
            {
                clearcontainer();

                LoadablePnl1.Visible = true;
                LoadablePnl2.Visible = true;
                LoadablePnl3.Visible = true;

                PanelContainer1.Controls.Add(Dpanel4);
                PanelContainer2.Controls.Add(Dpanel5);
                PanelContainer3.Controls.Add(LoadablePnl1);
                PanelContainer4.Controls.Add(LoadablePnl2);
                PanelContainer5.Controls.Add(LoadablePnl3);
                //TEXT CHANGE
                Dname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Dname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname1.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = true;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
                prevButton.Visible = true;
                nextButton.Visible = true;

            }
            else if (label3.Text == "2")
            {
                clearcontainer();

                LoadablePnl1.Visible = true;
                LoadablePnl2.Visible = true;
                LoadablePnl3.Visible = true;
                LoadablePnl4.Visible = true;


                PanelContainer1.Controls.Add(Dpanel5);
                PanelContainer2.Controls.Add(LoadablePnl1);
                PanelContainer3.Controls.Add(LoadablePnl2);
                PanelContainer4.Controls.Add(LoadablePnl3);
                PanelContainer5.Controls.Add(LoadablePnl4);
                //TEXT CHANGE
                Dname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname2.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = true;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
                prevButton.Visible = true;
                nextButton.Visible = true;
                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "3")
            {
                clearcontainer();

                LoadablePnl1.Visible = true;
                LoadablePnl2.Visible = true;
                LoadablePnl3.Visible = true;
                LoadablePnl4.Visible = true;
                LoadablePnl5.Visible = true;


                PanelContainer1.Controls.Add(LoadablePnl1);
                PanelContainer2.Controls.Add(LoadablePnl2);
                PanelContainer3.Controls.Add(LoadablePnl3);
                PanelContainer4.Controls.Add(LoadablePnl4);
                PanelContainer5.Controls.Add(LoadablePnl5);
                //TEXT CHANGE
                Lname1.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname3.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = true;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
                prevButton.Visible = true;
                nextButton.Visible = true;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "4")
            {
                clearcontainer();


                LoadablePnl2.Visible = true;
                LoadablePnl3.Visible = true;
                LoadablePnl4.Visible = true;
                LoadablePnl5.Visible = true;
                LoadablePnl6.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl2);
                PanelContainer2.Controls.Add(LoadablePnl3);
                PanelContainer3.Controls.Add(LoadablePnl4);
                PanelContainer4.Controls.Add(LoadablePnl5);
                PanelContainer5.Controls.Add(LoadablePnl6);
                //TEXT CHANGE
                Lname2.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname4.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname6.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = true;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;
                prevButton.Visible = true;
                nextButton.Visible = true;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "5")
            {
                clearcontainer();

                LoadablePnl3.Visible = true;
                LoadablePnl4.Visible = true;
                LoadablePnl5.Visible = true;
                LoadablePnl6.Visible = true;
                LoadablePnl7.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl3);
                PanelContainer2.Controls.Add(LoadablePnl4);
                PanelContainer3.Controls.Add(LoadablePnl5);
                PanelContainer4.Controls.Add(LoadablePnl6);
                PanelContainer5.Controls.Add(LoadablePnl7);
                //TEXT CHANGE
                Lname3.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname5.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname6.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname7.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = true;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;



                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "6")
            {
                clearcontainer();


                LoadablePnl4.Visible = true;
                LoadablePnl5.Visible = true;
                LoadablePnl6.Visible = true;
                LoadablePnl7.Visible = true;
                LoadablePnl8.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl4);
                PanelContainer2.Controls.Add(LoadablePnl5);
                PanelContainer3.Controls.Add(LoadablePnl6);
                PanelContainer4.Controls.Add(LoadablePnl7);
                PanelContainer5.Controls.Add(LoadablePnl8);
                //TEXT CHANGE
                Lname4.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname6.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname7.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname8.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = true;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }
            else if (label3.Text == "7")
            {
                clearcontainer();


                LoadablePnl5.Visible = true;
                LoadablePnl6.Visible = true;
                LoadablePnl7.Visible = true;
                LoadablePnl8.Visible = true;
                LoadablePnl9.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl5);
                PanelContainer2.Controls.Add(LoadablePnl6);
                PanelContainer3.Controls.Add(LoadablePnl7);
                PanelContainer4.Controls.Add(LoadablePnl8);
                PanelContainer5.Controls.Add(LoadablePnl9);
                //TEXT CHANGE
                Lname5.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname6.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname7.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname8.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname9.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = true;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }

            else if (label3.Text == "8")
            {
                clearcontainer();

                LoadablePnl6.Visible = true;
                LoadablePnl7.Visible = true;
                LoadablePnl8.Visible = true;
                LoadablePnl9.Visible = true;
                LoadablePnl10.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl6);
                PanelContainer2.Controls.Add(LoadablePnl7);
                PanelContainer3.Controls.Add(LoadablePnl8);
                PanelContainer4.Controls.Add(LoadablePnl9);
                PanelContainer5.Controls.Add(LoadablePnl10);
                //TEXT CHANGE
                Lname6.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname7.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname8.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname9.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname10.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);

                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = true;
                lbutton9.Visible = false;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;
            }

            else if (label3.Text == "9")
            {
                clearcontainer();


                LoadablePnl7.Visible = true;
                LoadablePnl8.Visible = true;
                LoadablePnl9.Visible = true;
                LoadablePnl10.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl7);
                PanelContainer2.Controls.Add(LoadablePnl8);
                PanelContainer3.Controls.Add(LoadablePnl9);
                PanelContainer4.Controls.Add(LoadablePnl10);
                //TEXT CHANGE
                Lname7.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname8.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname9.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);
                Lname10.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);


                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = true;
                lbutton10.Visible = false;

                prevButton.Visible = true;
                nextButton.Visible = true;

                PanelContainer5.Visible = false;

            }
            else if (label3.Text == "10")
            {
                clearcontainer();

                LoadablePnl8.Visible = true;
                LoadablePnl9.Visible = true;
                LoadablePnl10.Visible = true;

                PanelContainer1.Controls.Add(LoadablePnl8);
                PanelContainer2.Controls.Add(LoadablePnl9);
                PanelContainer3.Controls.Add(LoadablePnl10);
                //TEXT CHANGE
                Lname8.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname9.Font = new Font("Bowlby One SC", 12f, FontStyle.Regular);
                Lname10.Font = new Font("Bowlby One SC", 26f, FontStyle.Regular);


                DefaultSoundBtn1.Visible = false;
                DefaultSoundBtn2.Visible = false;
                DefaultSoundBtn3.Visible = false;
                DefaultSoundBtn4.Visible = false;
                DefaultSoundBtn5.Visible = false;
                lbutton1.Visible = false;
                lbutton2.Visible = false;
                lbutton3.Visible = false;
                lbutton4.Visible = false;
                lbutton5.Visible = false;
                lbutton6.Visible = false;
                lbutton7.Visible = false;
                lbutton8.Visible = false;
                lbutton9.Visible = false;
                lbutton10.Visible = true;

                PanelContainer4.Visible = false;
                PanelContainer5.Visible = false;

                nextButton.Visible = false;
            }
            else if (PanelContainer1 == null || PanelContainer2 == null || PanelContainer3 == null || PanelContainer4 == null || PanelContainer5 == null)
            {

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Image Files|*.jpg;*.png;*.bmp|All Files|*.*" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;
                    imageData = File.ReadAllBytes(imagePath);

                    // Display the selected image in pictureBox8
                    pictureBox8.Image = Image.FromStream(new MemoryStream(imageData));
                }
            }
        }

        private void insertSound_Click(object sender, EventArgs e)
        {
            if (int.TryParse(label3.Text, out int soundID))
            {
                // Check if SoundName and ImageData are already populated
                if (!string.IsNullOrEmpty(textBox1.Text) && imageData != null)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Sound Files|*.wav;*.mp3|All Files|*.*" })
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string soundFilePath = openFileDialog.FileName;
                            byte[] soundData = File.ReadAllBytes(soundFilePath);

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundData = @SoundData WHERE SoundID = @ID", connection))
                            {
                                connection.Open();

                                cmd.Parameters.AddWithValue("@ID", soundID);
                                cmd.Parameters.AddWithValue("@SoundData", soundData);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                // Set the flag to indicate that sound data has been saved
                                soundDataSaved = rowsAffected > 0;

                                // MessageBox.Show(soundDataSaved ? "Sound upda : "Sound not found in the database.");
                                if (soundDataSaved = true)
                                {
                                    insertSound.Text = "CHANGE";
                                    insertSound.BackColor = Color.SeaGreen;
                                    string selectedFileName = openFileDialog.SafeFileName;
                                    label2.Visible = true;
                                    label5.Visible = true;
                                    // Display the selected file name in label5
                                    label5.Text = selectedFileName;
                                }
                                else
                                {
                                    insertSound.Text = "INSERT";
                                    insertSound.BackColor = Color.Red;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Insert an Image and a Name!");
                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in TextBox1!");
            }
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(label3.Text, out int soundID))
            {
                // Check if soundData is missing
                if (!soundDataSaved)
                {
                    MessageBox.Show("Input a Sound!");
                }
                else if (imageData == null)
                {
                    MessageBox.Show("Input an Image!");
                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Input a Name!");
                }
                else
                {
                    prevButton.Visible = true;
                    nextButton.Visible = true;

                    bool updateSuccessful = false;

                    // Continue with the update process
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET ImageData = @ImageData WHERE SoundID = @ID", connection))
                    {
                        try
                        {
                            connection.Open();
                            cmd.Parameters.AddWithValue("@ID", soundID);
                            cmd.Parameters.AddWithValue("@ImageData", imageData);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            updateSuccessful = rowsAffected > 0;



                            // Update the corresponding PictureBox with the newly inserted image, based on label3's text
                            if (updateSuccessful)
                            {
                                PictureBox targetPictureBox = this.Controls.Find("Lpicture" + label3.Text, true).FirstOrDefault() as PictureBox;
                                if (targetPictureBox != null)
                                {
                                    insertSound.Text = "INSERT";
                                    insertSound.BackColor = Color.MediumVioletRed;
                                    targetPictureBox.Image = Image.FromStream(new MemoryStream(imageData));

                                    label2.Visible = false;
                                    label5.Visible = false;

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating image: {ex.Message}");
                        }
                    }


                    // If the update was successful and label3.Text is "1", proceed with the second update
                    if (updateSuccessful && label3.Text == "1")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 1); // Adjust the ID based on your condition

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // Open the connection


                                        // SQL query to retrieve image data from tbl_assets WHERE SoundID is 3
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand command = new SqlCommand(query, connection))
                                        {
                                            // Replace @ImageID with the actual parameter name and value (in this case, 3)
                                            command.Parameters.AddWithValue("@ImageID", 4);

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {
                                                    // Check if the column with image data exists
                                                    if (reader["ImageData"] != DBNull.Value)
                                                    {
                                                        // Retrieve the image data as a byte array
                                                        byte[] imageData = (byte[])reader["ImageData"];

                                                        // Convert the byte array to a MemoryStream
                                                        using (MemoryStream stream = new MemoryStream(imageData))
                                                        {
                                                            // Create a Bitmap from the MemoryStream
                                                            Bitmap image = new Bitmap(stream);

                                                            // Set the image to the PictureBox
                                                            lbutton1.Image = image;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        Lname1.Text = textBox1.Text;

                                        soundDataSaved = false;
                                        label5.Text = "...";
                                        panel1.Visible = false;
                                        imageData = null;
                                        textBox1.Text = "";
                                        pictureBox8.Image = null;
                                        LoadImageFromDatabase();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }

                    else if (label3.Text == "2")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                // Update the Name in tbl_KINDERAERIALVEHICLES
                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 2); // Adjust the ID based on your condition

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // SQL query to retrieve image data from tbl_ImageAssets where ImageID is 4
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand imageCommand = new SqlCommand(query, connection))
                                        {
                                            // Replace @ImageID with the actual parameter name and value (in this case, 4)
                                            imageCommand.Parameters.AddWithValue("@ImageID", 4);

                                            // Retrieve the image data
                                            byte[] imageData = imageCommand.ExecuteScalar() as byte[];

                                            if (imageData != null)
                                            {
                                                // Convert the byte array to a MemoryStream
                                                using (MemoryStream stream = new MemoryStream(imageData))
                                                {
                                                    // Create a Bitmap from the MemoryStream
                                                    Bitmap image = new Bitmap(stream);

                                                    // Set the image to lbutton2
                                                    lbutton2.Image = image;

                                                    // Update other UI elements

                                                    Lname2.Text = textBox1.Text;

                                                    soundDataSaved = false;
                                                    label5.Text = "...";
                                                    panel1.Visible = false;
                                                    imageData = null;
                                                    textBox1.Text = "";
                                                    pictureBox8.Image = null;
                                                    LoadImageFromDatabase();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Image data not found in the database.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }

                    else if (label3.Text == "3")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 3); // Adjust the ID based on your condition

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // Open the connection


                                        // SQL query to retrieve image data from tbl_assets WHERE SoundID is 3
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand command = new SqlCommand(query, connection))
                                        {
                                            // Replace @ImageID with the actual parameter name and value (in this case, 3)
                                            command.Parameters.AddWithValue("@ImageID", 4);

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {
                                                    // Check if the column with image data exists
                                                    if (reader["ImageData"] != DBNull.Value)
                                                    {
                                                        // Retrieve the image data as a byte array
                                                        byte[] imageData = (byte[])reader["ImageData"];

                                                        // Convert the byte array to a MemoryStream
                                                        using (MemoryStream stream = new MemoryStream(imageData))
                                                        {
                                                            // Create a Bitmap from the MemoryStream
                                                            Bitmap image = new Bitmap(stream);

                                                            // Set the image to the PictureBox
                                                            lbutton3.Image = image;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        Lname3.Text = textBox1.Text;

                                        soundDataSaved = false;
                                        label5.Text = "...";
                                        panel1.Visible = false;
                                        imageData = null;
                                        textBox1.Text = "";
                                        pictureBox8.Image = null;
                                        LoadImageFromDatabase();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }
                    else if (label3.Text == "4")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 4); // 

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand command = new SqlCommand(query, connection))
                                        {

                                            command.Parameters.AddWithValue("@ImageID", 4); //

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {

                                                    if (reader["ImageData"] != DBNull.Value)
                                                    {

                                                        byte[] imageData = (byte[])reader["ImageData"];


                                                        using (MemoryStream stream = new MemoryStream(imageData))
                                                        {
                                                            Bitmap image = new Bitmap(stream);
                                                            lbutton4.Image = image;//
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        Lname4.Text = textBox1.Text; //

                                        soundDataSaved = false;
                                        label5.Text = "...";
                                        panel1.Visible = false;
                                        imageData = null;
                                        textBox1.Text = "";
                                        pictureBox8.Image = null;
                                        LoadImageFromDatabase();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }
                    else if (label3.Text == "5")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 5); // 

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand command = new SqlCommand(query, connection))
                                        {

                                            command.Parameters.AddWithValue("@ImageID", 4); //

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {

                                                    if (reader["ImageData"] != DBNull.Value)
                                                    {

                                                        byte[] imageData = (byte[])reader["ImageData"];


                                                        using (MemoryStream stream = new MemoryStream(imageData))
                                                        {
                                                            Bitmap image = new Bitmap(stream);
                                                            lbutton5.Image = image;//
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        Lname5.Text = textBox1.Text; //

                                        soundDataSaved = false;
                                        label5.Text = "...";
                                        panel1.Visible = false;
                                        imageData = null;
                                        textBox1.Text = "";
                                        pictureBox8.Image = null;
                                        LoadImageFromDatabase();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    } //

                    else if (label3.Text == "6")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 6); // 

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand command = new SqlCommand(query, connection))
                                        {

                                            command.Parameters.AddWithValue("@ImageID", 4); //wag baguhin

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {

                                                    if (reader["ImageData"] != DBNull.Value)
                                                    {

                                                        byte[] imageData = (byte[])reader["ImageData"];


                                                        using (MemoryStream stream = new MemoryStream(imageData))
                                                        {
                                                            Bitmap image = new Bitmap(stream);
                                                            lbutton6.Image = image;//
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        Lname6.Text = textBox1.Text; //

                                        soundDataSaved = false;
                                        label5.Text = "...";
                                        panel1.Visible = false;
                                        imageData = null;
                                        textBox1.Text = "";
                                        pictureBox8.Image = null;
                                        LoadImageFromDatabase();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }//
                    else if (label3.Text == "7")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 7); // 

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand command = new SqlCommand(query, connection))
                                        {

                                            command.Parameters.AddWithValue("@ImageID", 4); //

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {

                                                    if (reader["ImageData"] != DBNull.Value)
                                                    {

                                                        byte[] imageData = (byte[])reader["ImageData"];


                                                        using (MemoryStream stream = new MemoryStream(imageData))
                                                        {
                                                            Bitmap image = new Bitmap(stream);
                                                            lbutton7.Image = image;//
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        Lname7.Text = textBox1.Text; //

                                        soundDataSaved = false;
                                        label5.Text = "...";
                                        panel1.Visible = false;
                                        imageData = null;
                                        textBox1.Text = "";
                                        pictureBox8.Image = null;
                                        LoadImageFromDatabase();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }
                    else if (label3.Text == "8")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 8); // 

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand command = new SqlCommand(query, connection))
                                        {

                                            command.Parameters.AddWithValue("@ImageID", 4); //

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {

                                                    if (reader["ImageData"] != DBNull.Value)
                                                    {

                                                        byte[] imageData = (byte[])reader["ImageData"];


                                                        using (MemoryStream stream = new MemoryStream(imageData))
                                                        {
                                                            Bitmap image = new Bitmap(stream);
                                                            lbutton8.Image = image;//
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        Lname8.Text = textBox1.Text; //

                                        soundDataSaved = false;
                                        label5.Text = "...";
                                        panel1.Visible = false;
                                        imageData = null;
                                        textBox1.Text = "";
                                        pictureBox8.Image = null;
                                        LoadImageFromDatabase();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }
                    else if (label3.Text == "9")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 9); // 

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand command = new SqlCommand(query, connection))
                                        {

                                            command.Parameters.AddWithValue("@ImageID", 4); //

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {

                                                    if (reader["ImageData"] != DBNull.Value)
                                                    {

                                                        byte[] imageData = (byte[])reader["ImageData"];


                                                        using (MemoryStream stream = new MemoryStream(imageData))
                                                        {
                                                            Bitmap image = new Bitmap(stream);
                                                            lbutton9.Image = image;//
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        Lname9.Text = textBox1.Text; //

                                        soundDataSaved = false;
                                        label5.Text = "...";
                                        panel1.Visible = false;
                                        imageData = null;
                                        textBox1.Text = "";
                                        pictureBox8.Image = null;
                                        LoadImageFromDatabase();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }
                    else if (label3.Text == "10")
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                string soundName = textBox1.Text;

                                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundName = @Name WHERE SoundID = @ID", connection))
                                {
                                    cmd.Parameters.AddWithValue("@Name", soundName);
                                    cmd.Parameters.AddWithValue("@ID", 10); // 

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        string query = "SELECT ImageData FROM tbl_ImageAssets WHERE ImageID = @ImageID";

                                        using (SqlCommand command = new SqlCommand(query, connection))
                                        {

                                            command.Parameters.AddWithValue("@ImageID", 4); //

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {

                                                    if (reader["ImageData"] != DBNull.Value)
                                                    {

                                                        byte[] imageData = (byte[])reader["ImageData"];


                                                        using (MemoryStream stream = new MemoryStream(imageData))
                                                        {
                                                            Bitmap image = new Bitmap(stream);
                                                            lbutton10.Image = image;//
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        Lname10.Text = textBox1.Text; //

                                        soundDataSaved = false;
                                        label5.Text = "...";
                                        panel1.Visible = false;
                                        imageData = null;
                                        textBox1.Text = "";
                                        pictureBox8.Image = null;
                                        LoadImageFromDatabase();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update value in the database.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }

                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            label2.Visible = false;
            insertSound.Text = "INSERT";
            insertSound.BackColor = Color.MediumVioletRed;
            nextButton.Visible = true;
            prevButton.Visible = true;
            // Check if label3.Text can be parsed to an integer
            if (int.TryParse(label3.Text, out int soundID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_KINDERAERIALVEHICLES SET SoundData = NULL, ImageData = NULL WHERE SoundID = @ID", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@ID", soundID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            textBox1.Text = "";
                            pictureBox8.Image = null;
                            panel1.Visible = false;
                            label5.Text = "...";
                            soundDataSaved = false;
                            imageData = null;
                            // Set imageData to null


                        }
                        else
                        {
                            // SoundID not found in the database
                            MessageBox.Show("Sound not found in the database.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in label3.Text!");
            }
        }

        private void ModalPlay_Click(object sender, EventArgs e)
        {
            prevButton.Visible = false;
            nextButton.Visible = false;
            if (ModalID.Text == "D1")
            {
                int soundIDToPlay = 56; // I-update ito base sa SoundID na nais mong i-play

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
            else if (ModalID.Text == "D2")
            {
                int soundIDToPlay = 57; // I-update ito base sa SoundID na nais mong i-play

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
            else if (ModalID.Text == "D3")
            {
                int soundIDToPlay = 58; // I-update ito base sa SoundID na nais mong i-play

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
            else if (ModalID.Text == "D4")
            {
                int soundIDToPlay = 59; // I-update ito base sa SoundID na nais mong i-play

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
            else if (ModalID.Text == "D5")
            {
                int soundIDToPlay = 60; // I-update ito base sa SoundID na nais mong i-play

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
            if (int.TryParse(ModalID.Text, out int modalIDValue) && modalIDValue >= 1 && modalIDValue <= 10)
            {
                if (int.TryParse(label3.Text, out int soundID))
                {
                    string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                    Player.URL = soundFilePath;
                    Player.controls.play();
                }
                else
                {
                    MessageBox.Show("Invalid integer value in Label3!");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Player.controls.stop();
            Modal.Visible = false;
            Modal.SendToBack();
            prevButton.Visible = true;
            nextButton.Visible = true;
        }

        private void DefaultSoundBtn1_Click(object sender, EventArgs e)
        {
            ModalID.Text = label3.Text;
            ModalName.Text = Dname1.Text;
            Modal.Visible = true;
            Modal.BringToFront();
            ModalPic.Image = Dpicture1.Image;
            prevButton.Visible = false;
            nextButton.Visible = false;

            int soundIDToPlay = 56; // I-update ito base sa SoundID na nais mong i-play

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

        private void DefaultSoundBtn2_Click(object sender, EventArgs e)
        {
            ModalID.Text = label3.Text;
            ModalName.Text = Dname2.Text;
            Modal.Visible = true;
            Modal.BringToFront();
            ModalPic.Image = Dpicture2.Image;
            prevButton.Visible = false;
            nextButton.Visible = false;

            int soundIDToPlay = 57; // I-update ito base sa SoundID na nais mong i-play

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

        private void DefaultSoundBtn3_Click(object sender, EventArgs e)
        {
            ModalID.Text = label3.Text;
            ModalName.Text = Dname3.Text;
            Modal.Visible = true;
            Modal.BringToFront();
            ModalPic.Image = Dpicture3.Image;
            prevButton.Visible = false;
            nextButton.Visible = false;

            int soundIDToPlay = 58; // I-update ito base sa SoundID na nais mong i-play

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

        private void DefaultSoundBtn4_Click(object sender, EventArgs e)
        {
            ModalID.Text = label3.Text;
            ModalName.Text = Dname4.Text;
            Modal.Visible = true;
            Modal.BringToFront();
            ModalPic.Image = Dpicture4.Image;
            prevButton.Visible = false;
            nextButton.Visible = false;

            int soundIDToPlay = 59; // I-update ito base sa SoundID na nais mong i-play

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

        private void DefaultSoundBtn5_Click(object sender, EventArgs e)
        {
            ModalID.Text = label3.Text;
            ModalName.Text = Dname5.Text;
            Modal.Visible = true;
            Modal.BringToFront();
            ModalPic.Image = Dpicture5.Image;
            prevButton.Visible = false;
            nextButton.Visible = false;

            int soundIDToPlay = 60; // I-update ito base sa SoundID na nais mong i-play

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

        private void lbutton1_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname1.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture1.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }

        private void lbutton2_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname2.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture2.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }

        private void lbutton3_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname3.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture3.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }

        private void lbutton4_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname4.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture4.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }

        private void lbutton5_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname5.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture5.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }

        private void lbutton6_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname6.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture6.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }

        private void lbutton7_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname7.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture7.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }

        private void lbutton8_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname8.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture8.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }

        private void lbutton9_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname9.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture9.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }

        private void lbutton10_Click(object sender, EventArgs e)
        {

            LoadImageFromDatabase();
            if (int.TryParse(label3.Text, out int soundID))
            {
                string soundFilePath = GetFilePathFromLoadableSounds(soundID);

                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    // Assuming you have a Windows Media Player control named "Player" on your form
                    ModalID.Text = label3.Text;
                    ModalName.Text = Lname10.Text;
                    Modal.Visible = true;
                    Modal.BringToFront();
                    ModalPic.Image = Lpicture10.Image;
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    Player.URL = soundFilePath;
                    Player.controls.play();


                }
                else
                {
                    // Show the panel if there is no sound file path
                    prevButton.Visible = false;
                    nextButton.Visible = false;
                    panel1.BringToFront();
                    panel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid integer value in Label3!");
            }
        }


        //END
    }
}
