using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.EntityFramework
{
    /// <summary>
    ///     业务单元操作接口
    /// </summary>
    public interface IUnitOfWork
    {
      


        #region 方法

        /// <summary>
        /// 提交当前单元操作的结果
        /// </summary>
        /// <returns></returns>
        void Save();

        #endregion
    }
}
