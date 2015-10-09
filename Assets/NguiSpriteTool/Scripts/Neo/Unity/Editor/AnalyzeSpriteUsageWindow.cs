using UnityEditor;
using UnityEngine;
using Neo.Unity.NGUI;
using System.Collections.Generic;

namespace Neo.Unity.Editor {
  public class AnalyzeSpriteUsageWindow : EditorWindow {

    [MenuItem("Neo/NGUI/Sprite Overview")]
    public static void ShowWindow() {
      AnalyzeSpriteUsageWindow currentWindow = GetWindow<AnalyzeSpriteUsageWindow>();
      currentWindow.titleContent.text = "Sprite Overview";
      currentWindow.titleContent.image = AssetDatabase.LoadAssetAtPath<Texture>(@"Assets\NguiSpriteTool\Tests\Editor\Prefabs\NguiElements\ExampleTextures\blue.png");
    }

    private bool pendingAnalyzation = false;
    private Dictionary<string, AtlasListView> atlasViews = new Dictionary<string, AtlasListView>();
    private int selectedIndex = 0;
    private string[] atlasSelection = new string[0];

    private SpriteTool spriteTool;
    private Vector2 currentScrollPosition = Vector2.zero;

    void OnGUI() {
      EditorGUILayout.Separator();
      currentScrollPosition = EditorGUILayout.BeginScrollView(currentScrollPosition);
      drawAtlasList();
      drawHeader();
      EditorGUILayout.EndScrollView();
    }

    private void drawHeader() {
      EditorGUI.BeginDisabledGroup(pendingAnalyzation);
        GUILayout.Label("Click the button to start Sprite analyzation.");
        GUILayout.Space(20);
        if(pendingAnalyzation) drawSuspender();
        else if(GUILayout.Button("Check sprite usage")) startAnalyzation();
      EditorGUI.EndDisabledGroup();
    }

    private void drawSuspender() {
      GUILayout.Space(10);
      GUILayout.Label("Please wait ...");
      GUILayout.Space(20);
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

    private void startAnalyzation() {
      pendingAnalyzation = true;
      spriteTool = new SpriteTool();
      spriteTool.GetSpriteUsages(onSpritesReady);
    }

    private void onSpritesReady() {
      pendingAnalyzation = false;
      selectedIndex = 0;
      atlasSelection = new string[spriteTool.Info.Atlasses.Count];

      int i = 0;
      foreach(UIAtlas atlas in spriteTool.Info.Atlasses) {
        atlasSelection[i] = atlas.name;
        atlasViews[atlas.name] = new AtlasListView(spriteTool.Info.GetAtlasDataFor(atlas));
        i++;
      }
    }
  }
}
