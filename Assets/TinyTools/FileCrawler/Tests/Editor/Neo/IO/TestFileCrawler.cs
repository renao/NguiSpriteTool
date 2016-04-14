using NUnit.Framework;
using System.Collections.Generic;
using Neo.IO;

namespace Tests.Neo.IO {

  public class TestFileCrawler {

    /*
    * TODO:   I know it's ugly, but this is the current test setup:
    *
    * Folder: C:\temp\TestFolder\ > Main test folder.
    * File:   C:\temp\TestFolder\a.prefab
    * File:   C:\temp\TestFolder\noprefab
    * File:   C:\temp\TestFolder\SubFolder\b.prefab
    * File:   C:\temp\TestFolder\SubFolder\noprefab
    */


    [Test]
    public void ReturnsAllFilesWithoutGivenFileExtension() {
      List<string> prefabs = FileCrawler.FetchFilesRecursively(absoluteTestFolderPath);

      Assert.IsNotNull(prefabs);
      Assert.AreEqual(4, prefabs.Count);

      assertContains(prefabs, @"C:\temp\TestFolder\SubFolder\b.prefab");
      assertContains(prefabs, @"C:\temp\TestFolder\a.prefab");
      assertContains(prefabs, @"C:\temp\TestFolder\SubFolder\noprefab");
      assertContains(prefabs, @"C:\temp\TestFolder\noprefab");
    }


    [Test]
    public void LooksForFilesWithPrefabExtension() {
      List<string> prefabs = FileCrawler.FetchFilesRecursively(absoluteTestFolderPath, "prefab");

      Assert.IsNotNull(prefabs);
      Assert.AreEqual(2, prefabs.Count);

      Assert.AreEqual(@"C:\temp\TestFolder\SubFolder\b.prefab", prefabs[0]);
      Assert.AreEqual(@"C:\temp\TestFolder\a.prefab",  prefabs[1]);
    }

    private void assertContains(List<string> collection, string expected) {
      Assert.True(collection.Contains(expected));
    }

    private string absoluteTestFolderPath {
      get { return @"C:\temp\TestFolder"; }
    }
  }
}
