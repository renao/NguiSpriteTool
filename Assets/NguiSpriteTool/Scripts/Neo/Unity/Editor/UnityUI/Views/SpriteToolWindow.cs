using UnityEditor;
using UnityEngine;
using Neo.UI;
using Neo.Unity.UnityUI.Models;
using Neo.Unity.UnityUI.Views;


namespace Neo.Unity.SpriteTool.UnityUI {
  public class SpriteToolWindow : EditorWindow {

    [MenuItem("Tools/Unity UI/Sprite Overview")]
    public static void ShowWindow() {
      SpriteToolWindow currentWindow = GetWindow<SpriteToolWindow>();
      currentWindow.titleContent.image = Resources.Load<Texture>("NguiSpriteTool/sprite-overview-icon");
      currentWindow.titleContent.text = "Sprite Overview";
    }

    private bool pendingAnalyzation = false;
    private Neo.Unity.UnityUI.SpriteTool spriteTool;
    private Vector2 currentScrollPosition = Vector2.zero;

    void OnGUI() {
      EditorGUILayout.Separator();
      currentScrollPosition = EditorGUILayout.BeginScrollView(currentScrollPosition);
      drawHeader();
      drawSpriteList();
      EditorGUILayout.EndScrollView();
    }

    private void drawSuspender() {
      GUILayout.Space(10);
      GUILayout.Label("Please wait.");
      GUILayout.Space(20);
    }

    private void drawHeader() {
      EditorGUI.BeginDisabledGroup(pendingAnalyzation);
      Color guiDefault = GUI.color;
      GUILayout.Label("Analyze the usage of Unity UI Sprites in this project.");
      GUI.color = Colorizer.Invert(GUI.backgroundColor);
      GUILayout.Label("NOTE: This tool does only support statically used Sprites from prefabs and scenes inside this project folder.");
      GUI.color = guiDefault;
      GUILayout.Space(20);
      if(pendingAnalyzation)
        drawSuspender();
      else if(GUILayout.Button("Search"))
        startAnalyzation();
      EditorGUI.EndDisabledGroup();
    }

    private void drawSpriteList() {
      if (spriteTool != null) {
        foreach(SpriteUsage spriteInfo in spriteTool.SpriteInfos) {
          new SpriteView(spriteInfo).Draw();
        }
      }
    }


    private void startAnalyzation() {
      pendingAnalyzation = true;
      spriteTool = new Neo.Unity.UnityUI.SpriteTool();
      spriteTool.GetSpriteUsages(onSpritesReady);
    }

    private void onSpritesReady() {
      pendingAnalyzation = false;
    }
  }
}
