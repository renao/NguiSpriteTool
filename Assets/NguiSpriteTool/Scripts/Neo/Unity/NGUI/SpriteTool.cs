using System.Collections.Generic;
using System;
using UnityEngine;
using Neo.IO;


namespace Neo.Unity.NGUI {
  public class SpriteTool {

    public List<UIAtlas> Atlas = new List<UIAtlas>();
    public Dictionary<UIAtlas, List<UISprite>> Sprites = new Dictionary<UIAtlas, List<UISprite>>();
    public Dictionary<UISprite, List<string>> Prefabs = new Dictionary<UISprite, List<string>>();
    
    private FileCrawler crawler;

    public SpriteTool(string dataPath=null) {
      crawler = new FileCrawler(dataPath ?? Application.dataPath);
    }

    public void GetSpriteUsages(Action Callback=null) {
      List<string> prefabLocations = crawler.FetchFilesByExtension("prefab");

      foreach (string location in prefabLocations) {
        string loc = location.Replace(Application.dataPath + @"\", @"Assets\");
        GameObject go = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(loc);

        if(go != null) {
          UISprite sprite = go.GetComponent<UISprite>();
          if(sprite != null) {
            if (!Atlas.Contains(sprite.atlas)) Atlas.Add(sprite.atlas);
            if(!Sprites.ContainsKey(sprite.atlas)) {
              Sprites[sprite.atlas] = new List<UISprite>();
            }
            Sprites[sprite.atlas].Add(sprite);

            if(!Prefabs.ContainsKey(sprite)) {
              Prefabs[sprite] = new List<string>();
            }                                           
            Prefabs[sprite].Add(loc);
          }
        }
      }
      if(Callback != null) Callback();
    }
  }
}
