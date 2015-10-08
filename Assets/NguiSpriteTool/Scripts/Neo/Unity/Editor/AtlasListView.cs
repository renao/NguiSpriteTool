using UnityEditor;
using System.Collections.Generic;
using Neo.Unity.NGUI.Models;

namespace Neo.Unity.Editor {
  public class AtlasListView {

    private UIAtlas atlas;
    private List<SpriteUsages> spriteUsages;
    private bool showsAtlasList = true;


    private Dictionary<UISprite, AtlasListSpriteView> spriteViews = new Dictionary<UISprite, AtlasListSpriteView>();

    public AtlasListView(UIAtlas Atlas, List<SpriteUsages> SpriteUsages) {
      atlas = Atlas;
      spriteUsages = SpriteUsages;
     
      foreach(SpriteUsages usage in spriteUsages) {
        spriteViews[usage.sprite] = new AtlasListSpriteView(usage);
      }
    }

    public void Draw(bool enabled=true) {
      showsAtlasList = EditorGUILayout.Foldout(showsAtlasList, atlas.name);
      if(showsAtlasList) {
        drawSprites();
      }
    }

    private void drawSprites() {
      EditorGUI.indentLevel = 1;
      foreach(AtlasListSpriteView view in spriteViews.Values) {
        view.Draw();
      }
      EditorGUI.indentLevel = 0;
    }
  }
}
