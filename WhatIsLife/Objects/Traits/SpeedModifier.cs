using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatIsLife.Helpers;

namespace WhatIsLife.Objects.Traits
{
    public class SpeedModifier : BaseTrait
    {
        // Percentage
        private float _lowerBoundMultiplier = 0.5f;
        private float _upperBoundMultiplier = 2f;

        public override void Mutate(Entity entity)
        {
            if (GameObjects.Random.Chance(MutationChance))
            {
                var modifier = GameObjects.Random.NextFloat(_lowerBoundMultiplier, _upperBoundMultiplier);
                entity.Attributes.Speed.Value *= modifier;
             //   entity.Attributes.Hunger.DecrementModifier *= ((0f + modifier) / 1);
            }
        }
    }
}
