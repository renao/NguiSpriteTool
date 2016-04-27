using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Neo.IO;
using Neo.Unity.Analysis.Models;
using Neo.Unity.Analysis.Formatters;
using Neo.Unity.Analysis;
using NUnit.Framework;

namespace Tests.Neo.Unity.Analysis {
  public class TestComponentTool {

    protected ComponentTool<UISprite> tool;

    [SetUp]
    public virtual void SetUp() {
      tool = new ComponentTool<UISprite>(Application.dataPath + @"\NguiSpriteTool\Tests\Editor\Prefabs");
    }

    [Test]
    public void InitsCorrectly() {
      Assert.NotNull(tool);
      Assert.NotNull(tool.Info);
    }

    [Test]
    public void GetsSpriteAndAtlasInfo() {
      tool.FetchComponentInfo();

      // tool.GetSpriteUsages();

      // Assert.AreEqual(1, tool.Info.Atlasses.Count);


      /*
      TODO: Make this work.
        
      Assert.AreEqual(1, tool.Atlas.Count);
      Assert.AreEqual(1, tool.Sprites.Count);

      Assert.AreEqual("TestAtlas", tool.Atlas[0].name);
      Assert.AreEqual("blue", tool.Sprites[tool.Atlas[0]][0].spriteName);

      Assert.AreEqual(1, tool.Prefabs[tool.Sprites[tool.Atlas[0]][0]].Count);
      Assert.AreEqual(@"Assets\NguiSpriteTool\Tests\Editor\Prefabs\AnotherSpriteObjectWithBlueSprite.prefab", tool.Prefabs[tool.Sprites[tool.Atlas[0]][0]][0]);
      Assert.Fail("Add missing two sprite assertions and extend with structure for atlas, sprite and prefabs");
      */
    }

    [Test]
    public void ExecutesCallback() {
      tool.FetchComponentInfo(Assert.Pass);
      Assert.Fail();
    }

    internal class TestComponent : Component { }
  }
}
