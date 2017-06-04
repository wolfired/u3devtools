using UnityEditor;
using UnityEngine;

namespace u3devtools.sloot
{
    [InitializeOnLoad]
    public class RunAfterEditorLaunched
    {
        private static double mark = 0;

        static RunAfterEditorLaunched()
        {
            Debug.Log("Unity启动完毕!");
            EditorApplication.update += Update;
        }

        private static void Update()
        {
            if (1 <= EditorApplication.timeSinceStartup - mark)
            {
                mark = EditorApplication.timeSinceStartup;
                Debug.Log("Editor Updateing");
            }
        }
    }
}
