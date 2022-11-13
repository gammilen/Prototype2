using System.Collections.Generic;

namespace Ships.Core
{
    public class ShipModulesModifiersSource
    {
        public static Dictionary<Stat, StatModifier> GetModifiers(IReadOnlyList<IShipModuleData> modulesData)
        {
            var modifiers = new Dictionary<Stat, StatModifier>();
            for (int i = 0; i < modulesData.Count; i++)
            {
                var module = modulesData[i];
                if (module is not IStatModuleData statModule)
                {
                    continue;
                }
                var modifier = new StatModifier()
                {
                    Abs = statModule.Modification == Mod.Abs ? statModule.ModificationValue : 0,
                    Pct = statModule.Modification == Mod.Pct ? statModule.ModificationValue : 0,
                };
                if (modifiers.ContainsKey(statModule.Stat))
                {
                    modifiers[statModule.Stat].Add(modifier);
                }
                else
                {
                    modifiers[statModule.Stat] = modifier;
                }
            }
            return modifiers;
        }
    }
}