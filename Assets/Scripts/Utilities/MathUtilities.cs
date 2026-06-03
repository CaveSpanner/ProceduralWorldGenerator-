using UnityEngine;

namespace ProceduralWorldGenerator.Utilities
{
    /// <summary>
    /// Shared math helpers used by generation systems.
    /// </summary>
    public static class MathUtilities
    {
        /// <summary>
        /// Remaps a value from one range to another.
        /// </summary>
        /// <param name="value">Input value.</param>
        /// <param name="inMin">Input minimum.</param>
        /// <param name="inMax">Input maximum.</param>
        /// <param name="outMin">Output minimum.</param>
        /// <param name="outMax">Output maximum.</param>
        /// <returns>Remapped value.</returns>
        public static float Remap(float value, float inMin, float inMax, float outMin, float outMax)
        {
            var safeRange = Mathf.Max(0.0001f, inMax - inMin);
            var normalized = (value - inMin) / safeRange;
            return Mathf.Lerp(outMin, outMax, normalized);
        }

        /// <summary>
        /// Normalizes a value to the [0,1] interval.
        /// </summary>
        /// <param name="value">Input value.</param>
        /// <param name="min">Minimum bound.</param>
        /// <param name="max">Maximum bound.</param>
        /// <returns>Normalized value in range [0,1].</returns>
        public static float Normalize(float value, float min, float max)
        {
            return Mathf.Clamp01(Remap(value, min, max, 0f, 1f));
        }
    }
}
