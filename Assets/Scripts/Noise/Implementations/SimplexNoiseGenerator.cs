using System;
using ProceduralWorldGenerator.Noise.Abstract;
using UnityEngine;

namespace ProceduralWorldGenerator.Noise.Implementations
{
    /// <summary>
    /// Produces a lightweight Simplex-style noise approximation suitable for prototyping.
    /// </summary>
    public sealed class SimplexNoiseGenerator : NoiseGenerator
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
            var amplitude = parameters.Amplitude;
            var frequency = parameters.Frequency;
            var accumulatedValue = 0f;
            var maxAmplitude = 0f;

            for (var octave = 0; octave < parameters.Octaves; octave++)
            {
                var octaveOffsetX = random.Next(-100000, 100001) + parameters.Offset.x;
                var octaveOffsetY = random.Next(-100000, 100001) + parameters.Offset.y;
                var normalizedX = ((x + octaveOffsetX) / parameters.Scale) * frequency;
                var normalizedY = ((y + octaveOffsetY) / parameters.Scale) * frequency;

                // Rotated multi-sample blend to reduce axial artifacts and approximate simplex-like behavior.
                var a = Mathf.PerlinNoise(normalizedX * 1.21f, normalizedY * 1.09f);
                var b = Mathf.PerlinNoise((normalizedX - normalizedY) * 0.75f, (normalizedX + normalizedY) * 0.75f);
                var c = Mathf.PerlinNoise(-normalizedY * 1.37f, normalizedX * 1.13f);
                var sample = (a + b + c) / 3f;

                accumulatedValue += sample * amplitude;
                maxAmplitude += amplitude;
                amplitude *= parameters.Persistence;
                frequency *= parameters.Lacunarity;
            }

            if (maxAmplitude <= 0f)
            {
                return 0.5f;
            }

            return Mathf.Clamp01(accumulatedValue / maxAmplitude);
        }
    }
}
