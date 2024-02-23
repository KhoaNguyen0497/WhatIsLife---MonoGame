using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatIsLife.Objects.Attributes;

namespace WhatIsLife.Objects.Traits
{
    // Traits are gained on birth, with low chance for a mutation
    // Trais can be inherited. When traits are inherited, the same chance applies for a mutation, but are likely to skewed towards the parents' value
    // These traits modify attributes of an Entity

    public class TraitSystem
    {
        public SpeedModifier SpeedModifier { get; set; } = new SpeedModifier();
        public List<BaseTrait> Traits { get; set; } = new List<BaseTrait>();

        public TraitSystem()
        {
            foreach (var trait in GetType().GetProperties().Where(p => typeof(BaseTrait).IsAssignableFrom(p.PropertyType)))
            {
                Traits.Add(trait.GetValue(this) as BaseTrait);
            }
        }

        public void Reset(Entity entity)
        {
            Traits.ForEach(trait => trait.Mutate(entity));
        }
    }
}
