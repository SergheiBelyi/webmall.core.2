namespace Webmall.Model.PriceAggregator.DataModels.Ware
{
    public class FileInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Ext { get; set; }

        public string MimeType { get; set; }

        public FileType Type { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }

    public enum FileType
    {
        File,
        Video,
        Link
    }
}
