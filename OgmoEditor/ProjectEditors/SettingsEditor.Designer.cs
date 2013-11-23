using OgmoEditor.ProjectEditors.ValueDefinitionEditors;
namespace OgmoEditor.ProjectEditors
{
    partial class SettingsEditor
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
            this.defaultHeightTextBox = new System.Windows.Forms.TextBox();
            this.defaultWidthTextBox = new System.Windows.Forms.TextBox();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.angleModeComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cameraHeightTextBox = new System.Windows.Forms.TextBox();
            this.cameraWidthTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.exportCameraPositionCheckbox = new System.Windows.Forms.CheckBox();
            this.jarTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gridColorChooser = new OgmoEditor.ColorChooser();
            this.backgroundColorChooser = new OgmoEditor.ColorChooser();
            this.valuesEditor = new OgmoEditor.ProjectEditors.ValueDefinitionEditors.ValueDefinitionsEditor();
            this.colorChooser1 = new OgmoEditor.ColorChooser();
            this.SuspendLayout();
            // 
            // defaultHeightTextBox
            // 
            this.defaultHeightTextBox.Location = new System.Drawing.Point(207, 165);
            this.defaultHeightTextBox.Name = "defaultHeightTextBox";
            this.defaultHeightTextBox.Size = new System.Drawing.Size(62, 20);
            this.defaultHeightTextBox.TabIndex = 5;
            this.defaultHeightTextBox.Validated += new System.EventHandler(this.defaultWidthTextBox_Validated);
            // 
            // defaultWidthTextBox
            // 
            this.defaultWidthTextBox.Location = new System.Drawing.Point(121, 165);
            this.defaultWidthTextBox.Name = "defaultWidthTextBox";
            this.defaultWidthTextBox.Size = new System.Drawing.Size(62, 20);
            this.defaultWidthTextBox.TabIndex = 4;
            this.defaultWidthTextBox.Validated += new System.EventHandler(this.defaultWidthTextBox_Validated);
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(131, 13);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(197, 20);
            this.projectNameTextBox.TabIndex = 0;
            this.projectNameTextBox.Validated += new System.EventHandler(this.projectNameTextBox_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Default";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Level Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Project Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Background Color";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Grid Color";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Angle Export";
            // 
            // angleModeComboBox
            // 
            this.angleModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.angleModeComboBox.FormattingEnabled = true;
            this.angleModeComboBox.Items.AddRange(new object[] {
            "Radians",
            "Degrees"});
            this.angleModeComboBox.Location = new System.Drawing.Point(131, 103);
            this.angleModeComboBox.Name = "angleModeComboBox";
            this.angleModeComboBox.Size = new System.Drawing.Size(80, 21);
            this.angleModeComboBox.TabIndex = 3;
            this.angleModeComboBox.SelectionChangeCommitted += new System.EventHandler(this.angleModeComboBox_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(347, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Camera";
            // 
            // cameraHeightTextBox
            // 
            this.cameraHeightTextBox.Location = new System.Drawing.Point(466, 168);
            this.cameraHeightTextBox.Name = "cameraHeightTextBox";
            this.cameraHeightTextBox.Size = new System.Drawing.Size(62, 20);
            this.cameraHeightTextBox.TabIndex = 12;
            this.cameraHeightTextBox.Validated += new System.EventHandler(this.cameraWidthTextBox_Validated);
            // 
            // cameraWidthTextBox
            // 
            this.cameraWidthTextBox.Location = new System.Drawing.Point(380, 168);
            this.cameraWidthTextBox.Name = "cameraWidthTextBox";
            this.cameraWidthTextBox.Size = new System.Drawing.Size(62, 20);
            this.cameraWidthTextBox.TabIndex = 11;
            this.cameraWidthTextBox.Validated += new System.EventHandler(this.cameraWidthTextBox_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(347, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "Size";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(448, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "x";
            // 
            // exportCameraPositionCheckbox
            // 
            this.exportCameraPositionCheckbox.AutoSize = true;
            this.exportCameraPositionCheckbox.Location = new System.Drawing.Point(368, 194);
            this.exportCameraPositionCheckbox.Name = "exportCameraPositionCheckbox";
            this.exportCameraPositionCheckbox.Size = new System.Drawing.Size(135, 17);
            this.exportCameraPositionCheckbox.TabIndex = 47;
            this.exportCameraPositionCheckbox.Text = "Export Camera Position";
            this.exportCameraPositionCheckbox.UseVisualStyleBackColor = true;
            this.exportCameraPositionCheckbox.CheckedChanged += new System.EventHandler(this.exportCameraPositionCheckbox_CheckedChanged);
            // 
            // jarTextBox
            // 
            this.jarTextBox.Location = new System.Drawing.Point(57, 440);
            this.jarTextBox.Name = "jarTextBox";
            this.jarTextBox.Size = new System.Drawing.Size(311, 20);
            this.jarTextBox.TabIndex = 48;
            this.jarTextBox.Validated += new System.EventHandler(this.jarTextBox_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Jar Location";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridColorChooser
            // 
            this.gridColorChooser.Location = new System.Drawing.Point(127, 68);
            this.gridColorChooser.Name = "gridColorChooser";
            this.gridColorChooser.Size = new System.Drawing.Size(108, 28);
            this.gridColorChooser.TabIndex = 2;
            this.gridColorChooser.ColorChanged += new OgmoEditor.ColorChooser.ColorCallback(this.gridColorChooser_ColorChanged);
            // 
            // backgroundColorChooser
            // 
            this.backgroundColorChooser.Location = new System.Drawing.Point(127, 39);
            this.backgroundColorChooser.Name = "backgroundColorChooser";
            this.backgroundColorChooser.Size = new System.Drawing.Size(108, 28);
            this.backgroundColorChooser.TabIndex = 1;
            this.backgroundColorChooser.ColorChanged += new OgmoEditor.ColorChooser.ColorCallback(this.backgroundColorChooser_ColorChanged);
            // 
            // valuesEditor
            // 
            this.valuesEditor.Location = new System.Drawing.Point(57, 217);
            this.valuesEditor.Name = "valuesEditor";
            this.valuesEditor.Size = new System.Drawing.Size(341, 191);
            this.valuesEditor.TabIndex = 13;
            this.valuesEditor.Title = "Level Values";
            // 
            // colorChooser1
            // 
            this.colorChooser1.Location = new System.Drawing.Point(127, 57);
            this.colorChooser1.Name = "colorChooser1";
            this.colorChooser1.Size = new System.Drawing.Size(108, 28);
            this.colorChooser1.TabIndex = 36;
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.jarTextBox);
            this.Controls.Add(this.exportCameraPositionCheckbox);
            this.Controls.Add(this.cameraHeightTextBox);
            this.Controls.Add(this.cameraWidthTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.angleModeComboBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gridColorChooser);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.backgroundColorChooser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.valuesEditor);
            this.Controls.Add(this.defaultHeightTextBox);
            this.Controls.Add(this.defaultWidthTextBox);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsEditor";
            this.Size = new System.Drawing.Size(573, 490);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox defaultHeightTextBox;
        private System.Windows.Forms.TextBox defaultWidthTextBox;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ValueDefinitionsEditor valuesEditor;
        private System.Windows.Forms.Label label9;
        private ColorChooser backgroundColorChooser;
        private ColorChooser colorChooser1;
        private System.Windows.Forms.Label label10;
        private ColorChooser gridColorChooser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox angleModeComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox cameraHeightTextBox;
        private System.Windows.Forms.TextBox cameraWidthTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox exportCameraPositionCheckbox;
        private System.Windows.Forms.TextBox jarTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}
