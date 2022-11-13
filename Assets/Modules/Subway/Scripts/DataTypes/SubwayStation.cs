namespace Subway
{
    public struct SubwayStation
    {
        public readonly string Name;
        private readonly int _hash;

        public SubwayStation(string name)
        {
            Name = name;
            _hash = Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is SubwayStation station && _hash.Equals(station.GetHashCode());
        }

        public override int GetHashCode() => _hash;
    }
}