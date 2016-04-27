using UnityEngine;
using UnityEngine.SceneManagement;

namespace Neo.Unity.Analysis.Formatters {

  public class ComponentInfoFormatter {
    public string scenePathFormat = "[{0}] ";
    public static string childOfFormat = "{0} => {1}";

    public string ScenePath(Scene scene) {
      return string.Format(scenePathFormat, scene.name);
    }

    public string AddChildToPath(string path, GameObject child) {
      return string.Format(childOfFormat, path, child.name);
    }
  }
}
