﻿using System;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property |
                          AttributeTargets.Field)]
    public class RestartRequiredAttribute : Attribute
    {
    }
}
