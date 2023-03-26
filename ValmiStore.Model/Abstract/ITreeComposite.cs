using System.Collections.Generic;

namespace Webmall.Model.Abstract
{
    public interface ITreeComposite<T>
    {
        string Id { get; set; }
        string Url {get; set; }
        IEnumerable<T> Children { get; }
    }
}