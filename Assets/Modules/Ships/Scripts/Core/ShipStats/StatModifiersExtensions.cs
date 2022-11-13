using System;
using System.Collections.Generic;

namespace Ships.Core
{
    public static class StatModifiersExtensions
    {
        public static int GetModifiedPosIntValue(this Dictionary<Stat, StatModifier> modifiers,
            Stat stat, int initialValue)
        {
            if (!modifiers.ContainsKey(stat))
            {
                return initialValue;
            }
            var val = (int)Math.Floor(modifiers[stat].Modify(initialValue));
            return val < 0 ? 0 : val;
        }

        public static float GetModifiedPosFloatValue(this Dictionary<Stat, StatModifier> modifiers,
            Stat stat, float initialValue)
        {
            if (!modifiers.ContainsKey(stat))
            {
                return initialValue;
            }
            var val = modifiers[stat].Modify(initialValue);
            return val < 0 ? 0 : val;
        }
    }
}