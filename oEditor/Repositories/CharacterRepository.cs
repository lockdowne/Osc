using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oEngine.Entities;
using oEngine.Common;
using System.Xml.Linq;
using System.IO;

namespace oEditor.Repositories
{
    public class CharacterRepository : IRepository<Character>
    {
        public void CheckPath()
        {
            if (!File.Exists(Consts.Repositories.Characters))
            {
                XDocument file = new XDocument(new XElement("Root"));
                file.Save(Consts.Repositories.Characters);
            }
        }

        public IEnumerable<Character> FindEntities(Func<Character, bool> predicate)
        {
            CheckPath();

            XDocument xml = XDocument.Load(Consts.Repositories.Characters);

            foreach(XElement element in xml.Descendants().Where(node => node.Name.LocalName == Consts.Nodes.Character))
            {
                Character entity = element.FromXElement<Character>();

                if (predicate(entity))
                    yield return entity;
            }
        }

        public void SaveEntity(Character entity)
        {
            CheckPath();

            XDocument xml = XDocument.Load(Consts.Repositories.Characters);

            // First check if scene already exists

            // Iterate through elements finding matching scene id
            foreach (XElement element in xml.Descendants().Where(node => node.Name.LocalName == Consts.Nodes.Character))
            {
                Character character = element.FromXElement<Character>();

                if (character.ID == entity.ID)
                {
                    element.Remove();
                }
            }

            xml.Add(entity.ToXElement());
            xml.Save(Consts.Repositories.Characters);
        }

        public void RemoveEntities(Func<Character, bool> predicate)
        {
            CheckPath();

            XDocument xml = XDocument.Load(Consts.Repositories.Characters);

            List<XElement> toRemove = new List<XElement>();

            foreach (XElement element in xml.Descendants().Where(e => e.Name.LocalName == Consts.Nodes.Character))
            {
            }

            toRemove.ForEach(element => element.Remove());

            xml.Save(Consts.Repositories.Characters);
        }

        public void RemoveEntity(Character entity)
        {
            
        }

        public event Action RepositoryChanged;


        public event Action<Character> OpenEntity;


        public void OnOpenEntity(Character obj)
        {
            throw new NotImplementedException();
        }
    }
}
