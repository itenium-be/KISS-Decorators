using System.Text;
using System.IO.Compression;

namespace Kiss.Decorators
{
    public class StreamsTests
    {
        [Fact]
        public void StreamToFile_BufferedAndZipped()
        {
            const string inputString = "Testing123";
            byte[] buffer = Encoding.UTF8.GetBytes(inputString);
            string path = Path.Combine(AppContext.BaseDirectory, "output.zip");

            using (FileStream fileStream = new(path, FileMode.Create, FileAccess.Write))
            using (BufferedStream bufferedStream = new(fileStream))
            using (GZipStream gzipStream = new(bufferedStream, CompressionMode.Compress))
            {
                gzipStream.Write(buffer, 0, buffer.Length);
            }

            using (FileStream fileStream = new(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new(fileStream))
            using (GZipStream gzipStream = new(bufferedStream, CompressionMode.Decompress))
            using (MemoryStream memoryStream = new())
            {
                gzipStream.CopyTo(memoryStream);
                byte[] decompressedBuffer = memoryStream.ToArray();

                string result = Encoding.UTF8.GetString(decompressedBuffer);
                Assert.Equal(inputString, result);
            }
        }
    }
}