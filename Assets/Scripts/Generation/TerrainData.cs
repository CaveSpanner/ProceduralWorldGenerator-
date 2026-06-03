using System;
using ProceduralWorldGenerator.Biomes.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Generation
{
    /// <summary>
    /// Holds generated world output arrays.
    /// </summary>
    [Serializable]
    public class TerrainData
    {
        /// <summary>
        /// Gets map width in pixels.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets map height in pixels.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets normalized height data by index.
        /// </summary>
        public float[] Heights { get; private set; }

        /// <summary>
        /// Gets biome assignment by index.
        /// </summary>
        public BiomeDefinition[] Biomes { get; private set; }

        /// <summary>
        /// Gets color map by index.
        /// </summary>
        public Color[] Colors { get; private set; }

        /// <summary>
        /// Creates a new terrain data instance.
        /// </summary>
        /// <param name="width">Map width.</param>
        /// <param name="height">Map height.</param>
        public TerrainData(int width, int height)
        {
            Width = Mathf.Max(1, width);
            Height = Mathf.Max(1, height);
            Heights = new float[Width * Height];
            Biomes = new BiomeDefinition[Width * Height];
            Colors = new Color[Width * Height];
        }

        /// <summary>
        /// Converts (x,y) to linear array index.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        /// <returns>Linear index.</returns>
        public int ToIndex(int x, int y)
        {
            x = Mathf.Clamp(x, 0, Width - 1);
            y = Mathf.Clamp(y, 0, Height - 1);
            return y * Width + x;
        }
    }
}
