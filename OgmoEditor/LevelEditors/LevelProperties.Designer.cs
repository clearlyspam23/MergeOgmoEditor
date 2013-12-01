namespace OgmoEditor.LevelEditors
{
    partial class LevelProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelProperties));
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sizeXTextBox = new System.Windows.Forms.TextBox();
            this.sizeYTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.minSizeLabel = new System.Windows.Forms.Label();
            this.maxSizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cameraWidthBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cameraHeightBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.startXBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.startYBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(91, 161);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(154, 38);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(251, 161);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 38);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // sizeXTextBox
            // 
            this.sizeXTextBox.Location = new System.Drawing.Point(128, 20);
            this.sizeXTextBox.Name = "sizeXTextBox";
            this.sizeXTextBox.Size = new System.Drawing.Size(76, 20);
            this.sizeXTextBox.TabIndex = 6;
            // 
            // sizeYTextBox
            // 
            this.sizeYTextBox.Location = new System.Drawing.Point(228, 20);
            this.sizeYTextBox.Name = "sizeYTextBox";
            this.sizeYTextBox.Size = new System.Drawing.Size(76, 20);
            this.sizeYTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Level Size";
            // 
            // minSizeLabel
            // 
            this.minSizeLabel.AutoSize = true;
            this.minSizeLabel.Location = new System.Drawing.Point(46, 49);
            this.minSizeLabel.Name = "minSizeLabel";
            this.minSizeLabel.Size = new System.Drawing.Size(23, 13);
            this.minSizeLabel.TabIndex = 10;
            this.minSizeLabel.Text = "min";
            this.minSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxSizeLabel
            // 
            this.maxSizeLabel.AutoSize = true;
            this.maxSizeLabel.Location = new System.Drawing.Point(46, 73);
            this.maxSizeLabel.Name = "maxSizeLabel";
            this.maxSizeLabel.Size = new System.Drawing.Size(26, 13);
            this.maxSizeLabel.TabIndex = 11;
            this.maxSizeLabel.Text = "max";
            this.maxSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Camera Size";
            // 
            // cameraWidthBox
            // 
            this.cameraWidthBox.Location = new System.Drawing.Point(128, 94);
            this.cameraWidthBox.Name = "cameraWidthBox";
            this.cameraWidthBox.Size = new System.Drawing.Size(76, 20);
            this.cameraWidthBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "x";
            // 
            // cameraHeightBox
            // 
            this.cameraHeightBox.Location = new System.Drawing.Point(228, 94);
            this.cameraHeightBox.Name = "cameraHeightBox";
            this.cameraHeightBox.Size = new System.Drawing.Size(76, 20);
            this.cameraHeightBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Start Position";
            // 
            // startXBox
            // 
            this.startXBox.Location = new System.Drawing.Point(128, 124);
            this.startXBox.Name = "startXBox";
            this.startXBox.Size = new System.Drawing.Size(76, 20);
            this.startXBox.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "x";
            // 
            // startYBox
            // 
            this.startYBox.Location = new System.Drawing.Point(228, 124);
            this.startYBox.Name = "startYBox";
            this.startYBox.Size = new System.Drawing.Size(76, 20);
            this.startYBox.TabIndex = 19;
            // 
            // LevelProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(329, 211);
            this.Controls.Add(this.startYBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.startXBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cameraHeightBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cameraWidthBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxSizeLabel);
            this.Controls.Add(this.minSizeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeYTextBox);
            this.Controls.Add(this.sizeXTextBox);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LevelProperties";
            this.Text = "Level Properties";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevelProperties_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox sizeXTextBox;
        private System.Windows.Forms.TextBox sizeYTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label minSizeLabel;
        private System.Windows.Forms.Label maxSizeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cameraWidthBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cameraHeightBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox startXBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox startYBox;
    }
}