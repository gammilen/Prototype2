namespace Ships.Core
{
    public interface ISubscribingMessageBroker<T, K>
    {
        void AddSubscriber(IInfoHandler<T> subscriber, K subParam);
        void RemoveSubscriber(IInfoHandler<T> subscriber, K subParam);
    }
}