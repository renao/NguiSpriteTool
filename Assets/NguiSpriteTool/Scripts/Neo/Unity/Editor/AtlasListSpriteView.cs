using UnityEditor;
using UnityEngine;
using Neo.Unity.NGUI.Models;

namespace Neo.Unity.Editor {
  public class AtlasListSpriteView {

    private SpriteUsages spriteUsages;
    private bool showsSpriteList = false;
    private Vector2 scrollPosition = Vector2.zero;

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
      scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        EditorGUI.DrawPreviewTexture(textureRect, spriteTexture);
        EditorGUI.indentLevel += 1;
        foreach(string prefab in spriteUsages.PrefabLocation) {
          EditorGUILayout.LabelField(prefab);
        }
      EditorGUI.indentLevel -=1;
      GUILayout.EndScrollView();
    }
    private Texture spriteTexture {
      get {
        Texture2D tex = spriteUsages.sprite.mainTexture as Texture2D;
        return tex;
      }
    }

    private Rect textureRect {
      get {
        Rect rect = new Rect(
          x: 40,
          y: 0,
          width: 100,
          height: 100
          );
        return rect;
      }
    }
  }
}
