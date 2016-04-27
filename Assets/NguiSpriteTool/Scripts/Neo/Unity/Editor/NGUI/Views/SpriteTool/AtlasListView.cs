using UnityEditor;
using System.Collections.Generic;

namespace Neo.Unity.Editor.Views.SpriteTool {
  public class AtlasListView {

    private UIAtlas atlas;
    private List<UISprite> sprites;
    private bool showsAtlasList = false;
    private bool showsUnusedList = false;


    private Dictionary<UISprite, AtlasListSpriteView> spriteViews = new Dictionary<UISprite, AtlasListSpriteView>();

    public AtlasListView(UIAtlas atlas, List<UISprite> sprites) {
      this.atlas = atlas;
      this.sprites = sprites;
    }

    public void Draw() {
      EditorGUILayout.Separator();
      /*
      showsUnusedList = EditorGUILayout.Foldout(showsUnusedList, "Not linked [" + sprites.Count + "]");
      if(showsUnusedList) {
        EditorGUILayout.BeginVertical();
        EditorGUI.indentLevel += 1;

         foreach(string spriteName in atlasUsage.UnusedSprites) {
          EditorGUILayout.LabelField(spriteName);
        }
        EditorGUI.indentLevel -= 1;
        EditorGUILayout.EndVertical();
      }
      EditorGUILayout.Separator();
      */
      showsAtlasList = EditorGUILayout.Foldout(showsAtlasList, "Linked [" + sprites.Count + "]");
      if(showsAtlasList) {
        drawSprites();
      }
      EditorGUILayout.Separator();
    }

    private void drawSprites() {
      EditorGUI.indentLevel += 1;
      foreach(AtlasListSpriteView view in spriteViews.Values) {
        view.Draw();
      }
      EditorGUI.indentLevel -= 1;
    }
  }
}
