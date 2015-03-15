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
            if (!File.Exists(Consts.OscCharacterRepositoryPath))
            {
                XDocument file = new XDocument(new XElement("Root"));
                file.Save(Consts.OscSceneRepositoryPath);
            }
        }

        public IEnumerable<Character> FindEntities(Func<Character, bool> predicate)
        {
            CheckPath();

            XDocument xml = XDocument.Load(Consts.OscCharacterRepositoryPath);

            foreach(XElement element in xml.Descendants(Consts.CharacterNode))
            {
                Character entity = element.FromXElement<Character>();

                if (predicate(entity))
                    yield return entity;
            }
        }

        public void SaveEntity(Character entity)
        {
            CheckPath();

            XDocument xml = XDocument.Load(Consts.OscCharacterRepositoryPath);

            // First check if scene already exists

            // Iterate through elements finding matching scene id
            foreach (XElement element in xml.Descendants(Consts.CharacterNode))
            {
                Character character = element.FromXElement<Character>();

                if (character.ID == entity.ID)
                {
                    element.Remove();
                }
            }

            xml.Add(entity.ToXElement());
            xml.Save(Consts.OscSceneRepositoryPath);
        }

        public void RemoveEntities(Func<Character, bool> predicate)
        {
            
        }

        public void RemoveEntity(Character entity)
        {
            
        }
    }
}
