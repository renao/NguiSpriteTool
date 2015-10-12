using System.Collections.Generic;

namespace Neo.Unity.NGUI.Models {
  public class AtlasSpriteInfo {

    private Dictionary<UIAtlas, AtlasUsages> atlasses;
    private List<SpriteIssue> issues;

    public AtlasSpriteInfo() {
      atlasses = new Dictionary<UIAtlas, AtlasUsages>();
      issues = new List<SpriteIssue>();
    }

    public void AddSprite(UISprite Sprite, string PrefabLocation) {
      if(Sprite.atlas == null) {
        Issues.Add(new SpriteIssue(Sprite, UISpriteInconsistence.AtlasNotFound, PrefabLocation));
      } else {
        if(!atlasses.ContainsKey(Sprite.atlas)) {
          atlasses[Sprite.atlas] = new AtlasUsages(Sprite.atlas);
        }
        atlasses[Sprite.atlas].Add(Sprite, PrefabLocation);
      }
    }

    public List<UIAtlas> Atlasses { get { return new List<UIAtlas>(atlasses.Keys); } }
    public AtlasUsages GetAtlasDataFor(UIAtlas atlas) { return atlasses[atlas]; }
    public List<SpriteIssue> Issues { get { return issues; } }
  }
}
