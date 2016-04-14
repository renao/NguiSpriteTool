using System;
using System.IO;
using Neo.Collections;

namespace Neo.IO {
  public class FileCrawler {

    private string mainPath;
    private string fileExtension;

    public FileCrawler(string mainPath) {
      this.mainPath = mainPath;
    }

    public List<string> FetchFilesByExtension(string FileExtension) {
      fileExtension = FileExtension;
      return fetchFilesFrom(mainPath);
    }

    private List<string> fetchFilesFrom(string path) {
      List<string> files = new List<string>();

      Directory.GetDirectories(path).ForEach(dir => {
        files.AddRange(fetchFilesFrom(dir));
      });

      Directory.GetFiles(path, searchPattern).ForEach(file =>  {
        files.Add(file);
      });

      return files;
    }

    private string searchPattern { get { return "*." + fileExtension; } }
    private string localPath { get { return new Uri(mainPath).LocalPath; } }
  }
}
