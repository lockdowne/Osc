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
        public void CheckPath()
        {
            if (!File.Exists(Consts.OscSceneRepositoryPath))
            {
                XDocument file = new XDocument(new XElement("Root"));
                file.Save(Consts.OscSceneRepositoryPath);
            }
        }

        public IEnumerable<Scene> FindEntities(Func<Scene, bool> predicate)
        {
            CheckPath();

            // If file gets too large then we should use xmlreader instead of loading it all in memory
            XDocument xml = XDocument.Load(Consts.OscSceneRepositoryPath);

            foreach (XElement element in xml.Descendants(Consts.SceneNode))
            {
                Scene scene = element.FromXElement<Scene>();

                if (predicate(scene))
                    yield return scene;
            }
        }

        public void SaveEntity(Scene entity)
        {
            // Check if path exists if not create file
            CheckPath();

            // First check if scene already exists
            XDocument xml = XDocument.Load(Consts.OscSceneRepositoryPath);

            // Iterate through elements finding matching scene id
            foreach (XElement element in xml.Descendants(Consts.SceneNode))
            {
                Scene fileScene = element.FromXElement<Scene>();

                if (fileScene.ID == entity.ID)
                {
                    element.Remove();
                }
            }

            xml.Add(entity.ToXElement());

            xml.Save(Consts.OscSceneRepositoryPath);
        }

        public void RemoveEntities(Func<Scene, bool> predicate)
        {
            
        }

        public void RemoveEntity(Scene entity)
        {
            
        }
    }
}
