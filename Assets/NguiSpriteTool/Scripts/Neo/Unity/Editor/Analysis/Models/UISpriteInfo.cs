using Neo.Unity.Analysis.Models.Base;

namespace Neo.Unity.Analysis.Models {
  public class UISpriteInfo : ComponentInfo<UISprite> {

    public UIAtlas Atlas {
      get {
        return Sprite.atlas;
      }
    }
    public UISprite Sprite {
      get {
        return Component as UISprite;
      }
    }

    public UISpriteInfo(UISprite sprite, string location) : base(sprite, location) {}
  }
}
