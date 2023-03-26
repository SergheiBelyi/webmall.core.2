using System.Collections.Generic;

namespace Webmall.Model.Abstract
{
    public interface ICommonTreeComposite<T>
    {
        string Id { get; set; }
        string Name { get; set; }
        string Url {get; set; }
        List<ICommonTreeComposite<T>> Children { get; }
    }
}