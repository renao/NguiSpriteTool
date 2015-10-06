using NUnit.Framework;
using Neo.Unity.NGUI;

namespace Tests.Neo.Unity.NGUI {
  public class TestSpriteTool {

    private SpriteTool tool;

    [SetUp]
    public void SetUp() {
      tool = new SpriteTool(UnityEngine.Application.dataPath + @"\NguiSpriteTool\Tests\Editor\Prefabs");
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

      Assert.AreEqual(1, tool.Prefabs.Count);
      Assert.AreEqual(1, tool.Atlas.Count);
      Assert.AreEqual(1, tool.Sprites.Count);

      Assert.AreEqual("TestAtlas", tool.Atlas[0].name);
      Assert.AreEqual("blue", tool.Sprites[tool.Atlas[0]][0].spriteName);

      Assert.AreEqual(1, tool.Prefabs[tool.Sprites[tool.Atlas[0]][0]].Count);
      Assert.AreEqual(@"Assets\NguiSpriteTool\Tests\Editor\Prefabs\SpriteObject.prefab", tool.Prefabs[tool.Sprites[tool.Atlas[0]][0]][0]);
    }

    [Test]
    public void ExecutesCallback() {
      tool.GetSpriteUsages(Assert.Pass);
      Assert.Fail();
    }


  }
}
