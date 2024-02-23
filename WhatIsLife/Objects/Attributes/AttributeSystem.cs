using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WhatIsLife.Objects.Attributes
{
    // These values can be increased/decreased over the course of the Entity's life
    public class AttributeSystem
    {
        public Hunger Hunger { get; set; } = new Hunger();
        public Speed Speed { get; set; } = new Speed();

        public Radius Radius { get; set; } = new Radius();

        public List<BaseAttribute> Attributes { get; set; } = new List<BaseAttribute>();

        public AttributeSystem() 
        {
            foreach (var attribute in GetType().GetProperties().Where(p => typeof(BaseAttribute).IsAssignableFrom(p.PropertyType)))
            {
                Attributes.Add(attribute.GetValue(this) as BaseAttribute);
            }

            Reset();
        }

        public void Reset()
        {
            Attributes.ForEach(x => x.Reset());
        }
    }
}
