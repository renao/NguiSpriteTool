using NUnit.Framework;
using Neo.Unity.Analysis.Models;
using UnityEngine;

namespace Tests.Neo.Unity.Analysis.Models {
  public class TestUIAtlasInfo {

    private UIAtlasInfo info;
    private UISpriteInfo spriteInfo;

    [SetUp]
    public void SetUp() {
      spriteInfo = createSpriteInfo();
      info = new UIAtlasInfo(spriteInfo.Sprite.atlas, "some_location");
    }

    [Test]
    public void InitsCorrectlyForAtlas() {
      Assert.AreEqual(spriteInfo.Atlas, info.Atlas);
      Assert.AreEqual(0, info.SpriteInfos.Count);
    }

    [Test]
    public void AddsSpriteInfo() {
      info.AddAtlasSpriteInfo(spriteInfo);

      Assert.AreEqual(1, info.SpriteInfos.Count);
      Assert.AreEqual(spriteInfo, info.SpriteInfos[0]);
    }

    private UISpriteInfo createSpriteInfo() {
      GameObject go = Resources.Load<GameObject>("ContainsSprite");
      return new UISpriteInfo(go.GetComponent<UISprite>(), "some_location");
    }
  }
}
