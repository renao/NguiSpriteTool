using NUnit.Framework;
using Neo.IO;
using System.IO;

namespace Tests.Neo.IO {

  [TestFixture]
  public class TestsPathCombiner {

    [Test]
    public void CombinesPartsToQualifiedPath() {
      string part1 = "first";
      string part2 = "second";
      string part3 = "last.cs";

      string expected = Path.Combine(Path.Combine(part1, part2), part3);
      Assert.AreEqual(expected, PathCombiner.Combine(part1, part2, part3));
    }
  }
}
