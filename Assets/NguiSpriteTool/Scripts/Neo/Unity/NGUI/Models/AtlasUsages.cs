using System.Collections.Generic;

namespace Neo.Unity.NGUI.Models {
  public class AtlasUsages {
    public UIAtlas Atlas;
    public Dictionary<string, SpriteUsages> SpriteInfo;

    public AtlasUsages(UIAtlas Atlas) {
      this.Atlas = Atlas;
      SpriteInfo = new Dictionary<string, SpriteUsages>();
    }

    public void Add(UISprite Sprite, string PrefabLocation) {
      if(!SpriteInfo.ContainsKey(Sprite.spriteName)) {
        SpriteInfo[Sprite.spriteName] = new SpriteUsages(Sprite);
      }

      SpriteInfo[Sprite.spriteName].Add(PrefabLocation);
    }
  }
}
