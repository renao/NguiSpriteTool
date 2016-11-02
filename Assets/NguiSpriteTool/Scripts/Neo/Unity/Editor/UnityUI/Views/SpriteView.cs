using UnityEditor;
using Neo.Unity.UnityUI.Models;

namespace Neo.Unity.UnityUI.Views {
  public class SpriteView {

    private SpriteUsage spriteInfo;

    public SpriteView(SpriteUsage spriteInfo) {
      this.spriteInfo = spriteInfo;
    }

    public void Draw() {
      EditorGUILayout.BeginVertical();
      EditorGUI.indentLevel += 1;

      EditorGUILayout.Foldout(true, spriteInfo.Sprite.name);

        foreach(string spriteReference in spriteInfo.SpriteReferences) {
          EditorGUILayout.SelectableLabel(spriteReference);
        }

      EditorGUI.indentLevel -= 1;
      EditorGUILayout.EndVertical();
    }
  }
}
