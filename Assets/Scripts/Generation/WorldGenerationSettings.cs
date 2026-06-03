using System.Collections.Generic;
using ProceduralWorldGenerator.Biomes.Abstract;
using ProceduralWorldGenerator.Noise;
using UnityEngine;

namespace ProceduralWorldGenerator.Generation
{
    /// <summary>
    /// Data-driven settings asset used by world generation.
    /// </summary>
    [CreateAssetMenu(menuName = "Procedural World/Generation Settings", fileName = "WorldGenerationSettings")]
    public class WorldGenerationSettings : ScriptableObject
    {
        [SerializeField] private int width = 256;
        [SerializeField] private int height = 256;
        [SerializeField] private NoiseType noiseType = NoiseType.Perlin;
        [SerializeField] private NoiseParameters noiseParameters = new NoiseParameters();
        [SerializeField] private NoiseParameters domainWarpParameters = new NoiseParameters();
        [SerializeField] private float domainWarpStrength = 20f;
        [SerializeField] private List<BiomeDefinition> biomes = new List<BiomeDefinition>();

        /// <summary>
        /// Gets map width.
        /// </summary>
        public int Width => Mathf.Max(1, width);

        /// <summary>
        /// Gets map height.
        /// </summary>
        public int Height => Mathf.Max(1, height);

        /// <summary>
        /// Gets selected noise algorithm.
        /// </summary>
        public NoiseType NoiseType => noiseType;

        /// <summary>
        /// Gets primary noise parameters.
        /// </summary>
        public NoiseParameters NoiseParameters => noiseParameters;

        /// <summary>
        /// Gets domain warp parameters.
        /// </summary>
        public NoiseParameters DomainWarpParameters => domainWarpParameters;

        /// <summary>
        /// Gets domain warp displacement strength.
        /// </summary>
        public float DomainWarpStrength => Mathf.Max(0f, domainWarpStrength);

        /// <summary>
        /// Gets configured biome definitions in mapping order.
        /// </summary>
        public IReadOnlyList<BiomeDefinition> Biomes => biomes;

        /// <summary>
        /// Validates settings and nested parameter objects.
        /// </summary>
        public void Validate()
        {
            width = Width;
            height = Height;
            noiseParameters ??= new NoiseParameters();
            domainWarpParameters ??= new NoiseParameters();
            noiseParameters.Validate();
            domainWarpParameters.Validate();
            domainWarpStrength = DomainWarpStrength;
            biomes ??= new List<BiomeDefinition>();
        }

        private void OnValidate()
        {
            Validate();
        }
    }
}
