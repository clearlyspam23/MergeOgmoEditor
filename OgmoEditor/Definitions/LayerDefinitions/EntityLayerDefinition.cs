using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OgmoEditor;
using OgmoEditor.ProjectEditors.LayerDefinitionEditors;
using OgmoEditor.LevelData.Layers;
using OgmoEditor.LevelData;
using System.Windows.Forms;

namespace OgmoEditor.Definitions.LayerDefinitions
{
    public class EntityLayerDefinition : LayerDefinition
    {
        public EntityType EntityType;

        public EntityLayerDefinition()
            : base()
        {
            Image = "entity.png";
            EntityType = EntityType.Entity;
        }

        public override UserControl GetEditor()
        {
            return new EntityLayerDefinitionEditor(this);
        }

        public override Layer GetInstance(Level level)
        {
            return new EntityLayer(level, this);
        }

        public override LayerDefinition Clone()
        {
            EntityLayerDefinition def = new EntityLayerDefinition();
            def.EntityType = EntityType;
            def.Name = Name;
            def.Grid = Grid;
            def.ScrollFactor = ScrollFactor;
            return def;
        }
    }
}
