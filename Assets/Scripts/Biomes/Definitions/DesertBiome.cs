using ProceduralWorldGenerator.Biomes.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Biomes.Definitions
{
    /// <summary>
    /// Biome definition for desert areas.
    /// </summary>
    [CreateAssetMenu(menuName = "Procedural World/Biomes/Desert", fileName = "DesertBiome")]
    public sealed class DesertBiome : BiomeDefinition
    {
        private void Reset()
        {
            ApplyDefaults("Desert", 2, 0.45f, 0.65f, new Color(0.82f, 0.71f, 0.41f), new Color(0.94f, 0.85f, 0.57f));
        }
    }
}
