using NUnit.Framework;
using UnityEngine;
using Neo.Unity.Analysis.Models;

namespace Tests.Neo.Unity.Analysis.Models.Base {
  public class BaseComponentInfoTest<T> where T : Component {

    protected ComponentInfo<T> info;
    protected string location;
    protected T component;

    [SetUp]
    public virtual void SetUp() {
      info = new ComponentInfo<T>(component, location);
    }

    [Test]
    public void InitsWithComponentsBaseInfos() {
      Assert.AreEqual(component, info.Component);
      Assert.AreEqual(location, info.Location);
    }
  }

  internal class TestComponent : Component {}
}
