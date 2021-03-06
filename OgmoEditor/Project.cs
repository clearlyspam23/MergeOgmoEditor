﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using OgmoEditor.Definitions.LayerDefinitions;
using System.Runtime.Serialization;
using System.Drawing;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Collections;
using OgmoEditor;
using OgmoEditor.Definitions.ValueDefinitions;
using OgmoEditor.Definitions;
using OgmoEditor.ProjectEditors;
using OgmoEditor.LevelEditors;
using System.Deployment.Application;
using System.Web.Script.Serialization;

namespace OgmoEditor
{
    [XmlRoot("project")]
    public class Project
    {
        public enum AngleExportMode { Radians, Degrees };

        //Serialized project properties
        public string OgmoVersion;
        public string Name;
        public OgmoColor BackgroundColor;
        public OgmoColor GridColor;
        public Size LevelDefaultSize;
        public Size LevelMinimumSize;
        public Size LevelMaximumSize;
        public string Filename;
        public AngleExportMode AngleMode;
        public bool CameraEnabled;
        public Size CameraSize;
        public bool ExportCameraPosition;

        public string Jarname;
        public string JarFoldername;
        public string FullJarFilename;

        public string playerEntity;

        //Definitions
        public List<ValueDefinition> LevelValueDefinitions;
        public List<LayerDefinition> LayerDefinitions;
        public List<Tileset> Tilesets;
        public SerializableDictionary<EntityType, List<EntityDefinition>> EntityDefinitions;

        //Events
        public event Ogmo.ProjectCallback OnPathChanged;

        public Project()
        {
            //Default project properties
            Name = Ogmo.NEW_PROJECT_NAME;
            BackgroundColor = OgmoColor.DefaultBackgroundColor;
            GridColor = OgmoColor.DefaultGridColor;
            Filename = "";
            Jarname = "";
            FullJarFilename = "";
            LevelDefaultSize = LevelMinimumSize = new Size(800, 600);
            LevelMaximumSize = new Size(100000, 100000);
            CameraEnabled = true;
            CameraSize = new Size(800, 600);
            ExportCameraPosition = false;

            //Definitions
            LevelValueDefinitions = new List<ValueDefinition>();
            LayerDefinitions = new List<LayerDefinition>();
            Tilesets = new List<Tileset>();
            EntityDefinitions = new SerializableDictionary<EntityType, List<EntityDefinition>>();
        }

        public void InitDefault()
        {
            //The default layer
            foreach (EntityType entityType in Enum.GetValues(typeof(EntityType)))
            {
                EntityLayerDefinition def = new EntityLayerDefinition();
                EntityDefinitions.Add(entityType, new List<EntityDefinition>());
                def.Name = entityType.ToString();
                def.Grid = new Size(16, 16);
                def.EntityType = entityType;
                LayerDefinitions.Add(def);
            }
            StringValueDefinition background = new StringValueDefinition();
            background.Name = "Background";
            background.Default = "darkroom";
            LevelValueDefinitions.Add(background);
        }

        public void CloneFrom(Project copy)
        {
            //Default project properties
            OgmoVersion = copy.OgmoVersion;
            Name = copy.Name;
            BackgroundColor = copy.BackgroundColor;
            GridColor = copy.GridColor;
            Filename = copy.Filename;
            LevelDefaultSize = copy.LevelDefaultSize;
            LevelMinimumSize = copy.LevelMinimumSize;
            LevelMaximumSize = copy.LevelMaximumSize;
            AngleMode = copy.AngleMode;
            CameraEnabled = copy.CameraEnabled;
            CameraSize = copy.CameraSize;
            ExportCameraPosition = copy.ExportCameraPosition;

            Jarname = copy.Jarname;
            FullJarFilename = copy.FullJarFilename;
            JarFoldername = copy.JarFoldername;

            //Definitions
            LevelValueDefinitions = new List<ValueDefinition>();
            foreach (var d in copy.LevelValueDefinitions)
                LevelValueDefinitions.Add(d.Clone());

            LayerDefinitions = new List<LayerDefinition>();   
            foreach (var d in copy.LayerDefinitions)
                LayerDefinitions.Add(d.Clone());
  
            Tilesets = new List<Tileset>();
            foreach (var d in copy.Tilesets)
                Tilesets.Add(d.Clone());

            EntityDefinitions = new SerializableDictionary<EntityType, List<EntityDefinition>>();
            foreach (EntityType entityType in Enum.GetValues(typeof(EntityType)))
            {
                List<EntityDefinition> defList = new List<EntityDefinition>();
                EntityDefinitions[entityType] = defList;
                foreach (var d in copy.EntityDefinitions[entityType])
                {
                    defList.Add(d.Clone());
                }
            }
        }

        public void LoadContent()
        {
            foreach (EntityType entityType in Enum.GetValues(typeof(EntityType)))
            {
                foreach (var def in EntityDefinitions[entityType])
                {
                    def.GenerateImages();
                }
            }

            foreach (var t in Tilesets)
                t.GenerateBitmap();
        }


