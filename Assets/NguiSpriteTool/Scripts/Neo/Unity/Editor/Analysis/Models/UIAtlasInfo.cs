using System.Collections.Generic;
using Neo.Unity.Analysis.Models;

namespace Neo.Unity.Analysis.Models {
  public class UIAtlasInfo {
    public UIAtlas Atlas;
    public Dictionary<string, List<UISpriteInfo>> SpriteInfos;

    public UIAtlasInfo(UIAtlas atlas) {
      Atlas = atlas;
      SpriteInfos = new Dictionary<string, List<UISpriteInfo>>();
    }

    public void AddSpriteInfo(UISpriteInfo spriteInfo) {
      string spriteName = spriteInfo.Sprite.spriteName;
      if (Atlas.name != spriteInfo.Sprite.atlas.name) return;

      if (!SpriteInfos.ContainsKey(spriteName)) {
        SpriteInfos[spriteName] = new List<UISpriteInfo>();
      }
      SpriteInfos[spriteName].Add(spriteInfo);
    }
  }
}
