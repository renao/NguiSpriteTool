using UnityEditor;
using UnityEngine;
using Neo.UI;
using Neo.Unity.NGUI;
using Neo.Unity.Analysis.Models;
using System.Collections.Generic;
using System.Linq;

namespace Neo.Unity.Editor {
  public class SpriteToolWindow : EditorWindow {

    [MenuItem("Tools/NGUI/UISprite Usage")]
    public static void ShowWindow() {
      SpriteToolWindow currentWindow = GetWindow<SpriteToolWindow>();
      currentWindow.titleContent.image = Resources.Load<Texture>("NguiSpriteTool/sprite-overview-icon");
      currentWindow.titleContent.text = "UISprite Usage";
    }

    //private Dictionary<UIAtlas, AtlasListView> atlasViews = new Dictionary<UIAtlas, AtlasListView>();
    // private IssueListView issueListView;
    //private int selectedIndex = 0;
    //private UIAtlas[] atlasSelection = new UIAtlas[0];
    /*private string[] atlasNames {
      get {
        string[] names = new string[atlasSelection.Length];

        for (int i = 0; i < atlasSelection.Length; i++) {
          names[i] = atlasSelection[i].name;
        }

        return names;
      }
    }*/

    private int currentAtlasIndex = 0;
    private string[] currentAtlasNames = new string[0];
    private bool pendingAnalyzation = false;

    private SpriteTool spriteTool = new SpriteTool();
    private Vector2 currentScrollPosition = Vector2.zero;

    void OnGUI() {
      EditorGUILayout.Separator();
      currentScrollPosition = EditorGUILayout.BeginScrollView(currentScrollPosition);
      drawHeader();
      if (spriteTool != null) {
       drawAtlasList();
        // drawIssueList();
      }
      EditorGUILayout.EndScrollView();
    }

    private void drawSuspender() {
      GUILayout.Space(10);
      GUILayout.Label("Please wait.");
      GUILayout.Space(20);
    }

    /*
    private void drawIssueList() {
      if(issueListView != null) {
        issueListView.Draw();
      }
    }
    */

    private void drawAtlasList() {
      if(currentAtlasIndex < currentAtlasNames.Length) {
        EditorGUILayout.LabelField(string.Format("Select Atlas [{0} / {1}]", currentAtlasIndex + 1, spriteTool.SpriteInfos.Atlasses.Count));
        currentAtlasIndex = EditorGUILayout.Popup(currentAtlasIndex, currentAtlasNames);
      }
      /*
      foreach(Dictionary<string, List<UISpriteInfo>> spriteInfo in spriteTool.SpriteInfos.Atlasses[currentAtlasName].AtlasSpriteInfos) {
        // EditorGUILayout.LabelField(spriteInfo.Component.spriteName);
      }*/
    }
    /*
    private void drawAtlasList() {
      if(
        (selectedIndex < atlasSelection.Length)
        && atlasViews.ContainsKey(atlasSelection[selectedIndex])
      ) {
        selectedIndex = EditorGUILayout.Popup(selectedIndex, atlasNames);
        atlasViews[atlasSelection[selectedIndex]].Draw();
      }
    }
    */

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
      spriteTool.FetchComponentInfo(onFinished);
    }

    private void onFinished() {
      pendingAnalyzation = false;
      currentAtlasIndex = 0;
      UnityEngine.Debug.Log("TODO: Fix this.");
      currentAtlasNames = spriteTool.SpriteInfos.Atlasses.Keys.ToArray<string>();
      // selectedIndex = 0;
      // atlasSelection = new UIAtlas[spriteTool.SpriteInfo.UsedAtlasses.Count];
      // int i = 0;
      /*foreach (UIAtlas atlas in spriteTool.SpriteInfo.UsedAtlasses) {
        atlasSelection[i] = atlas;
        atlasViews[atlas] = new AtlasListView(atlas, (spriteTool.Info as UISpriteInfoList).UsedAtlasses[atlas]);
        i++;
      }*/
      // issueListView = new IssueListView(spriteTool.Info.Issues);
    }
  }
}
