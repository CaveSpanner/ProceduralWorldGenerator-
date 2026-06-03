using ProceduralWorldGenerator.Generation;
using UnityEngine;

namespace ProceduralWorldGenerator.Demo
{
    /// <summary>
    /// Runtime visualizer used to preview generated worlds in editor and play mode.
    /// </summary>
    [ExecuteAlways]
    public sealed class WorldGeneratorVisualizer : MonoBehaviour
    {
        [SerializeField] private WorldGenerationSettings settings;
        [SerializeField] private Renderer targetRenderer;
        [SerializeField] private bool autoGenerate = true;

        /// <summary>
        /// Generates and applies a world preview texture.
        /// </summary>
        public void Regenerate()
        {
            if (settings == null || targetRenderer == null)
            {
                return;
            }

            var generator = new WorldGenerator();
            var terrainData = generator.Generate(settings);
            var texture = new Texture2D(terrainData.Width, terrainData.Height, TextureFormat.RGBA32, false)
            {
                filterMode = FilterMode.Point,
                wrapMode = TextureWrapMode.Clamp
            };

            texture.SetPixels(terrainData.Colors);
            texture.Apply(false, false);

            targetRenderer.sharedMaterial.mainTexture = texture;
        }

        private void OnValidate()
        {
            if (autoGenerate)
            {
                Regenerate();
            }
        }

        private void Start()
        {
            if (autoGenerate)
            {
                Regenerate();
            }
        }
    }
}
