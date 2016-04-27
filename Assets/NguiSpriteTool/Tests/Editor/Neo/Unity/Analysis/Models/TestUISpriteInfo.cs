using NUnit.Framework;
using Neo.Unity.Analysis.Models;
using Tests.Neo.Unity.Analysis.Models.Base;

namespace Tests.Neo.Unity.Analysis.Models {
  public class TestUISpriteInfo : BaseComponentInfoTest<UISprite> {

    [SetUp]
    public override void SetUp() {
      component = new UISprite();
      location = "UISpriteLocation";
      info = new UISpriteInfo(component, location);
    }
  }
}
