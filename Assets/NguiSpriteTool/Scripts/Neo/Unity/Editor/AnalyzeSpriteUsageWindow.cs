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
    private bool containsResults = false;
    private Dictionary<UIAtlas, AtlasListView> atlasViews = new Dictionary<UIAtlas, AtlasListView>();

    private SpriteTool spriteTool;
    private Vector2 currentScrollPosition = Vector2.zero;

    void OnGUI() {
      currentScrollPosition = EditorGUILayout.BeginScrollView(currentScrollPosition);
        drawHeader();
        if(containsResults) drawAtlasList();
      EditorGUILayout.EndScrollView();
    }

    private void drawHeader() {
      EditorGUI.BeginDisabledGroup(pendingAnalyzation);
        GUILayout.Label("Click the button to start Sprite analyzation.");
        GUILayout.Space(20);
        if(pendingAnalyzation) drawSuspender();
        else if(GUILayout.Button("Analyze Sprite usage")) startAnalyzation();
      EditorGUI.EndDisabledGroup();
    }

    private void drawSuspender() {
      GUILayout.Space(10);
      GUILayout.Label("Please wait ...");
      GUILayout.Space(20);
    }

    private void drawAtlasList() {
      foreach(AtlasListView view in atlasViews.Values) {
        view.Draw();
      }
    }

    private void startAnalyzation() {
      pendingAnalyzation = true;
      spriteTool = new SpriteTool();
      spriteTool.GetSpriteUsages(onSpritesReady);
    }

    private void onSpritesReady() {
      pendingAnalyzation = false;
      containsResults = true;

      foreach(UIAtlas atlas in spriteTool.Atlas) {
        atlasViews[atlas] = new AtlasListView(
          atlas,
          spriteTool.Sprites[atlas],
          spriteTool.Prefabs
        );
        atlasViews[atlas].Draw();
      }

      Repaint();
    }


  }
}
