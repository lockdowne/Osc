using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using oEngine.Common;
using System.Xml.Linq;
using System.Xml;
using oEditor.Common;
using oEditor.Aggregators;

namespace oEditor.Repositories
{
    public class TilemapRepository : IRepository<Tilemap>
    {
        public void CheckRepository()
        {
            // TODO: Check directory/zip file/

            if(!File.Exists(Consts.Repositories.Tilemaps))
            {
                XDocument file = new XDocument(new XElement("Root"));
                file.Save(Consts.Repositories.Tilemaps);
            }
        }

        public IEnumerable<Tilemap> FindEntities(Func<Tilemap, bool> predicate)
        {          
            CheckRepository();

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
          
            CheckRepository();

            XDocument xml = XDocument.Load(Consts.Repositories.Tilemaps);

            XElement toReplace = null;

            foreach (XElement element in xml.Descendants().Where(e => e.Name.LocalName == Consts.Nodes.Tilemap))
            {
                if (element.Element("ID").Value == entity.ID.ToString())
                {
                    toReplace = element;
                    break;
                }
            }

            if (toReplace == null)
                xml.Element("Root").Add(entity.ToXElement());
            else
                toReplace.ReplaceWith(entity.ToXElement());

            xml.Save(Consts.Repositories.Tilemaps);           
        }

        public void RemoveEntity(Tilemap entity)
        {          
            CheckRepository();

            XDocument xml = XDocument.Load(Consts.Repositories.Tilemaps);

            XElement toRemove = null;

            foreach (XElement element in xml.Descendants().Where(e => e.Name.LocalName == Consts.Nodes.Tilemap))
            {
                if (element.Element("ID").Value == entity.ID.ToString())
                {
                    toRemove = element;
                    break;
                }
            }

            // Entity wasn't found
            if (toRemove == null)
                return;

            toRemove.Remove();

            xml.Save(Consts.Repositories.Tilemaps);          
        }
    }
}
