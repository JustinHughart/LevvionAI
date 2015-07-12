using System.Windows.Forms;
using LevvionAI.Data;

namespace LevvionAITool
{
    /// <summary>
    /// A node for editting a circle.
    /// </summary>
    public partial class CircleForm : Form
    {
        /// <summary>
        /// The circle
        /// </summary>
        private Circle _circle;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleForm"/> class.
        /// </summary>
        /// <param name="circle">The circle.</param>
        public CircleForm(Circle circle)
        {
            _circle = circle;

            InitializeComponent();

            LoadData();
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            foreach (var node in _circle.Nodes)
            {
                lstNodes.Items.Add(node);
            }
        }

        /// <summary>
        /// BTNs the edit click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnEditClick(object sender, System.EventArgs e)
        {
            if (lstNodes.SelectedItem != null)
            {
                var node = lstNodes.SelectedItem as Node;

                if (node != null)
                {
                    Form form;

                    if (node.IsCircle())
                    {
                        form = new CircleForm(node as Circle);
                        form.Show();
                    }
                    else
                    {
                        form = new NodeForm(node);
                        form.Show();
                    }
                }
            }
        }

        /// <summary>
        /// BTNs the add circle click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnAddCircleClick(object sender, System.EventArgs e)
        {
            AddNewItem(new Circle());
        }

        /// <summary>
        /// BTNs the node click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnNodeClick(object sender, System.EventArgs e)
        {
            AddNewItem(new Node());
        }

        /// <summary>
        /// Adds the new item.
        /// </summary>
        /// <param name="node">The node.</param>
        private void AddNewItem(Node node)
        {
            lstNodes.Items.Add(node);
            lstNodes.RefreshToString();
        }

        /// <summary>
        /// BTNs the delete click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnDeleteClick(object sender, System.EventArgs e)
        {
            if (lstNodes.SelectedItem != null)
            {
                lstNodes.Items.Remove(lstNodes.SelectedItem);
            }
        }

        /// <summary>
        /// BTNs the node properties click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnNodePropertiesClick(object sender, System.EventArgs e)
        {
            var form = new NodeForm(_circle);
            form.Show();
        }

        /// <summary>
        /// BTNs the cancel click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnCancelClick(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// BTNs the save click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnSaveClick(object sender, System.EventArgs e)
        {
            _circle.Nodes.Clear();

            foreach (var node in lstNodes.Items)
            {
                _circle.Nodes.Add((Node)node);
            }

            Close();
        }

        
    }
}
