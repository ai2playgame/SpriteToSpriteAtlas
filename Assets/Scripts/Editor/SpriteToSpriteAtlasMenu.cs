using System.IO;
using UnityEditor;
using UnityEngine.U2D;
using UnityEditor.U2D;
using UnityEngine;

namespace Editor
{
    public static class SpriteToSpriteAtlasMenu
    {
        [MenuItem("Utils/2D/Sprite To SpriteAtlas")]
        private static void SpriteToSpriteAtlas()
        {
            foreach (var selection in Selection.objects)
            {
                var spritePath = AssetDatabase.GetAssetPath(selection);
                var spriteAsset = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
                if (spriteAsset == null)
                {
                    Debug.LogWarning($"{spritePath}はUnityEngine.Spriteではありません。");
                    continue;
                }

                SpriteAtlas atlas = new SpriteAtlas();
                atlas.Add(new Object[] { spriteAsset });

                var atlasPath = Path.ChangeExtension(spritePath, ".spriteatlas");
                Debug.LogWarning($"created {atlasPath}");
                AssetDatabase.CreateAsset(atlas, atlasPath);
            }

            AssetDatabase.SaveAssets();
        }
    }
}