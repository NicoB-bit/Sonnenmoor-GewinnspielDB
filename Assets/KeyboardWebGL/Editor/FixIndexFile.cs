using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Callbacks;
using System.IO;

namespace WebGLKeyboard
{
    /// <summary>
    /// Edits the index.html file (the Unity default one) after the build to add the necessary elements to the fix work
    /// </summary>
    public class FixIndexFile : IPostprocessBuildWithReport
    {
        public int callbackOrder { get { return 0; } }

        public void OnPostprocessBuild(BuildReport report)
        {
            if (report.summary.platform == BuildTarget.WebGL)
            {
                string text = File.ReadAllText(Path.Combine(report.summary.outputPath, "index.html"));

                string[] injection = {
                    "\t\t<script>\n\t\t\tvar gameInstance = undefined;\n\n\t\t\tfunction FixInputOnSubmit() {\n\t\t\t\tdocument.getElementById(\"fixInput\").blur();\n\t\t\t\tevent.preventDefault();\n\t\t\t}\n\t\t</script>\n\t\t<div>\n\t\t\t<form onsubmit=\"FixInputOnSubmit()\" autocomplete=\"off\" style=\"width: 0px; height: 0px; position: absolute; top: -9999px;\">\n\t\t\t\t<input type=\"text\" id=\"fixInput\" oninput=\"gameInstance.Module.asmLibraryArg._FixInputUpdate()\" onblur=\"gameInstance.Module.asmLibraryArg._FixInputOnBlur()\" style=\"font-size: 42px;\">\n\t\t\t</form>\n\t\t</div>\n",
                    "\t\t\t\t\tgameInstance = unityInstance;\n"
                };

                text = text.Replace(
                    "<body>\n",
                    "<body>\n" + injection[0]
                );
                text = text.Replace(
                    "}).then((unityInstance) => {\n",
                    "}).then((unityInstance) => {\n" + injection[1]
                );

                File.WriteAllText(Path.Combine(report.summary.outputPath, "index.html"), text);
            }
        }
    }
}