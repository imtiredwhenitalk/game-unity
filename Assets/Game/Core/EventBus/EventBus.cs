public class EventBus
{
    private readonly Dictionary<Type, List<Delegate>> subscribers = new();

    public void Subscribe<T>(Action<T> handler)
    {
        var type = typeof(T);
        if (!subscribers.ContainsKey(type))
            subscribers[type] = new List<Delegate>();
        subscribers[type].Add(handler);
    }

    public void Unsubscribe<T>(Action<T> handler)
    {
        if (subscribers.TryGetValue(typeof(T), out var list))
            list.Remove(handler);
    }

    public void Publish<T>(T eventData)
    {
        if (subscribers.TryGetValue(typeof(T), out var list))
            foreach (var handler in list.ToArray())
                (handler as Action<T>)?.Invoke(eventData);
    }
}