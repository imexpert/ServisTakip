namespace ServisTakip.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToFilter(this string filter)
        {
            return filter.ToUpperInvariant().Trim().Replace(" ", "");
        }
    }
}
