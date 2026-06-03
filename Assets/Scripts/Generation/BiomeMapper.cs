using System;
using System.Collections.Generic;
using System.Linq;
using ProceduralWorldGenerator.Biomes.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Generation
{
    /// <summary>
    /// Maps normalized heights to configured biome definitions.
    /// </summary>
    public sealed class BiomeMapper
    {
        private readonly List<BiomeDefinition> orderedBiomes;

        /// <summary>
        /// Initializes a new biome mapper instance.
        /// </summary>
        /// <param name="biomes">Biome list used for mapping.</param>
        public BiomeMapper(IEnumerable<BiomeDefinition> biomes)
        {
            if (biomes == null)
            {
                throw new ArgumentNullException(nameof(biomes));
            }

            orderedBiomes = biomes
                .Where(b => b != null)
                .OrderByDescending(b => b.Priority)
                .ToList();
        }

        /// <summary>
        /// Returns biome matching the supplied normalized height.
        /// </summary>
        /// <param name="height">Normalized terrain height in range [0, 1].</param>
        /// <returns>Matching biome or null when none apply.</returns>
        public BiomeDefinition GetBiome(float height)
        {
            var normalizedHeight = Mathf.Clamp01(height);

            for (var i = 0; i < orderedBiomes.Count; i++)
            {
                var biome = orderedBiomes[i];
                if (biome.MatchesHeight(normalizedHeight))
                {
                    return biome;
                }
            }

            return orderedBiomes.Count > 0 ? orderedBiomes[orderedBiomes.Count - 1] : null;
        }

        /// <summary>
        /// Gets biome color for supplied normalized height.
        /// </summary>
        /// <param name="height">Normalized terrain height.</param>
        /// <returns>Mapped biome color or magenta when no biomes exist.</returns>
        public Color GetColor(float height)
        {
            var biome = GetBiome(height);
            return biome != null ? biome.GetColor(height) : Color.magenta;
        }
    }
}
