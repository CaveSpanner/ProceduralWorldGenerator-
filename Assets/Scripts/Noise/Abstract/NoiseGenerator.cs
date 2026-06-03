using UnityEngine;

namespace ProceduralWorldGenerator.Noise.Abstract
{
    /// <summary>
    /// Base class for all 2D noise generator implementations.
    /// </summary>
    public abstract class NoiseGenerator
    {
        /// <summary>
        /// Generates a normalized noise sample in the range [0, 1] for the given coordinate.
        /// </summary>
        /// <param name="x">World-space x coordinate.</param>
        /// <param name="y">World-space y coordinate.</param>
        /// <param name="parameters">Noise parameters used for generation.</param>
        /// <returns>Normalized noise value in range [0, 1].</returns>
        public abstract float Generate(float x, float y, NoiseParameters parameters);

        /// <summary>
        /// Creates a noise map with dimensions <paramref name="width"/> x <paramref name="height"/>.
        /// </summary>
        /// <param name="width">Map width in samples.</param>
        /// <param name="height">Map height in samples.</param>
        /// <param name="parameters">Noise parameters used for generation.</param>
        /// <returns>Generated normalized noise map.</returns>
        public virtual float[,] GenerateMap(int width, int height, NoiseParameters parameters)
        {
            parameters?.Validate();
            width = Mathf.Max(1, width);
            height = Mathf.Max(1, height);

            var map = new float[width, height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    map[x, y] = Generate(x, y, parameters);
                }
            }

            return map;
        }
    }
}
