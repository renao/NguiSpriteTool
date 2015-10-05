using NUnit.Framework;
using Neo.Unity.NGUI;

namespace Tests.Neo.Unity.NGUI {
  public class TestSpriteTool {

    private SpriteTool tool;

    [SetUp]
    public void SetUp() {
      tool = new SpriteTool();
    }


    [Test]
    public void InitsCorrectly() {
      Assert.NotNull(tool);
      Assert.NotNull(tool.Atlas);
      Assert.NotNull(tool.Sprites);
      Assert.AreEqual(0, tool.Atlas.Count);
      Assert.AreEqual(0, tool.Sprites.Count);
    }

    [Test]
    public void GetsSpriteAndAtlasInfo() {
      tool.GetSpriteUsages();


      Assert.AreEqual(0, tool.Prefabs.Count);
      Assert.AreEqual(2, tool.Atlas.Count);
      Assert.AreEqual(2000, tool.Sprites.Count);
    }


  }
}
