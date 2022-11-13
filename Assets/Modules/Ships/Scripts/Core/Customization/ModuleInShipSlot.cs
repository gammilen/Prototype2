namespace Ships.Core
{
    public struct ModuleInShipSlot
    {
        public int ShipIndex;
        public int SlotIndex;

        public bool IsSet => ShipIndex >= 0 && SlotIndex >= 0;

        public bool Equals(ModuleInShipSlot other)
        {
            return ShipIndex == other.ShipIndex && SlotIndex == other.SlotIndex;
        }
    }
}