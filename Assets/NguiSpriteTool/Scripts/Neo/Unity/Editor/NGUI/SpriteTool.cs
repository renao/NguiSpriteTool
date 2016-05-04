using UnityEngine;
using System.Collections.Generic;
using Neo.Unity.Analysis;
using Neo.Unity.Analysis.Models;
using Neo.Unity.Analysis.Models.Base;

namespace Neo.Unity.NGUI {
  public class SpriteTool : ComponentTool<UISprite> {

    public List<UIAtlasInfo> AtlasInfos { get; private set; }

    public SpriteTool(string dataPath=null) {
      this.dataPath = dataPath ?? Application.dataPath;
      this.AtlasInfos = new List<UIAtlasInfo>();
    }

    protected override ComponentInfo<UISprite> createComponentInfo(UISprite component, string path) {
      if (component != null && component.atlas != null) {
        daddInfosToAtlasInfo(component, path);
      }

      return new UISpriteInfo(component, path);
    }

    private void daddInfosToAtlasInfo(UISprite sprite, string location) {
      UIAtlasInfo atlasInfo = AtlasInfos.Find((ai) => ai.Component == sprite.atlas);

      if (atlasInfo == null) {
        atlasInfo = new UIAtlasInfo(sprite.atlas, location);
        AtlasInfos.Add(atlasInfo);
      }

      atlasInfo.AddAtlasSpriteInfo(new UISpriteInfo(sprite, location));
    }
  }
}
