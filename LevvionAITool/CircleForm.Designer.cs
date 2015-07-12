namespace LevvionAITool
{
    partial class CircleForm
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddCircle = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lstNodes = new System.Windows.Forms.ListBox();
            this.btnNodeProperties = new System.Windows.Forms.Button();
            this.btnNode = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(253, 478);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // btnAddCircle
            // 
            this.btnAddCircle.Location = new System.Drawing.Point(93, 478);
            this.btnAddCircle.Name = "btnAddCircle";
            this.btnAddCircle.Size = new System.Drawing.Size(75, 23);
            this.btnAddCircle.TabIndex = 7;
            this.btnAddCircle.Text = "Add Circle";
            this.btnAddCircle.UseVisualStyleBackColor = true;
            this.btnAddCircle.Click += new System.EventHandler(this.BtnAddCircleClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 478);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
            // 
            // lstNodes
            // 
            this.lstNodes.FormattingEnabled = true;
            this.lstNodes.Location = new System.Drawing.Point(12, 12);
            this.lstNodes.Name = "lstNodes";
            this.lstNodes.Size = new System.Drawing.Size(694, 459);
            this.lstNodes.TabIndex = 5;
            // 
            // btnNodeProperties
            // 
            this.btnNodeProperties.Location = new System.Drawing.Point(612, 478);
            this.btnNodeProperties.Name = "btnNodeProperties";
            this.btnNodeProperties.Size = new System.Drawing.Size(94, 23);
            this.btnNodeProperties.TabIndex = 9;
            this.btnNodeProperties.Text = "Node Properties";
            this.btnNodeProperties.UseVisualStyleBackColor = true;
            this.btnNodeProperties.Click += new System.EventHandler(this.BtnNodePropertiesClick);
            // 
            // btnNode
            // 
            this.btnNode.Location = new System.Drawing.Point(174, 478);
            this.btnNode.Name = "btnNode";
            this.btnNode.Size = new System.Drawing.Size(75, 23);
            this.btnNode.TabIndex = 10;
            this.btnNode.Text = "Add Node";
            this.btnNode.UseVisualStyleBackColor = true;
            this.btnNode.Click += new System.EventHandler(this.BtnNodeClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(539, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(466, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // CircleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 512);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNode);
            this.Controls.Add(this.btnNodeProperties);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddCircle);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lstNodes);
            this.Name = "CircleForm";
            this.Text = "CircleForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddCircle;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListBox lstNodes;
        private System.Windows.Forms.Button btnNodeProperties;
        private System.Windows.Forms.Button btnNode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}