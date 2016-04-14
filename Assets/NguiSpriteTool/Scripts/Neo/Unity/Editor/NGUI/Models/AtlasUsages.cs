using Neo.Collections;

namespace Neo.Unity.NGUI.Models {
  public class AtlasUsages {
    public UIAtlas Atlas;
    public Dictionary<string, SpriteLink> UsedSprites;
    public List<string> UnusedSprites;

    public AtlasUsages(UIAtlas Atlas) {
      this.Atlas = Atlas;
      UsedSprites = new Dictionary<string, SpriteLink>();

      initUnusedSprites();
    }

    public void Add(UISprite Sprite, string PrefabLocation) {
      if(!UsedSprites.ContainsKey(Sprite.spriteName)) {
        UsedSprites[Sprite.spriteName] = new SpriteLink(Sprite);
      }

      UsedSprites[Sprite.spriteName].Add(PrefabLocation);

      if(UnusedSprites.Contains(Sprite.spriteName)) {
        UnusedSprites.Remove(Sprite.spriteName);
      }
    }


    private void initUnusedSprites() {
      UnusedSprites = new List<string>();
      string[] sprites = Atlas.GetListOfSprites().ToArray();
      if(sprites != null && sprites.Length > 0) UnusedSprites.AddRange(sprites);
    }

  }
}
