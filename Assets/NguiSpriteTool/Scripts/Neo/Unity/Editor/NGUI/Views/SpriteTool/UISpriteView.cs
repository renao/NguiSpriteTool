using Neo.Unity.Analysis.Models;
using UnityEditor;
using UnityEngine;

namespace Neo.Unity.Editor.Views.SpriteTool {
  public class UISpriteView {

    private UISpriteInfo spriteInfo;
    private bool showsSpriteList = false;

    public UISpriteView(UISpriteInfo spriteInfo) {
      this.spriteInfo = spriteInfo;
    }

    public void Draw() {
      showsSpriteList = EditorGUILayout.Foldout(showsSpriteList, spriteInfo.Component.spriteName);

      if(showsSpriteList) {
        drawSpriteInfo();
      }
    }

    private void drawSpriteInfo() {
      EditorGUILayout.BeginVertical();
      if (GUILayout.Button(new GUIContent(spriteInfo.Location, "Click to select containing prefab"), EditorStyles.toolbarButton)) {
        selectGameObjectAt(spriteInfo.Location);
      }
      GUILayout.EndVertical();
    }

    private void selectGameObjectAt(string path) {
      Selection.activeGameObject = AssetDatabase.LoadAssetAtPath<GameObject>(path);
    }

  }
}
