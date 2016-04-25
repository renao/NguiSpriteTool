using UnityEngine;

namespace Neo.UI {
  public class Colorizer {

    public static Color Invert(Color color) {
      return new Color(
          r: invertFloatColorComponent(color.r),
          g: invertFloatColorComponent(color.g),
          b: invertFloatColorComponent(color.b),
          a: color.a
        );
    }

    public static Color32 Invert(Color32 color) {
      return new Color32(
        r: invertByteColorComponent(color.r),
        g: invertByteColorComponent(color.g),
        b: invertByteColorComponent(color.b),
        a: color.a
      );
    }

    private static byte invertByteColorComponent(byte componentValue, byte componentMax=0xFF) {
      return (byte) (componentMax - componentValue);
    }

    private static float invertFloatColorComponent(float componentValue, float componentMax=1f) {
      return componentMax - componentValue;
    }
  }
}
