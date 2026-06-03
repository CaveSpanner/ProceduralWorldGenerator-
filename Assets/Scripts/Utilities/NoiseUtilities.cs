using System;
using ProceduralWorldGenerator.Noise;
using ProceduralWorldGenerator.Noise.Abstract;
using ProceduralWorldGenerator.Noise.Implementations;

namespace ProceduralWorldGenerator.Utilities
{
    /// <summary>
    /// Factory helpers for building noise generator instances.
    /// </summary>
    public static class NoiseUtilities
    {
        /// <summary>
        /// Creates a noise generator for the specified type.
        /// </summary>
        /// <param name="noiseType">Noise type selector.</param>
        /// <returns>Concrete noise generator instance.</returns>
        public static NoiseGenerator CreateGenerator(NoiseType noiseType)
        {
            return noiseType switch
            {
                NoiseType.Perlin => new PerlinNoiseGenerator(),
                NoiseType.Simplex => new SimplexNoiseGenerator(),
                NoiseType.DomainWarping => new DomainWarpingNoiseGenerator(new PerlinNoiseGenerator(), new SimplexNoiseGenerator()),
                _ => throw new ArgumentOutOfRangeException(nameof(noiseType), noiseType, "Unsupported noise type")
            };
        }
    }
}
