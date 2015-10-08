using System.Collections.Generic;

namespace Neo.Unity.NGUI.Models {
  public class AtlasSpriteInfo {

    private Dictionary<UIAtlas, AtlasUsages> atlasses;


    public AtlasSpriteInfo() {
      atlasses = new Dictionary<UIAtlas, AtlasUsages>();
    }

    public void AddSprite(UISprite Sprite, string PrefabLocation) {
      if(!atlasses.ContainsKey(Sprite.atlas)) {
        atlasses[Sprite.atlas] = new AtlasUsages(Sprite.atlas);
      }       
      atlasses[Sprite.atlas].Add(Sprite, PrefabLocation);
    }

    public List<UIAtlas> Atlasses { get { return new List<UIAtlas>(atlasses.Keys); } }
    public List<SpriteUsages> GetSpriteUsagesFrom(UIAtlas atlas) { return new List<SpriteUsages>((atlasses[atlas].SpriteInfo.Values)); }
  }
}
