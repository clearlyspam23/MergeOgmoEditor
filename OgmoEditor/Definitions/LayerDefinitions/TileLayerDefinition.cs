﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OgmoEditor.ProjectEditors.LayerDefinitionEditors;
using OgmoEditor.LevelData.Layers;
using OgmoEditor.LevelData;
using System.Windows.Forms;

namespace OgmoEditor.Definitions.LayerDefinitions
{
    public class TileLayerDefinition : LayerDefinition
    {
        public enum TileExportMode { CSV, TrimmedCSV, XML, XMLCoords };
        public TileExportMode ExportMode;

        public TileLayerDefinition()
            : base()
        {
            Image = "tile.png";
            ExportMode = TileExportMode.CSV;
        }

        public override UserControl GetEditor()
        {
            return new TileLayerDefinitionEditor(this);
        }

        public override Layer GetInstance(Level level)
        {
            return new TileLayer(level, this);
        }

        public override LayerDefinition Clone()
        {
            TileLayerDefinition def = new TileLayerDefinition();
            def.Name = Name;
            def.Grid = Grid;
            def.ScrollFactor = ScrollFactor;
            def.ExportMode = ExportMode;
            return def;
        }
    }
}
