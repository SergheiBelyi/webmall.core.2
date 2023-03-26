using System;

namespace Webmall.UI.Core.Helpers
{
    public static class PhpHelper
    {
        public static string file_get_contents(string fileName)
        {

            string sContents;
            if (fileName.ToLower().IndexOf("http:", StringComparison.Ordinal) > -1)
            {
                // URL 
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] response = wc.DownloadData(fileName);
                sContents = System.Text.Encoding.ASCII.GetString(response);
            }
            else
            {
                // Regular Filename 
                System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                sContents = sr.ReadToEnd();
                sr.Close();
            }
            return sContents;
        }

    }
}