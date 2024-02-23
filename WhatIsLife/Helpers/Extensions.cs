using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatIsLife.Helpers
{
    public static class Extensions
    {
        public static bool Chance(this Random random, int chance)
        {
            return random.Next(1, 100) < chance;
        }

        public static float NextFloat(this Random random, float lower, float upper) 
        {
            double range = (double)upper - (double)lower;
            double sample = random.NextDouble();
            double scaled = (sample * range) + lower;
            return (float)scaled;
        }

        public static IEnumerable<IEnumerable<TValue>> Chunk<TValue>(
        this IEnumerable<TValue> values,
        int chunkSize)
        {
            return values
                   .Select((v, i) => new { v, groupIndex = i / chunkSize })
                   .GroupBy(x => x.groupIndex)
                   .Select(g => g.Select(x => x.v));
        }
    }
}
