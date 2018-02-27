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
        private readonly Dictionary<Type, List<IEventHandler<IEventData>>> _registeredEventsDic = new Dictionary<Type, List<IEventHandler<IEventData>>>();

        public void Publish<TEvent>(TEvent eventItem) where TEvent : IEvent
        {
            if (_registeredEventsDic.ContainsKey(typeof(TEvent)))
            {
                var list = _registeredEventsDic[typeof(TEvent)];
                foreach (var item in list)
                {
                    item.Excute(null);
                }
            }
        }

        public void PublishAsync<TEvent>(TEvent eventItem) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public void Register<TEvent>(Action act) where TEvent : IEvent
        {
            if (act == null)
                throw new ArgumentNullException(nameof(act));
            if (!_registeredEventsDic.ContainsKey(typeof(TEvent)))
            {
                _registeredEventsDic.Add(typeof(TEvent), new List<IEventHandler<IEventData>>() { new EventHandler(act) });
            }
            else
            {
                _registeredEventsDic[typeof(TEvent)].Add(new EventHandler(act));
            }
        }

        public void UnRegister<TEvent>(TEvent eventItem) where TEvent : IEvent
        {
            if (_registeredEventsDic.ContainsKey(typeof(TEvent)))
            {
                var list = _registeredEventsDic[typeof(TEvent)];
                var item = list.FirstOrDefault(x => x.ToString() == eventItem.ToString());
                list.Remove(item);
            }

        }
    }
}
