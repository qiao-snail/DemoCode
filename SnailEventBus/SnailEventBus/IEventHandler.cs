using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailEventBus
{
    /// <summary>
    /// 执行事件接口（领域事件）
    /// </summary>
    public interface IEventHandler<TEventArg> where TEventArg : IEventData
    {
        /// <summary>
        /// 执行事件
        /// </summary>
        /// <param name="args">事件参数</param>
        void Excute(TEventArg args);
    }
}
