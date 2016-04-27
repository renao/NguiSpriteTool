using Neo.Unity.Analysis.Models;
using UnityEditor;
using UnityEngine;

namespace Neo.Unity.Editor.Views.SpriteTool {
  public class AtlasListSpriteView {

    private UISpriteInfo spriteInfo;
    private bool showsSpriteList = false;

    public AtlasListSpriteView(UISpriteInfo spriteInfo) {
      this.spriteInfo = spriteInfo;
    }

    public void Draw(bool enabled=true) {
      showsSpriteList = EditorGUILayout.Foldout(showsSpriteList, spriteInfo.Component.spriteName);
      /*if(showsSpriteList) {
        drawPrefabInfos();
      }*/
    }
    /*
    private void drawPrefabInfos() {
      EditorGUILayout.BeginVertical();
        EditorGUI.indentLevel += 1;
        foreach(string prefab in spriteInfo.AtlasLocation) {
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
    */
  }
}
