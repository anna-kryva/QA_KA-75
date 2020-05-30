using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RequestImplement.Extensions
{
    public static class UriExtension
    {
        public static Uri Append(this Uri uri, params string[] paths)
        {
            return new Uri(paths.Aggregate(uri.AbsoluteUri, (current, path) =>
                $"{current.TrimEnd('/')}/{path.TrimStart('/')}"));
        }
    }
}
