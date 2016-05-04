using UnityEditor;
using UnityEngine;
using Neo.UI;
using Neo.Unity.NGUI;
using Neo.Unity.Analysis.Models;
using Neo.Unity.Editor.Views.SpriteTool;

namespace Neo.Unity.Editor {
  public class SpriteToolWindow : EditorWindow {

    [MenuItem("Tools/NGUI/UISprite Usage")]
    public static void ShowWindow() {
      SpriteToolWindow currentWindow = GetWindow<SpriteToolWindow>();
      currentWindow.titleContent.image = Resources.Load<Texture>("NguiSpriteTool/sprite-overview-icon");
      currentWindow.titleContent.text = "UISprite Usage";
    }

    private bool pendingAnalyzation = false;

    private int currentAtlasSelectionId = 0;
    private string[] currentAtlasNames = new string[0];
    private UIAtlasView[] atlasViews = new UIAtlasView[0];

    private SpriteTool spriteTool = new SpriteTool();
    private Vector2 currentScrollPosition = Vector2.zero;

    void OnGUI() {
      EditorGUILayout.Separator();
      currentScrollPosition = EditorGUILayout.BeginScrollView(currentScrollPosition);
      drawHeader();
      if (spriteTool != null && atlasViews != null && atlasViews.Length > 0) {
       drawAtlasList();
      }
      EditorGUILayout.EndScrollView();
    }

    private void drawSuspender() {
      GUILayout.Space(10);
      GUILayout.Label("Please wait.");
      GUILayout.Space(20);
    }

    private void drawAtlasList() {
      if(currentAtlasSelectionId < currentAtlasNames.Length) {
        EditorGUILayout.LabelField(string.Format("Select Atlas [{0}/{1}]", currentAtlasSelectionId + 1, spriteTool.AtlasInfos.Count));
        currentAtlasSelectionId = EditorGUILayout.Popup(currentAtlasSelectionId, currentAtlasNames);
        atlasViews[currentAtlasSelectionId].Draw();
      }
    }

    private void initAtlasViews() {
      atlasViews = new UIAtlasView[spriteTool.AtlasInfos.Count];

      int i = 0;
      foreach(UIAtlasInfo atlasInfo in spriteTool.AtlasInfos) {
        atlasViews[i] = new UIAtlasView(atlasInfo);
        i++;
      }
    }

    private void drawHeader() {
      EditorGUI.BeginDisabledGroup(pendingAnalyzation);
      Color guiDefault = GUI.color;
      GUILayout.Label("Analyze the usage of UISprite in this project.");
      GUI.color = Colorizer.Invert(GUI.backgroundColor);
      GUILayout.Label("NOTE: This tool does only support statically set UISprites from prefabs and scenes inside this project folder.");
      GUI.color = guiDefault;
      GUILayout.Space(20);
      if(pendingAnalyzation)
        drawSuspender();
      else if(GUILayout.Button("Analyze")) {
        onAnalyze();
      }
      EditorGUI.EndDisabledGroup();
    }


    private void onAnalyze() {
      pendingAnalyzation = true;
      spriteTool = new SpriteTool();
      spriteTool.FetchComponentInfo(onFinishedAnalyzation);
    }

    private void onFinishedAnalyzation() {
      pendingAnalyzation = false;
      currentAtlasSelectionId = 0;
      currentAtlasNames = spriteTool.AtlasInfos.ConvertAll(info => info.Component.name).ToArray();

      initAtlasViews();
    }
  }
}
