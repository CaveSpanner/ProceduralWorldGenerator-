using System;
using ProceduralWorldGenerator.Noise.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Noise.Implementations
{
    /// <summary>
    /// Produces layered Perlin noise using octave parameters.
    /// </summary>
    public sealed class PerlinNoiseGenerator : NoiseGenerator
    {
        /// <inheritdoc />
        public override float Generate(float x, float y, NoiseParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            parameters.Validate();

            var random = new System.Random(parameters.Seed);
            var maxAmplitude = 0f;
            var value = 0f;
            var amplitude = parameters.Amplitude;
            var frequency = parameters.Frequency;

            for (var octave = 0; octave < parameters.Octaves; octave++)
            {
                var octaveOffsetX = random.Next(-100000, 100001) + parameters.Offset.x;
                var octaveOffsetY = random.Next(-100000, 100001) + parameters.Offset.y;

                var sampleX = ((x + octaveOffsetX) / parameters.Scale) * frequency;
                var sampleY = ((y + octaveOffsetY) / parameters.Scale) * frequency;
                var perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2f - 1f;

                value += perlinValue * amplitude;
                maxAmplitude += amplitude;
                amplitude *= parameters.Persistence;
                frequency *= parameters.Lacunarity;
            }

            if (maxAmplitude <= 0f)
            {
                return 0.5f;
            }

            return Mathf.Clamp01((value / maxAmplitude + 1f) * 0.5f);
        }
    }
}
