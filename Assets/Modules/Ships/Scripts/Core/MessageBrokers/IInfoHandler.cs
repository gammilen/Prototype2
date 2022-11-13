namespace Ships.Core
{
    public interface IInfoHandler<T>
    {
        void Handle(T info);
    }
}