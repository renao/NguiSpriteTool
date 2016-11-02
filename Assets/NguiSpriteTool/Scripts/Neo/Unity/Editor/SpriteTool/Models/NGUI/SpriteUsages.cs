using Neo.Collections;

namespace Neo.Unity.SpriteTool.Models.NGUI {
  public class SpriteUsages {
    public UISprite sprite;
    public List<string> PrefabLocation;

    public SpriteUsages(UISprite sprite) {
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
