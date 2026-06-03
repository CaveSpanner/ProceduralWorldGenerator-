using System;
using UnityEngine;

namespace ProceduralWorldGenerator.Biomes
{
    /// <summary>
    /// Defines an inclusive biome height interval.
    /// </summary>
    [Serializable]
    public struct BiomeHeightRange
    {
        /// <summary>
        /// Gets or sets the minimum normalized biome height.
        /// </summary>
        [Range(0f, 1f)] public float Min;

        /// <summary>
        /// Gets or sets the maximum normalized biome height.
        /// </summary>
        [Range(0f, 1f)] public float Max;

        /// <summary>
        /// Returns true when the provided value is inside this range.
        /// </summary>
        /// <param name="value">Normalized height value.</param>
        /// <returns>True if value is in [Min, Max].</returns>
        public bool Contains(float value)
        {
            return value >= Min && value <= Max;
        }

        /// <summary>
        /// Ensures min and max remain normalized and ordered.
        /// </summary>
        public void Validate()
        {
            Min = Mathf.Clamp01(Min);
            Max = Mathf.Clamp01(Max);
            if (Max < Min)
            {
                (Min, Max) = (Max, Min);
            }
        }
    }
}
