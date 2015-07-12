using System;
using System.Windows.Forms;

namespace LevvionAITool
{
    public partial class ActionForm : Form
    {
        private NodeForm _nodeform;

        public ActionForm(NodeForm nodeform)
        {
            _nodeform = nodeform;

            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            txtID.Text = _nodeform.Node.Action.ID;
            timeDuration.SetTime(_nodeform.Node.Action.Duration);
            timeCooldown.SetTime(_nodeform.Node.Action.Cooldown);
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            var action = _nodeform.Node.Action;

            action.ID = txtID.Text;
            action.Duration = timeDuration.GetTime();
            action.Cooldown = timeCooldown.GetTime();

            _nodeform.RefreshLabels();

            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
