using Osc.Rotch.Editor.Common;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Engine.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Editor.Repositories
{
    public class TilemapAssetRepository : IRepository<TilemapAsset>
    {
        private List<TilemapAsset> entities = new List<TilemapAsset>();

        public TilemapAssetRepository()
        {
            try
            {
                if (IOMethods.CreateDirectory(Consts.Repositories.Tilemaps))
                {
                    if (File.Exists(Consts.Repositories.Tilemaps))
                    {
                        entities = XnaSerializer.XnaDeserialize<List<TilemapAsset>>(Consts.Repositories.TilemapAssets); //Serializer.Deserialize<List<Tilemap>>(Consts.Repositories.Tilemaps);
                    }
                }
            }
            catch (Exception exception)
            {

            }
        }

        public TilemapAsset Find(Predicate<TilemapAsset> predicate)
        {
            return entities.Find(predicate);
        }

        public IEnumerable<TilemapAsset> FindAll(Predicate<TilemapAsset> predicate)
        {
            return entities.FindAll(predicate);
        }

        public IEnumerable<TilemapAsset> All()
        {
            return entities;
        }

        public bool Any(Func<TilemapAsset, bool> predicate)
        {
            return entities.Any(predicate);
        }

        public void Add(TilemapAsset entity)
        {
            entities.Add(entity);
        }

        public void Remove(TilemapAsset entity)
        {
            entities.Remove(entity);
        }

        public void Save()
        {
            if(IOMethods.CreateDirectory(Consts.Repositories.TilemapAssets))
            {
                Serializer.Serialize(entities, Consts.Repositories.TilemapAssets);
            }
        }

        public async Task SaveAsync()
        {
            if(IOMethods.CreateDirectory(Consts.Repositories.TilemapAssets))
            {
                await Serializer.SerializeAsync(entities, Consts.Repositories.TilemapAssets);
            }
        }
    }
}
