using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using OgmoEditor.Definitions.LayerDefinitions;

namespace OgmoEditor.ProjectEditors.LayerDefinitionEditors
{
    public partial class EntityLayerDefinitionEditor : UserControl
    {
        private EntityLayerDefinition def;

        public EntityLayerDefinitionEditor(EntityLayerDefinition def)
        {
            this.def = def;
            InitializeComponent();
            Location = new Point(206, 128);
            foreach (EntityType entityType in Enum.GetValues(typeof(EntityType)))
            {
                EntityTypeComboBox.Items.Add(entityType);
            }
            EntityTypeComboBox.SelectedItem = def.EntityType;
        }

        public EntityLayerDefinitionEditor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void EntityTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            def.EntityType = (EntityType) EntityTypeComboBox.SelectedItem;
        }
    }
}
