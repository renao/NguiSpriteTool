using NUnit.Framework;
using UnityEngine;
using Neo.Unity.SpriteTool.Models.NGUI;

namespace Tests.Neo.Unity.NGUI.Models {
  public class TestAtlasUsages {

    private UIAtlas atlas;
    private UISprite sprite;
    private AtlasUsages usages;

    [SetUp]
    public void SetUp() {
      GameObject go = new GameObject();
      atlas = go.AddComponent<UIAtlas>();
      sprite = go.AddComponent<UISprite>();
      sprite.atlas = atlas;
      sprite.spriteName = "testSprite";

      UISpriteData[] spriteDatas = new UISpriteData[] {
        new UISpriteData() {
          name = "available"
        },
        new UISpriteData() {
          name = "unused"
        }
      };

      sprite.spriteName = "available";
      atlas.spriteList.AddRange(spriteDatas);

      usages = new AtlasUsages(atlas);
    }

    [Test]
    public void InitsCorrectly() {
      Assert.NotNull(usages);
      Assert.AreEqual(atlas, usages.Atlas);
      Assert.NotNull(usages.UsedSprites);
      Assert.AreEqual(0, usages.UsedSprites.Count);
    }

    [Test]
    public void AddSpriteUsage() {
      usages.Add(sprite, "firstLocation");
      Assert.AreEqual(1, usages.UsedSprites.Count);
      Assert.AreEqual(1, usages.UsedSprites[sprite.spriteName].PrefabLocation.Count);

      usages.Add(sprite, "secondLocation");
      Assert.AreEqual(1, usages.UsedSprites.Count);
      Assert.AreEqual(2, usages.UsedSprites[sprite.spriteName].PrefabLocation.Count);
    }

    [Test]
    public void GetUnusedSprites() {
      Assert.AreEqual(2, usages.UnusedSprites.Count);
      Assert.AreEqual(0, usages.UsedSprites.Count);

      usages.Add(sprite, "someLocation");
      Assert.AreEqual(1, usages.UnusedSprites.Count);
      Assert.AreEqual(1, usages.UsedSprites.Count);

      Assert.True(usages.UsedSprites.ContainsKey("available"));
      Assert.True(usages.UnusedSprites.Contains("unused"));
    }

  }
}
