using ProceduralWorldGenerator.Biomes.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Biomes.Definitions
{
    /// <summary>
    /// Biome definition for mountain areas.
    /// </summary>
    [CreateAssetMenu(menuName = "Procedural World/Biomes/Mountain", fileName = "MountainBiome")]
    public sealed class MountainBiome : BiomeDefinition
    {
        private void Reset()
        {
            ApplyDefaults("Mountain", 4, 0.75f, 1f, new Color(0.70f, 0.70f, 0.72f), new Color(0.95f, 0.95f, 0.97f));
        }
    }
}
