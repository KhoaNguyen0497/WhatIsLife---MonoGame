using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsLife.Objects.Attributes
{
    public class Speed : BaseAttribute
    {
        protected override float InitialValue { get; set; } = GlobalObjects.GameConfig.BaseEntitySpeed;
    }
}
