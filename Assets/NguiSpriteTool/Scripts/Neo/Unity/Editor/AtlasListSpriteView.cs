using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Neo.Unity.NGUI.Models;

namespace Neo.Unity.Editor {
  public class AtlasListSpriteView {

    private SpriteUsages spriteUsages;
    private bool showsSpriteList = false;

    public AtlasListSpriteView(SpriteUsages SpriteUsages) {
      spriteUsages = SpriteUsages;
    }

    public void Draw(bool enabled=true) {
      showsSpriteList = EditorGUILayout.Foldout(showsSpriteList, spriteUsages.sprite.spriteName +  "[" + spriteUsages.PrefabLocation.Count + "]");
      if(showsSpriteList) {
        drawPrefabInfos();
      }
    }

    private void drawPrefabInfos() {
      EditorGUI.indentLevel += 1;
      foreach(string prefab in spriteUsages.PrefabLocation) {
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
        Texture2D tex = spriteUsages.sprite.mainTexture as Texture2D;
        return tex;
      }
    }

    private Rect textureRect {
      get {
        Rect rect = new Rect();
        rect.height = spriteUsages.sprite.height;
        rect.width = spriteUsages.sprite.width;
        return rect;
      }
    }
  }
}
