using NUnit.Framework;
using Neo.Unity.Analysis.Models;
using Tests.Neo.Unity.Analysis.Models.Base;
using UnityEngine;
using Neo.Collections;

namespace Tests.Neo.Unity.Analysis.Models {
  [TestFixture]
  public class TestUISpriteInfoList : BaseComponentInfoListTest<UISprite>{

    private List<GameObject> testObjects;

    [SetUp]
    public override void SetUp() {
      list = new UISpriteInfoList();
      testObjects = new List<GameObject>();
    }

    [Test]
    public void InitsAtlasStructure() {
      Assert.NotNull(spriteInfoList.Atlasses);
      Assert.AreEqual(0, spriteInfoList.Atlasses.Count);
    }

    [Test]
    public void MaintainsAtlasInfos() {
      UISpriteInfo spInfo = spriteInfo();
      spriteInfoList.Add(spInfo);

      Assert.AreEqual(1, spriteInfoList.Atlasses.Count);
      Assert.True(spriteInfoList.Atlasses.ContainsKey(spInfo.Sprite.atlas.name));
      Assert.NotNull(spriteInfoList.Atlasses[spInfo.Sprite.atlas.name]);
      Assert.AreEqual(1, spriteInfoList.Atlasses[spInfo.Sprite.atlas.name].SpriteInfos.Count);
    }

    private UISpriteInfo spriteInfo() {
      GameObject go = Resources.Load<GameObject>("ContainsSprite");
      testObjects.Add(go);

      UISprite sprite = go.GetComponent<UISprite>();
      return new UISpriteInfo(sprite, "some_location_info");
    }

    private UISpriteInfoList spriteInfoList {
      get {
        return list as UISpriteInfoList;
      }
    }
  }

}
