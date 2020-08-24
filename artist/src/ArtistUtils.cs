using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

using UnityEngine;
using UnityEditor;

namespace u3devtools.artist
{
    public class ArtistUtils
    {
        [MenuItem("Assets/U3Devtools/Create Base Texture")]
        public static void CreateBaseTexture()
        {
            Debug.Log("CreateBaseTexture");

            string path_cur = AssetDatabase.GetAssetPath(Selection.activeObject);

            string[] file_paths = Directory.GetFiles(path_cur, ArtistSetting.singleton.baseTextureName + ".*", SearchOption.TopDirectoryOnly);

            if (0 < file_paths.Length)
            {
                return;
            }

            string path_tex = Path.Combine(path_cur, ArtistSetting.singleton.baseTextureName + ".png");

            Texture2D tex2d = new Texture2D(4, 4);
            File.WriteAllBytes(path_tex, tex2d.EncodeToPNG());
            AssetDatabase.ImportAsset(path_tex, ImportAssetOptions.ForceUpdate);
            AssetDatabase.Refresh();
        }
    }
}
