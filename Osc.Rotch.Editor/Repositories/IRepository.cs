using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Editor.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Find(Predicate<TEntity> predicate);

        IEnumerable<TEntity> FindAll(Predicate<TEntity> predicate);
        IEnumerable<TEntity> All();

        bool Any(Func<TEntity, bool> predicate);

        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Save();
        Task SaveAsync();
    }
}
