namespace Ships.Core
{
    public struct StatModifier
    {
        public float Abs;
        public float Pct;

        public float Modify(float value)
        {
            return Abs + value * (1 + Pct);
        }

        public float Modify(int value)
        {
            return Modify((float)value);
        }

        public void Add(StatModifier modifier)
        {
            Abs += modifier.Abs;
            Pct += modifier.Pct;
        }
    }
}