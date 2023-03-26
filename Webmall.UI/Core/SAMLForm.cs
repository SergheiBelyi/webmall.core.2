using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Webmall.UI.Core
{
    // ReSharper disable once InconsistentNaming
    public class SAMLForm
    {
        private string _actionURL;
        private IDictionary<string, string> _hiddenControls = new Dictionary<string, string>();
        private static string _htmlFormTemplate = "<html xmlns=\"http://www.w3.org/1999/xhtml\"><body onload=\"document.forms.samlform.submit()\"><noscript><p><strong>Note:</strong> Since your browser does not support Javascript, you must press the Continue button once to proceed.</p></noscript><form id=\"samlform\" action=\"{0}\" method=\"post\"><div>{1}</div><noscript><div><input type=\"submit\" value=\"Continue\"/></div></noscript></form></body></html>";

        public void AddHiddenControl(string controlName, string controlValue)
        {
            _hiddenControls.Add(controlName, controlValue);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in _hiddenControls.Keys)
            {
                string formVariable = _hiddenControls[str];
                builder.AppendFormat("<input type=\"hidden\" name=\"{0}\" value=\"{1}\"/>", str, HttpUtility.HtmlEncode(formVariable));
            }
            StringBuilder builder2 = new StringBuilder();
            builder2.AppendFormat(_htmlFormTemplate, _actionURL, builder);
            return builder2.ToString();
        }

        public void Write(Stream stream)
        {
            string str = ToString();

            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
        }

        public void Write(HttpResponse httpResponse)
        {
            Write(httpResponse.OutputStream);
        }


        public string ActionURL
        {
            get
           {
                return _actionURL;
            }
            set
            {
                _actionURL = value;
            }
        }

        public IDictionary<string, string> HiddenControls
        {
            get
            {
                return _hiddenControls;
            }
            set
            {
                _hiddenControls = value;
            }
        }

        public static string HtmlFormTemplate
        {
            get
            {
               return _htmlFormTemplate;
            }
            set
            {
                _htmlFormTemplate = value;
            }
        }

    }
}