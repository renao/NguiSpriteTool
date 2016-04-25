using UnityEngine;
using Neo.UI;
using NUnit.Framework;

namespace Tests.Neo.UI {

  [TestFixture]
  public class TestColorizer {

    private Color black, gray, white;
    private Color32 byteBlack, byteGray, byteWhite;


    [SetUp]
    public void SetUp() {
      black = Color.black;
      gray = Color.gray;
      white = Color.white;

      byteBlack = new Color32(0, 0, 0, 255);
      byteGray = new Color32(128, 128, 128, 255);
      byteWhite = new Color32(255, 255, 255, 255);
    }

    [Test]
    public void InvertsColors() {
      Assert.AreEqual(Color.white, Colorizer.Invert(black));
      Assert.AreEqual(Color.gray,  Colorizer.Invert(gray));
      Assert.AreEqual(Color.black, Colorizer.Invert(white));
    }

    [Test]
    public void InvertsByteColors() {
      Assert.AreEqual(byteWhite, Colorizer.Invert(byteBlack));
      Assert.AreEqual(new Color32(127, 127, 127, 255), Colorizer.Invert(byteGray));
      Assert.AreEqual(byteBlack, Colorizer.Invert(byteWhite));
    }
  }
}
