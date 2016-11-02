using UnityEditor;
using System.Collections.Generic;
using Neo.Unity.SpriteTool.Models.NGUI;

namespace Neo.Unity.NGUI.Views.SpriteTool {
  public class AtlasListView {

    private AtlasUsages atlasUsage;
    private bool showsAtlasList = false;
    private bool showsUnusedList = false;


    private Dictionary<UISprite, AtlasListSpriteView> spriteViews = new Dictionary<UISprite, AtlasListSpriteView>();

    public AtlasListView(AtlasUsages UsageInfo) {
      atlasUsage = UsageInfo;
      foreach(SpriteLink usage in atlasUsage.UsedSprites.Values) {
        spriteViews[usage.sprite] = new AtlasListSpriteView(usage);
      }
    }

    public void Draw() {
      EditorGUILayout.Separator();

      showsUnusedList = EditorGUILayout.Foldout(showsUnusedList, "Not linked [" + atlasUsage.UnusedSprites.Count + "]");
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
      showsAtlasList = EditorGUILayout.Foldout(showsAtlasList, "Linked [" + atlasUsage.UsedSprites.Count + "]");
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
