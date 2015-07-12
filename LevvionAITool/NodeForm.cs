using System;
using System.Windows.Forms;
using LevvionAI.Data;

namespace LevvionAITool
{
    public enum ConditionType
    {
        Bool, Int, Float, String, Multi,
    }

    public partial class NodeForm : Form
    {
        private Node _node;

        public NodeForm(Node node)
        {
            _node = node;

            InitializeComponent();

            LoadComboBox();

            LoadData();
        }

        private void LoadComboBox()
        {
            var actions = Enum.GetValues(typeof(ConditionType));

            foreach (var action in actions)
            {
                cboCondition.Items.Add((ConditionType)action);
            }

            cboCondition.SelectedIndex = cboCondition.Items.IndexOf(DetectConditionType());
        }

        private ConditionType DetectConditionType()
        {
            string typename = _node.Condition.GetType().Name;

            if (typename == "BoolCondition")
            {
                return ConditionType.Bool;
            }

            if (typename == "IntCondition")
            {
                return ConditionType.Int;
            }

            if (typename == "FloatCondition")
            {
                return ConditionType.Float;
            }

            if (typename == "StringCondition")
            {
                return ConditionType.String;
            }

            if (typename == "MultiCondition")
            {
                return ConditionType.Multi;
            }

            throw new Exception("Invalid condition type.");
        }

        private void LoadData()
        {
            numPriority.Value = _node.Priority;
            numChance.Value = (decimal)_node.Chance;
            chkInterrupt.Checked = _node.Interruptable;

            RefreshLabels();
        }

        public void RefreshLabels()
        {
            lblAction.Text = _node.Action.ToString();
            lblCondition.Text = _node.Condition.ToString();
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            //Action and Condition are handled by their own forms.
            _node.Priority = (int)numPriority.Value;
            _node.Chance = (float)numChance.Value;
            _node.Interruptable = chkInterrupt.Checked;
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
