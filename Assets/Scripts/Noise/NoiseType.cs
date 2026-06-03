namespace ProceduralWorldGenerator.Noise
{
    /// <summary>
    /// Selects the noise algorithm used during terrain generation.
    /// </summary>
    public enum NoiseType
    {
        /// <summary>
        /// Uses Unity Perlin noise.
        /// </summary>
        Perlin = 0,

        /// <summary>
        /// Uses a Simplex-like noise approximation.
        /// </summary>
        Simplex = 1,

        /// <summary>
        /// Uses domain-warped noise for richer patterns.
        /// </summary>
        DomainWarping = 2
    }
}
