using NUnit.Framework;
using Neo.Unity.NGUI.Helpers;
using UnityEngine;
using UnityEditor.SceneManagement;

namespace Tests.Neo.Unity.NGUI.Helpers {
  public class TestSpriteToolFormatter{

    private UnityEngine.SceneManagement.Scene scene;
    private GameObject child;

    [SetUp]
    public void SetUp() {
      scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
      child = new GameObject("childObject");
    }

    [TearDown]
    public void TearDown() {
      GameObject.DestroyImmediate(child);
      EditorSceneManager.CloseScene(scene, true);
    }

    [Test]
    public void FormatsScenePath() {
      Assert.Ignore("Scene without a name invalidates ScenePath tests in some cases.");
      Assert.AreEqual(
        string.Format("[{0}] ", scene.name),
        SpriteToolFormatter.ScenePath(scene)
      );
    }

    [Test]
    public void AddsChildToCurrentPath() {
      string currentPath = "some path before";
      Assert.AreEqual(
        string.Format("{0} => {1}", currentPath, child.name),
        SpriteToolFormatter.AddChildToPath(currentPath, child)
      );
    }
  }
}
