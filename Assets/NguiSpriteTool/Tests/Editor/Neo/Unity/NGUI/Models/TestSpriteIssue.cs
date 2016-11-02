using Neo.Unity.SpriteTool.Models.NGUI;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Neo.Unity.NGUI.Models {
  public class TestSpriteInconsistencies {

    private UISprite sprite;
    private SpriteIssue issue;

    [SetUp]
    public void SetUp() {
      GameObject go = new GameObject();
      sprite = go.AddComponent<UISprite>();
      issue = new SpriteIssue(sprite, UISpriteInconsistence.AtlasNotFound, "some location");
    }

    [Test]
    public void StoresIssue() {
      Assert.AreEqual(sprite, issue.Sprite);
      Assert.AreEqual(UISpriteInconsistence.AtlasNotFound, issue.Inconsistence);
      Assert.AreEqual("some location", issue.PrefabLocation);
    }
  }
}
