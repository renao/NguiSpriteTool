using NUnit.Framework;
using Neo.Unity.NGUI;
using Tests.Neo.Unity.Analysis;

namespace Tests.Neo.Unity.NGUI {
  public class TestSpriteTool : TestComponentTool {

    [SetUp]
    public override void SetUp() {
      tool = new SpriteTool(UnityEngine.Application.dataPath + @"\NguiSpriteTool\Tests\Editor\Prefabs");
    }
  }
}
