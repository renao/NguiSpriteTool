using System.IO;

namespace Neo.IO {
  public class PathCombiner {

    public static string Combine(params string[] parts) {
      string path = string.Empty;
      for (int i = 0, imax = parts.Length; i < imax; i++) {
        path = Path.Combine(path, parts[i]);
      }
      return path;
    }
  }
}
