using oEngine.Common;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oEditor.Repositories
{
    public class SceneRepository : IRepository<Scene>
    {
        public event Action RepositoryChanged;
        public event Action<Scene> OpenEntity;

        public void CheckPath()
        {
            if (!File.Exists(Consts.Repositories.Scenes))
            {
                XDocument file = new XDocument(new XElement("Root"));
                file.Save(Consts.Repositories.Scenes);
            }
        }

        public IEnumerable<Scene> FindEntities(Func<Scene, bool> predicate)
        {
            CheckPath();

            // If file gets too large then we should use xmlreader instead of loading it all in memory
            XDocument xml = XDocument.Load(Consts.Repositories.Scenes);

            foreach (XElement element in xml.Descendants().Where(e => e.Name.LocalName == Consts.Nodes.Scene))
            {
                Scene scene = element.FromXElement<Scene>();

                if (predicate(scene))
                    yield return scene;
            }

            OnRepositoryChanged();
        }

        public void SaveEntity(Scene entity)
        {
            // Check for path existence
            CheckPath();

            // Load file
            XDocument xml = XDocument.Load(Consts.Repositories.Scenes);

            // Check if entity already exists and remove old copies
            RemoveEntities(scene => scene.ID == entity.ID);
          
            // Add entity to root
            xml.Element("Root").Add(entity.ToXElement());

            // Save new file
            xml.Save(Consts.Repositories.Scenes);

            OnRepositoryChanged();
            
        }

        public void RemoveEntities(Func<Scene, bool> predicate)
        {
            CheckPath();

            XDocument xml = XDocument.Load(Consts.Repositories.Scenes);

            List<XElement> toRemove = new List<XElement>();

            foreach(XElement element in xml.Descendants().Where(e => e.Name.LocalName == Consts.Nodes.Scene))
            {
                Scene scene = element.FromXElement<Scene>();

                if (predicate(scene))
                    toRemove.Add(element);//.Remove();
            }

            toRemove.ForEach(element => element.Remove());

            xml.Save(Consts.Repositories.Scenes);

            OnRepositoryChanged();
        }

        public void RemoveEntity(Scene entity)
        {
            CheckPath();

            RemoveEntities(scene => scene.ID == entity.ID);
        }

        public void OnOpenEntity(Scene obj)
        {
            if (OpenEntity != null)
                OpenEntity(obj);
        }

        private void OnRepositoryChanged()
        {
            if (RepositoryChanged != null)
                RepositoryChanged();
        }
    }
}
