using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Neo.IO;
using Neo.Unity.Analysis.Models.Base;
using Neo.Unity.Analysis.Formatters;

namespace Neo.Unity.Analysis {
  public class ComponentTool<T> where T : Component {

    public ComponentInfoList<T> Info {get; protected set; }

    internal string dataPath;
    internal ComponentInfoFormatter formatter;


    public ComponentTool(string dataPath=null) {
      Info = new ComponentInfoList<T>();
      this.dataPath = dataPath ?? Application.dataPath;
      formatter = new ComponentInfoFormatter();
    }

    public void FetchComponentInfo(Action Callback=null) {
      fetchComponents();
      if(Callback != null) Callback();
    }

    protected virtual ComponentInfo<T> createComponentInfo(T component, string path) {
      return new ComponentInfo<T>(component, path);
    }

    private void fetchComponents() {
      fetchComponentsFromPrefabs();
      fetchComponentsFromScene();
    }

    private void fetchComponentsFromPrefabs() {
      List<string> prefabLocations = FileCrawler.FetchFilesRecursively(dataPath, "prefab");
      foreach(string location in prefabLocations) {
        string loc = relativePath(location);
        GameObject go = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(loc);
        if(go != null) {
          fetchComponentsFromGameObject(go, loc);
        }
      }
    }

    private void fetchComponentsFromScene() {
      List<string> sceneLocations = FileCrawler.FetchFilesRecursively(dataPath, "unity");
      foreach(string location in sceneLocations) {
        Scene currentScene = EditorSceneManager.OpenScene(relativePath(location), OpenSceneMode.Additive);
        fetchComponentsFromScene(currentScene);
        EditorSceneManager.CloseScene(currentScene, true);
      }
    }

    private void fetchComponentsFromGameObject(GameObject go, string location) {
      T[] components = go.GetComponentsInChildren<T>(true);
      if(components != null) {
        foreach(T component in components) {
          Info.Add(createComponentInfo(component as T, location));
        }
      }
    }

    private void fetchComponentsFromScene(Scene scene) {
      scene.GetRootGameObjects().ForEach((rootObject) => {
        fetchComponentsWithScenePath(formatter.ScenePath(scene), rootObject);
      });
    }

    private void fetchComponentsWithScenePath(string currentPath, GameObject sceneObject) {
      foreach(T component in sceneObject.GetComponents<T>()) {
        Info.Add(createComponentInfo(component, currentPath));
      }
      for(int i = 0; i < sceneObject.transform.childCount; i++) {
        fetchComponentsWithScenePath(
          formatter.AddChildToPath(currentPath, sceneObject),
          sceneObject.transform.GetChild(i).gameObject
        );
      }
    }

    private string relativePath(string absolutePath) {
      return absolutePath.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
    }
  }
}
