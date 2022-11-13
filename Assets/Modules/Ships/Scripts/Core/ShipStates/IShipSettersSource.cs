namespace Ships.Core
{
    public interface IShipSettersSource
    {
        IShipStateSetter GetShipStateSetter(IShipState shipState);
    }
}