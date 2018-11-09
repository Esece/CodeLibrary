using System.Security.Cryptography;

namespace Esece
{
    public struct SecureGuid
    {
        /// <summary>
        /// Creates a new instance of the cryptographically safer Guid based on RNGCryptoServiceProvider
        /// </summary>
        /// <returns></returns>
        public static Guid NewGuid()
        {
            var randomizer = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var bytes = new byte[16];
            randomizer.GetBytes(bytes);

            return new Guid(bytes);
        }
    }
}
