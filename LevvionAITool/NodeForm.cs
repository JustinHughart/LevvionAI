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
        public Node Node;

        public NodeForm(Node node)
        {
            Node = node;

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
            string typename = Node.Condition.GetType().Name;

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
            numPriority.Value = Node.Priority;
            numChance.Value = (decimal)Node.Chance;
            chkInterrupt.Checked = Node.Interruptable;

            RefreshLabels();
        }

        public void RefreshLabels()
        {
            lblAction.Text = Node.Action.ToString();
            lblCondition.Text = Node.Condition.ToString();
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            //Action and Condition are handled by their own forms.
            Node.Priority = (int)numPriority.Value;
            Node.Chance = (float)numChance.Value;
            Node.Interruptable = chkInterrupt.Checked;
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