        public string ErrorCheck()
        {
            string s = "";

            /*
             *  PROJECT SETTINGS
             */

            s += OgmoParse.CheckNonblankString(Name, "Project Name");
            s += OgmoParse.CheckPosSize(LevelDefaultSize, "Default Level");
            s += OgmoParse.CheckPosSize(LevelMinimumSize, "Minimum Level");
            s += OgmoParse.CheckPosSize(LevelMaximumSize, "Maximum Level");
            s += OgmoParse.CheckDefinitionList(LevelValueDefinitions, "Level");

            /*
             *  LAYER DEFINITIONS
             */

            //Must have at least 1 layer
            if (LayerDefinitions.Count == 0)
                s += OgmoParse.Error("No layers are defined");

            //Check for duplicates and blanks
            s += OgmoParse.CheckDefinitionList(LayerDefinitions);

            foreach (var l in LayerDefinitions)
            {
                //All grid sizes must be > 0
                if (l.Grid.Width <= 0)
                    s += OgmoParse.Error("Layer \"" + l.Name + "\" has a grid cell width <= 0");
                if (l.Grid.Height <= 0)
                    s += OgmoParse.Error("Layer \"" + l.Name + "\" has a grid cell height <= 0");
            }

            //Must have a tileset if you have a tile layer
            if (LayerDefinitions.Find(l => l is TileLayerDefinition) != null && Tilesets.Count == 0)
                s += OgmoParse.Error("Tile layer(s) are defined, but no tilesets are defined");

            //Must have an entity if you have an entity layer
            if (LayerDefinitions.Find(l => l is EntityLayerDefinition) != null && EntityDefinitions.Count == 0)
                s += OgmoParse.Error("Object layer(s) are defined, but no objects are defined");

            /*
             *  TILESETS
             */

            //Check for duplicates and blanks
            s += OgmoParse.CheckDefinitionList(Tilesets);

            foreach (var t in Tilesets)
            {
                //File must exist
                s += OgmoParse.CheckPath(t.FilePath, SavedDirectory, "Tileset \"" + t.Name + "\" image file");
            }

            /*
             *  ENTITIES
             */

            //Check for duplicates and blanks
            foreach (EntityType entityType in Enum.GetValues(typeof(EntityType)))
            {
                s += OgmoParse.CheckDefinitionList(EntityDefinitions[entityType]);

                foreach (var o in EntityDefinitions[entityType])
                {
                    //Check Entity values for reserved words
                    s += OgmoParse.CheckEntityValues(o, o.ValueDefinitions);

                    //Image file must exist if it is using an image file to draw
                    //if (o.ImageDefinition.DrawMode == EntityImageDefinition.DrawModes.Image)
                    //    s += OgmoParse.CheckPath(o.ImageDefinition.ImagePath, SavedDirectory, "Object \"" + o.Name + "\" image file");
                }
            }
            /*
             *  VALUES
             */

            s += OgmoParse.CheckLevelValues(LevelValueDefinitions);

            return s;
        }

        [XmlIgnore]
        public string SavedDirectory
        {
            get
            {
                string dir = Filename;
                if (dir == "")
                    return "";

                string filename = Path.GetFileName(dir);
                return dir.Remove(dir.IndexOf(filename) - 1);
            }
        }

        public string GetPath(string path)
        {
            return SavedDirectory + Path.DirectorySeparatorChar + path;
        }

        public string ExportAngle(float angle)
        {
            if (AngleMode == AngleExportMode.Radians)
                return (angle * Util.DEGTORAD).ToString();
            else
                return angle.ToString();
        }

        public float ImportAngle(string angle)
        {
            if (AngleMode == AngleExportMode.Radians)
                return Convert.ToSingle(angle) * Util.RADTODEG;
            else
                return Convert.ToSingle(angle);
        }

        /*
         *  Saving the project file
         */
        public void Save()
        {
            //If it hasn't been saved yet, go to SaveAs
            if (Filename == "")
            {
                if (!SaveAs())
                    return;
            }

            writeTo(Filename);
        }

        public bool SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (Filename == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = SavedDirectory;
            dialog.RestoreDirectory = true;
            dialog.FileName = Name;
            dialog.DefaultExt = Ogmo.PROJECT_EXT;
            dialog.OverwritePrompt = true;
            dialog.Filter = Ogmo.PROJECT_FILTER;

            //Show dialog, handle cancel
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return false;

            Filename = dialog.FileName;
            if (OnPathChanged != null)
                OnPathChanged(this);

            return true;
        }

        private void writeTo(string filename)
        {
            //Set the current Ogmo Editor version in the project file
            if (ApplicationDeployment.IsNetworkDeployed)
                OgmoVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            else
                OgmoVersion = new Version(1, 0).ToString();

            XmlSerializer xs = new XmlSerializer(typeof(Project));
            Stream stream = new FileStream(filename, FileMode.Create);
            xs.Serialize(stream, this);
            stream.Close();
        }

        public void setJar(string fullpathname)
        {
            FullJarFilename = fullpathname;
            int lastIndex = fullpathname.LastIndexOf('\\')+1;
            if (lastIndex > fullpathname.Length)
                lastIndex = fullpathname.Length;
            Jarname = fullpathname.Substring(lastIndex);
            JarFoldername = fullpathname.Substring(0, Math.Max(0, lastIndex-1));
            Ogmo.MainWindow.checkEnableRun();
            if (Ogmo.isJarValid(FullJarFilename))
            {
                Ogmo.loadAll(this, JarFoldername);
            }
        }

    }
}
