using oEngine.Common;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oEditor.Common;

namespace oEditor.Repositories
{
    public class TilemapRepository : IRepository<Tilemap>
    {
        private List<Tilemap> entities = new List<Tilemap>();

        public TilemapRepository()
        {
            try
            {
                if (IOMethods.CreateDirectory(Consts.Repositories.Tilemaps))
                {
                    if (File.Exists(Consts.Repositories.Tilemaps))
                    {
                        entities = XnaSerializer.XnaDeserialize<List<Tilemap>>(Consts.Repositories.Tilemaps); //Serializer.Deserialize<List<Tilemap>>(Consts.Repositories.Tilemaps);
                    }
                }
            }
            catch(Exception exception)
            {
                
            }
        }

        public Tilemap Find(Predicate<Tilemap> predicate)
        {
            return entities.Find(predicate);
        }

        public IEnumerable<Tilemap> FindAll(Predicate<Tilemap> predicate)
        {
            return entities.FindAll(predicate);
        }

        public IEnumerable<Tilemap> All()
        {
            return entities;
        }

        public bool Any(Func<Tilemap, bool> predicate)
        {
            return entities.Any(predicate);
        }

        public void Add(Tilemap entity)
        {
            entities.Add(entity);
        }

        public void Remove(Tilemap entity)
        {
            entities.Remove(entity);
        }

        public void Save()
        {
            if (IOMethods.CreateDirectory(Consts.Repositories.Tilemaps))
            {
                Serializer.Serialize(entities, Consts.Repositories.Tilemaps);                
            }
        }

        public async Task SaveAsync()
        {
            if (IOMethods.CreateDirectory(Consts.Repositories.Tilemaps))
            {
                await Serializer.SerializeAsync(entities, Consts.Repositories.Tilemaps);
            }
        }
    }
}
