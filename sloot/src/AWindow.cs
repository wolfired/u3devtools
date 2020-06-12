using UnityEditor;
using UnityEngine;

namespace u3devtools.sloot
{
    public class AWindow : EditorWindow
    {
        [MenuItem("Sloot/AWindow")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(AWindow));
        }

        public void onGui()
        {

        }
    }
}
