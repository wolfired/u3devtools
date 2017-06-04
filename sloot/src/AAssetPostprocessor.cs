using UnityEditor;
using UnityEngine;

namespace u3devtools.sloot
{
    class AAssetPostprocessor : AssetPostprocessor
    {
        private void OnPostprocessAssetbundleNameChanged(string path, string pre, string nxt)
        {
            Debug.Log("Path: " + path + ", Pre: " + pre + ", Nxt: " + nxt);
        }
    }
}
