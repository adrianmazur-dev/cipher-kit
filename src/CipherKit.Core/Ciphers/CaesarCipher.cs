using System;
using CipherKit.Core.Exceptions;
using CipherKit.Core.Interfaces;

namespace CipherKit.Core.Services
{
    public class CaesarCipher : ICipher
    {
        private readonly int _shift;

        public CaesarCipher(int shift)
        {
            _shift = shift;
        }

        public string Encrypt(string plaintext)
        {
            if (plaintext == null) 
                throw new CipherParameterException("Plaintext cannot be null.");
            char[] buffer = plaintext.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    buffer[i] = (char)(((letter + _shift - offset) % 26) + offset);
                }
            }
            return new string(buffer);
        }

        public string Decrypt(string ciphertext)
        {
            if (ciphertext == null) 
                throw new CipherParameterException("Ciphertext cannot be null.");
            char[] buffer = ciphertext.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    int shifted = (letter - _shift - offset);
                    if (shifted < 0) shifted += 26;
                    buffer[i] = (char)((shifted % 26) + offset);
                }
            }
            return new string(buffer);
        }
    }
}
