# ProceduralWorldGenerator-

A modular, extensible procedural 2D top-down world generator for Unity (C#).

## Architecture Overview

```text
Assets/Scripts/
├── Noise/
│   ├── Abstract/NoiseGenerator.cs
│   ├── Implementations/
│   │   ├── PerlinNoiseGenerator.cs
│   │   ├── SimplexNoiseGenerator.cs
│   │   └── DomainWarpingNoiseGenerator.cs
│   ├── NoiseParameters.cs
│   └── NoiseType.cs
├── Biomes/
│   ├── Abstract/BiomeDefinition.cs
│   ├── Definitions/
│   │   ├── WaterBiome.cs
│   │   ├── GrasslandBiome.cs
│   │   ├── DesertBiome.cs
│   │   ├── RockyBiome.cs
│   │   └── MountainBiome.cs
│   ├── BiomeColor.cs
│   └── BiomeHeightRange.cs
├── Generation/
│   ├── WorldGenerator.cs
│   ├── WorldGenerationSettings.cs
│   ├── BiomeMapper.cs
│   └── TerrainData.cs
├── Utilities/
│   ├── MathUtilities.cs
│   ├── NoiseUtilities.cs
│   └── ColorUtilities.cs
└── Demo/
    └── WorldGeneratorVisualizer.cs
```

## Included Features

- Data-driven world settings via `WorldGenerationSettings` ScriptableObject
- Noise algorithms: Perlin, Simplex-style approximation, Domain Warping
- Configurable octaves, frequency, amplitude, persistence, lacunarity, seed, and offsets
- ScriptableObject biomes with overlap-friendly priority handling
- Default biome ranges supported:
  - Water: 0.00 - 0.35
  - Grassland: 0.35 - 0.55
  - Desert: 0.45 - 0.65
  - Rocky: 0.60 - 0.80
  - Mountains: 0.75+
- Demo visualizer (`WorldGeneratorVisualizer`) for real-time texture preview

## Setup and Usage

1. Open the project in Unity.
2. Create or load a `WorldGenerationSettings` asset.
3. Create biome assets from **Create > Procedural World > Biomes**.
4. Assign biome assets in settings (higher priority wins on overlaps).
5. Add `WorldGeneratorVisualizer` to a scene object with a `Renderer`.
6. Assign settings and target renderer, then regenerate.

## Notes

- Public APIs include XML documentation comments for editor/tooling help.
- Classes are separated by responsibility for easy extension.
- `Assets/Resources/DefaultGeneratorSettings.asset` is provided as an example starting point.
