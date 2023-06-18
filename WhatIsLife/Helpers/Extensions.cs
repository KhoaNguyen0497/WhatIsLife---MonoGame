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
