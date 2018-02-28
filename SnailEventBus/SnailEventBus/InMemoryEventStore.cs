using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailEventBus
{
    /// <summary>
    /// 内存事件管理
    /// </summary>
    public class InMemoryEventStore : IEventStore
    {
        /// <summary>
        /// 源和事件的字典
        /// </summary>
        private readonly Dictionary<Type, List<object>> _registeredEventsDic = new Dictionary<Type, List<object>>();

        public void Publish<TEvent>(TEvent tevent) where TEvent : class, IEvent
        {
            if (_registeredEventsDic.ContainsKey(typeof(TEvent)))
            {
                var list = _registeredEventsDic[typeof(TEvent)];
                foreach (var item in list)
                {
                    var s = item as IEventHandler<TEvent>;
                    s.Excute(tevent);
                }
            }
        }

        public void PublishAsync<TEvent>(TEvent eventItem) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public void Register<TEvent>(IEventHandler<TEvent> handler) where TEvent : class, IEvent
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            if (!_registeredEventsDic.ContainsKey(typeof(TEvent)))
            {
                _registeredEventsDic.Add(typeof(TEvent), new List<object>() { handler });
            }
            else
            {
                _registeredEventsDic[typeof(TEvent)].Add(handler);
            }
        }

        public void UnRegister<TEvent>() where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public void UnRegisterEvent<TEvent>() where TEvent : IEvent
        {
            if (_registeredEventsDic.ContainsKey(typeof(TEvent)))
            {
                _registeredEventsDic.Remove(typeof(TEvent));
            }

        }

        public void UnRegisterHandler<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            if (_registeredEventsDic.ContainsKey(typeof(TEvent)))
            {
                var list = _registeredEventsDic[typeof(TEvent)];
                var item = list.FirstOrDefault(x => x.ToString() == handler.ToString());
                list.Remove(item);
            }
        }
    }
}
