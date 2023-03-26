using System.IO;
using System.Text;

namespace Webmall.Model.CoreHelpers
{
    /// <summary>
    /// Расширенный StringWriter с использованием кодировки
    /// </summary>
    public class StringWriterWithEncoding : StringWriter
    {
        /// <summary>
        /// Кодировка
        /// </summary>
        private readonly Encoding _mEncoding;

        /// <summary>
        /// Инициализировать StringWriterWithEncoding 
        /// </summary>
        /// <param name="encoding">Кодировка</param>
        public StringWriterWithEncoding(Encoding encoding)
        {
            _mEncoding = encoding;
        }

        /// <summary>
        /// Получение кодировки
        /// </summary>
        public override Encoding Encoding => _mEncoding;
    }
}
