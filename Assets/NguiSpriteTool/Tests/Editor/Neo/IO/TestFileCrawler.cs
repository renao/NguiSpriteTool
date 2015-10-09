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

    private FileCrawler crawler;

    [SetUp]
    public void SetUp() {
      crawler = new FileCrawler(absoluteTestFolderPath);
    }

    [Test]
    public void Inits() {
      Assert.IsNotNull(crawler);
    }


    [Test]
    public void LooksForFilesWithPrefabExtension() {
      List<string> prefabs = crawler.FetchFilesByExtension("prefab");

      Assert.IsNotNull(prefabs);
      Assert.AreEqual(2, prefabs.Count);
      Assert.AreEqual(@"C:\temp\TestFolder\SubFolder\b.prefab", prefabs[0]);
      Assert.AreEqual(@"C:\temp\TestFolder\a.prefab",  prefabs[1]);
    }

    private string absoluteTestFolderPath {
      get { return @"C:\temp\TestFolder"; }
    }
  }
}
