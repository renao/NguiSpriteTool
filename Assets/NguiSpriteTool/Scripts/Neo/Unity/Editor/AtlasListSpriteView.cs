using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Neo.Unity.Editor {
  public class AtlasListSpriteView {

    private UISprite sprite;
    private List<string> prefabs;
    private bool showsSpriteList = false;

    public AtlasListSpriteView(UISprite Sprite, List<string> Prefabs) {
      sprite = Sprite;
      prefabs = Prefabs;
    }

    public void Draw(bool enabled=true) {
      showsSpriteList = EditorGUILayout.Foldout(showsSpriteList, sprite.spriteName +  "[" + prefabs.Count + "]");
      if(showsSpriteList) {
        drawPrefabInfos();
      }
    }

    private void drawPrefabInfos() {
      EditorGUI.indentLevel += 1;
      foreach(string prefab in prefabs) {
        GUILayout.BeginVertical();
          EditorGUILayout.LabelField(prefab);
          GUI.DrawTexture(textureRect, spriteTexture);
          EditorGUILayout.Separator();
        GUILayout.EndVertical();
      }
      EditorGUI.indentLevel -=1;
    }
    private Texture spriteTexture {
      get {
        Texture2D tex = sprite.mainTexture as Texture2D;
        return tex;
      }
    }

    private Rect textureRect {
      get {
        Rect rect = new Rect();
        rect.height = sprite.height;
        rect.width = sprite.width;
        return rect;
      }
    }
  }
}
