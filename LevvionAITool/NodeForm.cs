using System;
using System.Windows.Forms;
using LevvionAI.Data;
using LevvionAI.Data.Conditions;
using LevvionAITool.ConditionForms;

namespace LevvionAITool
{
    /// <summary>
    /// An enum showing the valid types of conditions.
    /// </summary>
    public enum ConditionType
    {
        Bool, Int, Float, String, Multi,
    }

    /// <summary>
    /// A form for editing a node.
    /// </summary>
    public partial class NodeForm : Form
    {
        /// <summary>
        /// The node to edit.
        /// </summary>
        public Node Node;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeForm"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public NodeForm(Node node)
        {
            Node = node;

            InitializeComponent();

            LoadComboBox();

            LoadData();
        }

        /// <summary>
        /// Loads the ComboBox.
        /// </summary>
        private void LoadComboBox()
        {
            var actions = Enum.GetValues(typeof(ConditionType));

            foreach (var action in actions)
            {
                cboCondition.Items.Add((ConditionType)action);
            }

            cboCondition.SelectedIndex = cboCondition.Items.IndexOf(DetectConditionType());
        }

        /// <summary>
        /// Detects the type of the condition.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">Invalid condition type.</exception>
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

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            numPriority.Value = Node.Priority;
            numChance.Value = (decimal)Node.Chance;
            chkInterrupt.Checked = Node.Interruptable;

            RefreshLabels();
        }

        /// <summary>
        /// Refreshes the labels.
        /// </summary>
        public void RefreshLabels()
        {
            lblAction.Text = Node.Action.ToString();
            lblCondition.Text = Node.Condition.ToString();
        }

        /// <summary>
        /// BTNs the save click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnSaveClick(object sender, EventArgs e)
        {
            //Action and Condition are handled by their own forms.
            Node.Priority = (int)numPriority.Value;
            Node.Chance = (float)numChance.Value;
            Node.Interruptable = chkInterrupt.Checked;
        }

        /// <summary>
        /// BTNs the cancel click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// BTNs the action click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnActionClick(object sender, EventArgs e)
        {
            var form = new ActionForm(this);
            form.Show();
        }

        /// <summary>
        /// Texts the condition click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception">Condition type not supported.</exception>
        private void TxtConditionClick(object sender, EventArgs e)
        {
            if ((ConditionType)cboCondition.SelectedItem != DetectConditionType())
            {
                Node.Condition = CreateCondition((ConditionType)cboCondition.SelectedItem);
                RefreshLabels();
            }

            Form form;

            switch ((ConditionType)cboCondition.SelectedItem)
            {
                    case ConditionType.Bool:
                    form = new BoolConditionForm(this);
                    break;
                    case ConditionType.Int:
                    form = new IntConditionForm(this);
                    break;
                    case ConditionType.Float:
                    form = new FloatConditionForm(this);
                    break;
                    case ConditionType.String:
                    form = new StringConditionForm(this);
                    break;
                    case ConditionType.Multi:
                    form = new MultiConditionForm(this);
                    break;
                default:
                    throw new Exception("Condition type not supported.");
            }

            form.Show();
            
        }

        /// <summary>
        /// Creates the condition.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Condition not supported.</exception>
        private Condition CreateCondition(ConditionType type)
        {
            switch (type)
            {
                case ConditionType.Bool:
                    return new BoolCondition();
                case ConditionType.Int:
                    return new IntCondition();
                case ConditionType.Float:
                    return new FloatCondition();
                case ConditionType.String:
                    return new StringCondition();
                case ConditionType.Multi:
                    return new MultiCondition();
                default:
                    throw new Exception("Condition not supported.");
            }
        }
    }
}
