using System;
using ProceduralWorldGenerator.Noise.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Noise.Implementations
{
    /// <summary>
    /// Applies coordinate displacement before sampling source noise.
    /// </summary>
    public sealed class DomainWarpingNoiseGenerator : NoiseGenerator
    {
        private readonly NoiseGenerator sourceGenerator;
        private readonly NoiseGenerator warpGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainWarpingNoiseGenerator"/> class.
        /// </summary>
        /// <param name="sourceGenerator">Source generator sampled after warping.</param>
        /// <param name="warpGenerator">Generator used to create coordinate displacement.</param>
        public DomainWarpingNoiseGenerator(NoiseGenerator sourceGenerator, NoiseGenerator warpGenerator)
        {
            this.sourceGenerator = sourceGenerator ?? throw new ArgumentNullException(nameof(sourceGenerator));
            this.warpGenerator = warpGenerator ?? throw new ArgumentNullException(nameof(warpGenerator));
        }

        /// <summary>
        /// Gets or sets warp strength in sample-space units.
        /// </summary>
        public float WarpStrength { get; set; } = 20f;

        /// <summary>
        /// Gets or sets parameters dedicated to warp field generation.
        /// </summary>
        public NoiseParameters WarpParameters { get; set; }

        /// <inheritdoc />
        public override float Generate(float x, float y, NoiseParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var warpSettings = WarpParameters ?? parameters;
            var offsetX = (warpGenerator.Generate(x + 133.7f, y - 91.2f, warpSettings) - 0.5f) * 2f;
            var offsetY = (warpGenerator.Generate(x - 58.4f, y + 203.1f, warpSettings) - 0.5f) * 2f;

            return sourceGenerator.Generate(x + offsetX * WarpStrength, y + offsetY * WarpStrength, parameters);
        }
    }
}
