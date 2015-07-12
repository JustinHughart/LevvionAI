using System;
using System.Windows.Forms;

namespace LevvionAITool
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The path to the file we're working on.
        /// </summary>
        private string _filepath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateNewProfile()
        {
            _filepath = "";
            ChangeTitle();

            lstCircles.
        }

        /// <summary>
        /// Changes the title of the window.
        /// </summary>
        private void ChangeTitle()
        {
            Text = "Essell Series Stat Profile Editor - " + _filepath;

            if (_filepath.Equals(""))
            {
                Text += "New Profile";
            }
        }

        /// <summary>
        /// Triggers when the new button is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            CreateNewProfile();
        }

        /// <summary>
        /// Triggers when the open button is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Essell Series Stat Profile (*.esp)|*.esp";
            ofd.ShowDialog();

            if (ofd.FileName == "")
            {
                return;
            }

            CreateNewProfile(); //Initialize the data.

            _filepath = ofd.FileName;

            ChangeTitle();

            LoadFromFile(_filepath);
        }

        /// <summary>
        /// Triggers when the save button is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_filepath == "")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Essell Series Stat Profile (*.esp)|*.esp";
                sfd.ShowDialog();

                if (sfd.FileName != "")
                {
                    _filepath = sfd.FileName;

                    ChangeTitle();
                }
            }

            if (_filepath != "")
            {
                SaveToFile(_filepath);
            }
        }

        /// <summary>
        /// Triggers when the save as button is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            bool valid = false;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Essell Series Stat Profile (*.esp)|*.esp";
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                valid = true;
                _filepath = sfd.FileName;
                ChangeTitle();
            }

            if (valid)
            {
                SaveToFile(_filepath);
            }
        }

        /// <summary>
        /// Triggers when the exit button is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="System.ArgumentException">File type not supported.</exception>
        private void SaveToFile(string path)
        {
            path = ValidatePath(path);

            //Modifiers
            var modifiers = new Dictionary<StatType, float>();
            modifiers.Add(StatType.Vitality, (float)numVIT.Value);
            modifiers.Add(StatType.Wisdom, (float)numWIS.Value);
            modifiers.Add(StatType.Stamina, (float)numSTA.Value);
            modifiers.Add(StatType.Strength, (float)numSTR.Value);
            modifiers.Add(StatType.Defense, (float)numDEF.Value);
            modifiers.Add(StatType.Intelligence, (float)numINT.Value);
            modifiers.Add(StatType.Resilience, (float)numRES.Value);
            modifiers.Add(StatType.Speed, (float)numSPD.Value);
            modifiers.Add(StatType.Accuracy, (float)numACC.Value);
            modifiers.Add(StatType.Evade, (float)numEVD.Value);
            modifiers.Add(StatType.Luck, (float)numLUK.Value);

            //Stats
            var stats = new Dictionary<StatType, ProfileStrength>();

            foreach (DataGridViewRow row in dgvStats.Rows)
            {
                StatType type = StatType.None;
                ProfileStrength strength = ProfileStrength.ResistElementHigh;

                if (row.Cells[0].Value == null || row.Cells[1].Value == null)
                {
                    continue;
                }

                type = (StatType)row.Cells[0].Value;
                strength = (ProfileStrength)row.Cells[1].Value;

                stats.Add(type, strength);
            }

            //Basic Data
            var profile = new StatProfile(modifiers, stats);
            profile.Name = txtName.Text;
            profile.Description = txtDescription.Text;

            //First we'll back up the old file.
            if (File.Exists(path))
            {
                string backuppath = path + ".bak";

                if (File.Exists(backuppath))
                {
                    File.Delete(backuppath);
                }

                File.Copy(path, backuppath);
                File.Delete(path);
            }

            //Then save it!
            var doc = new XDocument(profile.SaveToXml());

            using (var stream = File.OpenWrite(path))
            {
                doc.Save(stream);
            }
        }

        /// <summary>
        /// Loads from file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="System.ArgumentException">File type not supported.</exception>
        /// <exception cref="System.Xml.XmlException">
        /// No root.
        /// or
        /// Root is not an entity.
        /// </exception>
        private void LoadFromFile(string path)
        {
            path = ValidatePath(path);

            //Load the profile.
            XDocument doc = XDocument.Load(path);
            var profile = new StatProfile();
            profile.LoadFromXml(doc.Root);

            //Assign basic data.
            txtName.Text = profile.Name;
            txtDescription.Text = profile.Description;

            //Assign modifiers.
            numVIT.Value = (decimal)profile.GetModifier(StatType.Vitality);
            numWIS.Value = (decimal)profile.GetModifier(StatType.Wisdom);
            numSTA.Value = (decimal)profile.GetModifier(StatType.Stamina);
            numSTR.Value = (decimal)profile.GetModifier(StatType.Strength);
            numDEF.Value = (decimal)profile.GetModifier(StatType.Defense);
            numINT.Value = (decimal)profile.GetModifier(StatType.Intelligence);
            numRES.Value = (decimal)profile.GetModifier(StatType.Resilience);
            numSPD.Value = (decimal)profile.GetModifier(StatType.Speed);
            numACC.Value = (decimal)profile.GetModifier(StatType.Accuracy);
            numEVD.Value = (decimal)profile.GetModifier(StatType.Evade);
            numLUK.Value = (decimal)profile.GetModifier(StatType.Luck);

            //Assign stats.
            var stats = profile.GetPrivateDataCopy().Item2;

            foreach (var stat in stats)
            {
                var row = new object[2];
                row[0] = stat.Key;
                row[1] = stat.Value;
                dgvStats.Rows.Add(row);
            }
        }

        /// <summary>
        /// Validates the path. I had wierd issues with paths, which is why this exists.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        private string ValidatePath(string input)
        {
            while (input.EndsWith(" "))
            {
                input.Remove(input.Length - 2);
            }

            return input;
        }



    }
}
