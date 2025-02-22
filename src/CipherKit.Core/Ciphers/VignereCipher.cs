using System;
using System.Text;
using CipherKit.Core.Interfaces;
using CipherKit.Core.Exceptions;

namespace CipherKit.Core.Ciphers
{
    public class VignereCipher : ICipher
    {
        private readonly string _key;
        
        public VignereCipher(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new CipherParameterException("Key cannot be null or empty.");
            _key = key;
        }

        public string Encrypt(string plaintext)
        {
            if (plaintext == null)
                throw new CipherParameterException("Plaintext cannot be null.");
            var sb = new StringBuilder();
            string key = _key.ToUpper();
            int keyIndex = 0;

            foreach (char ch in plaintext)
            {
                if (char.IsLetter(ch))
                {
                    char offset = char.IsUpper(ch) ? 'A' : 'a';
                    int encryptedChar = ((ch - offset) + (key[keyIndex % key.Length] - 'A')) % 26;
                    sb.Append((char)(encryptedChar + offset));
                    keyIndex++;
                }
                else
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString();
        }

        public string Decrypt(string ciphertext)
        {
            if (ciphertext == null)
                throw new CipherParameterException("Ciphertext cannot be null.");
            var sb = new StringBuilder();
            string key = _key.ToUpper();
            int keyIndex = 0;

            foreach (char ch in ciphertext)
            {
                if (char.IsLetter(ch))
                {
                    char offset = char.IsUpper(ch) ? 'A' : 'a';
                    int decryptedChar = ((ch - offset) - (key[keyIndex % key.Length] - 'A') + 26) % 26;
                    sb.Append((char)(decryptedChar + offset));
                    keyIndex++;
                }
                else
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString();
        }
    }
}
