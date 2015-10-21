using UnityEditor;
using UnityEngine;
using Neo.Unity.NGUI.Models;

namespace Neo.Unity.Editor.Views.SpriteTool {
  public class AtlasListSpriteView {

    private SpriteLink spriteUsages;
    private bool showsSpriteList = false;

    public AtlasListSpriteView(SpriteLink SpriteUsages) {
      spriteUsages = SpriteUsages;
    }

    public void Draw(bool enabled=true) {
      showsSpriteList = EditorGUILayout.Foldout(showsSpriteList, spriteUsages.sprite.spriteName +  "[" + spriteUsages.PrefabLocation.Count + "]");
      if(showsSpriteList) {
        drawPrefabInfos();
      }
    }

    private void drawPrefabInfos() {
      EditorGUILayout.BeginVertical();
        EditorGUI.indentLevel += 1;
        foreach(string prefab in spriteUsages.PrefabLocation) {
          if (GUILayout.Button(new GUIContent(prefab), EditorStyles.miniButton)) {
            selectGameObjectAt(prefab);
          }
        }
      EditorGUI.indentLevel -=1;
      GUILayout.EndVertical();
    }

    private void selectGameObjectAt(string path) {
      Selection.activeGameObject = AssetDatabase.LoadAssetAtPath<GameObject>(path);
    }

  }
}
