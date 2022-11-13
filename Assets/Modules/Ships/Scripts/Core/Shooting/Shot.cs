namespace Ships.Core
{
    public class Shot
    {
        public readonly WeaponState Weapon;
        public readonly int Damage;
        public readonly float Speed;

        public Shot(WeaponState weapon, int damage, float speed)
        {
            Weapon = weapon;
            Damage = damage;
            Speed = speed;
        }
    }
}