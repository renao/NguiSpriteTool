using NUnit.Framework;
using UnityEngine;
using Neo.Unity.Analysis.Models.Base;

namespace Tests.Neo.Unity.Analysis.Models.Base {
  public class BaseComponentInfoListTest<T> where T : Component {

    protected ComponentInfoList<T> list;

    [SetUp]
    public virtual void SetUp() {
      list = new ComponentInfoList<T>();
    }
  }
}
