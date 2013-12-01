using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Drawing;
using OgmoEditor.LevelData.Layers;
using OgmoEditor.LevelEditors;
using System.Diagnostics;
using OgmoEditor.Windows;

namespace OgmoEditor.LevelData
{
    public class Level
    {
        //Running instance variables
        public Project Project { get; private set; }
        public string SavePath;
        private bool changed;
        public bool Salvaged { get; private set; }

        //Actual parameters to be edited/exported
        public Size Size;
        public List<Layer> Layers { get; private set; }
        public List<Value> Values { get; private set; }
        public Point CameraPosition;
        public Size CameraSize;
        public Point startLocation;

        public Level(Project project, string filename)
        {
            this.Project = project;

            if (File.Exists(filename))
            {
                //Load the level from XML
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filename, FileMode.Open);
                doc.Load(stream);
                stream.Close();

                LoadFromXML(doc);
                SavePath = filename;
            }
            else
            {
                //Initialize size
                Size = Project.LevelDefaultSize;
                CameraSize = Project.CameraSize;
                startLocation = new Point(64, 64);

                //Initialize layers
                Layers = new List<Layer>();
                foreach (var def in Project.LayerDefinitions)
                    Layers.Add(def.GetInstance(this));

                //Initialize values
                if (Project.LevelValueDefinitions.Count > 0)
                {
                    Values = new List<Value>();
                    foreach (var def in Project.LevelValueDefinitions)
                        Values.Add(new Value(def));
                }

                SavePath = "";
            }

            changed = false;
        }

        public Level(Project project, XmlDocument xml)
        {
            this.Project = project;
            initialize();

            LoadFromXML(xml);
            SavePath = "";
            changed = false;
        }

        public Level(Level level)
            : this(level.Project, level.GenerateXML())
        {

        }

        public void CloneFrom(Level level)
        {
            LoadFromXML(level.GenerateXML());
        }

        private void initialize()
        {
            
        }

        public bool Changed
        {
            get { return changed; }
            set
            {
                changed = value;
                int idx = Ogmo.Levels.FindIndex(l => l == this);
                if (idx >= 0) Ogmo.MainWindow.MasterTabControl.TabPages[idx].Text = Name;
            }
        }

        public string Name
        {
            get
            {
                string s;
                if (string.IsNullOrEmpty(SavePath))
                    s = Ogmo.NEW_LEVEL_NAME;
                else
                    s = Path.GetFileName(SavePath);
                if (Changed)
                    s += "*";
                return s;
            }
        }

        public string SaveName
        {
            get
            {
                string s;
                if (string.IsNullOrEmpty(SavePath))
                    s = Ogmo.NEW_LEVEL_NAME;
                else
                    s = Path.GetFileName(SavePath);
                return s;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return !HasBeenSaved && !Changed;
            }
        }

        public bool HasBeenSaved
        {
            get { return !string.IsNullOrEmpty(SavePath); }
        }

        public Rectangle Bounds
        {
            get { return new Rectangle(0, 0, Size.Width, Size.Height); }
        }

        public PointF Center
        {
            get { return new PointF(Size.Width / 2, Size.Height / 2); }
        }

        /*
         *  XML
         */
        public XmlDocument GenerateXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlAttribute a;

            XmlElement level = doc.CreateElement("level");
            doc.AppendChild(level);

            //Export the size  
            {
                a = doc.CreateAttribute("width");
                a.InnerText = Size.Width.ToString();
                level.Attributes.Append(a);

                a = doc.CreateAttribute("height");
                a.InnerText = Size.Height.ToString();
                level.Attributes.Append(a);
            }

            XmlElement start = doc.CreateElement("start");

            a = doc.CreateAttribute("x");
            a.InnerText = startLocation.X.ToString();
            start.Attributes.Append(a);

            a = doc.CreateAttribute("y");
            a.InnerText = startLocation.Y.ToString();
            start.Attributes.Append(a);

            level.AppendChild(start);

            XmlElement cam = doc.CreateElement("camera");

            a = doc.CreateAttribute("width");
            a.InnerText = CameraSize.Width.ToString();
            cam.Attributes.Append(a);

            a = doc.CreateAttribute("height");
            a.InnerText = CameraSize.Height.ToString();
            cam.Attributes.Append(a);

            //Export camera position
            if (Ogmo.Project.ExportCameraPosition)
            {

                a = doc.CreateAttribute("x");
                a.InnerText = CameraPosition.X.ToString();
                cam.Attributes.Append(a);

                a = doc.CreateAttribute("y");
                a.InnerText = CameraPosition.Y.ToString();
                cam.Attributes.Append(a);

            }

            level.AppendChild(cam);

            //Export the level values
            if (Values != null)
                foreach (var v in Values)
                    level.Attributes.Append(v.GetXML(doc));

            //Export the layers
            for (int i = 0; i < Layers.Count; i++)
                level.AppendChild(Layers[i].GetXML(doc));

