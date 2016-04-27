using UnityEngine;
using Neo.Unity.Analysis;
using Neo.Unity.Analysis.Models;
using Neo.Unity.Analysis.Models.Base;

namespace Neo.Unity.NGUI {
  public class SpriteTool : ComponentTool<UISprite> {

    public UISpriteInfoList SpriteInfos {
      get {
        return Info as UISpriteInfoList;
      }
    }

    public SpriteTool(string dataPath=null) {
      this.Info = new UISpriteInfoList();
      this.dataPath = dataPath ?? Application.dataPath;
    }

    protected override ComponentInfo<UISprite> createComponentInfo(UISprite component, string path) {
      return new UISpriteInfo(component, path);
    }
  }
}
