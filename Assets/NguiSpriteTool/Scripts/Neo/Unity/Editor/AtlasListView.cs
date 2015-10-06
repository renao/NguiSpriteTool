using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Neo.Unity.Editor {
  public class AtlasListView : ScriptableObject {

    private UIAtlas atlas;
    private List<UISprite> sprites;
    private Dictionary<UISprite, List<string>> prefabs;
    private Vector2 scrollPosition = Vector2.zero;
    private bool unfolded = false;


    public AtlasListView(UIAtlas Atlas, List<UISprite> Sprites, Dictionary<UISprite, List<string>> Prefabs) {
      atlas = Atlas;
      sprites = Sprites;
      prefabs = Prefabs;
    }

    public void Draw(bool enabled=true) {
      // scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
      unfolded = EditorGUILayout.InspectorTitlebar(unfolded, this);

      if(unfolded) {
        drawSprites();
      }
      // EditorGUILayout.EndScrollView();
    }

    private void drawSprites() {
      foreach(UISprite sprite in sprites) {
        EditorGUILayout.PrefixLabel(sprite.spriteName);
        EditorGUILayout.IntField(prefabs[sprite].Count);
      }
    }
  }
}
