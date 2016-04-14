namespace Neo.Unity.NGUI.Models {
  public class SpriteIssue {

    public UISprite Sprite;
    public UISpriteInconsistence Inconsistence;
    public string PrefabLocation;

    public SpriteIssue(UISprite sprite, UISpriteInconsistence inconsistence, string location) {
      Sprite = sprite;
      Inconsistence = inconsistence;
      PrefabLocation = location;
    }
  }

  public enum UISpriteInconsistence {
    AtlasNotFound,
    NoAtlasMember
  }
}