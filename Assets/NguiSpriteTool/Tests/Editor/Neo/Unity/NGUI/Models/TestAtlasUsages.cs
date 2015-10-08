using NUnit.Framework;
using Neo.Unity.NGUI.Models;

namespace Tests.Neo.Unity.NGUI.Models {
  public class TestAtlasUsages {

    private UIAtlas atlas;
    private UISprite sprite;
    private AtlasUsages usages;

    [SetUp]
    public void SetUp() {
      atlas = new UIAtlas();
      sprite = new UISprite() {
        atlas = atlas,
        spriteName = "testSprite"
      };
      usages = new AtlasUsages(atlas);
    }

    [Test]
    public void InitsCorrectly() {
      Assert.NotNull(usages);
      Assert.AreEqual(atlas, usages.Atlas);
      Assert.NotNull(usages.SpriteInfo);
      Assert.AreEqual(0, usages.SpriteInfo.Count);
    }

    [Test]
    public void AddSpriteUsage() {
      usages.Add(sprite, "firstLocation");
      Assert.AreEqual(1, usages.SpriteInfo.Count);
      Assert.AreEqual(1, usages.SpriteInfo[sprite.spriteName].PrefabLocation.Count);

      usages.Add(sprite, "secondLocation");
      Assert.AreEqual(1, usages.SpriteInfo.Count);
      Assert.AreEqual(2, usages.SpriteInfo[sprite.spriteName].PrefabLocation.Count);
    }
  }
}
