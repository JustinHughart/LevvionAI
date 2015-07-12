namespace LevvionAITool
{
    partial class NodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.lblAction = new System.Windows.Forms.Label();
            this.txtCondition = new System.Windows.Forms.Button();
            this.lblCondition = new System.Windows.Forms.Label();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.numChance = new System.Windows.Forms.NumericUpDown();
            this.chkInterrupt = new System.Windows.Forms.CheckBox();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Condition:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Priority:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chance:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Interruptable:";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(87, 9);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(87, 23);
            this.btnAction.TabIndex = 5;
            this.btnAction.Text = "Edit Action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.BtnActionClick);
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(180, 14);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(47, 13);
            this.lblAction.TabIndex = 6;
            this.lblAction.Text = "lblAction";
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(87, 39);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(88, 23);
            this.txtCondition.TabIndex = 7;
            this.txtCondition.Text = "Edit Condition";
            this.txtCondition.UseVisualStyleBackColor = true;
            this.txtCondition.Click += new System.EventHandler(this.TxtConditionClick);
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(270, 44);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(64, 13);
            this.lblCondition.TabIndex = 8;
            this.lblCondition.Text = "lblCondition:";
            // 
            // numPriority
            // 
            this.numPriority.Location = new System.Drawing.Point(88, 72);
            this.numPriority.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(87, 20);
            this.numPriority.TabIndex = 9;
            // 
            // numChance
            // 
            this.numChance.DecimalPlaces = 5;
            this.numChance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.numChance.Location = new System.Drawing.Point(88, 97);
            this.numChance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChance.Name = "numChance";
            this.numChance.Size = new System.Drawing.Size(87, 20);
            this.numChance.TabIndex = 10;
            // 
            // chkInterrupt
            // 
            this.chkInterrupt.AutoSize = true;
            this.chkInterrupt.Location = new System.Drawing.Point(88, 123);
            this.chkInterrupt.Name = "chkInterrupt";
            this.chkInterrupt.Size = new System.Drawing.Size(15, 14);
            this.chkInterrupt.TabIndex = 11;
            this.chkInterrupt.UseVisualStyleBackColor = true;
            // 
            // cboCondition
            // 
            this.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Location = new System.Drawing.Point(183, 41);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(81, 21);
            this.cboCondition.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 149);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(87, 149);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // NodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 185);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboCondition);
            this.Controls.Add(this.chkInterrupt);
            this.Controls.Add(this.numChance);
            this.Controls.Add(this.numPriority);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.txtCondition);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NodeForm";
            this.Text = "Node Form";
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Button txtCondition;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.NumericUpDown numChance;
        private System.Windows.Forms.CheckBox chkInterrupt;
        private System.Windows.Forms.ComboBox cboCondition;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}