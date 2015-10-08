using NUnit.Framework;
using Neo.Unity.NGUI.Models;

namespace Tests.Neo.Unity.NGUI.Models {
  public class TestAtlasSpriteInfo{

    private AtlasSpriteInfo info;

    [SetUp]
    public void SetUp() {
      info = new AtlasSpriteInfo();
    }

    [Test]
    public void InitsCorrectly() {
      Assert.NotNull(info);
      Assert.NotNull(info.Atlasses);
      Assert.AreEqual(0, info.Atlasses.Count);
    }

    [Test]
    public void AddsSprite() {
      UIAtlas testAtlas = new UIAtlas();

      UISprite sprite = new UISprite() {
        spriteName = "spriteName",
        atlas = testAtlas
      };

      Assert.NotNull(sprite);
      Assert.NotNull(sprite.atlas);
      Assert.NotNull(sprite.atlas.name);

      info.AddSprite(sprite, "location");
      Assert.AreEqual(1, info.Atlasses.Count);
      
      info.AddSprite(sprite, "location2");
      Assert.AreEqual(1, info.Atlasses.Count);
    }

  }
}
