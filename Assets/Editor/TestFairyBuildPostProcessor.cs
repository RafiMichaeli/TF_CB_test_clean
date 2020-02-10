using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class TestFairyBuildPostProcessor {
  [PostProcessBuildAttribute(1)]
  public static void OnPostprocessBuild(BuildTarget buildTarget, string path) {
    if (buildTarget == BuildTarget.iOS) {
      string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

      PBXProject proj = new PBXProject();
      proj.ReadFromString(File.ReadAllText(projPath));
      var mainTarget = proj.GetUnityMainTargetGuid();

      proj.AddShellScriptBuildPhase(mainTarget, "Strip unused architectures", "", "sh Frameworks/Plugins/iOS/TestFairy.framework/strip-architectures.sh");

      File.WriteAllText(projPath, proj.WriteToString());
    }
  }
}
