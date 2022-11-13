using System;

namespace Subway
{
    public struct UnorderedValuePair<T> : IEquatable<UnorderedValuePair<T>>
        where T : struct
    {
        public readonly T ItemA;
        public readonly T ItemB;
        private readonly int _hash;

        public UnorderedValuePair(T a, T b)
        {
            ItemA = a;
            ItemB = b;

            var hashA = ItemA.GetHashCode();
            var hashB = ItemB.GetHashCode();
            _hash = HashCode.Combine(Math.Min(hashA, hashB), Math.Max(hashA, hashB));
        }

        public bool Equals(UnorderedValuePair<T> other)
        {
            return _hash == other.GetHashCode();
            //return X.Equals(other.X) && Y.Equals(other.Y) || X.Equals(other.Y) && Y.Equals(other.X);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((UnorderedValuePair<T>) obj);
        }

        public override int GetHashCode() => _hash;

        public static bool operator ==(UnorderedValuePair<T> left, UnorderedValuePair<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UnorderedValuePair<T> left, UnorderedValuePair<T> right)
        {
            return !left.Equals(right);
        }
    }
}
