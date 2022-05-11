using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.DataProviders
{
    public class Filter<TEntity>
    {
        public Filter(Func<TEntity, bool> predicate)
        {
            this.predicate = predicate;
        }

        private readonly Func<TEntity, bool> predicate;

        public IEnumerable<TEntity> Apply(IEnumerable<TEntity> entities)
        {
            return entities.Where(predicate);
        }
    }
}
