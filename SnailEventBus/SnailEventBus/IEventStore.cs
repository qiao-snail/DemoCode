using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailEventBus
{
    /// <summary>
    /// 事件管理接口
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// 注册一个事件
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="act"></param>
        void Register<TEvent>(Action act) where TEvent : IEvent;
        /// <summary>
        /// 注销事件
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="eventItem"></param>
        void UnRegister<TEvent>(TEvent eventItem) where TEvent : IEvent;
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="Tevent"></typeparam>
        /// <param name="eventItem"></param>
        void Publish<Tevent>(Tevent eventItem) where Tevent : IEvent;
        /// <summary>
        /// 异步发布事件
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="eventItem"></param>
        void PublishAsync<TEvent>(TEvent eventItem) where TEvent : IEvent;
    }

}
