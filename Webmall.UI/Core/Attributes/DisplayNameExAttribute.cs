using System;
using System.ComponentModel;
using System.Reflection;

namespace Webmall.UI.Core.Attributes
{
    public class DisplayNameExAttribute : DisplayNameAttribute
    {
        private PropertyInfo _nameProperty;
        private Type _resourceType;

        public DisplayNameExAttribute(string displayNameKey) : base(displayNameKey)
        {
        }

        public Type NameResourceType
        {
            get
            {
                return _resourceType;
            }
            set
            {
                _resourceType = value;
                _nameProperty = _resourceType.GetProperty(base.DisplayName, BindingFlags.Static | BindingFlags.Public);
            }
        }

        public override string DisplayName
        {
            get
            {
                if (_nameProperty == null)
                {
                    return string.Format(@"[{0}]", base.DisplayName);
                }

                return (string)_nameProperty.GetValue(_nameProperty.DeclaringType, null);
            }
        }
    }
}