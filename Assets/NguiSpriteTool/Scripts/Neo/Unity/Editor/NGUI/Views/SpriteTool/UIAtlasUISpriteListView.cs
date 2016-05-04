using System.Collections.Generic;
using Neo.Unity.Analysis.Models;

namespace Neo.Unity.Editor.Views.SpriteTool {
  public class UIAtlasUISpriteListView {

    private UIAtlasInfo atlasInfo;

    private Dictionary<UISprite, UISpriteView> spriteViews = new Dictionary<UISprite, UISpriteView>();

    public UIAtlasUISpriteListView(UIAtlasInfo atlasInfo) {
      this.atlasInfo = atlasInfo;
      initSubViews();
    }

    public void Draw() {
      foreach (UISpriteView view in spriteViews.Values) {
        view.Draw();
      }
    }

    private void initSubViews() {
      foreach (UISpriteInfo spriteInfo in atlasInfo.SpriteInfos) {
        spriteViews[spriteInfo.Sprite] = new UISpriteView(spriteInfo);
      }
    }
  }
}
