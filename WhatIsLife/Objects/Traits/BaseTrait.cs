using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatIsLife.Helpers;

namespace WhatIsLife.Objects.Traits
{
    public abstract class BaseTrait
    {
        public int MutationChance = 100;

        public abstract void Mutate(Entity entity);
    }
}
