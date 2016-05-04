using System.Collections.Generic;
using Neo.Unity.Analysis.Models.Base;

namespace Neo.Unity.Analysis.Models {
  public class UIAtlasInfo : ComponentInfo<UIAtlas> {

    public UIAtlas Atlas { get { return Component; } }
    public List<UISpriteInfo> SpriteInfos;

    public UIAtlasInfo(UIAtlas atlas, string location) : base(atlas, location) {
      Component = atlas;
      SpriteInfos = new List<UISpriteInfo>();
    }

    public void AddAtlasSpriteInfo(UISpriteInfo spriteInfo) {
      if (spriteInfo.Sprite.atlas == null) return;
      SpriteInfos.Add(spriteInfo);
    }
  }
}
