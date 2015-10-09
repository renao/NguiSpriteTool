using UnityEngine;
using System;
using System.Collections.Generic;
using Neo.IO;
using Neo.Unity.NGUI.Models;


namespace Neo.Unity.NGUI {
  public class SpriteTool {

    public AtlasSpriteInfo Info;

    private FileCrawler crawler;

    public SpriteTool(string dataPath=null) {
      crawler = new FileCrawler(dataPath ?? Application.dataPath);
      Info = new AtlasSpriteInfo();
    }

    public void GetSpriteUsages(Action Callback=null) {
      fetchUsedSprites();
      if(Callback != null) Callback();
    }


    private void fetchUsedSprites() {
      List<string> prefabLocations = crawler.FetchFilesByExtension("prefab");

      foreach(string location in prefabLocations) {
        string loc = location.Replace(Application.dataPath + @"\", @"Assets\");
        GameObject go = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(loc);

        if(go != null) fetchSpritesFrom(go, loc);
      }
    }

    private void fetchSpritesFrom(GameObject go, string location) {
      UISprite[] sprites = go.GetComponentsInChildren<UISprite>(true);
      if(sprites != null) {
        foreach(UISprite sprite in sprites) Info.AddSprite(sprite, location);
      }
    }


  }
}
