using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using LevvionAI;
using LevvionAI.Data;

namespace LevvionAITool
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The path to the file we're working on.
        /// </summary>
        private string _filepath;
        private const string FileMask = "Mask of LevvionAI (*.lai)|*.lai";

        public MainForm()
        {
            InitializeComponent();
            CreateNewAI();
        }

        private void CreateNewAI()
        {
            _filepath = "";
            ChangeTitle();

            lstCircles.Items.Clear();
        }

        /// <summary>
        /// Changes the title of the window.
        /// </summary>
        private void ChangeTitle()
        {
            Text = "Mask of Levvion - " + _filepath;

            if (_filepath.Equals(""))
            {
                Text += "New AI";
            }
        }

        /// <summary>
        /// Triggers when the new button is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            CreateNewAI();
        }

        /// <summary>
        /// Triggers when the open button is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = FileMask;
            ofd.ShowDialog();

            if (ofd.FileName == "")
            {
                return;
            }

            CreateNewAI(); //Initialize the data.

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
                sfd.Filter = FileMask;
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
            sfd.Filter = FileMask;
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

            var ai = new AIController(null);

            foreach (var item in lstCircles.Items)
            {
                ai.Circles.Add(item as Circle);
            }

            //Then save it!
            var doc = new XDocument(ai.SaveToXml());

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
            var ai = new AIController(null);
            ai.LoadFromXml(doc.Root);

            foreach (var circle in ai.Circles)
            {
                AddNewItem(circle);
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

        private void BtnEditClick(object sender, EventArgs e)
        {

        }

        private void BtnAddNewClick(object sender, EventArgs e)
        {

        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {

        }

        private void AddNewItem(Circle circle)
        {
            lstCircles.Items.Add(circle);
        }
    }
}
