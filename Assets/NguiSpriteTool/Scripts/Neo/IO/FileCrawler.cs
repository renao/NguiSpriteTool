using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Neo.IO {
  public class FileCrawler {

    public static List<string> FetchFilesRecursively(string path, string fileExtension=null) {
      List<string> files = new List<string>();
      string localPath = getLocalPath(path);

      Directory.GetDirectories(localPath).ForEach(dir => files.AddRange(FetchFilesRecursively(dir, fileExtension)));
      Directory.GetFiles(localPath, extensionSearchPattern(fileExtension)).ForEach(files.Add);

      return files;
    }

    private static string extensionSearchPattern(string fileExtension= null) {
      if (string.IsNullOrEmpty(fileExtension)) return "*";
      else return new StringBuilder("*.").Append(fileExtension).ToString();
    }

    private static string getLocalPath(string path) {
      return new Uri(path).LocalPath;
    }
  }
}
