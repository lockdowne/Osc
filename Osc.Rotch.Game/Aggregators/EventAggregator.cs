using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oGame.Aggregators
{
    public class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, List<WeakReference>> eventSubscribers = new Dictionary<Type, List<WeakReference>>();

        private readonly object lockObject = new object();

        public void Subscribe(object subscriber)
        {
            lock (lockObject)
            {
                IEnumerable<Type> subscriberTypes = subscriber.GetType().GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

                WeakReference weakReference = new WeakReference(subscriber);

                foreach (Type subscriberType in subscriberTypes)
                {
                    List<WeakReference> subscribers = GetSubscribers(subscriberType);
                    subscribers.Add(weakReference);
                }
            }
        }

        public void Publish<TEvent>(TEvent publish)
        {
            Type subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEvent));

            List<WeakReference> subscribers = GetSubscribers(subscriberType);

            List<WeakReference> subscribersToRemove = new List<WeakReference>();

            foreach (WeakReference weakSubscriber in subscribers)
            {
                if (weakSubscriber.IsAlive)
                {
                    ISubscriber<TEvent> subscriber = (ISubscriber<TEvent>)weakSubscriber.Target;

                    SynchronizationContext syncContext = SynchronizationContext.Current;

                    if (syncContext == null)
                        syncContext = new SynchronizationContext();

                    syncContext.Post(s => subscriber.OnEvent(publish), null);
                }
                else
                {
                    subscribersToRemove.Add(weakSubscriber);
                }
            }

            if (subscribersToRemove.Count > 0)
            {
                lock (lockObject)
                {
                    foreach (WeakReference removeReference in subscribersToRemove)
                        subscribers.Remove(removeReference);
                }
            }
        }

        private List<WeakReference> GetSubscribers(Type subscriberType)
        {
            List<WeakReference> subscribers;

            lock (lockObject)
            {
                bool found = eventSubscribers.TryGetValue(subscriberType, out subscribers);

                if (!found)
                {
                    subscribers = new List<WeakReference>();
                    eventSubscribers.Add(subscriberType, subscribers);
                }
            }

            return subscribers;
        }
    }
}
