using System;
using ProceduralWorldGenerator.Noise;
using ProceduralWorldGenerator.Noise.Abstract;
using ProceduralWorldGenerator.Noise.Implementations;
using ProceduralWorldGenerator.Utilities;

namespace ProceduralWorldGenerator.Generation
{
    /// <summary>
    /// Coordinates noise generation and biome mapping to produce terrain outputs.
    /// </summary>
    public sealed class WorldGenerator
    {
        /// <summary>
        /// Generates terrain data from world generation settings.
        /// </summary>
        /// <param name="settings">World generation settings asset.</param>
        /// <returns>Generated terrain output.</returns>
        public TerrainData Generate(WorldGenerationSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Validate();

            var terrainData = new TerrainData(settings.Width, settings.Height);
            var noiseGenerator = BuildNoiseGenerator(settings);
            var biomeMapper = new BiomeMapper(settings.Biomes);

            for (var y = 0; y < terrainData.Height; y++)
            {
                for (var x = 0; x < terrainData.Width; x++)
                {
                    var index = terrainData.ToIndex(x, y);
                    var noiseValue = noiseGenerator.Generate(x, y, settings.NoiseParameters);
                    var biome = biomeMapper.GetBiome(noiseValue);

                    terrainData.Heights[index] = noiseValue;
                    terrainData.Biomes[index] = biome;
                    terrainData.Colors[index] = biomeMapper.GetColor(noiseValue);
                }
            }

            return terrainData;
        }

        private static NoiseGenerator BuildNoiseGenerator(WorldGenerationSettings settings)
        {
            var baseGenerator = NoiseUtilities.CreateGenerator(settings.NoiseType);
            if (settings.NoiseType != NoiseType.DomainWarping)
            {
                return baseGenerator;
            }

            if (baseGenerator is DomainWarpingNoiseGenerator domainWarpingGenerator)
            {
                domainWarpingGenerator.WarpStrength = settings.DomainWarpStrength;
                domainWarpingGenerator.WarpParameters = settings.DomainWarpParameters;
                return domainWarpingGenerator;
            }

            return baseGenerator;
        }
    }
}
