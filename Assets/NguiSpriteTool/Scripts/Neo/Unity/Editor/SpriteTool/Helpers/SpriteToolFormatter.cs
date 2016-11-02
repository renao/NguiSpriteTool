using UnityEngine;
using UnityEngine.SceneManagement;

namespace Neo.Unity.SpriteTool.Helpers {
  public class SpriteToolFormatter {
    private static string scenePathFormat = "[{0}] ";
    private static string childOfFormat = "{0} => {1}";

    public static string ScenePath(Scene scene) {
      return string.Format(scenePathFormat, scene.name);
    }

    public static string AddChildToPath(string path, GameObject child) {
      return string.Format(childOfFormat, path, child.name);
    }
  }
}
