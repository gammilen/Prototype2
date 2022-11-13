namespace Ships.Core
{
    public interface IPublishingMessageBroker<T>
    {
        void Publish(T info);
    }
}