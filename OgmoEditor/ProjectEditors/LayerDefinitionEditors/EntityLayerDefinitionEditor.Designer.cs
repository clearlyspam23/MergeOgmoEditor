namespace OgmoEditor.ProjectEditors.LayerDefinitionEditors
{
    partial class EntityLayerDefinitionEditor
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.EntityTypeLabel = new System.Windows.Forms.Label();
            this.EntityTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 358);
            this.panel1.TabIndex = 0;
            // 
            // EntityTypeLabel
            // 
            this.EntityTypeLabel.AutoSize = true;
            this.EntityTypeLabel.Location = new System.Drawing.Point(21, 15);
            this.EntityTypeLabel.Name = "EntityTypeLabel";
            this.EntityTypeLabel.Size = new System.Drawing.Size(60, 13);
            this.EntityTypeLabel.TabIndex = 4;
            this.EntityTypeLabel.Text = "Entity Type";
            // 
            // EntityTypeComboBox
            // 
            this.EntityTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.EntityTypeComboBox.FormattingEnabled = true;
            this.EntityTypeComboBox.Location = new System.Drawing.Point(87, 12);
            this.EntityTypeComboBox.Name = "EntityTypeComboBox";
            this.EntityTypeComboBox.Size = new System.Drawing.Size(121, 150);
            this.EntityTypeComboBox.TabIndex = 0;
            this.EntityTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.EntityTypeComboBox_SelectedIndexChanged);
            // 
            // EntityLayerDefinitionEditor
            // 
            this.Controls.Add(this.EntityTypeLabel);
            this.Controls.Add(this.EntityTypeComboBox);
            this.Name = "EntityLayerDefinitionEditor";
            this.Size = new System.Drawing.Size(353, 358);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label EntityTypeLabel;
        private System.Windows.Forms.ComboBox EntityTypeComboBox;


    }
}
