using CipherKit.Core.Enums;
using CipherKit.Core.Interfaces;

namespace CipherKit.Core.Services
{
    public static class CipherManager
    {
        // Returns an instance of CaesarCipher
        public static ICipher GetCaesarCipher(int shift)
        {
            return new CaesarCipher(shift);
        }

        // Returns an instance of PlayfairCipher
        public static ICipher GetPlayfairCipher(string key)
        {
            return new PlayfairCipher(key);
        }
    }
}
