using UnityEditor;
using System.Collections.Generic;
using Neo.Unity.SpriteTool.Models.NGUI;

namespace Neo.Unity.NGUI.Views.SpriteTool {
  public class IssueListView {

    private List<SpriteIssue> issues;
    private bool showsIssues = true;

    public IssueListView(List<SpriteIssue> Issues) {
      issues = Issues;
    }

    public void Draw() {
      showsIssues = EditorGUILayout.Foldout(showsIssues, "Issues [" + issues.Count + "]");
      if(showsIssues) {
        EditorGUILayout.BeginVertical();
        EditorGUI.indentLevel += 1;

        foreach(SpriteIssue issue in issues) {
          drawIssue(issue);
        }
        EditorGUI.indentLevel -= 1;
        EditorGUILayout.EndVertical();
      }

      EditorGUILayout.Separator();
    }

    private void drawIssue(SpriteIssue issue) {
      EditorGUI.indentLevel += 1;
      EditorGUILayout.BeginVertical();
      EditorGUILayout.LabelField(issue.Inconsistence.ToString());
      EditorGUILayout.LabelField(issue.Sprite.spriteName);
      EditorGUILayout.LabelField(issue.PrefabLocation);
      EditorGUILayout.EndVertical();
      EditorGUI.indentLevel -= 1;
    }
  }
}
