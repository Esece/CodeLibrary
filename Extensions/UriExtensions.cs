using System;

namespace Esece.Extensions
{
    public static class UriExtensions
    {
        public static string GetBaseUri(this Uri uri)
        {
            return uri.OriginalString.Substring(0, uri.OriginalString.Length - uri.PathAndQuery.Length);
        }
    }
}
