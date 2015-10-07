using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Neo.Unity.Editor {
  public class AtlasListView {

    private UIAtlas atlas;
    private List<UISprite> sprites;
    private Dictionary<UISprite, List<string>> prefabs;
    private bool showsAtlasList = true;

    private Dictionary<UISprite, AtlasListSpriteView> spriteViews = new Dictionary<UISprite, AtlasListSpriteView>();

    public AtlasListView(UIAtlas Atlas, List<UISprite> Sprites, Dictionary<UISprite, List<string>> Prefabs) {
      atlas = Atlas;
      sprites = Sprites;
      prefabs = Prefabs;

      sprites.Sort((a, b) => {
        return a.spriteName.CompareTo(b.spriteName);
      });

      
      foreach(UISprite sprite in sprites) {
        spriteViews[sprite] = new AtlasListSpriteView(sprite, prefabs[sprite]);
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
