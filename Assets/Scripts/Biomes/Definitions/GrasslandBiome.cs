using ProceduralWorldGenerator.Biomes.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Biomes.Definitions
{
    /// <summary>
    /// Biome definition for grassland areas.
    /// </summary>
    [CreateAssetMenu(menuName = "Procedural World/Biomes/Grassland", fileName = "GrasslandBiome")]
    public sealed class GrasslandBiome : BiomeDefinition
    {
        private void Reset()
        {
            ApplyDefaults("Grassland", 1, 0.35f, 0.55f, new Color(0.20f, 0.53f, 0.20f), new Color(0.35f, 0.72f, 0.28f));
        }
    }
}
