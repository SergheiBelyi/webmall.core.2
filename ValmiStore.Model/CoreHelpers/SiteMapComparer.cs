using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Webmall.Model.CoreHelpers
{
    public class SiteMapComparer : IEqualityComparer<XElement>
    {
        public bool Equals(XElement x, XElement y)
        {
            // ReSharper disable PossibleNullReferenceException
            return string.Compare(x.Descendants().First(i => i.Name.LocalName == "loc").Value, y.Descendants().First(i => i.Name.LocalName == "loc").Value, StringComparison.Ordinal) == 0;
            // ReSharper restore PossibleNullReferenceException
        }

        public int GetHashCode(XElement obj)
        {
            return base.GetHashCode();
        }
    }
}