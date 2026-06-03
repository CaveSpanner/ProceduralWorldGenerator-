using ProceduralWorldGenerator.Biomes;
using UnityEngine;

namespace ProceduralWorldGenerator.Biomes.Abstract
{
    /// <summary>
    /// Base ScriptableObject that defines height and color behavior for a biome.
    /// </summary>
    public abstract class BiomeDefinition : ScriptableObject
    {
        [SerializeField] protected string biomeName = "Biome";
        [SerializeField] protected int priority;
        [SerializeField] protected BiomeHeightRange heightRange;
        [SerializeField] protected BiomeColor biomeColor;

        /// <summary>
        /// Gets biome display name.
        /// </summary>
        public string BiomeName => biomeName;

        /// <summary>
        /// Gets priority used when biome ranges overlap (higher wins).
        /// </summary>
        public int Priority => priority;

        /// <summary>
        /// Gets inclusive normalized height range for this biome.
        /// </summary>
        public BiomeHeightRange HeightRange => heightRange;

        /// <summary>
        /// Returns true when this biome owns the supplied normalized height value.
        /// </summary>
        /// <param name="height">Normalized terrain height.</param>
        /// <returns>True if the height falls inside this biome range.</returns>
        public bool MatchesHeight(float height)
        {
            var range = heightRange;
            range.Validate();
            return range.Contains(Mathf.Clamp01(height));
        }

        /// <summary>
        /// Calculates biome surface color for a normalized height value.
        /// </summary>
        /// <param name="height">Normalized terrain height.</param>
        /// <returns>Biome color for the supplied height.</returns>
        public Color GetColor(float height)
        {
            var range = heightRange;
            range.Validate();
            var span = Mathf.Max(0.0001f, range.Max - range.Min);
            var t = (Mathf.Clamp01(height) - range.Min) / span;
            return biomeColor.Evaluate(t);
        }

        /// <summary>
        /// Validates serialized range values when data changes.
        /// </summary>
        protected virtual void OnValidate()
        {
            var range = heightRange;
            range.Validate();
            heightRange = range;
        }

        /// <summary>
        /// Applies default biome values for newly created biome assets.
        /// </summary>
        /// <param name="name">Biome display name.</param>
        /// <param name="priorityValue">Overlap priority value.</param>
        /// <param name="minHeight">Range minimum.</param>
        /// <param name="maxHeight">Range maximum.</param>
        /// <param name="low">Low gradient color.</param>
        /// <param name="high">High gradient color.</param>
        protected void ApplyDefaults(string name, int priorityValue, float minHeight, float maxHeight, Color low, Color high)
        {
            biomeName = name;
            priority = priorityValue;
            heightRange = new BiomeHeightRange
            {
                Min = minHeight,
                Max = maxHeight
            };
            heightRange.Validate();
            biomeColor = new BiomeColor
            {
                LowColor = low,
                HighColor = high
            };
        }
    }
}
