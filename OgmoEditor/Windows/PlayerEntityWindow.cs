using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OgmoEditor.Windows
{
    public partial class PlayerEntityWindow : Form
    {
        public PlayerEntityWindow(Project project)
        {
            InitializeComponent();
            foreach (var o in project.EntityDefinitions[EntityType.Entity])
                listBox.Items.Add(o.Name);
            if(project.playerEntity!=null)
                listBox.SelectedIndex = listBox.Items.IndexOf(project.playerEntity);
        }

        private void PlayerEntityWindow_Load(object sender, EventArgs e)
        {

        }

        private void selectButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                selectButton.Enabled = false;
            else
            {
                selectButton.Enabled = true;
            }
        }
    }
}
