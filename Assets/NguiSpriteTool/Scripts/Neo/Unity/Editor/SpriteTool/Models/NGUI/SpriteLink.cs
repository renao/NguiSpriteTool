using Neo.Collections;

namespace Neo.Unity.SpriteTool.Models.NGUI {
  public class SpriteLink {
    public UISprite sprite;
    public List<string> PrefabLocation;

    public SpriteLink(UISprite sprite) {
      this.sprite = sprite;
      PrefabLocation = new List<string>();
    }

    public void Add(string prefabLocation) {
      if(!PrefabLocation.Contains(prefabLocation)) {
        PrefabLocation.Add(prefabLocation);
      }
    }
  }
}
