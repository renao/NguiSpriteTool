using System.Collections.Generic;
using Neo.Unity.Analysis.Models.Base;
using Neo.Unity.Editor.Analysis.Models;

namespace Neo.Unity.Analysis.Models {
  public class UISpriteInfoList : ComponentInfoList<UISprite> {

    public Dictionary<string, UIAtlasInfo> Atlasses;


    public UISpriteInfoList() : base() {
      Atlasses = new Dictionary<string, UIAtlasInfo>();
    }


    public void Add(UISpriteInfo spriteInfo) {
      addAtlas(spriteInfo);
      base.Add(spriteInfo);
    }

    private void addAtlas(UISpriteInfo spriteInfo) {
      if(!Atlasses.ContainsKey(spriteInfo.Component.atlas.name)) {
        Atlasses[spriteInfo.Component.atlas.name] = new UIAtlasInfo(spriteInfo.Component.atlas);
      }
      Atlasses[spriteInfo.Component.atlas.name].AddSpriteInfo(spriteInfo);
    }

  }
}
