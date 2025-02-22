using CipherKit.Core.Enums;
using CipherKit.Core.Interfaces;
using CipherKit.Core.Ciphers;

namespace CipherKit.Core.Services
{
    public static class CipherManager
    {
        public static ICipher GetCaesarCipher(int shift)
        {
            return new CaesarCipher(shift);
        }

        public static ICipher GetPlayfairCipher(string key)
        {
            return new PlayfairCipher(key);
        }
        
        public static ICipher GetVignereCipher(string key)
        {
            return new VignereCipher(key);
        }

        public static ICipher GetPolybiusCipher()
        {
            return new PolybiusCipher();
        }
    }
}