            return doc;
        }

        private void LoadFromXML(XmlDocument xml)
        {
            bool cleanXML = true;
            XmlElement level = (XmlElement)xml.GetElementsByTagName("level")[0];

            {
                Size size = new Size();

                //Import the size               
                if (level.Attributes["width"] != null)
                    size.Width = Convert.ToInt32(level.Attributes["width"].InnerText);
                else
                    size.Width = Ogmo.Project.LevelDefaultSize.Width;
                if (level.Attributes["height"] != null)
                    size.Height = Convert.ToInt32(level.Attributes["height"].InnerText);
                else
                    size.Height = Ogmo.Project.LevelDefaultSize.Height;

                //Error check the width
                if (size.Width < Ogmo.Project.LevelMinimumSize.Width)
                {
                    size.Width = Ogmo.Project.LevelMinimumSize.Width;
                    cleanXML = false;
                }
                else if (size.Width > Ogmo.Project.LevelMaximumSize.Width)
                {
                    size.Width = Ogmo.Project.LevelMaximumSize.Width;
                    cleanXML = false;
                }

                //Error check the height
                if (size.Height < Ogmo.Project.LevelMinimumSize.Height)
                {
                    size.Height = Ogmo.Project.LevelMinimumSize.Height;
                    cleanXML = false;
                }
                else if (size.Height > Ogmo.Project.LevelMaximumSize.Height)
                {
                    size.Height = Ogmo.Project.LevelMaximumSize.Height;
                    cleanXML = false;
                }

                Size = size;
            }

            if (level.GetElementsByTagName("start").Count > 0)
            {
                XmlElement start = (XmlElement)level.GetElementsByTagName("start")[0];
                startLocation.X = Convert.ToInt32(start.Attributes["x"].InnerText);
                startLocation.Y = Convert.ToInt32(start.Attributes["y"].InnerText);
            }

            //Import the camera position
            if (level.GetElementsByTagName("camera").Count > 0)
            {
                XmlElement cam = (XmlElement)level.GetElementsByTagName("camera")[0];
                XmlAttribute a = null;
                a = cam.Attributes["width"];
                if(a!=null)
                    CameraSize.Width = Convert.ToInt32(a.InnerText);
                a = cam.Attributes["height"];
                if(a!=null)
                    CameraSize.Height = Convert.ToInt32(a.InnerText);
                a = cam.Attributes["x"];
                if(a!=null)
                    CameraPosition.X = Convert.ToInt32(a.InnerText);
                a = cam.Attributes["y"];
                if(a!=null)
                    CameraPosition.Y = Convert.ToInt32(a.InnerText);
            }

            if (CameraSize.Width < Ogmo.Project.LevelMinimumSize.Width)
                CameraSize.Width = Ogmo.Project.LevelMinimumSize.Width;
            else if (CameraSize.Width > Size.Width)
                CameraSize.Width = Size.Width;
            if (CameraSize.Height < Ogmo.Project.LevelMinimumSize.Height)
                CameraSize.Height = Ogmo.Project.LevelMinimumSize.Height;
            else if (CameraSize.Height > Size.Height)
                CameraSize.Height = Size.Height;

            //Import the level values
            //Initialize values
            if (Project.LevelValueDefinitions.Count > 0)
            {
                Values = new List<Value>();
                foreach (var def in Project.LevelValueDefinitions)
                    Values.Add(new Value(def));
                OgmoParse.ImportValues(Values, level);
            }

            //Import layers
            Layers = new List<Layer>();
            for (int i = 0; i < Project.LayerDefinitions.Count; i++)
            {
                Layer layer = Project.LayerDefinitions[i].GetInstance(this);
                Layers.Add(layer);
                if (level[Project.LayerDefinitions[i].Name] != null)
                    cleanXML = (layer.SetXML(level[Project.LayerDefinitions[i].Name]) && cleanXML);
            }

            Salvaged = !cleanXML;
        }

        public void EditProperties()
        {
            Ogmo.MainWindow.DisableEditing();
            LevelProperties lp = new LevelProperties(this);
            lp.Show(Ogmo.MainWindow);
        }

        #region Saving

        public bool Save()
        {
            //If it hasn't been saved before, do SaveAs instead
            if (!HasBeenSaved)
                return SaveAs();

            WriteTo(SavePath);
            return true;
        }

        public bool SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Project.SavedDirectory;
            dialog.RestoreDirectory = true;
            dialog.FileName = SaveName;
            dialog.DefaultExt = Ogmo.LEVEL_EXT;
            dialog.OverwritePrompt = true;
            dialog.Filter = Ogmo.LEVEL_FILTER;

            //Handle cancel
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return false;

            SavePath = dialog.FileName;
            WriteTo(dialog.FileName);

            return true;
        }

        public void WriteTo(string filename)
        {
            //Generate the XML and write it!            
            XmlDocument doc = GenerateXML();
            doc.Save(filename);

            Changed = false;
        }

        #endregion

        public bool run()
        {
            if (!Save())
                return false;
            PlayerEntityWindow window = new PlayerEntityWindow(Ogmo.Project);
            if (window.ShowDialog() == DialogResult.Cancel)
                return false;
            if (window.listBox.SelectedIndex != -1)
                Ogmo.Project.playerEntity = window.listBox.Items[window.listBox.SelectedIndex] as string;
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo();
            p.StartInfo.FileName = Ogmo.javaExe;
            p.StartInfo.Arguments = "-jar \"" + Ogmo.Project.FullJarFilename + "\" -level \"" + SavePath + "\"";
            if (!string.IsNullOrEmpty(Ogmo.Project.playerEntity))
                p.StartInfo.Arguments = p.StartInfo.Arguments + " -player \"" + Ogmo.Project.playerEntity + "\"";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            return true;
        }
    }
}
