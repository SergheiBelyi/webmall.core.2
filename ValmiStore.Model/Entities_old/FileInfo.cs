namespace ValmiStore.Model.Entities
{
    public class FileInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Файл
        /// </summary>
        public string FileContent { get; set; }
    }
}