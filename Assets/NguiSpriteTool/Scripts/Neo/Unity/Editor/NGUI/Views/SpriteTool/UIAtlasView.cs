using UnityEditor;
using Neo.Unity.Analysis.Models;

namespace Neo.Unity.Editor.Views.SpriteTool {
  public class UIAtlasView {

    private UIAtlasUISpriteListView spriteListView;

    private UIAtlasInfo atlasInfo;
    private bool showAtlasSpriteList = false;

    public UIAtlasView(UIAtlasInfo atlasInfo) {
      this.atlasInfo = atlasInfo;
      initSubViews();
    }

    public void Draw() {
      EditorGUILayout.BeginVertical();

      showAtlasSpriteList = EditorGUILayout.Foldout(showAtlasSpriteList, "Bound UISprites [" + atlasInfo.SpriteInfos.Count + "]");

      if (showAtlasSpriteList) {
        spriteListView.Draw();
      }
      
      /* TODO: Add: Issues, Unused sprites */

      EditorGUILayout.EndVertical();
    }

    private void initSubViews() {
      spriteListView = new UIAtlasUISpriteListView(atlasInfo);
    }
  }
}
