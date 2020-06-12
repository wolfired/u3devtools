using System.IO;

using UnityEditor;
using UnityEngine;

using u3devtools.logger;

namespace u3devtools.sloot
{
    [InitializeOnLoad]
    public class RunAfterEditorLaunched
    {
        private static double mark = 0;

        private static LoggerManager _logger_manager = new LoggerManager(Path.Combine(Application.dataPath, "../editor.log"), LogLevel.ON);

        static RunAfterEditorLaunched()
        {
            _logger_manager.log_person("Unity Booted!");
            EditorApplication.update += Update;
        }

        private static void Update()
        {
            if (10 <= EditorApplication.timeSinceStartup - mark)
            {
                mark = EditorApplication.timeSinceStartup;
                _logger_manager.log_person("Editor Updateing");
            }
            _logger_manager.print();
        }
    }
}
