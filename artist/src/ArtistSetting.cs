using System;
using System.IO;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

namespace u3devtools.artist
{
    public class ArtistSetting : ScriptableObject
    {
        public static ArtistSetting singleton
        {
            [MenuItem("U3Devtools/Singleton Artist Setting")]
            get
            {
                string path = "Assets/ArtistSetting.asset";

                ArtistSetting ins = AssetDatabase.LoadAssetAtPath<ArtistSetting>(path);

                if (null == ins)
                {
                    ins = CreateInstance<ArtistSetting>();
                    AssetDatabase.CreateAsset(ins, path);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }

                return ins;
            }
        }
        public string baseTextureName = "BaseTexture";
        public List<string> platformStrings;

        void Awake()
        {
            platformStrings = new List<string>(new string[]{
                "DefaultTexturePlatform",
                "Standalone",
                "Web",
                "iPhone",
                "Android",
                "WebGL",
                "Windows Store Apps",
                "PS4",
                "XboxOne",
                "Nintendo 3DS",
                "tvOS",
            });
        }
    }
}
