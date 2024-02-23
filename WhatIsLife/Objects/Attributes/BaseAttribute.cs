using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsLife.Objects.Attributes
{
    public abstract class BaseAttribute
    {
        protected abstract float InitialValue { get; set; }
        public virtual float Value { get; set; } = 100;
        public virtual void Reset()
        {
            Value = InitialValue;
        }

        public virtual void Increment(float value)
        {
            Value += value;
        }

        public virtual void Decrement(float value)
        {
            Value -= value;
        }
    }
}
