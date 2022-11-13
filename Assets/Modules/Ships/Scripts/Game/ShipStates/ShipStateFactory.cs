using System.Collections.Generic;
using Ships.Core;

namespace Ships.Game
{
    public static class ShipStateFactory
    {
        public static ShipState GetShipState(IShipCustomization customization)
        {
            var modifiers = ShipModulesModifiersSource.GetModifiers(customization.GetModules(ShipModulesSlotType.Stat));

            var weapons = new List<WeaponState>();
            var weaponModules = customization.GetModules(ShipModulesSlotType.Weapon);
            for (int i = 0; i < weaponModules.Count; i++)
            {
                if (weaponModules[i] is IWeaponModuleData weapon)
                {
                    weapons.Add(new WeaponState(weapon.Damage, 
                        modifiers.GetModifiedPosFloatValue(Stat.WeaponsCooldown, weapon.CooldownTime),
                        weapon.Speed, i));
                }
            }
            return new ShipState(customization, weapons,
                1 / modifiers.GetModifiedPosFloatValue(Stat.ShieldRestoreSpeed, customization.ShipData.ShieldRestoreSpeed), 
                modifiers.GetModifiedPosIntValue(Stat.HP, customization.ShipData.HP),
                modifiers.GetModifiedPosIntValue(Stat.Shield, customization.ShipData.Shield));
        }
    }
}