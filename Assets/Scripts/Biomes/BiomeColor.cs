using System;
using UnityEngine;

namespace ProceduralWorldGenerator.Biomes
{
    /// <summary>
    /// Defines a gradient pair used to tint biome pixels.
    /// </summary>
    [Serializable]
    public struct BiomeColor
    {
        /// <summary>
        /// Gets or sets the lower-end biome color.
        /// </summary>
        public Color LowColor;

        /// <summary>
        /// Gets or sets the higher-end biome color.
        /// </summary>
        public Color HighColor;

        /// <summary>
        /// Evaluates color using normalized interpolation factor.
        /// </summary>
        /// <param name="t">Interpolation factor in range [0, 1].</param>
        /// <returns>Interpolated biome color.</returns>
        public Color Evaluate(float t)
        {
            return Color.Lerp(LowColor, HighColor, Mathf.Clamp01(t));
        }
    }
}
