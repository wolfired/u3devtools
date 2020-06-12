using UnityEditor;
using UnityEngine;

namespace u3devtools.sloot
{
    public class Main
    {
        [MenuItem("Sloot/Setting")]
        public static void ShowSettingWindow()
        {
            EditorWindow.GetWindow(typeof(SettingWindow));
        }

        [MenuItem("Sloot/Help")]
        public static void Help()
        {
            Debug.Log("Help!");
        }

        [MenuItem("Sloot/Assets/Test")]
        public static void Test()
        {
            // foreach (var item in AssetDatabase.GetAssetPathsFromAssetBundle("common"))
            // {
            //     Debug.Log(item);
            // }
            // foreach (var item in AssetDatabase.FindAssets("Bundles"))
            // {
            //     Debug.Log(AssetDatabase.GUIDToAssetPath(item));
            // }
            foreach (string item in AssetDatabase.GetAllAssetPaths())
            {
                // item.Split({ "Bundles" }, StringSplitOptions);
                // if (1 < item.Length)
                // {
                if (item.StartsWith("Assets/Bundles"))
                {
                    Debug.Log(item);
                    foreach (string dep in AssetDatabase.GetDependencies(item))
                    {
                        Debug.Log(dep);
                    }
                }
                // }
            }

            foreach (string item in AssetDatabase.GetAllAssetBundleNames())
            {
                Debug.Log(item);
            }
            // AssetImporter ai = AssetImporter.GetAtPath("Assets/Bundles/common/logo-result2x.png");
            // ai.SetAssetBundleNameAndVariant("abc", "");
        }
    }
}
