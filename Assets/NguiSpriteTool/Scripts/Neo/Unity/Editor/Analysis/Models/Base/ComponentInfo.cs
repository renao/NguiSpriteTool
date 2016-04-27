using UnityEngine;

namespace Neo.Unity.Analysis.Models.Base {
  public class ComponentInfo<T> where T : Component {
    public string Location;
    public T Component;

    public ComponentInfo(T component, string location) {
      Component = component;
      Location = location;
    }
  }
}
