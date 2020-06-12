using UnityEditor;
using UnityEngine;

namespace u3devtools.sloot
{
    public class SettingWindow : EditorWindow
    {
        private Setting4Bundle s4b;

        private void OnGUI()
        {
            if (null == s4b)
            {
                s4b = new Setting4Bundle("bundle");
            }
            s4b.BundleRoot = EditorGUILayout.TextField("资源根目录", s4b.BundleRoot);

            Rect r = EditorGUILayout.BeginHorizontal("Button");
            if (GUI.Button(r, GUIContent.none))
            {
                Debug.Log("Go here");
            }
            GUILayout.Label("I'm inside the button");
            GUILayout.Label("So am I");
            EditorGUILayout.EndHorizontal();

        }
    }
}
