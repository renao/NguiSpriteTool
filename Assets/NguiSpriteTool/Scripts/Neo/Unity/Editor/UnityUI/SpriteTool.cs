using System;
using System.Collections.Generic;
using Neo.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Neo.Unity.SpriteTool.Helpers;
using Neo.Unity.UnityUI.Models;

using SceneManager = UnityEditor.SceneManagement.EditorSceneManager;

namespace Neo.Unity.UnityUI {
  public class SpriteTool {

    public List<SpriteUsage> SpriteInfos;
    private string dataPath;

    public SpriteTool(string dataPath=null) {
      SpriteInfos = new List<SpriteUsage>();
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
      Image[] images = go.GetComponentsInChildren<Image>(true);
      if(images != null) {
        foreach(Image image in images) {
          if (image.sprite != null) {
            addToCollection(image, location);
          }
          // TODO: if == null => Report broken sprite.
        }
      }
    }

    private void fetchSpriteWithScenePath(string currentPath, GameObject sceneObject) {
      foreach (Image image in sceneObject.GetComponents<Image>()) {
        addToCollection(image, currentPath);
      }
      for (int i = 0; i < sceneObject.transform.childCount; i++) {
        fetchSpriteWithScenePath(
          SpriteToolFormatter.AddChildToPath(currentPath, sceneObject),
          sceneObject.transform.GetChild(i).gameObject
        );
      }
    }

    private void fetchSpritesFromScene(Scene scene) {
      scene.GetRootGameObjects().ForEach((rootObject) => {
        fetchSpriteWithScenePath(SpriteToolFormatter.ScenePath(scene), rootObject);
      });
    }


    private void addToCollection(Image image, string location) {
      SpriteUsage spriteUsage = SpriteInfos.Find((info) => info.Sprite.name == image.sprite.name);

      if (spriteUsage == null) {
        SpriteInfos.Add(new SpriteUsage(image, location));
      } else {
        spriteUsage.AddReference(location);
      }
    }
  }
}
