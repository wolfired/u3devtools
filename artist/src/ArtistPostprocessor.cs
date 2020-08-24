using System;
using System.IO;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using u3devtools.utils;

namespace u3devtools.artist
{
    public class ArtistPostprocessor : AssetPostprocessor
    {
        void OnPreprocessTexture()
        {
            if (ArtistSetting.singleton.baseTextureName == Path.GetFileNameWithoutExtension(this.assetPath))
            {
                return;
            }

            Debug.Log("OnPreprocessTexture");

            TextureImporter bti = lookupBaseTextureImport(PathUtils.GetParentPath(this.assetPath));

            if (null == bti)
            {
                return;
            }

            TextureImporterSettings btis = new TextureImporterSettings();
            bti.ReadTextureSettings(btis);

            TextureImporter ti = this.assetImporter as TextureImporter;
            ti.SetTextureSettings(btis);

            foreach (string platform_string in ArtistSetting.singleton.platformStrings)
            {
                ti.SetPlatformTextureSettings(bti.GetPlatformTextureSettings(platform_string));
            }
        }

        void OnPostprocessTexture(Texture2D texture)
        {
            if (ArtistSetting.singleton.baseTextureName == Path.GetFileNameWithoutExtension(this.assetPath))
            {
                return;
            }

            Debug.Log("OnPostprocessTexture");

            TextureImporter ti = this.assetImporter as TextureImporter;

            if (TextureImporterType.Sprite == ti.textureType && SpriteImportMode.Multiple == ti.spriteImportMode && ArtistSetting.singleton.baseTextureName != Path.GetFileNameWithoutExtension(this.assetPath))
            {
                TextureAtlas t = TextureAtlas.Read(Path.Combine(PathUtils.GetParentPath(this.assetPath), Path.GetFileNameWithoutExtension(this.assetPath) + ".xml"));

                List<SpriteMetaData> metas = new List<SpriteMetaData>();

                foreach (TextureAtlas.Sprite sprite in t.sprites)
                {
                    SpriteMetaData meta = new SpriteMetaData();
                    meta.name = sprite.name;
                    meta.rect = new Rect(sprite.x, t.height - sprite.y - sprite.h, sprite.w, sprite.h);
                    metas.Add(meta);
                }

                ti.spritesheet = metas.ToArray();

                AssetDatabase.ImportAsset(this.assetPath, ImportAssetOptions.ForceUpdate);
            }

            EditorUtility.SetDirty(ti);
        }

        private TextureImporter lookupBaseTextureImport(string search_path)
        {
            List<string> dirs = new List<string>(search_path.Split(new char[] { Path.DirectorySeparatorChar }));

            while (0 < dirs.Count)
            {
                string[] file_paths = Directory.GetFiles(String.Join(Path.DirectorySeparatorChar.ToString(), dirs), ArtistSetting.singleton.baseTextureName + ".*", SearchOption.TopDirectoryOnly);
                foreach (string file_path in file_paths)
                {
                    return TextureImporter.GetAtPath(file_path) as TextureImporter;
                }

                dirs.RemoveAt(dirs.Count - 1);
            }

            return null;
        }
    }
}
