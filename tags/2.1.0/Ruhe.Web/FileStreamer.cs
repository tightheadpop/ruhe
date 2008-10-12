using System;
using System.IO;
using System.Web;

namespace Ruhe.Web {
    public class FileStreamer {
        private static HttpResponse Response {
            get { return HttpContext.Current.Response; }
        }

        public static string GetContentType(string filePath) {
            string fileExtension = Path.GetExtension(filePath);
            switch (fileExtension.ToLower()) {
                case ".pdf":
                    return "application/pdf";
                case ".tif":
                case ".tiff":
                    return "image/tiff";
                default:
                    return "text/plain";
            }
        }

        public static byte[] GetFileContent(string filePath) {
            byte[] buffer;
            Stream stream = GetFileStream(filePath);
            buffer = GetFileContent(stream);
            stream.Close();
            return buffer;
        }

        public static byte[] GetFileContent(Stream stream) {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int) stream.Length);
            return buffer;
        }

        private static Stream GetFileStream(string filePath) {
            Stream stream = Stream.Null;
            if (File.Exists(filePath)) {
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            }
            return stream;
        }

        public static void ReceiveFileContent(byte[] FileContent, string FilePath, bool CreateNewFile) {
            FileStream stream;

            if (CreateNewFile) {
                stream = new FileStream(FilePath, FileMode.Create);
            } else {
                stream = new FileStream(FilePath, FileMode.Append);
            }

            BinaryWriter writer = new BinaryWriter(stream);
            try {
                writer.Write(FileContent);
            }
            finally {
                writer.Flush();
                writer.Close();
                stream.Close();
            }
        }

        public static void Send(string fullFilePath) {
            Send(fullFilePath, Path.GetFileName(fullFilePath));
        }

        public static void Send(string fullFilePath, string clientFileName) {
            Stream stream = GetFileStream(fullFilePath);
            Send(stream, clientFileName);
        }

        public static void Send(byte[] content, string clientFileName) {
            MemoryStream stream = new MemoryStream(content);
            Send(stream, clientFileName);
        }

        public static void Send(Stream contentStream, string clientFileName) {
            contentStream.Position = 0;

            Response.Clear();
            Response.AddHeader("Content-Disposition", String.Format("inline;filename={0}", clientFileName));
            Response.AddHeader("Content-Type", GetContentType(clientFileName));
            Response.AddHeader("Content-Length", contentStream.Length.ToString());

            Response.BinaryWrite(GetFileContent(contentStream));
            Response.End();
        }
    }
}