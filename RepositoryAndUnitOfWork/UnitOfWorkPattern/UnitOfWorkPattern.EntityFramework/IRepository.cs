using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.EntityFramework
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region 属性
        //IQueryable Entities { get; }
        #endregion

        #region 公共方法
        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Delete(object id);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        TEntity GetByKey(object key);
        #endregion
    }

}
