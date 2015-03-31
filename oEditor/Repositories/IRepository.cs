using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Repositories
{
    public interface IRepository<TModel>
    {
        void CheckRepository();

        IEnumerable<TModel> FindEntities(Func<TModel, bool> predicate);

        void SaveEntity(TModel entity);
        void RemoveEntity(TModel entity);
    }
}
