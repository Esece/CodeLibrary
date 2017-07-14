using System;

namespace S78
{
    public static class UriExtensions
    {
        public static string GetBaseUri(this Uri uri)
        {
            return uri.OriginalString.Substring(0, uri.OriginalString.Length - uri.PathAndQuery.Length);
        }
    }
}
