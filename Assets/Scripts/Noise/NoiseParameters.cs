using System;
using UnityEngine;

namespace ProceduralWorldGenerator.Noise
{
    /// <summary>
    /// Configurable settings used by noise generators.
    /// </summary>
    [Serializable]
    public class NoiseParameters
    {
        [SerializeField] private int seed = 1337;
        [SerializeField] private float scale = 100f;
        [SerializeField] private int octaves = 4;
        [SerializeField] private float frequency = 1f;
        [SerializeField] private float amplitude = 1f;
        [SerializeField] private float persistence = 0.5f;
        [SerializeField] private float lacunarity = 2f;
        [SerializeField] private Vector2 offset = Vector2.zero;

        /// <summary>
        /// Gets or sets the seed used for deterministic generation.
        /// </summary>
        public int Seed
        {
            get => seed;
            set => seed = value;
        }

        /// <summary>
        /// Gets or sets world scale used to normalize map coordinates.
        /// </summary>
        public float Scale
        {
            get => Mathf.Max(0.0001f, scale);
            set => scale = Mathf.Max(0.0001f, value);
        }

        /// <summary>
        /// Gets or sets the number of layered noise octaves.
        /// </summary>
        public int Octaves
        {
            get => Mathf.Max(1, octaves);
            set => octaves = Mathf.Max(1, value);
        }

        /// <summary>
        /// Gets or sets the initial noise frequency.
        /// </summary>
        public float Frequency
        {
            get => Mathf.Max(0.0001f, frequency);
            set => frequency = Mathf.Max(0.0001f, value);
        }

        /// <summary>
        /// Gets or sets the initial noise amplitude.
        /// </summary>
        public float Amplitude
        {
            get => Mathf.Max(0.0001f, amplitude);
            set => amplitude = Mathf.Max(0.0001f, value);
        }

        /// <summary>
        /// Gets or sets the amplitude reduction per octave.
        /// </summary>
        public float Persistence
        {
            get => Mathf.Clamp(persistence, 0.0001f, 1f);
            set => persistence = Mathf.Clamp(value, 0.0001f, 1f);
        }

        /// <summary>
        /// Gets or sets frequency multiplier applied each octave.
        /// </summary>
        public float Lacunarity
        {
            get => Mathf.Max(1f, lacunarity);
            set => lacunarity = Mathf.Max(1f, value);
        }

        /// <summary>
        /// Gets or sets position offset for panning noise.
        /// </summary>
        public Vector2 Offset
        {
            get => offset;
            set => offset = value;
        }

        /// <summary>
        /// Validates and normalizes all values for safe usage.
        /// </summary>
        public void Validate()
        {
            scale = Scale;
            octaves = Octaves;
            frequency = Frequency;
            amplitude = Amplitude;
            persistence = Persistence;
            lacunarity = Lacunarity;
        }
    }
}
