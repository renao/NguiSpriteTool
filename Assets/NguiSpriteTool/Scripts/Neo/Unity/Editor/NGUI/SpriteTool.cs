using System;
using System.Collections.Generic;
using Neo.IO;
using Neo.Unity.NGUI.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneManager = UnityEditor.SceneManagement.EditorSceneManager;

namespace Neo.Unity.NGUI {
  public class SpriteTool {

    public AtlasSpriteInfo Info;
    private string dataPath;

    public SpriteTool(string dataPath=null) {
      Info = new AtlasSpriteInfo();
      this.dataPath = dataPath ?? Application.dataPath;
    }

    public void GetSpriteUsages(Action Callback=null) {
      fetchUsedSprites();
      if(Callback != null) Callback();
    }

    private void fetchUsedSprites() {
      fetchSpritesFromPrefabs();
      fetchSpritesFromScenes();
    }

    private void fetchSpritesFromPrefabs() {
      List<string> prefabLocations = FileCrawler.FetchFilesRecursively(dataPath, "prefab");

      foreach(string location in prefabLocations) {
        string loc = location.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
        GameObject go = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(loc);
        if(go != null) {
          fetchSpritesFromGameObject(go, loc);
        }
      }
    }

    private void fetchSpritesFromScenes() {
      List<string> sceneLocations = FileCrawler.FetchFilesRecursively(dataPath, "unity");

      foreach(string location in sceneLocations) {
        string loc = location.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
        Scene currentScene = SceneManager.OpenScene(loc, UnityEditor.SceneManagement.OpenSceneMode.Additive);
        fetchSpritesFromScene(currentScene);
        SceneManager.CloseScene(currentScene, true);
      }
    }

    private void fetchSpritesFromGameObject(GameObject go, string location) {
      UISprite[] sprites = go.GetComponentsInChildren<UISprite>(true);
      if(sprites != null) {
        foreach(UISprite sprite in sprites) Info.AddSprite(sprite, location);
      }
    }

    private void fetchSpriteWithScenePath(string currentPath, GameObject sceneObject) {
      foreach (UISprite sprite in sceneObject.GetComponents<UISprite>()) {
        Info.AddSprite(sprite, currentPath);
      }
      for (int i = 0; i < sceneObject.transform.childCount; i++) {
        fetchSpriteWithScenePath(
          Formatter.ExtendPathWithGameObject(currentPath, sceneObject),
          sceneObject.transform.GetChild(i).gameObject
        );
      }
    }

    private void fetchSpritesFromScene(Scene scene) {
      scene.GetRootGameObjects().ForEach((rootObject) => {
        fetchSpriteWithScenePath(Formatter.ScenePath(scene), rootObject);
      });
    }
    
    internal class Formatter {
      public static string SceneInScenePath = "[{0}] ";
      public static string ChildOfFormat = "{0} => {1}";

      public static string ScenePath(Scene scene) {
        return string.Format(SceneInScenePath, scene.name);
      }

      public static string ExtendPathWithGameObject(string currentPath, GameObject gameObject) {
        return string.Format(ChildOfFormat, currentPath, gameObject.name);
      }
    }
  }
}
