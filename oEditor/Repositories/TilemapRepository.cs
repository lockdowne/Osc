using oEngine.Common;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using oEditor.Common;

namespace oEditor.Repositories
{
    public class TilemapRepository : IRepository<Tilemap>
    {
        public event Action RepositoryChanged;
        public event Action<Tilemap> OpenEntity;

        public void CheckPath()
        {
            if (!File.Exists(Consts.Repositories.Tilemaps))
            {
                XDocument file = new XDocument(new XElement("Root"));
                file.Save(Consts.Repositories.Tilemaps);
            }
        }

        public IEnumerable<Tilemap> FindEntities(Func<Tilemap, bool> predicate)
        {
            CheckPath();

            // If file gets too large then we should use xmlreader instead of loading it all in memory
            XDocument xml = XDocument.Load(Consts.Repositories.Tilemaps);

            foreach (XElement element in xml.Descendants().Where(e => e.Name.LocalName == Consts.Nodes.Tilemap))
            {
                Tilemap tilemap = element.DeserializeXElement<Tilemap>();

                if (predicate(tilemap))
                    yield return tilemap;
            }
        }

        public void SaveEntity(Tilemap entity)
        {
            // Check for path existence
            CheckPath();

            // Load file
            XDocument xml = XDocument.Load(Consts.Repositories.Tilemaps);

            // Check if entity already exists and remove old copies
        
            List<XElement> toRemove = new List<XElement>();

            foreach (XElement element in xml.Descendants().Where(e => e.Name.LocalName == Consts.Nodes.Tilemap))
            {
                Tilemap tilemap = element.FromXElement<Tilemap>();

                if (tilemap.ID == entity.ID)
                    toRemove.Add(element);//.Remove();
            }

            toRemove.ForEach(element => element.Remove());
          
            // Add entity to root
            xml.Element("Root").Add(entity.ToXElement());

            // Save new file
            xml.Save(Consts.Repositories.Tilemaps);

            OnRepositoryChanged();
            
        }

        public void RemoveEntities(Func<Tilemap, bool> predicate)
        {
            CheckPath();

            XDocument xml = XDocument.Load(Consts.Repositories.Tilemaps);

            List<XElement> toRemove = new List<XElement>();

            foreach(XElement element in xml.Descendants().Where(e => e.Name.LocalName == Consts.Nodes.Tilemap))
            {
                Tilemap tilemap = element.FromXElement<Tilemap>();

                if (predicate(tilemap))
                    toRemove.Add(element);//.Remove();
            }

            toRemove.ForEach(element => element.Remove());

            xml.Save(Consts.Repositories.Tilemaps);

            OnRepositoryChanged();
        }

        public void RemoveEntity(Tilemap entity)
        {
            CheckPath();

            RemoveEntities(scene => scene.ID == entity.ID);
        }

        public void OnOpenEntity(Tilemap obj)
        {
            if (obj == null)
                return;

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
