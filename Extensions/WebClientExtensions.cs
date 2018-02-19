namespace Esece.Extensions
{
    public static class WebClientExtensions
    {
        public static IEnumerable<string> DownloadZippedStrings(this WebClient webClient, string address)
        {
            using (var fileStream = new WebClient().OpenRead(address))
            {
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Read, false))
                {
                    foreach (var entry in archive.Entries)
                    {
                        using (var reader = new BinaryReader(entry.Open()))
                        {
                            yield return Encoding.UTF8.GetString(reader.ReadAllBytes());
                        }
                    }
                }
            }
        }
    }
}
