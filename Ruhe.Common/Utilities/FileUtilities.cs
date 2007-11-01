using System.IO;

namespace Ruhe.Common.Utilities {
    /// <summary>
    /// Function bucket providing common file utility methods
    /// </summary>
    public class FileUtilities {
        private FileUtilities() {}

        public static string GetContent(string filePath) {
            StreamReader reader = StreamReader.Null;
            try {
                reader = File.OpenText(filePath);
                return reader.ReadToEnd();
            }
            finally {
                reader.Close();
            }
        }
    }
}