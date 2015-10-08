using NUnit.Framework;
using Neo.Unity.NGUI.Models;

namespace Tests.Neo.Unity.NGUI.Models {
  public class TestSpriteUsages {

    private UISprite sprite;
    private SpriteUsages usages;

    [SetUp]
    public void SetUp() {
      sprite = new UISprite();
      usages = new SpriteUsages(sprite);
    }

    [Test]
    public void InitsCorrectly() {
      Assert.NotNull(usages);
      Assert.AreEqual(sprite, usages.sprite);
      Assert.AreEqual(0, usages.PrefabLocation.Count);
    }

    [Test]
    public void AddsPrefabPathsCorrectly() {
      usages.Add("firstLocation");
      usages.Add("secondLocation");

      Assert.AreEqual(2, usages.PrefabLocation.Count);
      Assert.AreEqual("firstLocation", usages.PrefabLocation[0]);
      Assert.AreEqual("secondLocation", usages.PrefabLocation[1]);
    }
  }
}
