using CipherKit.Core.Enums;
using CipherKit.Core.Interfaces;
using CipherKit.Core.Ciphers;

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
        
        // Added method for VignereCipher
        public static ICipher GetVignereCipher(string key)
        {
            return new VignereCipher(key);
        }
    }
}
