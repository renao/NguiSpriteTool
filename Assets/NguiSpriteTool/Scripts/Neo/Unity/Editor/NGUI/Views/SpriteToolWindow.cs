using UnityEditor;
using UnityEngine;
using Neo.Collections;
using Neo.Unity.Editor.Views.SpriteTool;
using Neo.Unity.NGUI;

namespace Neo.Unity.Editor {
  public class SpriteToolWindow : EditorWindow {

    [MenuItem("Tools/NGUI/Sprites Overview")]
    public static void ShowWindow() {
      SpriteToolWindow currentWindow = GetWindow<SpriteToolWindow>();
      currentWindow.titleContent.image = Resources.Load<Texture>("NguiSpriteTool/sprite-overview-icon");
      currentWindow.titleContent.text = "Sprites";
    }

    private bool pendingAnalyzation = false;
    private Dictionary<string, AtlasListView> atlasViews = new Dictionary<string, AtlasListView>();
    private IssueListView issueListView;
    private int selectedIndex = 0;
    private string[] atlasSelection = new string[0];

    private SpriteTool spriteTool;
    private Vector2 currentScrollPosition = Vector2.zero;

    void OnGUI() {
      EditorGUILayout.Separator();
      currentScrollPosition = EditorGUILayout.BeginScrollView(currentScrollPosition);
      drawIssueList();
      drawAtlasList();
      drawHeader();
      EditorGUILayout.EndScrollView();
    }

    private void drawSuspender() {
      GUILayout.Space(10);
      GUILayout.Label("Please wait ...");
      GUILayout.Space(20);
    }

    private void drawIssueList() {
      if(issueListView != null) {
        issueListView.Draw();
      }
    }

    private void drawAtlasList() {
      if(
        (selectedIndex < atlasSelection.Length)
        && atlasViews.ContainsKey(atlasSelection[selectedIndex])
      ) {
        selectedIndex = EditorGUILayout.Popup(selectedIndex, atlasSelection);
        atlasViews[atlasSelection[selectedIndex]].Draw();
      }
    }

    private void drawHeader() {
      EditorGUI.BeginDisabledGroup(pendingAnalyzation);
      Color guiDefault = GUI.color;
      GUILayout.Label("Check UISprite usage inside your prefabs.");
      GUI.color = Color.green;
      GUILayout.Label("NOTE: Only static UISprites supported!");
      GUI.color = guiDefault;
      GUILayout.Space(20);
      if(pendingAnalyzation)
        drawSuspender();
      else if(GUILayout.Button("Analyze"))
        startAnalyzation();
      EditorGUI.EndDisabledGroup();
    }


    private void startAnalyzation() {
      pendingAnalyzation = true;
      spriteTool = new SpriteTool();
      spriteTool.GetSpriteUsages(onSpritesReady);
    }

    private void onSpritesReady() {
      pendingAnalyzation = false;
      selectedIndex = 0;
      atlasSelection = new string[spriteTool.Info.Atlasses.Count];
      issueListView = new IssueListView(spriteTool.Info.Issues);

      int i = 0;
      foreach(UIAtlas atlas in spriteTool.Info.Atlasses) {
        atlasSelection[i] = atlas.name;
        atlasViews[atlas.name] = new AtlasListView(spriteTool.Info.GetAtlasDataFor(atlas));
        i++;
      }
    }
  }
}
