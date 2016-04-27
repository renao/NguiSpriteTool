using Neo.Collections;
using UnityEngine;

namespace Neo.Unity.Analysis.Models.Base {
  public class ComponentInfoList<T> : List<ComponentInfo<T>> where T : Component {}
}
