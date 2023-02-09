using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
