using UnityEngine;

namespace ProceduralWorldGenerator.Utilities
{
    /// <summary>
    /// Helper utilities for biome color blending.
    /// </summary>
    public static class ColorUtilities
    {
        /// <summary>
        /// Blends between two colors using normalized interpolation amount.
        /// </summary>
        /// <param name="a">First color.</param>
        /// <param name="b">Second color.</param>
        /// <param name="t">Blend factor in [0,1].</param>
        /// <returns>Blended color.</returns>
        public static Color Blend(Color a, Color b, float t)
        {
            return Color.Lerp(a, b, Mathf.Clamp01(t));
        }
    }
}
