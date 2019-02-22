using System;
using System.Collections.Generic;
using System.Text;

namespace NBodySim.Core
{
    /// <summary>
    /// Contains extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets a random <see cref="double"/> value between two numbers.
        /// </summary>
        public static double NextDouble(
     this Random random,
     double minValue,
     double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
