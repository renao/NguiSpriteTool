﻿using System.Collections.Generic;
using Neo.IO;
using UnityEngine;

namespace Neo.Unity.NGUI {
  public class SpriteTool {

    public List<UIAtlas> Atlas = new List<UIAtlas>();
    public Dictionary<UIAtlas, List<UISprite>> Sprites = new Dictionary<UIAtlas, List<UISprite>>();
    public Dictionary<UISprite, List<string>> Prefabs = new Dictionary<UISprite, List<string>>();
    
    private FileCrawler crawler;

    public SpriteTool() {
      crawler = new FileCrawler(Application.dataPath);
    }

    public void GetSpriteUsages() {
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
    }
  }
}
