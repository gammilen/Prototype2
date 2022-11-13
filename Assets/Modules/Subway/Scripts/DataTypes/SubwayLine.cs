namespace Subway
{
    public struct SubwayLine
    {
        public readonly string Name;
        private readonly int _hash;

        public SubwayLine(string name)
        {
            Name = name;
            _hash = Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is SubwayLine station && _hash.Equals(station.GetHashCode());
        }

        public override int GetHashCode() => _hash;
    }
}