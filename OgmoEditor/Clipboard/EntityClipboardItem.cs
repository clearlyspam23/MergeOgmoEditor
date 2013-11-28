using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OgmoEditor.LevelData.Layers;
using OgmoEditor.LevelEditors;
using OgmoEditor.LevelEditors.Actions.EntityActions;

namespace OgmoEditor.Clipboard
{
    public class EntityClipboardItem : ClipboardItem
    {
        public List<Entity> entities;

        public EntityClipboardItem(List<Entity> entities)
            : base()
        {
            this.entities = new List<Entity>();
            foreach (var e in entities)
                this.entities.Add(e.Clone());
        }

        public override bool CanPaste(Layer layer)
        {
            if (layer is EntityLayer)
            {
                EntityLayer e = (EntityLayer)layer;
                if (entities.Count() > 0)
                {
                    return entities[0].Definition.EntityType == e.Definition.EntityType;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override void Paste(LevelEditor editor, Layer layer)
        {
            List<Entity> created = new List<Entity>();

            editor.StartBatch();
            foreach (var e in entities)
            {
                Entity ee = e.Clone();
                created.Add(ee);
                editor.BatchPerform(new EntityAddAction(layer as EntityLayer, ee));
            }
            editor.EndBatch();

            Ogmo.EntitySelectionWindow.SetSelection(created);
        }
    }
}
