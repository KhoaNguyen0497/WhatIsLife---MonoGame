using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsLife.Objects.Attributes
{
    public class Hunger : BaseAttribute
    {
        // Modifier when Hunger increases
        public float IncrementModifier = 1f;

        // Modifier when Hunger decreases
        public float DecrementModifier = 1f;

        protected override float InitialValue { get; set; } = GlobalObjects.GameConfig.BaseEntityHunger;

        public override void Increment(float value)
        {
            base.Increment(value * IncrementModifier);
        }

        public override void Decrement(float value)
        {
            base.Decrement(value * DecrementModifier);
        }

        public bool DeathThreshold()
        {
            return Value <= 0;
        }

        public bool FindFoodThreshold()
        {
            return Value <= InitialValue / 2;
        }

        public override void Reset()
        {
            IncrementModifier = 1f;
            DecrementModifier = 1f;
            base.Reset();
        }
    }
}
