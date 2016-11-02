using Neo.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Neo.Unity.UnityUI.Models {
  public class SpriteUsage {
    
    public Sprite Sprite;
    public List<string> SpriteReferences;


    public SpriteUsage(Image image, string spriteReference) {
      SpriteReferences = new List<string>();
      Sprite = image.sprite;
      SpriteReferences.Add(spriteReference);
    }

    public void AddReference(string reference) {
      if (!SpriteReferences.Contains(reference)) {
        SpriteReferences.Add(reference);
      }
    }
  }
}
