namespace Webmall.Model
{
    public static class StringExtensions
    {
        public static int? ToNullableInt(this string number)
        {
            if (string.IsNullOrEmpty(number)) return null;
            return int.Parse(number);
        }
        
        public static int ToInt(this string number)
        {
            return string.IsNullOrEmpty(number) ? 0 : int.Parse(number);
        }

    }
}
