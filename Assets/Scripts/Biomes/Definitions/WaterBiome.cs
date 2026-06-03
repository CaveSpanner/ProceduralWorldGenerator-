using ProceduralWorldGenerator.Biomes.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Biomes.Definitions
{
    /// <summary>
    /// Biome definition for water areas.
    /// </summary>
    [CreateAssetMenu(menuName = "Procedural World/Biomes/Water", fileName = "WaterBiome")]
    public sealed class WaterBiome : BiomeDefinition
    {
        private void Reset()
        {
            ApplyDefaults("Water", 0, 0f, 0.35f, new Color(0.03f, 0.18f, 0.45f), new Color(0.17f, 0.52f, 0.80f));
        }
    }
}
