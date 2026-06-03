using ProceduralWorldGenerator.Biomes.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Biomes.Definitions
{
    /// <summary>
    /// Biome definition for rocky areas.
    /// </summary>
    [CreateAssetMenu(menuName = "Procedural World/Biomes/Rocky", fileName = "RockyBiome")]
    public sealed class RockyBiome : BiomeDefinition
    {
        private void Reset()
        {
            ApplyDefaults("Rocky", 3, 0.60f, 0.80f, new Color(0.40f, 0.37f, 0.34f), new Color(0.56f, 0.52f, 0.47f));
        }
    }
}
